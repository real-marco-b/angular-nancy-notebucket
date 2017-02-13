using NoteBucket.Backend.Domain;
using System.Collections.Generic;

namespace NoteBucket.Backend.Api.Contracts
{
    /// <summary>
    /// Specifies the API services for handling folders.
    /// </summary>
    public interface IFolderService
    {
        /// <summary>
        /// Gets all folders within the system.
        /// Expose this functionality carefully.
        /// </summary>
        /// <returns>A set of all folders created by any user.</returns>
        IEnumerable<Folder> GetAll();

        /// <summary>
        /// Gets all folders of a specific owner.
        /// </summary>
        /// <param name="owner">The owner of the folders.</param>
        /// <returns>A set of all folders that belong to the given owner.</returns>
        IEnumerable<Folder> GetByOwner(User owner);

        /// <summary>
        /// Gets all folders of a specific owner.
        /// </summary>
        /// <param name="ownerId">The owner of the folders, specified by id.</param>
        /// <returns>A set of all folders that belong to the given owner.</returns>
        IEnumerable<Folder> GetByOwner(int ownerId);

        /// <summary>
        /// Gets a specific folder by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the folder.</param>
        Folder GetById(int id);

        /// <summary>
        /// Adds a new folder.
        /// </summary>
        /// <param name="folder">The folder to add.</param>
        void Add(Folder folder);

        /// <summary>
        /// Updates a folder.
        /// </summary>
        /// <param name="folder">The folder to update.</param>
        void Update(Folder folder);

        /// <summary>
        /// Removes a folder.
        /// </summary>
        /// <param name="folder">The folder to remove.</param>
        void Remove(Folder folder);
    }
}
