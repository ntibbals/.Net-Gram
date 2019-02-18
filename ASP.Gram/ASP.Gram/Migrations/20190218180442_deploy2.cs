using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.Gram.Migrations
{
    public partial class deploy2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    Likes = table.Column<int>(nullable: false),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(type: "varchar(max)", nullable: true),
                    Author = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "Author", "Details", "ImageURL", "Likes" },
                values: new object[,]
                {
                    { 1, "JTT", "Check out the orcas!", "http://1.bp.blogspot.com/-rbBG3L514tQ/UD9eJuVrH1I/AAAAAAAAIo0/RKOGYNs0WwM/s400/Outer+Space+Wallpapers+6.jpg", 0 },
                    { 3, "Captain Kirk", "Captains log: We, have, found intelligent life on neptar.", "http://1.bp.blogspot.com/-rbBG3L514tQ/UD9eJuVrH1I/AAAAAAAAIo0/RKOGYNs0WwM/s400/Outer+Space+Wallpapers+6.jpg", 0 },
                    { 4, "Legolas", "1 million orcs killed. Time to break out the champagne!", "http://1.bp.blogspot.com/-rbBG3L514tQ/UD9eJuVrH1I/AAAAAAAAIo0/RKOGYNs0WwM/s400/Outer+Space+Wallpapers+6.jpg", 0 },
                    { 5, "John Snow", "I may not know much but I know how to kill white walkes!", "http://1.bp.blogspot.com/-rbBG3L514tQ/UD9eJuVrH1I/AAAAAAAAIo0/RKOGYNs0WwM/s400/Outer+Space+Wallpapers+6.jpg", 0 },
                    { 2, "Miss Jackson", "I am for real!", "http://1.bp.blogspot.com/-rbBG3L514tQ/UD9eJuVrH1I/AAAAAAAAIo0/RKOGYNs0WwM/s400/Outer+Space+Wallpapers+6.jpg", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostID",
                table: "Comments",
                column: "PostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
