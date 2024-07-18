// < auto-generated />
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xurmo.Modules.Catalogs.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class Initial_Create : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "image_path",
            schema: "catalogs",
            table: "products",
            type: "text",
            nullable: false,
            defaultValue: "");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "image_path",
            schema: "catalogs",
            table: "products");
    }
}
