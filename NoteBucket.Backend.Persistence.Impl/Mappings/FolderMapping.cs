using FluentNHibernate.Mapping;
using NoteBucket.Backend.Domain;

namespace NoteBucket.Backend.Persistence.Impl.Mappings
{
    public class FolderMapping : ClassMap<Folder>
    {
        public FolderMapping()
        {
            Id(x => x.Id).GeneratedBy.Native().Column("id");
            References(x => x.Owner).Column("ownerid");
            Map(x => x.Name).Column("name");
            Table("folders");
        }
    }
}
