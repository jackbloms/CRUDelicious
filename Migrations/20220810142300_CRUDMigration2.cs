using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDelicious.Migrations
{
    public partial class CRUDMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripion",
                table: "Dishes",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Dishes",
                newName: "Descripion");
        }
    }
}
