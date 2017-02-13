using NoteBucket.Backend.Domain;
using System.Collections.Generic;

namespace NoteBucket.Backend.Persistence.Contracts
{
    public interface IFolderRepository : IRepository<Folder>
    {
        /// <summary>
        /// Gets a specific folder by its name.
        /// </summary>
        /// <param name="name">The name to query.</param>
        /// <returns>An instance of the folder or null in case no folder with the given name was found.</returns>
        Folder GetByName(string name);

        /// <summary>
        /// Gets all folders that belong to an owner.
        /// </summary>
        /// <param name="owner">The owner to query.</param>
        /// <returns>An enumerable containing 0 to N folders</returns>
        IEnumerable<Folder> GetByOwner(User owner);
    }
}
