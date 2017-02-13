using FluentNHibernate.Mapping;
using NoteBucket.Backend.Domain;

namespace NoteBucket.Backend.Persistence.Impl.Mappings
{
    public class NoteMapping : ClassMap<Note>
    {
        public NoteMapping()
        {
            Id(x => x.Id).GeneratedBy.Native().Column("id");
            References(x => x.Folder).Column("folderid");
            Map(x => x.Title).Column("title");
            Map(x => x.Body).Column("body");
            Table("notes");
        }
    }
}
