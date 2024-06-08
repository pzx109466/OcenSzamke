using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OcenSzamke.Migrations
{
    /// <inheritdoc />
    public partial class TESTT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Reviews");
        }
    }
}
