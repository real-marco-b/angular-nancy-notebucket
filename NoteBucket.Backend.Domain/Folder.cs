using System;

namespace NoteBucket.Backend.Domain
{
    /// <summary>
    /// Represents a folder which serves as container for a set of notes.
    /// A folder is identified by its name and belongs to a specific user which created the folder.
    /// </summary>
    public class Folder : AbstractEntity<Folder>
    {
        /// <summary>
        /// Instantiates a new, transient folder.
        /// </summary>
        /// <param name="owner">The owner of the folder.</param>
        /// <param name="name">The name of the folder.</param>
        public Folder(User owner, string name)
        {
            if(owner == null)
            {
                throw new ArgumentNullException("owner");
            }

            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name");
            }

            Owner = owner;
            Name = name;
        }

        protected Folder()
        {
        }

        /// <summary>
        /// Gets or sets the name of the folder.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets the owner of the folder.
        /// </summary>
        public virtual User Owner { get; protected set; }
    }
}
