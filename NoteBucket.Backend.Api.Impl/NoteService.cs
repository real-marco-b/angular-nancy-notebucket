using NoteBucket.Backend.Api.Contracts;
using System;
using NoteBucket.Backend.Domain;
using System.Collections.Generic;
using NoteBucket.Backend.Persistence.Contracts;

namespace NoteBucket.Backend.Api.Impl
{
    public class NoteService : INoteService
    {
        private IRepositoryCatalog _catalog;

        public NoteService(IRepositoryCatalog catalog)
        {
            _catalog = catalog;
        }

        public IEnumerable<Note> GetByFolder(int folderId)
        {
            var folder = _catalog.Folders.GetById(folderId);

            if (folder == null)
            {
                throw new ArgumentException("Invalid Folder");
            }

            return _catalog.Notes.GetByFolder(folder);
        }

        public Note GetById(int id)
        {
            return _catalog.Notes.GetById(id);
        }
    }
}
