using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanBlog.Migrations
{
    public partial class BlogPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContactFullName = table.Column<string>(type: "TEXT", nullable: false),
                    ContactEmail = table.Column<string>(type: "TEXT", nullable: false),
                    ContactNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    BlogPostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.BlogPostId);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FullName" },
                values: new object[] { 1, "Serdar" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FullName" },
                values: new object[] { 2, "Gürleyen" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactID", "ContactEmail", "ContactFullName", "ContactNumber", "Message" },
                values: new object[] { 1, "serdar.gurleyen@siemens.com", "Serdar Gürleyen", "572892797", "her sey cok guzel calisiyor." });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "BlogPostId", "AuthorId", "Content", "CreationDate", "Title" },
                values: new object[] { 1, 1, "Content", new DateTime(2021, 2, 9, 10, 16, 27, 106, DateTimeKind.Local).AddTicks(9057), "Blog Post 01" });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "BlogPostId", "AuthorId", "Content", "CreationDate", "Title" },
                values: new object[] { 2, 1, "Content", new DateTime(2021, 2, 9, 10, 16, 27, 115, DateTimeKind.Local).AddTicks(9960), "Blog Post 02" });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "BlogPostId", "AuthorId", "Content", "CreationDate", "Title" },
                values: new object[] { 3, 2, "Content", new DateTime(2021, 2, 9, 10, 16, 27, 116, DateTimeKind.Local).AddTicks(91), "Blog Post 03" });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "BlogPostId", "AuthorId", "Content", "CreationDate", "Title" },
                values: new object[] { 4, 2, "Content", new DateTime(2021, 2, 9, 10, 16, 27, 116, DateTimeKind.Local).AddTicks(143), "Blog Post 04" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_AuthorId",
                table: "BlogPosts",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
