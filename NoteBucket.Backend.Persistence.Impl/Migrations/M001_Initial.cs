using FluentMigrator;

namespace NoteBucket.Backend.Persistence.Impl.Migrations
{
    [Migration(1)]
    public class M001 : Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            Create.Table("users")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("forename").AsString().Nullable()
                .WithColumn("surname").AsString().Nullable()
                .WithColumn("email").AsString().NotNullable()
                .WithColumn("password").AsFixedLengthString(64)
                .WithColumn("salt").AsFixedLengthString(36);

            Create.Table("folders")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ownerid").AsInt32().NotNullable()
                .WithColumn("name").AsString().Nullable();

            Create.Table("notes")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("folderid").AsInt32().NotNullable()
                .WithColumn("title").AsString().Nullable()
                .WithColumn("body").AsString().Nullable();

            Create.ForeignKey("fk_folder_owner")
                .FromTable("folders").ForeignColumn("ownerid")
                .ToTable("users").PrimaryColumn("id");

            Create.ForeignKey("fk_note_folder")
                .FromTable("notes").ForeignColumn("folderid")
                .ToTable("folders").PrimaryColumn("id");
        }
    }
}
