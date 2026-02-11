using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projetNet.Migrations
{
    /// <inheritdoc />
    public partial class addedvehiculeSaleandalteredBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("1021a71c-109e-41c6-bbd7-77233d5474f8"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("34612355-fbdb-4d09-8096-86f71fe8a6ac"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("5b9add65-57d1-49f9-bed6-9a1b555bc4ac"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("a30b56d0-fe6b-4d06-935d-62ebe7084b03"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("a9cb378c-251e-457a-af15-6e0292b03e5f"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("b83492a3-3865-40bc-b88a-59684525e68c"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("cc41c889-d79a-4a8c-b1e8-42ae5f265985"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("d558cf50-5644-4f34-afb0-abfbd06121ea"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("3dd84240-229a-4749-9f12-c5249c0f3120"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("4e51a813-fd69-496a-9605-b6e84f0e2052"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("9f6ca1e5-b761-4356-bb34-41fdeeb5d0a7"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("ad1dbab0-55bc-46b9-9fc0-e9bae500700d"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("bb1b7ba7-2ced-41e3-9a58-2558980bfb9b"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("fd587b0b-1524-4b18-9f52-a5a1f001a540"));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Bookings",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehiculeSales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OfferId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BuyerId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculeSales", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cbd33a6c-51eb-4344-b2d6-ec7224ecc6e2", "00b4b2ce-d5f4-4826-82ce-77d599a0ea52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cfc5064c-d9d6-47bc-8dd6-d19d08952084", "df1c0c6b-ba4e-4c85-98ae-49db81cb248c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f6214142-c9f8-4bca-a482-1f336f422de3", "9752291e-a640-4ec7-8088-f6835278525a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "71925a83-7062-4a9c-9e70-92445fe596fd", "7f02db02-58ea-4486-b0d2-6dfefb85796f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2dfebd1d-e2df-4a11-b33e-a418550420d8", "ea3058f7-a15a-42f8-9cd3-54a65509cbeb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "947a3786-d980-4c86-b761-03bf5bf1e0b7", "aaefa25e-12c6-43ad-8dbc-2071d031eb85" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Price", "SellerId", "Status", "Type", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("4763b222-5ab3-49f3-9267-e0a656756a31"), 60m, "owner4", "pending", "Rent", new Guid("dda0db13-c989-43e9-ae83-74ed4d68ee34") },
                    { new Guid("629f4f3d-d6a0-41c2-a1f2-d6b7a0dab5d8"), 120m, "owner2", "accepted", "Rent", new Guid("478e482b-ae54-45c0-8df4-01667c0bfbb1") },
                    { new Guid("7aa6f815-fb83-4047-89b4-fa900cf8df1e"), 80m, "owner4", "accepted", "Rent", new Guid("dda0db13-c989-43e9-ae83-74ed4d68ee34") },
                    { new Guid("86071019-83a9-4acf-82f2-b38a21a95dfb"), 100m, "owner6", "accepted", "Rent", new Guid("b757b9c6-e22a-44e6-980c-a6ac84a1e96c") },
                    { new Guid("956ed16a-0a12-4ef8-9a89-1ce27748e0ca"), 25000m, "owner5", "accepted", "Sale", new Guid("50fe8e9f-cfd6-4b06-b701-a92f29c70eb0") },
                    { new Guid("b5b224da-2501-4999-a2b7-2be9daca0973"), 8000m, "owner3", "rejected", "Sale", new Guid("0ab69d94-2a50-4418-b295-378376bfc514") },
                    { new Guid("c5568269-21e0-49ea-9ce4-0ee6a0a7067e"), 9000m, "owner3", "accepted", "Sale", new Guid("0ab69d94-2a50-4418-b295-378376bfc514") },
                    { new Guid("d22e6129-e79a-4e2d-a74e-bee965aef4ce"), 15000m, "owner1", "accepted", "Sale", new Guid("9a130edd-b4b5-4537-8262-7835965ca3eb") }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "RentalPrice", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("0ab69d94-2a50-4418-b295-378376bfc514"), "Renault", "Compact city car, economical.", "https://images.unsplash.com/photo-1461632830798-3adb3034e4c8?auto=format&fit=crop&w=400&q=80", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 },
                    { new Guid("478e482b-ae54-45c0-8df4-01667c0bfbb1"), "BMW", "Luxury SUV, fully loaded.", "https://images.unsplash.com/photo-1503736334956-4c8f8e92946d?auto=format&fit=crop&w=400&q=80", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 },
                    { new Guid("50fe8e9f-cfd6-4b06-b701-a92f29c70eb0"), "Mercedes", "Elegant and comfortable, well maintained.", "https://images.unsplash.com/photo-1502877336888-7bfc88a5e4a0?auto=format&fit=crop&w=400&q=80", "Bordeaux", 30000, "C-Class", "owner5", 25000m, null, null, "VIN9988776655", 2019 },
                    { new Guid("9a130edd-b4b5-4537-8262-7835965ca3eb"), "Toyota", "Reliable sedan, low mileage.", "https://images.unsplash.com/photo-1511918984145-48bbd2aa2d4c?auto=format&fit=crop&w=400&q=80", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 },
                    { new Guid("b757b9c6-e22a-44e6-980c-a6ac84a1e96c"), "Volkswagen", "Popular hatchback, great for families.", "https://images.unsplash.com/photo-1519643381400-7f7c7d3e0c44?auto=format&fit=crop&w=400&q=80", "Toulouse", 15000, "Golf", "owner6", 14000m, null, null, "VIN4455667788", 2021 },
                    { new Guid("dda0db13-c989-43e9-ae83-74ed4d68ee34"), "Peugeot", "Brand new, perfect for city driving.", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=400&q=80", "Nice", 500, "208", "owner4", 12000m, null, null, "VIN5566778899", 2023 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiculeSales");

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("4763b222-5ab3-49f3-9267-e0a656756a31"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("629f4f3d-d6a0-41c2-a1f2-d6b7a0dab5d8"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("7aa6f815-fb83-4047-89b4-fa900cf8df1e"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("86071019-83a9-4acf-82f2-b38a21a95dfb"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("956ed16a-0a12-4ef8-9a89-1ce27748e0ca"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("b5b224da-2501-4999-a2b7-2be9daca0973"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("c5568269-21e0-49ea-9ce4-0ee6a0a7067e"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("d22e6129-e79a-4e2d-a74e-bee965aef4ce"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("0ab69d94-2a50-4418-b295-378376bfc514"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("478e482b-ae54-45c0-8df4-01667c0bfbb1"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("50fe8e9f-cfd6-4b06-b701-a92f29c70eb0"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("9a130edd-b4b5-4537-8262-7835965ca3eb"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("b757b9c6-e22a-44e6-980c-a6ac84a1e96c"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("dda0db13-c989-43e9-ae83-74ed4d68ee34"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fb42146b-0ef9-48fe-b99c-393a9a56621f", "71f90d75-826a-4419-8b8d-496ac0bb571a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7d641e77-cd68-4628-a601-a36356340ab2", "ad31160a-6070-40ec-a6e2-7030b72000a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b6ed79b0-99dd-42cb-a53a-9563cfe4f741", "869f863e-b4b8-45b1-8fa8-86e8e8b77114" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4d585fb4-eb1a-4b74-b3b5-408992f3e1eb", "f82732f3-5584-4888-8ade-164d26af9ca3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f3bcf71f-0679-4ebc-9969-a2d146dc6b1b", "c39093db-5636-475b-afed-0201c1ee3990" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "56b12eab-39b8-4c15-9103-1c978bab1703", "c46df2b8-b9ae-4898-8e89-f571cc6f29d3" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Price", "SellerId", "Status", "Type", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("1021a71c-109e-41c6-bbd7-77233d5474f8"), 8000m, "owner3", "rejected", "Sale", new Guid("e3c3de72-78bf-4b96-99a3-b2b6ca3eff9f") },
                    { new Guid("34612355-fbdb-4d09-8096-86f71fe8a6ac"), 15000m, "owner1", "accepted", "Sale", new Guid("3466c6ee-f48d-471d-8007-d23b174e67a7") },
                    { new Guid("5b9add65-57d1-49f9-bed6-9a1b555bc4ac"), 80m, "owner4", "accepted", "Rent", new Guid("fd587b0b-1524-4b18-9f52-a5a1f001a540") },
                    { new Guid("a30b56d0-fe6b-4d06-935d-62ebe7084b03"), 120m, "owner2", "accepted", "Rent", new Guid("f05c709f-47c2-477e-a7ad-a3aa129c5e8f") },
                    { new Guid("a9cb378c-251e-457a-af15-6e0292b03e5f"), 25000m, "owner5", "accepted", "Sale", new Guid("9f6ca1e5-b761-4356-bb34-41fdeeb5d0a7") },
                    { new Guid("b83492a3-3865-40bc-b88a-59684525e68c"), 60m, "owner4", "pending", "Rent", new Guid("fd587b0b-1524-4b18-9f52-a5a1f001a540") },
                    { new Guid("cc41c889-d79a-4a8c-b1e8-42ae5f265985"), 9000m, "owner3", "accepted", "Sale", new Guid("e3c3de72-78bf-4b96-99a3-b2b6ca3eff9f") },
                    { new Guid("d558cf50-5644-4f34-afb0-abfbd06121ea"), 100m, "owner6", "accepted", "Rent", new Guid("3dd84240-229a-4749-9f12-c5249c0f3120") }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "RentalPrice", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("3dd84240-229a-4749-9f12-c5249c0f3120"), "Volkswagen", "Popular hatchback, great for families.", "https://images.unsplash.com/photo-1519643381400-7f7c7d3e0c44?auto=format&fit=crop&w=400&q=80", "Toulouse", 15000, "Golf", "owner6", 14000m, null, null, "VIN4455667788", 2021 },
                    { new Guid("4e51a813-fd69-496a-9605-b6e84f0e2052"), "Renault", "Compact city car, economical.", "https://images.unsplash.com/photo-1461632830798-3adb3034e4c8?auto=format&fit=crop&w=400&q=80", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 },
                    { new Guid("9f6ca1e5-b761-4356-bb34-41fdeeb5d0a7"), "Mercedes", "Elegant and comfortable, well maintained.", "https://images.unsplash.com/photo-1502877336888-7bfc88a5e4a0?auto=format&fit=crop&w=400&q=80", "Bordeaux", 30000, "C-Class", "owner5", 25000m, null, null, "VIN9988776655", 2019 },
                    { new Guid("ad1dbab0-55bc-46b9-9fc0-e9bae500700d"), "BMW", "Luxury SUV, fully loaded.", "https://images.unsplash.com/photo-1503736334956-4c8f8e92946d?auto=format&fit=crop&w=400&q=80", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 },
                    { new Guid("bb1b7ba7-2ced-41e3-9a58-2558980bfb9b"), "Toyota", "Reliable sedan, low mileage.", "https://images.unsplash.com/photo-1511918984145-48bbd2aa2d4c?auto=format&fit=crop&w=400&q=80", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 },
                    { new Guid("fd587b0b-1524-4b18-9f52-a5a1f001a540"), "Peugeot", "Brand new, perfect for city driving.", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=400&q=80", "Nice", 500, "208", "owner4", 12000m, null, null, "VIN5566778899", 2023 }
                });
        }
    }
}
