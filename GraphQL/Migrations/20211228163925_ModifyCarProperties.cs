using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQL.Migrations
{
    public partial class ModifyCarProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Vin",
                table: "Cars",
                newName: "BodyType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BodyType",
                table: "Cars",
                newName: "Vin");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
