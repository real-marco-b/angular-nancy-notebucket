using NHibernate;
using NHibernate.Linq;
using NoteBucket.Backend.Domain;
using NoteBucket.Backend.Persistence.Contracts;
using System.Linq;
using System;
using System.Collections.Generic;

namespace NoteBucket.Backend.Persistence.Impl.Repositories
{
    public class FolderRepository : AbstractRepository<Folder>, IFolderRepository
    {
        public FolderRepository(ISession session) : base(session)
        {
        }

        public Folder GetByName(string name)
        {
            return _session.Query<Folder>().Where(u => u.Name == name).FirstOrDefault();
        }

        public IEnumerable<Folder> GetByOwner(User owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException("owner");
            }

            return _session.Query<Folder>().Where(h => h.Owner != null && h.Owner.Id == owner.Id)
                .ToList();
        }
    }
}
