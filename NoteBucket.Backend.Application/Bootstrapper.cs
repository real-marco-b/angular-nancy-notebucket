using Autofac;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Nancy.Conventions;
using NHibernate;
using NHibernate.Context;
using NoteBucket.Backend.Api.Contracts;
using NoteBucket.Backend.Api.Impl;
using NoteBucket.Backend.Application.Security;
using NoteBucket.Backend.Application.Security.Tokens;
using NoteBucket.Backend.Persistence.Contracts;
using NoteBucket.Backend.Persistence.Impl.Infrastructure;
using NoteBucket.Backend.Persistence.Impl.Repositories;

namespace NoteBucket.Backend.Application
{
    /// <summary>
    /// Backend Application Configuration for Nancy.
    /// </summary>
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            // Register application infrastructure types for Injection
            var builder = new ContainerBuilder();
            builder.Register(_ => SessionFactorySingleton.Instance.SessionFactory).As<ISessionFactory>();
            builder.RegisterType<AuthenticationContext>().As<IAuthenticationContext>();
            builder.RegisterType<JwtTokenGenerator>().As<ITokenGenerator>();
            builder.RegisterType<JwtTokenHandler>().As<ITokenHandler>();
            builder.Update(container.ComponentRegistry);

            ConfigurePersistence(container, pipelines);

            base.ApplicationStartup(container, pipelines);
        }

        protected override void ConfigureRequestContainer(ILifetimeScope container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            // Register request-specific types for Injection
            var builder = new ContainerBuilder();
            builder.RegisterType<RepositoryCatalog>().As<IRepositoryCatalog>();
            RegisterServices(builder);
            builder.Update(container.ComponentRegistry);
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/", "Content"));
            base.ConfigureConventions(nancyConventions);
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<FolderService>().As<IFolderService>();
            builder.RegisterType<DemoDataService>().As<IDemoDataService>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<NoteService>().As<INoteService>();
        }

        private void ConfigurePersistence(ILifetimeScope container, IPipelines pipelines)
        {
            // Configure a session per request approach:
            // Before a request is executed, we create a session, bind it to NHibernate's CurrentSessionContext
            // and begin a transaction.
            // When a request was successfully executed, we automatically commit the transaction,
            // in case an error occured, we rollback the transaction.
            // Thus, we can ensure that persistent data changes on request execution either succeeded completely or
            // failed completely.
            // Another advantage is that we do not have to cope with session scopes within repositories and service logic.
            pipelines.BeforeRequest += ctx =>
            {
                CreateSession(container);
                return null;
            };

            pipelines.AfterRequest.AddItemToEndOfPipeline(ctx =>
            {
                CommitSession(container);
            });

            pipelines.OnError.AddItemToEndOfPipeline((ctx, ex) =>
            {
                RollbackSession(container);
                return null;
            });
        }

        private void CreateSession(ILifetimeScope container)
        {
            var factory = container.Resolve<ISessionFactory>();
            var session = factory.OpenSession();
            CurrentSessionContext.Bind(session);
            session.BeginTransaction();
        }

        private void CommitSession(ILifetimeScope container)
        {
            var factory = container.Resolve<ISessionFactory>();
            if (CurrentSessionContext.HasBind(factory))
            {
                var session = factory.GetCurrentSession();
                session.Transaction.Commit();
                CurrentSessionContext.Unbind(factory);
                session.Dispose();
            }
        }

        private void RollbackSession(ILifetimeScope container)
        {
            var factory = container.Resolve<ISessionFactory>();
            if (CurrentSessionContext.HasBind(factory))
            {
                var session = factory.GetCurrentSession();
                session.Transaction.Rollback();
                CurrentSessionContext.Unbind(factory);
                session.Dispose();
            }
        }
    }
}
