using FluentMigrator;

namespace CarsDapperProject.Domain.Migrations;

[Migration(version: 0)]
public class M000_Initial : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            DROP TABLE IF EXISTS brands CASCADE;
            DROP TABLE IF EXISTS cars CASCADE;
            DROP TABLE IF EXISTS owners CASCADE;");
    }

    public override void Down()
    { }
}
