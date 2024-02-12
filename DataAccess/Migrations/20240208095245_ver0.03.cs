using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ver003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryOptions_Options_OptionId",
                table: "CategoryOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryOptions",
                table: "CategoryOptions");

            migrationBuilder.DropIndex(
                name: "IX_CategoryOptions_OptionId",
                table: "CategoryOptions");

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("5e5f575c-c216-4c94-9bcf-e0b04f3ff6e1"));

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a12775ca-d502-47d5-95b2-183bd20ff9ad"));

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("c5ba9ff0-fdd6-4f66-9e42-a2abc295efdf"));

            migrationBuilder.DropColumn(
                name: "OptionId",
                table: "CategoryOptions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryOptions",
                table: "CategoryOptions",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d61f55ea-2b88-490c-abf3-e61cacbd6f79", "AQAAAAIAAYagAAAAEAdVuLeq7OeD9q+zIDcZwuekhSBccc16SIepzN23S3XAm7L6U+EL51vuYjj4ulfjFw==" });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "OderStatus", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("9e76219e-7366-42e6-bc03-1da9bd782fe1"), "system", new DateTime(2024, 2, 8, 12, 52, 44, 321, DateTimeKind.Local).AddTicks(5224), null, null, "Completed", 0, null, null },
                    { new Guid("d34c15bc-b13d-44d9-a0e4-1659de4d990c"), "system", new DateTime(2024, 2, 8, 12, 52, 44, 321, DateTimeKind.Local).AddTicks(5208), null, null, "Processing", 0, null, null },
                    { new Guid("d42bc807-ea98-4d95-a38a-38fa9d7d90b7"), "system", new DateTime(2024, 2, 8, 12, 52, 44, 321, DateTimeKind.Local).AddTicks(5223), null, null, "Shipped", 0, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOptions_CategoryId",
                table: "CategoryOptions",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryOptions",
                table: "CategoryOptions");

            migrationBuilder.DropIndex(
                name: "IX_CategoryOptions_CategoryId",
                table: "CategoryOptions");

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("9e76219e-7366-42e6-bc03-1da9bd782fe1"));

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("d34c15bc-b13d-44d9-a0e4-1659de4d990c"));

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("d42bc807-ea98-4d95-a38a-38fa9d7d90b7"));

            migrationBuilder.AddColumn<Guid>(
                name: "OptionId",
                table: "CategoryOptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryOptions",
                table: "CategoryOptions",
                columns: new[] { "CategoryId", "OptionId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "488177d1-d8a7-4326-b16d-483b8c122de4", "AQAAAAIAAYagAAAAEMS3ro5PhdG7zKnwI8LN2O5/7whWmREmT+RSZ12GSFlnLpCl81OyVJ5DQm/SnE9Iyw==" });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "OderStatus", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("5e5f575c-c216-4c94-9bcf-e0b04f3ff6e1"), "system", new DateTime(2024, 2, 8, 12, 48, 36, 341, DateTimeKind.Local).AddTicks(7158), null, null, "Processing", 0, null, null },
                    { new Guid("a12775ca-d502-47d5-95b2-183bd20ff9ad"), "system", new DateTime(2024, 2, 8, 12, 48, 36, 341, DateTimeKind.Local).AddTicks(7173), null, null, "Completed", 0, null, null },
                    { new Guid("c5ba9ff0-fdd6-4f66-9e42-a2abc295efdf"), "system", new DateTime(2024, 2, 8, 12, 48, 36, 341, DateTimeKind.Local).AddTicks(7172), null, null, "Shipped", 0, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOptions_OptionId",
                table: "CategoryOptions",
                column: "OptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryOptions_Options_OptionId",
                table: "CategoryOptions",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
