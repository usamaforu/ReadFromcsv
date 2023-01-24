using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesslayer.Migrations
{
    public partial class addNewColom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImageS3Url",
                table: "Employee2s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImageS3Url",
                table: "Employee2s");
        }
    }
}
