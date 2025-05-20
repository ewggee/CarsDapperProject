using FluentMigrator;

namespace CarsDapperProject.Domain.Migrations;

[Migration(version: 1)]
public class M001_CreateTables : Migration
{
    public override void Up()
    {
        Create.Table("brands")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("name").AsString(100).NotNullable();

        Create.Table("owners")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("name").AsString(100).NotNullable()
            //TODO: пересмотреть макс. значение для телефона
            .WithColumn("phone").AsString(100).NotNullable()
            .WithColumn("email").AsString(100).NotNullable();

        Create.Table("cars")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("model").AsString(100).NotNullable()
            .WithColumn("brand_id").AsInt32().NotNullable()
            .WithColumn("owner_id").AsInt32().Nullable()
            .ForeignKey("fk_car_brand", "brands", "id")
            .ForeignKey("fk_car_owner", "owners", "id");
    }

    public override void Down()
    {
        Delete.Table("brands");
        Delete.Table("cars");
        Delete.Table("owners");
    }
}
