using FluentMigrator;

namespace CarsDapperProject.Domain.Migrations;

[Migration(2)]
public class M002_SeedData : Migration
{
    public override void Up()
    {
        Insert.IntoTable("brands")
            .Row(new { name = "Audi" })
            .Row(new { name = "BMW" })
            .Row(new { name = "Mercedes" });

        Insert.IntoTable("cars")
            .Row(new { model = "Q5", brand_id = 1 });
    }

    public override void Down()
    {
        Delete.FromTable("brands").AllRows();
        Delete.FromTable("cars").AllRows();
        Delete.FromTable("owners").AllRows();
    }
}
