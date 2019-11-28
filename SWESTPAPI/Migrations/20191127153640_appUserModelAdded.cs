using Microsoft.EntityFrameworkCore.Migrations;

namespace SWESTPAPI.Migrations
{
    public partial class appUserModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appUsers",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    ID = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    VCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appUsers", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appUsers");
        }
    }
}
