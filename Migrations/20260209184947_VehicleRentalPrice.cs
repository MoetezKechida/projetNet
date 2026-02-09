using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projetNet.Migrations
{
    /// <inheritdoc />
    public partial class VehicleRentalPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("12f8d4c7-6cb9-49db-8a1b-29ad4087d8d7"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("a9e40417-6a78-4e72-936a-694d8eb985d5"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("f0abfd68-f336-4ee2-89db-8588f2b2bdfb"));

            migrationBuilder.AddColumn<decimal>(
                name: "RentalPrice",
                table: "Vehicles",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "RentalPrice", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("07f24c63-1b31-41ed-badd-43c8e36d8699"), "Toyota", "Reliable sedan, low mileage.", "/images/cars/toyota_corolla.jpg", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 },
                    { new Guid("6bee9362-8e77-4784-92b1-2491146e0e83"), "BMW", "Luxury SUV, fully loaded.", "/images/cars/bmw_x5.jpg", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 },
                    { new Guid("e041e38f-0207-4953-a5d8-711412a6cafd"), "Renault", "Compact city car, economical.", "/images/cars/renault_clio.jpg", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("07f24c63-1b31-41ed-badd-43c8e36d8699"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("6bee9362-8e77-4784-92b1-2491146e0e83"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("e041e38f-0207-4953-a5d8-711412a6cafd"));

            migrationBuilder.DropColumn(
                name: "RentalPrice",
                table: "Vehicles");

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("12f8d4c7-6cb9-49db-8a1b-29ad4087d8d7"), "Toyota", "Reliable sedan, low mileage.", "/images/cars/toyota_corolla.jpg", "Paris", 12000, "Corolla", "owner1", 15000m, null, "VIN1234567890", 2022 },
                    { new Guid("a9e40417-6a78-4e72-936a-694d8eb985d5"), "BMW", "Luxury SUV, fully loaded.", "/images/cars/bmw_x5.jpg", "Lyon", 8000, "X5", "owner2", 35000m, null, "VIN0987654321", 2021 },
                    { new Guid("f0abfd68-f336-4ee2-89db-8588f2b2bdfb"), "Renault", "Compact city car, economical.", "/images/cars/renault_clio.jpg", "Marseille", 20000, "Clio", "owner3", 9000m, null, "VIN1122334455", 2020 }
                });
        }
    }
}
