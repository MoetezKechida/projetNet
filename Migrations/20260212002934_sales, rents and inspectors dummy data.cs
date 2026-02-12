using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projetNet.Migrations
{
    /// <inheritdoc />
    public partial class salesrentsandinspectorsdummydata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "27f8d5f7-21ce-4724-b268-9afc63cb73a1", "206a1885-bd50-4797-8a51-c5b51c369d6e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9ea51def-c8b1-40b9-97f7-1d0dc27b5913", "30bc72e7-48f2-4b66-85c8-9c69e3214a5f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ddbcd846-ab95-4948-ad08-6733e20e5c94", "2d9a4cb2-5fbc-4547-a723-89e2e1d051b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "143687dc-fc9d-489a-9314-ee39c9e4364d", "fcef9968-41a1-42c2-b725-2c30f55b234d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d00f83e0-868f-42b9-aff0-7f5fb4316d39", "aa095336-9072-4013-ab7a-85627e55231c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "67416dd0-280c-4c96-bf9a-36afdadc44a6", "de3f8396-57c4-405a-b877-3b0558e58821" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsEmailVerified", "IsPhoneVerified", "IsVerifiedSeller", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "SellerRating", "SellerReviewCount", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "insp1", 0, "e8e9f3b0-937b-49c1-b95d-5cf0f40ce208", null, "inspector1@projetnet.com", true, "Alice", false, false, null, "Inspector", false, null, null, null, null, null, true, null, null, "b75ac1fc-7ba7-4655-92fe-8d09ae3ae808", 0.0, 0, false, "inspector1" },
                    { "insp2", 0, "c5ee9d32-9a1d-4392-a0a6-dbae6e48651a", null, "inspector2@projetnet.com", true, "Bob", false, false, null, "Checker", false, null, null, null, null, null, true, null, null, "c6f282e2-c914-440a-8a6d-02afd4702300", 0.0, 0, false, "inspector2" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingType", "BuyerId", "EndDate", "StartDate", "Status", "TotalAmount", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("363431ee-c0bf-42ec-9086-7aae63eff5be"), "Rent", "owner1", new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "completed", 1200m, new Guid("1eb05e7b-43e6-4151-ab61-50adec037bc1") },
                    { new Guid("d413bd77-b841-42e7-988c-99e8001a4d46"), "Rent", "owner3", new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "completed", 400m, new Guid("8e6b9144-f05e-46ea-9ecc-4489964e4b56") }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Price", "SellerId", "Status", "Type", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("1a05e7da-f8e5-4b47-8ff0-0a8a5b63c1ce"), 9000m, "owner3", "accepted", "Sale", new Guid("effdeb80-e986-4251-8ce8-19e516543e33") },
                    { new Guid("268552bf-a97c-4f59-a54c-5d2f98f57780"), 60m, "owner4", "pending", "Rent", new Guid("8e6b9144-f05e-46ea-9ecc-4489964e4b56") },
                    { new Guid("28f2bc40-aaad-41b1-a648-1af23e0be20f"), 100m, "owner6", "accepted", "Rent", new Guid("94fe7ad2-9198-4939-8d1c-7dc2426cff84") },
                    { new Guid("2c324911-ed5c-4678-abcb-0e69b208c0f1"), 8000m, "owner3", "rejected", "Sale", new Guid("effdeb80-e986-4251-8ce8-19e516543e33") },
                    { new Guid("95eb8735-8c94-4f51-a6e1-12df1fa0376c"), 120m, "owner2", "accepted", "Rent", new Guid("1eb05e7b-43e6-4151-ab61-50adec037bc1") },
                    { new Guid("972cf7eb-d513-4a77-babf-9fb61f2c2408"), 25000m, "owner5", "accepted", "Sale", new Guid("ad7eb865-8682-4f1d-8117-4bfbf6405954") },
                    { new Guid("e6013024-1f3f-4c77-8b0b-5593c83522b9"), 80m, "owner4", "accepted", "Rent", new Guid("8e6b9144-f05e-46ea-9ecc-4489964e4b56") },
                    { new Guid("f39f51d5-b298-4175-8418-f71167442c98"), 15000m, "owner1", "accepted", "Sale", new Guid("a666a023-1db6-4a4a-b34e-8468f3183893") }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "RentalPrice", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("1eb05e7b-43e6-4151-ab61-50adec037bc1"), "BMW", "Luxury SUV, fully loaded.", "https://images.unsplash.com/photo-1503736334956-4c8f8e92946d?auto=format&fit=crop&w=400&q=80", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 },
                    { new Guid("8e6b9144-f05e-46ea-9ecc-4489964e4b56"), "Peugeot", "Brand new, perfect for city driving.", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=400&q=80", "Nice", 500, "208", "owner4", 12000m, null, null, "VIN5566778899", 2023 },
                    { new Guid("94fe7ad2-9198-4939-8d1c-7dc2426cff84"), "Volkswagen", "Popular hatchback, great for families.", "https://images.unsplash.com/photo-1519643381400-7f7c7d3e0c44?auto=format&fit=crop&w=400&q=80", "Toulouse", 15000, "Golf", "owner6", 14000m, null, null, "VIN4455667788", 2021 },
                    { new Guid("a666a023-1db6-4a4a-b34e-8468f3183893"), "Toyota", "Reliable sedan, low mileage.", "https://images.unsplash.com/photo-1511918984145-48bbd2aa2d4c?auto=format&fit=crop&w=400&q=80", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 },
                    { new Guid("ad7eb865-8682-4f1d-8117-4bfbf6405954"), "Mercedes", "Elegant and comfortable, well maintained.", "https://images.unsplash.com/photo-1502877336888-7bfc88a5e4a0?auto=format&fit=crop&w=400&q=80", "Bordeaux", 30000, "C-Class", "owner5", 25000m, null, null, "VIN9988776655", 2019 },
                    { new Guid("effdeb80-e986-4251-8ce8-19e516543e33"), "Renault", "Compact city car, economical.", "https://images.unsplash.com/photo-1461632830798-3adb3034e4c8?auto=format&fit=crop&w=400&q=80", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 }
                });

            migrationBuilder.InsertData(
                table: "VehiculeSales",
                columns: new[] { "Id", "Amount", "BuyerId", "OfferId", "Status" },
                values: new object[,]
                {
                    { new Guid("813de2a0-23a2-43bd-a684-62be2081a804"), 15000m, "owner2", new Guid("a666a023-1db6-4a4a-b34e-8468f3183893"), "completed" },
                    { new Guid("be90d6c2-7c5b-4d8b-952f-df4963d20a38"), 9000m, "owner4", new Guid("effdeb80-e986-4251-8ce8-19e516543e33"), "completed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "insp1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "insp2");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("363431ee-c0bf-42ec-9086-7aae63eff5be"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("d413bd77-b841-42e7-988c-99e8001a4d46"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("1a05e7da-f8e5-4b47-8ff0-0a8a5b63c1ce"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("268552bf-a97c-4f59-a54c-5d2f98f57780"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("28f2bc40-aaad-41b1-a648-1af23e0be20f"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("2c324911-ed5c-4678-abcb-0e69b208c0f1"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("95eb8735-8c94-4f51-a6e1-12df1fa0376c"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("972cf7eb-d513-4a77-babf-9fb61f2c2408"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("e6013024-1f3f-4c77-8b0b-5593c83522b9"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("f39f51d5-b298-4175-8418-f71167442c98"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("1eb05e7b-43e6-4151-ab61-50adec037bc1"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("8e6b9144-f05e-46ea-9ecc-4489964e4b56"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("94fe7ad2-9198-4939-8d1c-7dc2426cff84"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("a666a023-1db6-4a4a-b34e-8468f3183893"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("ad7eb865-8682-4f1d-8117-4bfbf6405954"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("effdeb80-e986-4251-8ce8-19e516543e33"));

            migrationBuilder.DeleteData(
                table: "VehiculeSales",
                keyColumn: "Id",
                keyValue: new Guid("813de2a0-23a2-43bd-a684-62be2081a804"));

            migrationBuilder.DeleteData(
                table: "VehiculeSales",
                keyColumn: "Id",
                keyValue: new Guid("be90d6c2-7c5b-4d8b-952f-df4963d20a38"));

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
    }
}
