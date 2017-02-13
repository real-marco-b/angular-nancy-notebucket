using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using System;

namespace NoteBucket.Backend.Persistence.Impl.Infrastructure
{
    /// <summary>
    /// Handles the creation of the NHibernate session factory.
    /// The session factory creation is expensive and should only be executed once.
    /// This is ensured by the singleton implementation of this class.
    /// 
    /// The persistence layer configuration is done here.
    /// You may want to de-couple this.
    /// 
    /// For easy project bootstrapping, the persistence layer configures a SQLite database which
    /// should not be used in production.
    /// </summary>
    public class SessionFactorySingleton
    {
        private static SessionFactorySingleton _instance = null;
        private ISessionFactory _factory = null;

        private SessionFactorySingleton()
        {
            Configuration configuration = null;
            try
            {
                configuration = BuildConfiguration();
            }
            catch (Exception ex)
            {
                throw new Exception("Could not build ORM configuration", ex);
            }

            _factory = configuration.BuildSessionFactory();
        }

        public static SessionFactorySingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SessionFactorySingleton();
                }
                return _instance;
            }
        }

        public ISessionFactory SessionFactory
        {
            get { return _factory; }
        }

        private Configuration BuildConfiguration()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .ConnectionString(c => c.Is("Data Source=./notebucket-database.db;Version=3;")))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<SessionFactorySingleton>())
                .ExposeConfiguration(cfg => cfg.SetProperty(NHibernate.Cfg.Environment.CurrentSessionContextClass, "call"))
                .BuildConfiguration();
        }
    }
}
