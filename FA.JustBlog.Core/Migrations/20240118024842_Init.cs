using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FA.JustBlog.Core.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PostContent = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RateCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalRate = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    CommnentHeader = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 18, 9, 48, 42, 214, DateTimeKind.Local).AddTicks(5893)),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, "latest news", "News", "news" },
                    { 2, "latest news about sport", "Sport", "sport" },
                    { 3, "latest news about music", "Music", "music" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 0, "Description", "latest", "latest" },
                    { 2, 0, "Description", "hotest", "hotest" },
                    { 3, 0, "Description", "funny", "funny" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "PostContent", "PostedOn", "Published", "Rate", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 18, 9, 48, 42, 216, DateTimeKind.Local).AddTicks(9455), "This is an post content", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 9.8m, 15, "short", "Title latest", 147, "title-latest", 5 },
                    { 2, 1, new DateTime(2024, 1, 18, 9, 48, 42, 216, DateTimeKind.Local).AddTicks(9479), "This is an post content", new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 10.923076923076923076923076923m, 13, "short", "Title new releases", 142, "latest-release", 53 },
                    { 3, 3, new DateTime(2024, 1, 18, 9, 48, 42, 216, DateTimeKind.Local).AddTicks(9490), "This is an post content", new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 23.026143790849673202614379085m, 153, "short", "BillBoard Hot100 Release", 3523, "hot100-bb", 24 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "PostContent", "PostedOn", "Published", "Rate", "ShortDescription", "Title", "TotalRate", "UrlSlug" },
                values: new object[] { 4, 1, new DateTime(2024, 1, 18, 9, 48, 42, 216, DateTimeKind.Local).AddTicks(9498), "This is an post content", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0m, "short", "Title hotest", 0, "news-hot" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "PostContent", "PostedOn", "Published", "Rate", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[] { 5, 2, new DateTime(2024, 1, 18, 9, 48, 42, 216, DateTimeKind.Local).AddTicks(9503), "This is an post content", new DateTime(2024, 1, 18, 9, 48, 42, 216, DateTimeKind.Local).AddTicks(9501), true, 15.153846153846153846153846154m, 13, "short", "Football Well-Player", 197, "football-player", 35 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentText", "CommnentHeader", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 1, "This is acctually good!", "Bad", "axxxxxxx2@gmail.com", "Jeans", 1 },
                    { 2, "This is acctually good!", "Goods", "ahr2@gmail.com", "John", 2 },
                    { 3, "This is acctually good!xxx", "Goods", "ahr224@gmail.com", "Billie", 2 },
                    { 4, "This is acctually good!", "Goods", "ahro@gmail.com", "Ano", 2 },
                    { 5, "This is acctually good!", "Goods", "funnyguy@gmail.com", "Funny Guy", 3 }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 1 },
                    { 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                table: "PostTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UrlSlug",
                table: "Tags",
                column: "UrlSlug");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
