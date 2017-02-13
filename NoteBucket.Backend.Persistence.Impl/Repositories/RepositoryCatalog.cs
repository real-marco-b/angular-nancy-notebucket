using NoteBucket.Backend.Persistence.Contracts;
using System;
using NHibernate;
using NHibernate.Context;

namespace NoteBucket.Backend.Persistence.Impl.Repositories
{
    public class RepositoryCatalog : IRepositoryCatalog
    {
        public RepositoryCatalog(ISessionFactory factory)
        {
            if (CurrentSessionContext.HasBind(factory))
            {
                Session = factory.GetCurrentSession();
            }

            Folders = new FolderRepository(Session);
            Notes = new NoteRepository(Session);
            Users = new UserRepository(Session);
        }

        public ISession Session { get; private set; }

        public IFolderRepository Folders { get; private set; }

        public INoteRepository Notes { get; private set; }

        public IUserRepository Users { get; private set; }
    }
}
