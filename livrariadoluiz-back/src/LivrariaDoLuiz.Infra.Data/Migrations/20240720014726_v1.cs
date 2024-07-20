using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LivrariaDoLuiz.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edition = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Book_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("0a78abfb-1470-46a6-bafe-4c2d83d1a8dc"), new DateTime(2024, 7, 20, 1, 47, 26, 141, DateTimeKind.Utc).AddTicks(6060), "Author 2" },
                    { new Guid("589039c8-145e-43c9-b6ec-30d027b99f32"), new DateTime(2024, 7, 20, 1, 47, 26, 141, DateTimeKind.Utc).AddTicks(6034), "Author 1" },
                    { new Guid("76662f83-0688-494b-b598-6b55671ad4bf"), new DateTime(2024, 7, 20, 1, 47, 26, 141, DateTimeKind.Utc).AddTicks(6064), "Author 5" },
                    { new Guid("83a31b94-1872-4f6d-a344-622e590a4421"), new DateTime(2024, 7, 20, 1, 47, 26, 141, DateTimeKind.Utc).AddTicks(6061), "Author 3" },
                    { new Guid("a560d133-7005-4d89-894c-a115993fa9c2"), new DateTime(2024, 7, 20, 1, 47, 26, 141, DateTimeKind.Utc).AddTicks(6063), "Author 4" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("036b0792-20e0-4c92-98cf-05de89c0fbca"), new DateTime(2024, 7, 20, 1, 47, 26, 141, DateTimeKind.Utc).AddTicks(6159), "Gender 4" },
                    { new Guid("6befc28a-de38-4e49-bb23-376ed22925ff"), new DateTime(2024, 7, 20, 1, 47, 26, 141, DateTimeKind.Utc).AddTicks(6157), "Gender 3" },
                    { new Guid("70c3b7c4-6d88-49d1-9745-77231b022694"), new DateTime(2024, 7, 20, 1, 47, 26, 141, DateTimeKind.Utc).AddTicks(6151), "Gender 1" },
                    { new Guid("d3001e55-7bce-4b3b-9d85-e6d148b4b7a4"), new DateTime(2024, 7, 20, 1, 47, 26, 141, DateTimeKind.Utc).AddTicks(6156), "Gender 2" },
                    { new Guid("ffe63f4e-a7ff-4cde-bb74-2dd325ca5c0b"), new DateTime(2024, 7, 20, 1, 47, 26, 141, DateTimeKind.Utc).AddTicks(6160), "Gender 5" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Edition", "GenderId", "ISBN", "Language", "Name", "Pages" },
                values: new object[] { new Guid("a3b21d97-e3d6-4794-b5c5-64833ca7d3bb"), new Guid("589039c8-145e-43c9-b6ec-30d027b99f32"), new DateTime(2024, 7, 20, 1, 47, 26, 141, DateTimeKind.Utc).AddTicks(6286), 1, new Guid("6befc28a-de38-4e49-bb23-376ed22925ff"), "Xpto", "Portuguese", "Game of Thrones: As Crônicas de Gelo e Fogo", 700 });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_GenderId",
                table: "Book",
                column: "GenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
