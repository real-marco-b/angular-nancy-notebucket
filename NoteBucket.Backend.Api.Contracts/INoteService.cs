using NoteBucket.Backend.Domain;
using System.Collections.Generic;

namespace NoteBucket.Backend.Api.Contracts
{
    public interface INoteService
    {
        /// <summary>
        /// Gets all notes inside a specific folder.
        /// </summary>
        /// <param name="folderId">The folder te notes belong to, specified by id.</param>
        /// <returns>A set of all notes that belong to the given folder.</returns>
        IEnumerable<Note> GetByFolder(int folderId);

        /// <summary>
        /// Gets a specific note by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the note.</param>
        Note GetById(int id);
    }
}
