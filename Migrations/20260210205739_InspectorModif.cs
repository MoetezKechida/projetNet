using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projetNet.Migrations
{
    /// <inheritdoc />
    public partial class InspectorModif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("1a2e3650-765b-4b49-986f-786063683d24"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("3277a085-a60e-456c-8387-dd0bba08b299"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("c62d5f47-6c70-458d-b123-8378bc1765a5"));

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "RentalPrice", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("0100d552-05e6-464a-9145-364618f129bd"), "Toyota", "Reliable sedan, low mileage.", "/images/cars/toyota_corolla.jpg", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 },
                    { new Guid("c564db1b-c8da-4dc9-b054-00ee5b771a8f"), "Renault", "Compact city car, economical.", "/images/cars/renault_clio.jpg", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 },
                    { new Guid("caa0b06c-081a-4e7e-858b-a910ef480925"), "BMW", "Luxury SUV, fully loaded.", "/images/cars/bmw_x5.jpg", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("0100d552-05e6-464a-9145-364618f129bd"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("c564db1b-c8da-4dc9-b054-00ee5b771a8f"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("caa0b06c-081a-4e7e-858b-a910ef480925"));

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "RentalPrice", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("1a2e3650-765b-4b49-986f-786063683d24"), "Renault", "Compact city car, economical.", "/images/cars/renault_clio.jpg", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 },
                    { new Guid("3277a085-a60e-456c-8387-dd0bba08b299"), "BMW", "Luxury SUV, fully loaded.", "/images/cars/bmw_x5.jpg", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 },
                    { new Guid("c62d5f47-6c70-458d-b123-8378bc1765a5"), "Toyota", "Reliable sedan, low mileage.", "/images/cars/toyota_corolla.jpg", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 }
                });
        }
    }
}
