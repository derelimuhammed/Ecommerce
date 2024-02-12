using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ver002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOptionValues_Options_OptionId",
                table: "ProductOptionValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOptionValues",
                table: "ProductOptionValues");

            migrationBuilder.DropIndex(
                name: "IX_ProductOptionValues_OptionId",
                table: "ProductOptionValues");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AddressId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("59b84737-f015-46dd-8a15-beeea5262e3d"));

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("91270277-9a72-4af6-bbb6-f44fe6d37956"));

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("c144e119-6f21-4316-9404-79c9b08bbb13"));

            migrationBuilder.DropColumn(
                name: "OptionId",
                table: "ProductOptionValues");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOptionValues",
                table: "ProductOptionValues",
                columns: new[] { "ProductId", "OptionValueId" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOptionValues",
                table: "ProductOptionValues");

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

            migrationBuilder.AddColumn<Guid>(
                name: "OptionId",
                table: "ProductOptionValues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOptionValues",
                table: "ProductOptionValues",
                columns: new[] { "ProductId", "OptionId", "OptionValueId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b22698b8-42a2-4115-9631-1c2d1e2ac5f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e614c14b-b108-4c4b-bc3d-c313f363d293", "AQAAAAIAAYagAAAAEE8VZsOHFxEGMsGWkmc+smxmX5sGFN0UcSaOxHfjYK7L4qP8r9eMrBf9SU4J5mBI5A==" });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "OderStatus", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("59b84737-f015-46dd-8a15-beeea5262e3d"), "system", new DateTime(2024, 2, 8, 12, 4, 41, 120, DateTimeKind.Local).AddTicks(970), null, null, "Processing", 0, null, null },
                    { new Guid("91270277-9a72-4af6-bbb6-f44fe6d37956"), "system", new DateTime(2024, 2, 8, 12, 4, 41, 120, DateTimeKind.Local).AddTicks(992), null, null, "Completed", 0, null, null },
                    { new Guid("c144e119-6f21-4316-9404-79c9b08bbb13"), "system", new DateTime(2024, 2, 8, 12, 4, 41, 120, DateTimeKind.Local).AddTicks(982), null, null, "Shipped", 0, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptionValues_OptionId",
                table: "ProductOptionValues",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOptionValues_Options_OptionId",
                table: "ProductOptionValues",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
