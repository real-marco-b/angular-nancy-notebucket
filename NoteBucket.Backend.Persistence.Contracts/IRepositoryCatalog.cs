using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBucket.Backend.Persistence.Contracts
{
    /// <summary>
    /// Bundles repository instances bound to a given session.
    /// A session is the open connection to a persistence layer (e.g. database).
    /// Repository operations run in the context of a certain session.
    /// 
    /// This class allows easy access and injection of ready-to-use repository instances
    /// all bound to the catalogs session.
    /// </summary>
    public interface IRepositoryCatalog
    {
        IUserRepository Users { get; }

        IFolderRepository Folders { get; }

        INoteRepository Notes { get; }

        ISession Session { get; }
    }
}
