using System.Collections.Generic;

namespace NoteBucket.Backend.Persistence.Contracts
{
    /// <summary>
    /// Specifies a common interface for all data repositories.
    /// A data repository manages a set of persistent entities of the same type.
    /// </summary>
    /// <typeparam name="TEntity">The entity type the repository is handling.</typeparam>
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Gets a specific persistent entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>An instance of the queried entity or null in case no entity with the given identifier was found</returns>
        TEntity GetById(int id);

        /// <summary>
        /// Gets all persistent entities of the entity type handled by the repository.
        /// </summary>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Persists an entity.
        /// </summary>
        /// <param name="entity">The entity to persist.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Removes an entity.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        void Remove(TEntity entity);
    }
}
