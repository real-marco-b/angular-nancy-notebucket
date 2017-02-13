using NHibernate;
using NHibernate.Linq;
using NoteBucket.Backend.Domain;
using NoteBucket.Backend.Persistence.Contracts;
using System.Linq;

namespace NoteBucket.Backend.Persistence.Impl.Repositories
{
    public class UserRepository : AbstractRepository<User>, IUserRepository
    {
        public UserRepository(ISession session) : base(session)
        {
        }

        public User GetByEMail(string email)
        {
            return _session.Query<User>().Where(u => u.EMail == email).FirstOrDefault();
        }
    }
}
