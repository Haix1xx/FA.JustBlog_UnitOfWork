using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 21, 22, 4, 22, 154, DateTimeKind.Local).AddTicks(3970),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 21, 20, 29, 14, 403, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "AspNetUsers",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentTime",
                value: new DateTime(2024, 1, 21, 22, 4, 22, 154, DateTimeKind.Local).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentTime",
                value: new DateTime(2024, 1, 21, 22, 4, 22, 154, DateTimeKind.Local).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommentTime",
                value: new DateTime(2024, 1, 21, 22, 4, 22, 154, DateTimeKind.Local).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CommentTime",
                value: new DateTime(2024, 1, 21, 22, 4, 22, 154, DateTimeKind.Local).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CommentTime",
                value: new DateTime(2024, 1, 21, 22, 4, 22, 154, DateTimeKind.Local).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Modified",
                value: new DateTime(2024, 1, 21, 22, 4, 22, 154, DateTimeKind.Local).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Modified",
                value: new DateTime(2024, 1, 21, 22, 4, 22, 154, DateTimeKind.Local).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Modified",
                value: new DateTime(2024, 1, 21, 22, 4, 22, 154, DateTimeKind.Local).AddTicks(9735));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Modified",
                value: new DateTime(2024, 1, 21, 22, 4, 22, 154, DateTimeKind.Local).AddTicks(9741));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 1, 21, 22, 4, 22, 154, DateTimeKind.Local).AddTicks(9745), new DateTime(2024, 1, 21, 22, 4, 22, 154, DateTimeKind.Local).AddTicks(9744) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 21, 20, 29, 14, 403, DateTimeKind.Local).AddTicks(4316),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 21, 22, 4, 22, 154, DateTimeKind.Local).AddTicks(3970));

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "AspNetUsers",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentTime",
                value: new DateTime(2024, 1, 21, 20, 29, 14, 403, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentTime",
                value: new DateTime(2024, 1, 21, 20, 29, 14, 403, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommentTime",
                value: new DateTime(2024, 1, 21, 20, 29, 14, 403, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CommentTime",
                value: new DateTime(2024, 1, 21, 20, 29, 14, 403, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CommentTime",
                value: new DateTime(2024, 1, 21, 20, 29, 14, 403, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Modified",
                value: new DateTime(2024, 1, 21, 20, 29, 14, 403, DateTimeKind.Local).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Modified",
                value: new DateTime(2024, 1, 21, 20, 29, 14, 403, DateTimeKind.Local).AddTicks(9596));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Modified",
                value: new DateTime(2024, 1, 21, 20, 29, 14, 403, DateTimeKind.Local).AddTicks(9604));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Modified",
                value: new DateTime(2024, 1, 21, 20, 29, 14, 403, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 1, 21, 20, 29, 14, 403, DateTimeKind.Local).AddTicks(9613), new DateTime(2024, 1, 21, 20, 29, 14, 403, DateTimeKind.Local).AddTicks(9612) });
        }
    }
}
