using FluentNHibernate.Mapping;
using NoteBucket.Backend.Domain;

namespace NoteBucket.Backend.Persistence.Impl.Mappings
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Id(x => x.Id).GeneratedBy.Native().Column("id");
            Map(x => x.Forename).Column("forename");
            Map(x => x.Surname).Column("surname");
            Map(x => x.EMail).Column("email");
            Map(x => x.Password).Column("password");
            Map(x => x.Salt).Column("salt");
            Table("users");
        }
    }
}
