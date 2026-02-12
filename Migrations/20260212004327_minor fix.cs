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
                values: new object[] { "31db2769-951e-4e95-b4b4-aaa9a04a3499", "2a876004-801e-4674-ab1f-9f54c2ab3070" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "insp2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "18c90bb0-a3eb-4217-ae32-a8f9980f305f", "5dfbee2e-7643-40f4-b008-3111751c7a94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "38a4c444-c8da-438d-9db2-05b31feed61a", "6797def5-03ff-4cd0-8148-bb16b67eff13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9fcd7d03-886b-4eaa-95cf-d0619e9a4229", "54a0768f-3fb1-4eb7-a9df-6dbee6c595d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f30366f7-4091-40bf-900f-63d3f7b277c8", "3fd52767-d00c-4a94-808e-891674f39f3f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bba8c484-897a-4de8-b94a-9968ab5956e9", "8c127684-5b52-441f-b05b-90a2ec14d99a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "32022638-ce16-46f7-a2c1-180afde12d50", "91d2b176-a6b7-44c5-b792-9b12e710749c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "38d15dca-d6cd-4200-87b0-61556dd2ded3", "4e2cdc66-ee24-47a5-9650-5c3e9adcb32c" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingType", "BuyerId", "EndDate", "StartDate", "Status", "TotalAmount", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("3452d6f7-4b5a-41c0-b628-89f5b496cc4b"), "Rent", "owner3", new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "completed", 400m, new Guid("4170d68a-6436-4746-9ed0-8f21483791a5") },
                    { new Guid("df79ff31-390f-4356-89af-0dffb79f020b"), "Rent", "owner1", new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "completed", 1200m, new Guid("f83c19b3-3da2-430a-8368-f8cf9764bf42") }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Price", "SellerId", "Status", "Type", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("035a4b7e-4cff-4f02-98ec-bf8a944d17b6"), 100m, "owner6", "accepted", "Rent", new Guid("f2dbb8ea-a5a2-4051-a488-fd492f32f1e1") },
                    { new Guid("13edb84b-e6c3-4c52-9e04-259ca76df09c"), 120m, "owner2", "accepted", "Rent", new Guid("f83c19b3-3da2-430a-8368-f8cf9764bf42") },
                    { new Guid("2b388981-59bc-4f3f-b15a-0e941eafd1b4"), 15000m, "owner1", "accepted", "Sale", new Guid("7e15fbcd-e082-4ed4-8e1c-e0dd5188966e") },
                    { new Guid("7594725a-43a4-4f4c-add3-8db8880f41f0"), 25000m, "owner5", "accepted", "Sale", new Guid("5508bdf0-c808-4226-b072-ed52a000dba9") },
                    { new Guid("a7a52cc2-d9bc-4e2b-9ff5-ce606775c5d1"), 80m, "owner4", "accepted", "Rent", new Guid("4170d68a-6436-4746-9ed0-8f21483791a5") },
                    { new Guid("b8faf0cb-db66-4c58-9341-b7fdf9f91faa"), 8000m, "owner3", "rejected", "Sale", new Guid("d10e5432-6d5a-4efd-8503-9840e0bdea89") },
                    { new Guid("bb6b4d81-8825-45fe-84cd-ec7f99887c85"), 60m, "owner4", "pending", "Rent", new Guid("4170d68a-6436-4746-9ed0-8f21483791a5") },
                    { new Guid("e08dbc4a-e247-4713-bbaf-b8c41d49d022"), 9000m, "owner3", "accepted", "Sale", new Guid("d10e5432-6d5a-4efd-8503-9840e0bdea89") }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "RentalPrice", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("4170d68a-6436-4746-9ed0-8f21483791a5"), "Peugeot", "Brand new, perfect for city driving.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQgxnw6GwppRxRnaBDZVANJS2hD3j1zdJAegw&s", "Nice", 500, "208", "owner4", 12000m, null, null, "VIN5566778899", 2023 },
                    { new Guid("5508bdf0-c808-4226-b072-ed52a000dba9"), "Mercedes", "Elegant and comfortable, well maintained.", "https://parkers-images.bauersecure.com/wp-images/22257/cut-out/930x620/mercedes-c-class.jpg", "Bordeaux", 30000, "C-Class", "owner5", 25000m, null, null, "VIN9988776655", 2019 },
                    { new Guid("7e15fbcd-e082-4ed4-8e1c-e0dd5188966e"), "Toyota", "Reliable sedan, low mileage.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRB79QACDPdJ92zwTCMS6L54zqDvL0kSLuzGw&s", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 },
                    { new Guid("d10e5432-6d5a-4efd-8503-9840e0bdea89"), "Renault", "Compact city car, economical.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSlhWvzjZ8aRsjy-hZ-XsAyKEPtlmjTGArog&s", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 },
                    { new Guid("f2dbb8ea-a5a2-4051-a488-fd492f32f1e1"), "Volkswagen", "Popular hatchback, great for families.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfb3gI40_FUSJ4Zz5O-eRuj1uxuqdEMTt9ew&s", "Toulouse", 15000, "Golf", "owner6", 14000m, null, null, "VIN4455667788", 2021 },
                    { new Guid("f83c19b3-3da2-430a-8368-f8cf9764bf42"), "BMW", "Luxury SUV, fully loaded.", "https://imgd.aeplcdn.com/664x374/n/cw/ec/152681/x5-exterior-right-front-three-quarter-6.jpeg?isig=0&q=80", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 }
                });

            migrationBuilder.InsertData(
                table: "VehiculeSales",
                columns: new[] { "Id", "Amount", "BuyerId", "OfferId", "Status" },
                values: new object[,]
                {
                    { new Guid("6566b183-842c-4de1-aebd-95b675c07ea2"), 9000m, "owner4", new Guid("d10e5432-6d5a-4efd-8503-9840e0bdea89"), "completed" },
                    { new Guid("db46cb6f-c59d-420b-829b-500c9958eb48"), 15000m, "owner2", new Guid("7e15fbcd-e082-4ed4-8e1c-e0dd5188966e"), "completed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("3452d6f7-4b5a-41c0-b628-89f5b496cc4b"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("df79ff31-390f-4356-89af-0dffb79f020b"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("035a4b7e-4cff-4f02-98ec-bf8a944d17b6"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("13edb84b-e6c3-4c52-9e04-259ca76df09c"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("2b388981-59bc-4f3f-b15a-0e941eafd1b4"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("7594725a-43a4-4f4c-add3-8db8880f41f0"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("a7a52cc2-d9bc-4e2b-9ff5-ce606775c5d1"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("b8faf0cb-db66-4c58-9341-b7fdf9f91faa"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("bb6b4d81-8825-45fe-84cd-ec7f99887c85"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("e08dbc4a-e247-4713-bbaf-b8c41d49d022"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("4170d68a-6436-4746-9ed0-8f21483791a5"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("5508bdf0-c808-4226-b072-ed52a000dba9"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("7e15fbcd-e082-4ed4-8e1c-e0dd5188966e"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("d10e5432-6d5a-4efd-8503-9840e0bdea89"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("f2dbb8ea-a5a2-4051-a488-fd492f32f1e1"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("f83c19b3-3da2-430a-8368-f8cf9764bf42"));

            migrationBuilder.DeleteData(
                table: "VehiculeSales",
                keyColumn: "Id",
                keyValue: new Guid("6566b183-842c-4de1-aebd-95b675c07ea2"));

            migrationBuilder.DeleteData(
                table: "VehiculeSales",
                keyColumn: "Id",
                keyValue: new Guid("db46cb6f-c59d-420b-829b-500c9958eb48"));

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
    }
}
