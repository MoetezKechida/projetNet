using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projetNet.Migrations
{
    /// <inheritdoc />
    public partial class fixingfront : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsVerifiedSeller = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsPhoneVerified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SellerRating = table.Column<double>(type: "double", nullable: false),
                    SellerReviewCount = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    VehicleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BuyerId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookingType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    VehicleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InspectorId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Reason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VehicleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SellerId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Vin = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    RentalPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mileage = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                })
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

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsEmailVerified", "IsPhoneVerified", "IsVerifiedSeller", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "SellerRating", "SellerReviewCount", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "insp1", 0, "039e9159-2046-45e2-8c7d-2fd980a7c726", null, "inspector1@projetnet.com", true, "Alice", false, false, null, "Inspector", false, null, null, null, null, null, true, null, null, "b5e35070-63fd-4231-9792-05a5cd136b8f", 0.0, 0, false, "inspector1" },
                    { "insp2", 0, "aaab4f99-29f3-4ba6-8582-2ad05f851cb4", null, "inspector2@projetnet.com", true, "Bob", false, false, null, "Checker", false, null, null, null, null, null, true, null, null, "95488971-af4b-403c-82e9-1bcadc542faf", 0.0, 0, false, "inspector2" },
                    { "owner1", 0, "b5f2bbf2-2999-4311-93e1-8f771c10dd90", null, null, false, "Jean", false, false, true, "Dupont", false, null, null, null, null, null, false, null, null, "4de17271-51e4-422d-a78b-398a92f518fb", 0.0, 0, false, "seller1" },
                    { "owner2", 0, "f8c3a9bc-01f3-4aee-8f60-2e500dbb4462", null, null, false, "Marie", false, false, false, "Curie", false, null, null, null, null, null, false, null, null, "e9a7cfeb-23fa-4694-b8b3-38c62b6f6a97", 0.0, 0, false, "seller2" },
                    { "owner3", 0, "a9864e09-4928-48ac-83b4-dbaa7de0f86c", null, null, false, "Ali", false, false, true, "Ben Salah", false, null, null, null, null, null, false, null, null, "9fcbafce-b9bf-49d8-9856-f8b4dc13766f", 0.0, 0, false, "seller3" },
                    { "owner4", 0, "36b8fbcf-1a61-4a3f-b602-bf0a7b3be109", null, null, false, "Sophie", false, false, true, "Martin", false, null, null, null, null, null, false, null, null, "4be5d769-eed4-45e9-9f3b-850ca9358f40", 0.0, 0, false, "seller4" },
                    { "owner5", 0, "01cc4230-2d5b-467f-8bdf-521dba1b878a", null, null, false, "David", false, false, false, "Smith", false, null, null, null, null, null, false, null, null, "4dee556b-b39e-49d3-8fc5-0c39f0cc7a16", 0.0, 0, false, "seller5" },
                    { "owner6", 0, "78dc4324-b0a0-4843-8d8a-0080805d053e", null, null, false, "Fatima", false, false, true, "El Amrani", false, null, null, null, null, null, false, null, null, "6e265975-700b-4d99-a69b-de34b95328e2", 0.0, 0, false, "seller6" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingType", "BuyerId", "EndDate", "StartDate", "Status", "TotalAmount", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("857aee55-96f2-448c-a11e-80dc6d884ecc"), "Rent", "owner1", new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "completed", 1200m, new Guid("0f29ec4b-d7da-4c10-bcd3-e60b595b5d73") },
                    { new Guid("9c2ceb4f-c370-4474-a34c-a4a609d2801c"), "Rent", "owner3", new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "completed", 400m, new Guid("b5b13b24-eb33-4326-9af0-758b430e3c90") }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Price", "SellerId", "Status", "Type", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("02e1547f-d0c4-4827-a4e4-45d76dd4ff96"), 8000m, "owner3", "rejected", "Sale", new Guid("060020f8-9afe-49ff-9b20-a9db564497ab") },
                    { new Guid("0c557ce1-6b9b-4b6e-95e7-ba31019f52ad"), 120m, "owner2", "accepted", "Rent", new Guid("0f29ec4b-d7da-4c10-bcd3-e60b595b5d73") },
                    { new Guid("0d45e41e-f0bd-4f62-99b0-87f1d9691bf8"), 80m, "owner4", "accepted", "Rent", new Guid("b5b13b24-eb33-4326-9af0-758b430e3c90") },
                    { new Guid("2fd7ae14-63fa-4ec7-9626-8c4b545eea65"), 100m, "owner6", "accepted", "Rent", new Guid("ca4aa63e-b63c-473b-bcd1-59b2e7fed473") },
                    { new Guid("356964dd-edaa-46c7-84a1-4c1b6eb56394"), 25000m, "owner5", "accepted", "Sale", new Guid("08b72382-73d1-44ea-8538-408bfc37e19b") },
                    { new Guid("4c45d229-b775-4f13-b140-ba5ab23010ab"), 60m, "owner4", "pending", "Rent", new Guid("b5b13b24-eb33-4326-9af0-758b430e3c90") },
                    { new Guid("8502e524-23b5-46c8-8414-aff9ed8af851"), 15000m, "owner1", "accepted", "Sale", new Guid("ae108f8e-a7b2-422a-9b04-ce2b86087ef3") },
                    { new Guid("ab0f3b4f-adb2-4de7-b2f7-4910335cbc34"), 9000m, "owner3", "accepted", "Sale", new Guid("060020f8-9afe-49ff-9b20-a9db564497ab") }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Location", "Mileage", "Model", "OwnerId", "Price", "RentalPrice", "Status", "Vin", "Year" },
                values: new object[,]
                {
                    { new Guid("060020f8-9afe-49ff-9b20-a9db564497ab"), "Renault", "Compact city car, economical.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSlhWvzjZ8aRsjy-hZ-XsAyKEPtlmjTGArog&s", "Marseille", 20000, "Clio", "owner3", 9000m, null, null, "VIN1122334455", 2020 },
                    { new Guid("08b72382-73d1-44ea-8538-408bfc37e19b"), "Mercedes", "Elegant and comfortable, well maintained.", "https://parkers-images.bauersecure.com/wp-images/22257/cut-out/930x620/mercedes-c-class.jpg", "Bordeaux", 30000, "C-Class", "owner5", 25000m, null, null, "VIN9988776655", 2019 },
                    { new Guid("0f29ec4b-d7da-4c10-bcd3-e60b595b5d73"), "BMW", "Luxury SUV, fully loaded.", "https://imgd.aeplcdn.com/664x374/n/cw/ec/152681/x5-exterior-right-front-three-quarter-6.jpeg?isig=0&q=80", "Lyon", 8000, "X5", "owner2", 35000m, null, null, "VIN0987654321", 2021 },
                    { new Guid("ae108f8e-a7b2-422a-9b04-ce2b86087ef3"), "Toyota", "Reliable sedan, low mileage.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRB79QACDPdJ92zwTCMS6L54zqDvL0kSLuzGw&s", "Paris", 12000, "Corolla", "owner1", 15000m, null, null, "VIN1234567890", 2022 },
                    { new Guid("b5b13b24-eb33-4326-9af0-758b430e3c90"), "Peugeot", "Brand new, perfect for city driving.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQgxnw6GwppRxRnaBDZVANJS2hD3j1zdJAegw&s", "Nice", 500, "208", "owner4", 12000m, null, null, "VIN5566778899", 2023 },
                    { new Guid("ca4aa63e-b63c-473b-bcd1-59b2e7fed473"), "Volkswagen", "Popular hatchback, great for families.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfb3gI40_FUSJ4Zz5O-eRuj1uxuqdEMTt9ew&s", "Toulouse", 15000, "Golf", "owner6", 14000m, null, null, "VIN4455667788", 2021 }
                });

            migrationBuilder.InsertData(
                table: "VehiculeSales",
                columns: new[] { "Id", "Amount", "BuyerId", "OfferId", "Status" },
                values: new object[,]
                {
                    { new Guid("97231f53-f03f-4f85-878c-24cb030b4a8c"), 15000m, "owner2", new Guid("ae108f8e-a7b2-422a-9b04-ce2b86087ef3"), "completed" },
                    { new Guid("a5977d91-f5c3-4c21-a794-15d3948226c2"), 9000m, "owner4", new Guid("060020f8-9afe-49ff-9b20-a9db564497ab"), "completed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehiculeSales");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
