using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projetNet.Migrations
{
    /// <inheritdoc />
    public partial class imageurls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("1c9e50ac-6868-4e00-8438-d428ae9f3fb0"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("2539db57-89b5-4caa-8ec9-b0a89bc0640c"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("e6733d59-a1ea-4608-a599-4293f28452a0"));

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("1dab3518-8416-484f-90a1-9ba31938b639"), "Toyota", "Reliable sedan, low mileage.", "/images/cars/toyota_corolla.jpg", "Paris", 12000, "Corolla", "owner1", 15000m, "VIN1234567890", 2022 },
                    { new Guid("8478f339-439f-4315-904e-6efdba3cdb7d"), "Renault", "Compact city car, economical.", "/images/cars/renault_clio.jpg", "Marseille", 20000, "Clio", "owner3", 9000m, "VIN1122334455", 2020 },
                    { new Guid("9e199fbc-e7a0-45a0-97e8-e18837e08722"), "BMW", "Luxury SUV, fully loaded.", "/images/cars/bmw_x5.jpg", "Lyon", 8000, "X5", "owner2", 35000m, "VIN0987654321", 2021 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("1dab3518-8416-484f-90a1-9ba31938b639"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("8478f339-439f-4315-904e-6efdba3cdb7d"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("9e199fbc-e7a0-45a0-97e8-e18837e08722"));

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("1c9e50ac-6868-4e00-8438-d428ae9f3fb0"), "BMW", "Luxury SUV, fully loaded.", "/images/cars/bmw_x5.jpg", "Lyon", 8000, "X5", "owner2", 35000m, "VIN0987654321", 2021 },
                    { new Guid("2539db57-89b5-4caa-8ec9-b0a89bc0640c"), "Renault", "Compact city car, economical.", "/images/cars/renault_clio.jpg", "Marseille", 20000, "Clio", "owner3", 9000m, "VIN1122334455", 2020 },
                    { new Guid("e6733d59-a1ea-4608-a599-4293f28452a0"), "Toyota", "Reliable sedan, low mileage.", "/images/cars/toyota_corolla.jpg", "Paris", 12000, "Corolla", "owner1", 15000m, "VIN1234567890", 2022 }
                });
        }
    }
}
