using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.Gram.Migrations
{
    public partial class dep3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "Posts",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Posts",
                newName: "PostID");
        }
    }
}
