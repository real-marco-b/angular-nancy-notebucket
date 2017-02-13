using System;

namespace NoteBucket.Backend.Domain
{
    /// <summary>
    /// Serves as the base class of all entities.
    /// The class provides hash code and identity handling based on a provided Id property.
    /// </summary>
    /// <typeparam name="TEntity">The concrete type of the entity deriving from AbstractEntity.</typeparam>
    public abstract class AbstractEntity<TEntity> where TEntity : AbstractEntity<TEntity>
    {
        private int? _hashCode;

        /// <summary>
        /// Represents the identifier of the entity which is unique in the scope of that entity type.
        /// </summary>
        public virtual int Id { get; protected set; }

        /// <summary>
        /// Returns true if the entity instance is not yet managed by the persistence layer.
        /// </summary>
        public virtual bool IsTransient
        {
            get
            {
                return Id == 0;
            }
        }

        public override bool Equals(object obj)
        {
            return EntityEquals(obj as AbstractEntity<TEntity>);
        }

        public override int GetHashCode()
        {
            if (!_hashCode.HasValue)
            {
                _hashCode = IsTransient ? base.GetHashCode() : Id.GetHashCode();
            }
            return _hashCode.Value;
        }

        public static bool operator ==(AbstractEntity<TEntity> a, AbstractEntity<TEntity> b)
        {
            return Object.Equals(a, b);
        }

        public static bool operator !=(AbstractEntity<TEntity> a, AbstractEntity<TEntity> b)
        {
            return !(a == b);
        }

        private bool EntityEquals(AbstractEntity<TEntity> other)
        {
            if (other == null || IsTransient ^ other.IsTransient)
            {
                return false;
            }
            if (IsTransient)
            {
                return ReferenceEquals(this, other);
            }
            return Id == other.Id;
        }
    }
}
