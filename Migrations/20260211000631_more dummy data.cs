using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projetNet.Migrations
{
    /// <inheritdoc />
    public partial class moredummydata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.Sql(@"
                INSERT INTO ""AspNetUsers"" (""Id"", ""AccessFailedCount"", ""ConcurrencyStamp"", ""CreatedAt"", ""Email"", ""EmailConfirmed"", ""FirstName"", ""IsEmailVerified"", ""IsPhoneVerified"", ""IsVerifiedSeller"", ""LastName"", ""LockoutEnabled"", ""LockoutEnd"", ""NormalizedEmail"", ""NormalizedUserName"", ""PasswordHash"", ""PhoneNumber"", ""PhoneNumberConfirmed"", ""SellerRating"", ""SellerReviewCount"", ""SecurityStamp"", ""TwoFactorEnabled"", ""UserName"")
                VALUES
                ('owner1', 0, '58fea65b-c000-43c3-9153-3e50e8807fc1', NULL, NULL, 0, 'Jean', 0, 0, 1, 'Dupont', 0, NULL, NULL, NULL, NULL, NULL, 0, 0.0, 0, '24afc70a-aa24-427b-bd72-b4bf858e9eec', 0, 'seller1'),
                ('owner2', 0, '8a35e6bf-01a3-4529-a4b8-ffa094d81b62', NULL, NULL, 0, 'Marie', 0, 0, 0, 'Curie', 0, NULL, NULL, NULL, NULL, NULL, 0, 0.0, 0, '79d51093-e5dc-477f-91d1-17be29427410', 0, 'seller2'),
                ('owner3', 0, 'c66dfb1e-a1e2-4773-901d-716fa0a400ec', NULL, NULL, 0, 'Ali', 0, 0, 1, 'Ben Salah', 0, NULL, NULL, NULL, NULL, NULL, 0, 0.0, 0, '2adf0f92-50c1-4cf5-bbdf-17b199313dec', 0, 'seller3'),
                ('owner4', 0, 'b10fd30b-2d92-47cd-93c9-0692a7415c4e', NULL, NULL, 0, 'Sophie', 0, 0, 1, 'Martin', 0, NULL, NULL, NULL, NULL, NULL, 0, 0.0, 0, 'c65df75a-dea5-4455-9082-b58fcc577a58', 0, 'seller4'),
                ('owner5', 0, '24b4b289-1ff4-42ff-be61-c08fec25ce6f', NULL, NULL, 0, 'David', 0, 0, 0, 'Smith', 0, NULL, NULL, NULL, NULL, NULL, 0, 0.0, 0, '7fc201a4-33eb-4f49-8603-7a6848fad102', 0, 'seller5'),
                ('owner6', 0, 'e18697d0-5d70-4149-b0b2-5f451550ad8a', NULL, NULL, 0, 'Fatima', 0, 0, 1, 'El Amrani', 0, NULL, NULL, NULL, NULL, NULL, 0, 0.0, 0, '51eb85f6-cfa1-4cc8-a74a-ed3b907deab4', 0, 'seller6');
            ");

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Price", "SellerId", "Status", "Type", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("0add8409-ac64-4006-bce9-99ca608e21bc"), 15000m, "owner1", "accepted", "Sale", new Guid("f578e7bf-f5dd-42d9-864c-3910740f748c") },
                    { new Guid("158be38a-3aa6-4353-9a20-3e0f0c1e1da7"), 8000m, "owner3", "rejected", "Sale", new Guid("5af98744-9ea8-4345-9439-5f6928760a11") },
                    { new Guid("4e875721-54b0-47f0-a380-9427734e3a18"), 100m, "owner6", "accepted", "Rent", new Guid("242ce266-814d-455d-85cf-d28e8e271901") },
                    { new Guid("628c08fc-b61a-4c11-802e-4f0024bd86fe"), 80m, "owner4", "accepted", "Rent", new Guid("0ecb6c7d-68f8-4d60-9f2c-a3224a49f982") },
                    { new Guid("787b8343-ad4a-4818-9b24-2f17e86d3dad"), 25000m, "owner5", "accepted", "Sale", new Guid("1b6d50b6-915e-4e3f-8b89-4cc975f95fea") },
                    { new Guid("89ee2513-2a86-49a4-81cc-fd1c017f0b16"), 120m, "owner2", "accepted", "Rent", new Guid("42a2775a-1183-40eb-be3c-bcf9e1a3d92f") },
                    { new Guid("90c8f45a-88ff-47d2-830a-f04326366fa0"), 9000m, "owner3", "accepted", "Sale", new Guid("5af98744-9ea8-4345-9439-5f6928760a11") },
                    { new Guid("f4e8c8c3-652e-4942-a293-42e148da29f5"), 60m, "owner4", "pending", "Rent", new Guid("0ecb6c7d-68f8-4d60-9f2c-a3224a49f982") }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "RentalPrice", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("0ecb6c7d-68f8-4d60-9f2c-a3224a49f982"), "Peugeot", "Brand new, perfect for city driving.", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=400&q=80", "Nice", 500, "208", "owner4", 12000m, null, null, "VIN5566778899", 2023 },
                    { new Guid("1b6d50b6-915e-4e3f-8b89-4cc975f95fea"), "Mercedes", "Elegant and comfortable, well maintained.", "https://images.unsplash.com/photo-1502877336888-7bfc88a5e4a0?auto=format&fit=crop&w=400&q=80", "Bordeaux", 30000, "C-Class", "owner5", 25000m, null, null, "VIN9988776655", 2019 },
                    { new Guid("242ce266-814d-455d-85cf-d28e8e271901"), "Volkswagen", "Popular hatchback, great for families.", "https://images.unsplash.com/photo-1519643381400-7f7c7d3e0c44?auto=format&fit=crop&w=400&q=80", "Toulouse", 15000, "Golf", "owner6", 14000m, null, null, "VIN4455667788", 2021 },
                    { new Guid("42a2775a-1183-40eb-be3c-bcf9e1a3d92f"), "BMW", "Luxury SUV, fully loaded.", "https://images.unsplash.com/photo-1503736334956-4c8f8e92946d?auto=format&fit=crop&w=400&q=80", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 },
                    { new Guid("5af98744-9ea8-4345-9439-5f6928760a11"), "Renault", "Compact city car, economical.", "https://images.unsplash.com/photo-1461632830798-3adb3034e4c8?auto=format&fit=crop&w=400&q=80", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 },
                    { new Guid("f578e7bf-f5dd-42d9-864c-3910740f748c"), "Toyota", "Reliable sedan, low mileage.", "https://images.unsplash.com/photo-1511918984145-48bbd2aa2d4c?auto=format&fit=crop&w=400&q=80", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner6");

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("0add8409-ac64-4006-bce9-99ca608e21bc"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("158be38a-3aa6-4353-9a20-3e0f0c1e1da7"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("4e875721-54b0-47f0-a380-9427734e3a18"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("628c08fc-b61a-4c11-802e-4f0024bd86fe"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("787b8343-ad4a-4818-9b24-2f17e86d3dad"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("89ee2513-2a86-49a4-81cc-fd1c017f0b16"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("90c8f45a-88ff-47d2-830a-f04326366fa0"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("f4e8c8c3-652e-4942-a293-42e148da29f5"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("0ecb6c7d-68f8-4d60-9f2c-a3224a49f982"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("1b6d50b6-915e-4e3f-8b89-4cc975f95fea"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("242ce266-814d-455d-85cf-d28e8e271901"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("42a2775a-1183-40eb-be3c-bcf9e1a3d92f"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("5af98744-9ea8-4345-9439-5f6928760a11"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("f578e7bf-f5dd-42d9-864c-3910740f748c"));

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
    }
}
