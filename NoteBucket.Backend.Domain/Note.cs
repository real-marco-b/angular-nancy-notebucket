using System;

namespace NoteBucket.Backend.Domain
{
    /// <summary>
    /// Represents an editable text document within a folder.
    /// A note is described by a title and a body text.
    /// </summary>
    public class Note : AbstractEntity<Note>
    {
        /// <summary>
        /// Instantiates a new note by its parent folder and title.
        /// </summary>
        /// <param name="folder">The folder the note will belong to.</param>
        /// <param name="title">The title the note will have.</param>
        public Note(Folder folder, string title)
        {
            if(folder == null)
            {
                throw new ArgumentNullException("folder");
            }

            Folder = folder;
            Title = title;
        }

        /// <summary>
        /// Instantiates a new note by its parent folder, title and body text.
        /// </summary>
        /// <param name="folder">The folder the note will belong to.</param>
        /// <param name="title">The title the note will have.</param>
        /// <param name="body">The body the note will have.</param>
        public Note(Folder folder, string title, string body)
            : this(folder, title)
        {
            Body = body;
        }

        protected Note() { }

        /// <summary>
        /// Gets or sets the title of the note.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the body of the note.
        /// </summary>
        public virtual string Body { get; set; }

        /// <summary>
        /// Gets the folder of the note.
        /// </summary>
        public virtual Folder Folder{ get; protected set; }
    }
}
