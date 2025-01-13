using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroBlogger.Migrators.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class PostsUdatMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "temp_image_url",
                table: "posts",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "temp_image_url",
                table: "posts");
        }
    }
}
