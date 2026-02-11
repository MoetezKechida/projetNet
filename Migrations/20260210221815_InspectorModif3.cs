using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projetNet.Migrations
{
    /// <inheritdoc />
    public partial class InspectorModif3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("340ba702-fea2-4167-827c-721b11562112"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("3f874a2d-f82a-43d1-946a-8f1f70039032"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("c6c77470-2443-4e0f-a36f-68e68465ccb9"));

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "Reason",
                keyValue: null,
                column: "Reason",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "Inspections",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Inspections",
                keyColumn: "InspectorId",
                keyValue: null,
                column: "InspectorId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "InspectorId",
                table: "Inspections",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "RentalPrice", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("00628c7b-8824-410f-8765-7ad9e421e077"), "Toyota", "Reliable sedan, low mileage.", "/images/cars/toyota_corolla.jpg", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 },
                    { new Guid("8129fa52-5b70-4298-a1c9-935dd8fa1cf6"), "BMW", "Luxury SUV, fully loaded.", "/images/cars/bmw_x5.jpg", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 },
                    { new Guid("e5169658-0a13-4499-b68c-2afdd70d2325"), "Renault", "Compact city car, economical.", "/images/cars/renault_clio.jpg", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("00628c7b-8824-410f-8765-7ad9e421e077"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("8129fa52-5b70-4298-a1c9-935dd8fa1cf6"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("e5169658-0a13-4499-b68c-2afdd70d2325"));

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "Inspections",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "InspectorId",
                table: "Inspections",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "RentalPrice", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("340ba702-fea2-4167-827c-721b11562112"), "Toyota", "Reliable sedan, low mileage.", "/images/cars/toyota_corolla.jpg", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 },
                    { new Guid("3f874a2d-f82a-43d1-946a-8f1f70039032"), "BMW", "Luxury SUV, fully loaded.", "/images/cars/bmw_x5.jpg", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 },
                    { new Guid("c6c77470-2443-4e0f-a36f-68e68465ccb9"), "Renault", "Compact city car, economical.", "/images/cars/renault_clio.jpg", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 }
                });
        }
    }
}
