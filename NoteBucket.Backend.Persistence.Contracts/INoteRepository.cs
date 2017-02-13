using NoteBucket.Backend.Domain;
using System.Collections.Generic;

namespace NoteBucket.Backend.Persistence.Contracts
{
    public interface INoteRepository : IRepository<Note>
    {
        /// <summary>
        /// Gets all notes that belong to a folder.
        /// </summary>
        /// <param name="folder">The folder to query.</param>
        /// <returns>An enumerable containing 0 to N notes.</returns>
        IEnumerable<Note> GetByFolder(Folder folder);
    }
}
