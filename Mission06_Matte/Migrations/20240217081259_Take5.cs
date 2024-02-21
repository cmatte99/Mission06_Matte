using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission06_Matte.Migrations
{
    /// <inheritdoc />
    public partial class Take5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Applications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationID",
                table: "Applications",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "ApplicationID");
        }
    }
}
