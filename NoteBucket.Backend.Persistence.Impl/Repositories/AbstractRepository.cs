using NHibernate;
using NHibernate.Linq;
using NoteBucket.Backend.Domain;
using NoteBucket.Backend.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteBucket.Backend.Persistence.Impl.Repositories
{
    /// <summary>
    /// Implements the common CRUD operations specified by IRepository.
    /// 
    /// <seealso cref="IRepository{TEntity}"/>
    /// </summary>
    /// <typeparam name="TEntity">The entity class type the repository handles.</typeparam>
    public abstract class AbstractRepository<TEntity> : IRepository<TEntity>
    {
        protected ISession _session;

        public AbstractRepository(ISession session)
        {
            _session = session;
        }

        public void Add(TEntity entity)
        {
            _session.Save(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _session.Query<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _session.Get<TEntity>(id);
        }

        public void Remove(TEntity entity)
        {
            _session.Delete(entity);
        }

        public void Update(TEntity entity)
        {
            _session.Update(entity);
        }
    }
}
