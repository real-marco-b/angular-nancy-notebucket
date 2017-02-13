using NHibernate;
using NHibernate.Linq;
using NoteBucket.Backend.Domain;
using NoteBucket.Backend.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBucket.Backend.Persistence.Impl.Repositories
{
    public class NoteRepository : AbstractRepository<Note>, INoteRepository
    {
        public NoteRepository(ISession session) : base(session)
        {
        }

        public IEnumerable<Note> GetByFolder(Folder folder)
        {
            return _session.Query<Note>().Where(n => n.Folder != null && n.Folder.Id == folder.Id)
                .ToList();
        }
    }
}
