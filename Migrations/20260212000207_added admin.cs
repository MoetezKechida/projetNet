using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projetNet.Migrations
{
    /// <inheritdoc />
    public partial class addedadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("043103e0-9d0d-4e79-8d90-bbdeb127171c"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("11b4561a-1070-44aa-85b3-ce75ebe5c0ea"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("3ff98863-fdb7-45d8-a371-4e3fed03ed3b"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("40ea8f70-c418-48ea-8907-72683c5d2d3c"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("448510e1-5790-44ac-ab18-4512a8b070e9"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("61a83c67-8415-4cf3-b0c1-6105b9903ac3"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("9dbd077b-1ab3-4f19-ab46-8638495b9931"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("ee818b69-ab26-41f9-85c5-5bb57511f9ef"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("2f469778-8bf5-4cdf-9e0e-ac89ea2a2a10"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("4491282b-a1a2-4df8-bcfc-a888f8dc5a36"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("8b0c391f-03b4-4ae0-b429-cf0b1ad36297"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("91f249ce-e391-4546-8555-2493914bd79f"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("f6cea901-fbe4-485c-b83c-e41731156b80"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("ffaea396-a7a1-4bf5-91c4-4437e502c245"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "70d3a253-f9a0-4655-80e1-1cee42e8325f", "e0f4f360-cccb-4da4-a06c-8afd4fdb2b49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e49eb0c6-8166-46b7-badc-0c898d1b311c", "e65c4638-c69c-4acd-84f6-e178d3b51985" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ac994e2a-b766-4160-a63c-e8d434cc0b24", "1a332e3a-60ac-4681-87ed-846a6f99f263" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5a2de0f8-97c8-4822-a60a-0a82afd71dff", "8af85a9c-4965-4b2e-be41-3af3396bc454" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "119889b5-68f0-408b-ab9f-86540c0fcc93", "92f33219-d718-4e73-9147-29fd4ad97a51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c6265def-76d3-4e08-8c29-cd56a7744374", "c2ea1d7b-c69c-49da-ac93-efc0ae999f64" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Price", "SellerId", "Status", "Type", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("64177a75-e8d5-4284-9049-351ad15ce5fe"), 9000m, "owner3", "accepted", "Sale", new Guid("7dae5654-e4fd-41e9-b753-954c60d3a7d2") },
                    { new Guid("8c5ff4d6-db12-463f-a58e-fdc1edfe7a7a"), 8000m, "owner3", "rejected", "Sale", new Guid("7dae5654-e4fd-41e9-b753-954c60d3a7d2") },
                    { new Guid("8fb817b0-9c35-4a29-88d9-79ffe99eec1e"), 25000m, "owner5", "accepted", "Sale", new Guid("5ad68e4f-76b0-4590-88f5-8b61e509fb7a") },
                    { new Guid("9122176b-a915-4f0b-a0f1-350bf141f6e9"), 15000m, "owner1", "accepted", "Sale", new Guid("9c38d9e4-4b15-451f-8f64-99518f1556fb") },
                    { new Guid("9526b3c5-3f30-49ee-93f3-18ca8121d6fe"), 100m, "owner6", "accepted", "Rent", new Guid("bc302679-4a1a-43d3-9926-a7f511d238ad") },
                    { new Guid("a42245b4-0e9c-4b2c-a458-7b4ac2e96109"), 80m, "owner4", "accepted", "Rent", new Guid("97d3a22c-b9fb-4f6f-8534-1810d6bbcd5c") },
                    { new Guid("d9e98976-80d8-45cc-931b-e29ca62377c3"), 60m, "owner4", "pending", "Rent", new Guid("97d3a22c-b9fb-4f6f-8534-1810d6bbcd5c") },
                    { new Guid("dd1803bb-e7d0-4056-b2d9-833e2a0d1191"), 120m, "owner2", "accepted", "Rent", new Guid("71a2e281-4c56-421e-bde1-82a58a3ba828") }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "RentalPrice", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("5ad68e4f-76b0-4590-88f5-8b61e509fb7a"), "Mercedes", "Elegant and comfortable, well maintained.", "https://images.unsplash.com/photo-1502877336888-7bfc88a5e4a0?auto=format&fit=crop&w=400&q=80", "Bordeaux", 30000, "C-Class", "owner5", 25000m, null, null, "VIN9988776655", 2019 },
                    { new Guid("71a2e281-4c56-421e-bde1-82a58a3ba828"), "BMW", "Luxury SUV, fully loaded.", "https://images.unsplash.com/photo-1503736334956-4c8f8e92946d?auto=format&fit=crop&w=400&q=80", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 },
                    { new Guid("7dae5654-e4fd-41e9-b753-954c60d3a7d2"), "Renault", "Compact city car, economical.", "https://images.unsplash.com/photo-1461632830798-3adb3034e4c8?auto=format&fit=crop&w=400&q=80", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 },
                    { new Guid("97d3a22c-b9fb-4f6f-8534-1810d6bbcd5c"), "Peugeot", "Brand new, perfect for city driving.", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=400&q=80", "Nice", 500, "208", "owner4", 12000m, null, null, "VIN5566778899", 2023 },
                    { new Guid("9c38d9e4-4b15-451f-8f64-99518f1556fb"), "Toyota", "Reliable sedan, low mileage.", "https://images.unsplash.com/photo-1511918984145-48bbd2aa2d4c?auto=format&fit=crop&w=400&q=80", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 },
                    { new Guid("bc302679-4a1a-43d3-9926-a7f511d238ad"), "Volkswagen", "Popular hatchback, great for families.", "https://images.unsplash.com/photo-1519643381400-7f7c7d3e0c44?auto=format&fit=crop&w=400&q=80", "Toulouse", 15000, "Golf", "owner6", 14000m, null, null, "VIN4455667788", 2021 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("64177a75-e8d5-4284-9049-351ad15ce5fe"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("8c5ff4d6-db12-463f-a58e-fdc1edfe7a7a"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("8fb817b0-9c35-4a29-88d9-79ffe99eec1e"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("9122176b-a915-4f0b-a0f1-350bf141f6e9"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("9526b3c5-3f30-49ee-93f3-18ca8121d6fe"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("a42245b4-0e9c-4b2c-a458-7b4ac2e96109"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("d9e98976-80d8-45cc-931b-e29ca62377c3"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("dd1803bb-e7d0-4056-b2d9-833e2a0d1191"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("5ad68e4f-76b0-4590-88f5-8b61e509fb7a"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("71a2e281-4c56-421e-bde1-82a58a3ba828"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("7dae5654-e4fd-41e9-b753-954c60d3a7d2"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("97d3a22c-b9fb-4f6f-8534-1810d6bbcd5c"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("9c38d9e4-4b15-451f-8f64-99518f1556fb"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("bc302679-4a1a-43d3-9926-a7f511d238ad"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2f1ba0bd-1372-4dd3-b809-380f14e96cc3", "21d9bfd2-0cb0-461c-a504-d07dd6755f27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4cb64b48-7eae-4a1a-9ef6-e978cc4336e1", "3cc7ebce-efe2-4797-be05-91ab6031b438" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2960f037-8162-44a8-806b-d51826963c84", "cd32f9b4-ea2f-430a-9b73-d31b563e3689" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "404e2e7b-682e-4376-b9ae-86b803bda34f", "27a359f6-364a-4a90-b40c-6b783537b8b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bb47b35b-782e-4194-9566-789298d904c4", "0169869e-9878-452c-b8be-e9e69fa0ce2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "074d6d85-9607-49dc-854d-e9af38048145", "b51336eb-ab30-47e8-81c2-5f21521dc8ab" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Price", "SellerId", "Status", "Type", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("043103e0-9d0d-4e79-8d90-bbdeb127171c"), 8000m, "owner3", "rejected", "Sale", new Guid("ffaea396-a7a1-4bf5-91c4-4437e502c245") },
                    { new Guid("11b4561a-1070-44aa-85b3-ce75ebe5c0ea"), 120m, "owner2", "accepted", "Rent", new Guid("f6cea901-fbe4-485c-b83c-e41731156b80") },
                    { new Guid("3ff98863-fdb7-45d8-a371-4e3fed03ed3b"), 100m, "owner6", "accepted", "Rent", new Guid("2f469778-8bf5-4cdf-9e0e-ac89ea2a2a10") },
                    { new Guid("40ea8f70-c418-48ea-8907-72683c5d2d3c"), 60m, "owner4", "pending", "Rent", new Guid("4491282b-a1a2-4df8-bcfc-a888f8dc5a36") },
                    { new Guid("448510e1-5790-44ac-ab18-4512a8b070e9"), 80m, "owner4", "accepted", "Rent", new Guid("4491282b-a1a2-4df8-bcfc-a888f8dc5a36") },
                    { new Guid("61a83c67-8415-4cf3-b0c1-6105b9903ac3"), 25000m, "owner5", "accepted", "Sale", new Guid("8b0c391f-03b4-4ae0-b429-cf0b1ad36297") },
                    { new Guid("9dbd077b-1ab3-4f19-ab46-8638495b9931"), 15000m, "owner1", "accepted", "Sale", new Guid("91f249ce-e391-4546-8555-2493914bd79f") },
                    { new Guid("ee818b69-ab26-41f9-85c5-5bb57511f9ef"), 9000m, "owner3", "accepted", "Sale", new Guid("ffaea396-a7a1-4bf5-91c4-4437e502c245") }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "RentalPrice", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("2f469778-8bf5-4cdf-9e0e-ac89ea2a2a10"), "Volkswagen", "Popular hatchback, great for families.", "https://images.unsplash.com/photo-1519643381400-7f7c7d3e0c44?auto=format&fit=crop&w=400&q=80", "Toulouse", 15000, "Golf", "owner6", 14000m, null, null, "VIN4455667788", 2021 },
                    { new Guid("4491282b-a1a2-4df8-bcfc-a888f8dc5a36"), "Peugeot", "Brand new, perfect for city driving.", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=400&q=80", "Nice", 500, "208", "owner4", 12000m, null, null, "VIN5566778899", 2023 },
                    { new Guid("8b0c391f-03b4-4ae0-b429-cf0b1ad36297"), "Mercedes", "Elegant and comfortable, well maintained.", "https://images.unsplash.com/photo-1502877336888-7bfc88a5e4a0?auto=format&fit=crop&w=400&q=80", "Bordeaux", 30000, "C-Class", "owner5", 25000m, null, null, "VIN9988776655", 2019 },
                    { new Guid("91f249ce-e391-4546-8555-2493914bd79f"), "Toyota", "Reliable sedan, low mileage.", "https://images.unsplash.com/photo-1511918984145-48bbd2aa2d4c?auto=format&fit=crop&w=400&q=80", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 },
                    { new Guid("f6cea901-fbe4-485c-b83c-e41731156b80"), "BMW", "Luxury SUV, fully loaded.", "https://images.unsplash.com/photo-1503736334956-4c8f8e92946d?auto=format&fit=crop&w=400&q=80", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 },
                    { new Guid("ffaea396-a7a1-4bf5-91c4-4437e502c245"), "Renault", "Compact city car, economical.", "https://images.unsplash.com/photo-1461632830798-3adb3034e4c8?auto=format&fit=crop&w=400&q=80", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 }
                });
        }
    }
}
