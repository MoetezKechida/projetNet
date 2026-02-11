using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projetNet.Migrations
{
    /// <inheritdoc />
    public partial class minorfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("3466c6ee-f48d-471d-8007-d23b174e67a7"), "Toyota", "Reliable sedan, low mileage.", "https://images.unsplash.com/photo-1511918984145-48bbd2aa2d4c?auto=format&fit=crop&w=400&q=80", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 },
                    { new Guid("3dd84240-229a-4749-9f12-c5249c0f3120"), "Volkswagen", "Popular hatchback, great for families.", "https://images.unsplash.com/photo-1519643381400-7f7c7d3e0c44?auto=format&fit=crop&w=400&q=80", "Toulouse", 15000, "Golf", "owner6", 14000m, null, null, "VIN4455667788", 2021 },
                    { new Guid("9f6ca1e5-b761-4356-bb34-41fdeeb5d0a7"), "Mercedes", "Elegant and comfortable, well maintained.", "https://images.unsplash.com/photo-1502877336888-7bfc88a5e4a0?auto=format&fit=crop&w=400&q=80", "Bordeaux", 30000, "C-Class", "owner5", 25000m, null, null, "VIN9988776655", 2019 },
                    { new Guid("e3c3de72-78bf-4b96-99a3-b2b6ca3eff9f"), "Renault", "Compact city car, economical.", "https://images.unsplash.com/photo-1461632830798-3adb3034e4c8?auto=format&fit=crop&w=400&q=80", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 },
                    { new Guid("f05c709f-47c2-477e-a7ad-a3aa129c5e8f"), "BMW", "Luxury SUV, fully loaded.", "https://images.unsplash.com/photo-1503736334956-4c8f8e92946d?auto=format&fit=crop&w=400&q=80", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 },
                    { new Guid("fd587b0b-1524-4b18-9f52-a5a1f001a540"), "Peugeot", "Brand new, perfect for city driving.", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=400&q=80", "Nice", 500, "208", "owner4", 12000m, null, null, "VIN5566778899", 2023 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("3466c6ee-f48d-471d-8007-d23b174e67a7"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("3dd84240-229a-4749-9f12-c5249c0f3120"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("9f6ca1e5-b761-4356-bb34-41fdeeb5d0a7"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("e3c3de72-78bf-4b96-99a3-b2b6ca3eff9f"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("f05c709f-47c2-477e-a7ad-a3aa129c5e8f"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("fd587b0b-1524-4b18-9f52-a5a1f001a540"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "58fea65b-c000-43c3-9153-3e50e8807fc1", "24afc70a-aa24-427b-bd72-b4bf858e9eec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8a35e6bf-01a3-4529-a4b8-ffa094d81b62", "79d51093-e5dc-477f-91d1-17be29427410" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c66dfb1e-a1e2-4773-901d-716fa0a400ec", "2adf0f92-50c1-4cf5-bbdf-17b199313dec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b10fd30b-2d92-47cd-93c9-0692a7415c4e", "c65df75a-dea5-4455-9082-b58fcc577a58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "24b4b289-1ff4-42ff-be61-c08fec25ce6f", "7fc201a4-33eb-4f49-8603-7a6848fad102" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e18697d0-5d70-4149-b0b2-5f451550ad8a", "51eb85f6-cfa1-4cc8-a74a-ed3b907deab4" });

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
    }
}
