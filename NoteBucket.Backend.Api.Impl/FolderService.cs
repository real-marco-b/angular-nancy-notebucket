using NoteBucket.Backend.Api.Contracts;
using System;
using NoteBucket.Backend.Domain;
using System.Collections.Generic;
using NoteBucket.Backend.Persistence.Contracts;

namespace NoteBucket.Backend.Api.Impl
{
    public class FolderService : IFolderService
    {
        private IRepositoryCatalog _catalog;

        public FolderService(IRepositoryCatalog catalog)
        {
            _catalog = catalog;
        }

        public void Add(Folder folder)
        {
            _catalog.Folders.Add(folder);
        }

        public IEnumerable<Folder> GetAll()
        {
            return _catalog.Folders.GetAll();
        }

        public Folder GetById(int id)
        {
            return _catalog.Folders.GetById(id);
        }

        public IEnumerable<Folder> GetByOwner(int ownerId)
        {
            var user = _catalog.Users.GetById(ownerId);
            if(user == null)
            {
                throw new ArgumentException("Owner not found");
            }
            return GetByOwner(user);
        }

        public IEnumerable<Folder> GetByOwner(User owner)
        {
            if(owner == null)
            {
                throw new ArgumentNullException("owner");
            }

            if(owner.IsTransient)
            {
                throw new Exception("Owner may not be transient");
            }

            return _catalog.Folders.GetByOwner(owner);
        }

        public void Remove(Folder folder)
        {
            _catalog.Folders.Remove(folder);
        }

        public void Update(Folder folder)
        {
            _catalog.Folders.Update(folder);
        }
    }
}
