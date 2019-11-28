using Microsoft.EntityFrameworkCore.Migrations;

namespace SWESTPAPI.Migrations
{
    public partial class appUserModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "isVerified",
                table: "appUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isVerified",
                table: "appUsers");
        }
    }
}
