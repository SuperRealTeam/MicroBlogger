using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroBlogger.Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class PostsUdatMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempImageUrl",
                table: "Posts",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempImageUrl",
                table: "Posts");
        }
    }
}
