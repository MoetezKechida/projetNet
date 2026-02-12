using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projetNet.Migrations
{
    /// <inheritdoc />
    public partial class fixedcarimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: "insp1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7d6f39c6-c646-44de-ad38-78809030bd5f", "cbd82bff-07ac-4d58-8a02-b3869a23f50f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "insp2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "288c9442-f76a-4823-b84f-ee35c1f958e1", "7241c118-13dd-4e36-831f-a1eeab04ebf4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "30a4d52f-e9f8-4bd0-96b3-4f244db8dac1", "cd3db5bd-6157-422f-9c9e-77fd88143cb3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8ea1ce22-fb89-4fd3-97e6-a50a330a5970", "6b23347d-7e64-47c2-ab8a-3d0b27524032" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ce0cbfa9-8486-4b50-9713-6f6acc8d7e31", "8f23b546-7a22-4d6c-ad17-c3213e26a033" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5cdfdeb2-094d-446c-a004-dc1c2f87168b", "558a3967-66ba-4874-a238-76c4c25e9d98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a8cb89fb-5752-4e74-9f1b-025c7856f8f6", "81563a44-8133-4611-8fac-ec1d4b6743d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "38b9c3d4-3863-44c7-b457-7bca8050fbbe", "c31a777b-1d4f-4543-86a1-849d6e807dfd" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingType", "BuyerId", "EndDate", "StartDate", "Status", "TotalAmount", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("b22ff717-19e9-4424-b0c3-cb18228416fa"), "Rent", "owner3", new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "completed", 400m, new Guid("8280451e-8158-47d9-ad85-adb3811e74b3") },
                    { new Guid("b50bcc74-ed17-486b-b5e4-a9bb995139b2"), "Rent", "owner1", new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "completed", 1200m, new Guid("7d19af23-9db8-4177-a3b2-e67317bbe47c") }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Price", "SellerId", "Status", "Type", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("2200bc7c-e9b4-40e3-b158-ad8ab94f8dc4"), 8000m, "owner3", "rejected", "Sale", new Guid("4e35aad7-34ac-402a-ae05-0754643ad474") },
                    { new Guid("3f40dece-648d-44c0-b2a5-8559a1a53af5"), 15000m, "owner1", "accepted", "Sale", new Guid("0cd98d8d-6c5f-48a9-a783-be5aa166febb") },
                    { new Guid("4c87d046-8b47-418f-a4e9-3c75a22d8581"), 120m, "owner2", "accepted", "Rent", new Guid("7d19af23-9db8-4177-a3b2-e67317bbe47c") },
                    { new Guid("a3824726-8df6-4e5f-8a74-bc5bc5c4a3a6"), 100m, "owner6", "accepted", "Rent", new Guid("d702e660-94d2-4b3b-b455-11e96b478703") },
                    { new Guid("aef99f6b-5d01-4150-8e28-ca2f354175c6"), 60m, "owner4", "pending", "Rent", new Guid("8280451e-8158-47d9-ad85-adb3811e74b3") },
                    { new Guid("d5f49032-3f31-4239-8cb4-2547cb69b83e"), 9000m, "owner3", "accepted", "Sale", new Guid("4e35aad7-34ac-402a-ae05-0754643ad474") },
                    { new Guid("d92fd3b2-b73d-4de1-9c8b-b503d750c48a"), 25000m, "owner5", "accepted", "Sale", new Guid("b84b2e75-b933-4c52-97df-5635fdb480f1") },
                    { new Guid("f60de35b-2151-44aa-a4ab-5334c881a714"), 80m, "owner4", "accepted", "Rent", new Guid("8280451e-8158-47d9-ad85-adb3811e74b3") }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "RentalPrice", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("0cd98d8d-6c5f-48a9-a783-be5aa166febb"), "Toyota", "Reliable sedan, low mileage.", "https://upload.wikimedia.org/wikipedia/commons/9/9d/2019_Toyota_Corolla_Icon_Tech_VVT-i_HEV_CVT_1.8_Front.jpg", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 },
                    { new Guid("4e35aad7-34ac-402a-ae05-0754643ad474"), "Renault", "Compact city car, economical.", "https://upload.wikimedia.org/wikipedia/commons/2/2e/2019_Renault_Clio_RS_Line_TCe_100_1.0_Front.jpg", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 },
                    { new Guid("7d19af23-9db8-4177-a3b2-e67317bbe47c"), "BMW", "Luxury SUV, fully loaded.", "https://upload.wikimedia.org/wikipedia/commons/2/2b/2019_BMW_X5_xDrive30d_M_Sport_Automatic_3.0_Front.jpg", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 },
                    { new Guid("8280451e-8158-47d9-ad85-adb3811e74b3"), "Peugeot", "Brand new, perfect for city driving.", "https://upload.wikimedia.org/wikipedia/commons/2/2d/Peugeot_208_2019_IMG_3192.jpg", "Nice", 500, "208", "owner4", 12000m, null, null, "VIN5566778899", 2023 },
                    { new Guid("b84b2e75-b933-4c52-97df-5635fdb480f1"), "Mercedes", "Elegant and comfortable, well maintained.", "https://upload.wikimedia.org/wikipedia/commons/2/2a/2018_Mercedes-Benz_C_200_Avantgarde_Automatic_2.0_Front.jpg", "Bordeaux", 30000, "C-Class", "owner5", 25000m, null, null, "VIN9988776655", 2019 },
                    { new Guid("d702e660-94d2-4b3b-b455-11e96b478703"), "Volkswagen", "Popular hatchback, great for families.", "https://upload.wikimedia.org/wikipedia/commons/7/7e/2019_Volkswagen_Golf_Mk7_facelift_1.5_Front.jpg", "Toulouse", 15000, "Golf", "owner6", 14000m, null, null, "VIN4455667788", 2021 }
                });

            migrationBuilder.InsertData(
                table: "VehiculeSales",
                columns: new[] { "Id", "Amount", "BuyerId", "OfferId", "Status" },
                values: new object[,]
                {
                    { new Guid("8565d618-bd01-44ca-af17-38720ffa30e1"), 15000m, "owner2", new Guid("0cd98d8d-6c5f-48a9-a783-be5aa166febb"), "completed" },
                    { new Guid("85a6e2e3-9d11-420d-8682-66027015e353"), 9000m, "owner4", new Guid("4e35aad7-34ac-402a-ae05-0754643ad474"), "completed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("b22ff717-19e9-4424-b0c3-cb18228416fa"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("b50bcc74-ed17-486b-b5e4-a9bb995139b2"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("2200bc7c-e9b4-40e3-b158-ad8ab94f8dc4"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("3f40dece-648d-44c0-b2a5-8559a1a53af5"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("4c87d046-8b47-418f-a4e9-3c75a22d8581"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("a3824726-8df6-4e5f-8a74-bc5bc5c4a3a6"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("aef99f6b-5d01-4150-8e28-ca2f354175c6"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("d5f49032-3f31-4239-8cb4-2547cb69b83e"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("d92fd3b2-b73d-4de1-9c8b-b503d750c48a"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("f60de35b-2151-44aa-a4ab-5334c881a714"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("0cd98d8d-6c5f-48a9-a783-be5aa166febb"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("4e35aad7-34ac-402a-ae05-0754643ad474"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("7d19af23-9db8-4177-a3b2-e67317bbe47c"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("8280451e-8158-47d9-ad85-adb3811e74b3"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("b84b2e75-b933-4c52-97df-5635fdb480f1"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("d702e660-94d2-4b3b-b455-11e96b478703"));

            migrationBuilder.DeleteData(
                table: "VehiculeSales",
                keyColumn: "Id",
                keyValue: new Guid("8565d618-bd01-44ca-af17-38720ffa30e1"));

            migrationBuilder.DeleteData(
                table: "VehiculeSales",
                keyColumn: "Id",
                keyValue: new Guid("85a6e2e3-9d11-420d-8682-66027015e353"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "insp1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e8e9f3b0-937b-49c1-b95d-5cf0f40ce208", "b75ac1fc-7ba7-4655-92fe-8d09ae3ae808" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "insp2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c5ee9d32-9a1d-4392-a0a6-dbae6e48651a", "c6f282e2-c914-440a-8a6d-02afd4702300" });

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
    }
}
