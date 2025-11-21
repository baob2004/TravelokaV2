using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelokaV2.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccomTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BedTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CancelPolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelPolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccomTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GgMapsQuery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ll = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Star = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accommodations_AccomTypes_AccomTypeId",
                        column: x => x.AccomTypeId,
                        principalTable: "AccomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "ReviewsAndRatings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: true),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsAndRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewsAndRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Accom_Facilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accom_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accom_Facilities_Accommodations_AccomId",
                        column: x => x.AccomId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accom_Facilities_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accom_Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accom_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accom_Images_Accommodations_AccomId",
                        column: x => x.AccomId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accom_Images_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralInfos",
                columns: table => new
                {
                    AccommodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PopularFacility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckOut = table.Column<TimeOnly>(type: "time", nullable: true),
                    CheckIn = table.Column<TimeOnly>(type: "time", nullable: true),
                    DistanceToDowntown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PopularInArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreakfastAvailability = table.Column<bool>(type: "bit", nullable: true),
                    AvailableRooms = table.Column<int>(type: "int", nullable: true),
                    NumberOfFloors = table.Column<int>(type: "int", nullable: true),
                    AnotherFacility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NearbyPOI = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralInfos", x => x.AccommodationId);
                    table.ForeignKey(
                        name: "FK_GeneralInfos_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    AccommodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Intruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequireDocs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckIn = table.Column<TimeOnly>(type: "time", nullable: true),
                    CheckOut = table.Column<TimeOnly>(type: "time", nullable: true),
                    Breakfast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Smoking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addtional = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.AccommodationId);
                    table.ForeignKey(
                        name: "FK_Policies_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasicFacilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomFacilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BathAmenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccommodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomCategories_Accommodations_AccomId",
                        column: x => x.AccomId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomCategories_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Accom_RR",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RRId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accom_RR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accom_RR_Accommodations_AccomId",
                        column: x => x.AccomId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accom_RR_ReviewsAndRatings_RRId",
                        column: x => x.RRId,
                        principalTable: "ReviewsAndRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room_Facilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Facilities_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_Facilities_RoomCategories_RoomCategoryId",
                        column: x => x.RoomCategoryId,
                        principalTable: "RoomCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room_Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Images_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_Images_RoomCategories_RoomCategoryId",
                        column: x => x.RoomCategoryId,
                        principalTable: "RoomCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breakfast = table.Column<bool>(type: "bit", nullable: true),
                    NumberOfBeds = table.Column<int>(type: "int", nullable: true),
                    BedTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CancelPolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_BedTypes_BedTypeId",
                        column: x => x.BedTypeId,
                        principalTable: "BedTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Rooms_CancelPolicies_CancelPolicyId",
                        column: x => x.CancelPolicyId,
                        principalTable: "CancelPolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "RoomCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRecords_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PaymentRecords_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentRecords_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AccomTypes",
                columns: new[] { "Id", "CreatedAt", "ModifyAt", "Type", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Khách sạn", null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Khu nghỉ dưỡng", null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Căn hộ", null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Biệt thự", null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Hostel", null },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Nhà khách", null },
                    { new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Homestay", null },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Nhà nghỉ", null },
                    { new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Khách sạn con nhộng", null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Bungalow", null },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Farmstay", null },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Khu cắm trại", null },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Nhà nghỉ Lodge", null },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Ryokan", null },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Riad", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "BedTypes",
                columns: new[] { "Id", "CreatedAt", "ModifyAt", "Type", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("bead0000-0000-0000-0000-000000000001"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Giường đơn", null },
                    { new Guid("bead0000-0000-0000-0000-000000000002"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Giường đôi", null },
                    { new Guid("bead0000-0000-0000-0000-000000000003"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Giường King", null },
                    { new Guid("bead0000-0000-0000-0000-000000000004"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Giường Super King", null },
                    { new Guid("bead0000-0000-0000-0000-000000000005"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Giường tầng", null },
                    { new Guid("bead0000-0000-0000-0000-000000000006"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Giường sofa", null },
                    { new Guid("bead0000-0000-0000-0000-000000000007"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Đệm futon", null },
                    { new Guid("bead0000-0000-0000-0000-000000000008"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Đệm tatami", null },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddd04"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Giường Queen", null },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeee05"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Giường Twin", null }
                });

            migrationBuilder.InsertData(
                table: "CancelPolicies",
                columns: new[] { "Id", "CreatedAt", "ModifyAt", "Type", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("cafe0000-0000-0000-0000-000000000001"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Linh hoạt (48h)", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000002"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Linh hoạt (72h)", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000003"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Linh hoạt (7 ngày)", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000004"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Linh hoạt (14 ngày)", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000005"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Không hoàn huỷ", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000006"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Vắng mặt tính phí 1 đêm", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000007"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Miễn phí tới 18:00", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000008"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Bán linh hoạt", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000009"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Siêu linh hoạt", null },
                    { new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Linh hoạt (24h)", null }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "CreatedAt", "Icon", "ModifyAt", "Name", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "wifi", null, "Wi-Fi miễn phí", null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa04"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "spa", null, "Spa", null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa05"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "parking", null, "Bãi đỗ xe", null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa06"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "restaurant", null, "Nhà hàng", null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa07"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "glass", null, "Bar", null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa08"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "bus", null, "Đưa đón sân bay", null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa09"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "bell", null, "Lễ tân 24/7", null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "washing", null, "Giặt là", null },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbb02"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "pool", null, "Hồ bơi", null },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccc03"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "dumbbell", null, "Phòng gym", null }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Alt", "CreatedAt", "ModifyAt", "UpdateBy", "Url" },
                values: new object[,]
                {
                    { new Guid("99999999-0000-0000-0000-000000000001"), "Sảnh", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1018/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000002"), "Phòng ngủ", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1015/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000003"), "Phòng tiêu chuẩn", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1025/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000004"), "Deluxe hướng biển", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1039/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000005"), "Phòng khách suite", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1040/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000006"), "Phòng tắm", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1041/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000007"), "Bữa sáng", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1042/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000008"), "Hồ bơi", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1043/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000009"), "Khu gym", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1044/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000010"), "Khu spa", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1045/600/400" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11112222-3333-4444-5555-666677778888"), "Tiền mặt" },
                    { new Guid("22223333-4444-5555-6666-777788889999"), "Thẻ tín dụng (Visa/Master)" },
                    { new Guid("33334444-5555-6666-7777-88889999aaaa"), "Thẻ ghi nợ" },
                    { new Guid("44445555-6666-7777-8888-9999aaaabbbb"), "MoMo" },
                    { new Guid("55556666-7777-8888-9999-aaaabbbbcccc"), "ZaloPay" },
                    { new Guid("66667777-8888-9999-aaaa-bbbbccccdddd"), "Chuyển khoản ngân hàng" },
                    { new Guid("77778888-9999-aaaa-bbbb-ccccddddeeee"), "Apple Pay" },
                    { new Guid("88889999-aaaa-bbbb-cccc-ddddeeeeffff"), "Google Pay" },
                    { new Guid("9999aaaa-bbbb-cccc-dddd-eeeeffff0000"), "VNPAY" },
                    { new Guid("aaaa9999-bbbb-cccc-dddd-eeeeffff1111"), "PayPal" }
                });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "AccomTypeId", "Address", "CreatedAt", "DeletedAt", "DeletedBy", "Description", "Email", "GgMapsQuery", "IsDeleted", "Ll", "Location", "ModifyAt", "Name", "Phone", "Rating", "Star", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("1111aaaa-2222-bbbb-3333-444455556666"), new Guid("99999999-9999-9999-9999-999999999999"), "Q.3, TP. Hồ Chí Minh", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "stay@eta.example", "Capsule+Eta+TP+Ho+Chi+Minh", false, "10.781,106.696", "TP. Hồ Chí Minh", null, "Capsule Eta", "+84 909 000 111", 7.9f, 3, null },
                    { new Guid("2222bbbb-3333-cccc-4444-555566667777"), new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), "Thị trấn Sa Pa, Lào Cai", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "stay@theta.example", "Lodge+Theta+Sa+Pa", false, "22.335,103.843", "Sa Pa", null, "Lodge Theta", "+84 909 222 333", 8.3f, 4, null },
                    { new Guid("3333cccc-4444-dddd-5555-666677778888"), new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "Trung tâm Đà Lạt, Lâm Đồng", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "info@iota.example", "Ryokan+Iota+Da+Lat", false, "11.940,108.458", "Đà Lạt", null, "Ryokan Iota", "+84 909 444 555", 9.2f, 5, null },
                    { new Guid("4444dddd-5555-eeee-6666-777788889999"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "TP. Buôn Ma Thuột, Đắk Lắk", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "farm@kappa.example", "Farmstay+Kappa+Dak+Lak", false, "12.667,108.037", "Đắk Lắk", null, "Farmstay Kappa", "+84 909 666 777", 8.4f, 4, null },
                    { new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("11111111-1111-1111-1111-111111111111"), "01 Nguyễn Huệ, Q.1, TP. Hồ Chí Minh", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "contact@alpha.example", "Khach+san+Alpha+TP+Ho+Chi+Minh", false, "10.776,106.700", "TP. Hồ Chí Minh", null, "Khách sạn Alpha", "+84 123 456 789", 8.6f, 4, null },
                    { new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("22222222-2222-2222-2222-222222222222"), "Đường ven biển, Nha Trang", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "hello@beta.example", "Khu+nghi+duong+Beta+Nha+Trang", false, "12.245,109.195", "Nha Trang", null, "Khu nghỉ dưỡng Beta", "+84 987 654 321", 9.1f, 5, null },
                    { new Guid("cccc1111-2222-3333-4444-555566667777"), new Guid("33333333-3333-3333-3333-333333333333"), "Nguyễn Văn Linh, Đà Nẵng", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "stay@gamma.example", "Can+ho+Gamma+Da+Nang", false, "16.047,108.206", "Đà Nẵng", null, "Căn hộ Gamma", "+84 909 111 222", 8.2f, 4, null },
                    { new Guid("dddd1111-2222-3333-4444-555566667777"), new Guid("44444444-4444-4444-4444-444444444444"), "Bãi biển An Bàng, Hội An", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "booking@delta.example", "Biet+thu+Delta+Hoi+An", false, "15.879,108.335", "Hội An", null, "Biệt thự Delta", "+84 909 333 444", 9f, 5, null },
                    { new Guid("eeee1111-2222-3333-4444-555566667777"), new Guid("55555555-5555-5555-5555-555555555555"), "Phố Cổ, Hà Nội", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "hi@epsilon.example", "Hostel+Epsilon+Ha+Noi", false, "21.028,105.854", "Hà Nội", null, "Hostel Epsilon", "+84 909 555 666", 8f, 3, null },
                    { new Guid("ffff1111-2222-3333-4444-555566667777"), new Guid("77777777-7777-7777-7777-777777777777"), "Dương Đông, Phú Quốc", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "hello@zeta.example", "Homestay+Zeta+Phu+Quoc", false, "10.284,103.984", "Phú Quốc", null, "Homestay Zeta", "+84 909 777 888", 8.7f, 4, null }
                });

            migrationBuilder.InsertData(
                table: "Accom_Facilities",
                columns: new[] { "Id", "AccomId", "FacilityId" },
                values: new object[,]
                {
                    { new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"), new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01") },
                    { new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"), new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbb02") },
                    { new Guid("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01") },
                    { new Guid("b4b4b4b4-b4b4-b4b4-b4b4-b4b4b4b4b4b4"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccc03") },
                    { new Guid("b5b5b5b5-b5b5-b5b5-b5b5-b5b5b5b5b5b5"), new Guid("cccc1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa05") },
                    { new Guid("b6b6b6b6-b6b6-b6b6-b6b6-b6b6b6b6b6b6"), new Guid("dddd1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa04") },
                    { new Guid("b7b7b7b7-b7b7-b7b7-b7b7-b7b7b7b7b7b7"), new Guid("eeee1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa09") },
                    { new Guid("b8b8b8b8-b8b8-b8b8-b8b8-b8b8b8b8b8b8"), new Guid("ffff1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa08") },
                    { new Guid("b9b9b9b9-b9b9-b9b9-b9b9-b9b9b9b9b9b9"), new Guid("1111aaaa-2222-bbbb-3333-444455556666"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10") },
                    { new Guid("babababa-baba-baba-baba-babababababa"), new Guid("2222bbbb-3333-cccc-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa06") }
                });

            migrationBuilder.InsertData(
                table: "Accom_Images",
                columns: new[] { "Id", "AccomId", "ImageId" },
                values: new object[,]
                {
                    { new Guid("e1e1e1e1-e1e1-e1e1-e1e1-e1e1e1e1e1e1"), new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000001") },
                    { new Guid("e2e2e2e2-e2e2-e2e2-e2e2-e2e2e2e2e2e2"), new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000002") },
                    { new Guid("e3e3e3e3-e3e3-e3e3-e3e3-e3e3e3e3e3e3"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000002") },
                    { new Guid("e4e4e4e4-e4e4-e4e4-e4e4-e4e4e4e4e4e4"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000004") },
                    { new Guid("e5e5e5e5-e5e5-e5e5-e5e5-e5e5e5e5e5e5"), new Guid("cccc1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000005") },
                    { new Guid("e6e6e6e6-e6e6-e6e6-e6e6-e6e6e6e6e6e6"), new Guid("dddd1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000006") },
                    { new Guid("e7e7e7e7-e7e7-e7e7-e7e7-e7e7e7e7e7e7"), new Guid("eeee1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000007") },
                    { new Guid("e8e8e8e8-e8e8-e8e8-e8e8-e8e8e8e8e8e8"), new Guid("ffff1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000008") },
                    { new Guid("e9e9e9e9-e9e9-e9e9-e9e9-e9e9e9e9e9e9"), new Guid("1111aaaa-2222-bbbb-3333-444455556666"), new Guid("99999999-0000-0000-0000-000000000009") },
                    { new Guid("efefefef-efef-efef-efef-efefefefefef"), new Guid("2222bbbb-3333-cccc-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000010") }
                });

            migrationBuilder.InsertData(
                table: "RoomCategories",
                columns: new[] { "Id", "About", "AccomId", "AccommodationId", "BasicFacilities", "BathAmenities", "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted", "ModifyAt", "Name", "RoomFacilities", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("09090909-1111-1313-1515-090909090909"), "29m², có ban công", new Guid("ffff1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Premier", "[]", null },
                    { new Guid("12121212-3434-5656-7878-909090909090"), "Phòng 20m² ấm cúng", new Guid("aaaa1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Tiêu chuẩn", "[]", null },
                    { new Guid("23232323-4545-6767-8989-010101010101"), "Phòng 32m², có ban công", new Guid("bbbb1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Deluxe Hướng Biển", "[]", null },
                    { new Guid("32323232-5454-7676-9898-020202020202"), "22m², có cửa sổ", new Guid("aaaa1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Superior", "[]", null },
                    { new Guid("43434343-6565-8787-0909-030303030303"), "45m², có góc tiếp khách", new Guid("aaaa1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Suite", "[]", null },
                    { new Guid("54545454-7676-9898-1010-040404040404"), "24m²", new Guid("bbbb1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Tiêu chuẩn", "[]", null },
                    { new Guid("65656565-8787-0909-1111-050505050505"), "35m², 2 giường", new Guid("bbbb1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Gia đình", "[]", null },
                    { new Guid("76767676-9898-1010-1212-060606060606"), "28m², bếp nhỏ", new Guid("cccc1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Studio", "[]", null },
                    { new Guid("87878787-0909-1111-1313-070707070707"), "40m², nhìn vườn", new Guid("dddd1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Grand Deluxe", "[]", null },
                    { new Guid("98989898-1010-1212-1414-080808080808"), "Giường tầng, phòng chung", new Guid("eeee1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Ký túc xá", "[]", null }
                });

            migrationBuilder.InsertData(
                table: "Room_Facilities",
                columns: new[] { "Id", "FacilityId", "RoomCategoryId" },
                values: new object[,]
                {
                    { new Guid("f1f1f1f1-1111-1111-1111-111111111111"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"), new Guid("12121212-3434-5656-7878-909090909090") },
                    { new Guid("f2f2f2f2-2222-2222-2222-222222222222"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbb02"), new Guid("23232323-4545-6767-8989-010101010101") },
                    { new Guid("f3f3f3f3-3333-3333-3333-333333333333"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa09"), new Guid("32323232-5454-7676-9898-020202020202") },
                    { new Guid("f4f4f4f4-4444-4444-4444-444444444444"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa04"), new Guid("43434343-6565-8787-0909-030303030303") },
                    { new Guid("f5f5f5f5-5555-5555-5555-555555555555"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa05"), new Guid("54545454-7676-9898-1010-040404040404") },
                    { new Guid("f6f6f6f6-6666-6666-6666-666666666666"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10"), new Guid("65656565-8787-0909-1111-050505050505") },
                    { new Guid("f7f7f7f7-7777-7777-7777-777777777777"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccc03"), new Guid("76767676-9898-1010-1212-060606060606") },
                    { new Guid("f8f8f8f8-8888-8888-8888-888888888888"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa06"), new Guid("87878787-0909-1111-1313-070707070707") },
                    { new Guid("f9f9f9f9-9999-9999-9999-999999999999"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"), new Guid("98989898-1010-1212-1414-080808080808") },
                    { new Guid("fafafafa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa07"), new Guid("09090909-1111-1313-1515-090909090909") }
                });

            migrationBuilder.InsertData(
                table: "Room_Images",
                columns: new[] { "Id", "ImageId", "RoomCategoryId" },
                values: new object[,]
                {
                    { new Guid("a1a1a1a1-1111-1111-1111-111111111111"), new Guid("99999999-0000-0000-0000-000000000003"), new Guid("12121212-3434-5656-7878-909090909090") },
                    { new Guid("a2a2a2a2-2222-2222-2222-222222222222"), new Guid("99999999-0000-0000-0000-000000000004"), new Guid("23232323-4545-6767-8989-010101010101") },
                    { new Guid("a3a3a3a3-3333-3333-3333-333333333333"), new Guid("99999999-0000-0000-0000-000000000005"), new Guid("32323232-5454-7676-9898-020202020202") },
                    { new Guid("a4a4a4a4-4444-4444-4444-444444444444"), new Guid("99999999-0000-0000-0000-000000000006"), new Guid("43434343-6565-8787-0909-030303030303") },
                    { new Guid("a5a5a5a5-5555-5555-5555-555555555555"), new Guid("99999999-0000-0000-0000-000000000007"), new Guid("54545454-7676-9898-1010-040404040404") },
                    { new Guid("a6a6a6a6-6666-6666-6666-666666666666"), new Guid("99999999-0000-0000-0000-000000000008"), new Guid("65656565-8787-0909-1111-050505050505") },
                    { new Guid("a7a7a7a7-7777-7777-7777-777777777777"), new Guid("99999999-0000-0000-0000-000000000009"), new Guid("76767676-9898-1010-1212-060606060606") },
                    { new Guid("a8a8a8a8-8888-8888-8888-888888888888"), new Guid("99999999-0000-0000-0000-000000000010"), new Guid("87878787-0909-1111-1313-070707070707") },
                    { new Guid("a9a9a9a9-9999-9999-9999-999999999999"), new Guid("99999999-0000-0000-0000-000000000002"), new Guid("98989898-1010-1212-1414-080808080808") },
                    { new Guid("abababab-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("99999999-0000-0000-0000-000000000001"), new Guid("09090909-1111-1313-1515-090909090909") }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Available", "BedTypeId", "Breakfast", "CancelPolicyId", "CategoryId", "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted", "ModifyAt", "Name", "NumberOfBeds", "Price", "Rating", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("77777777-0000-0000-0000-000000000001"), true, new Guid("dddddddd-dddd-dddd-dddd-dddddddddd04"), true, new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"), new Guid("12121212-3434-5656-7878-909090909090"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "A-101", 1, 850000m, 8.5f, null },
                    { new Guid("77777777-0000-0000-0000-000000000002"), true, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeee05"), true, new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"), new Guid("23232323-4545-6767-8989-010101010101"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "B-201", 2, 1250000m, 9.2f, null },
                    { new Guid("77777777-0000-0000-0000-000000000003"), true, new Guid("bead0000-0000-0000-0000-000000000001"), false, new Guid("cafe0000-0000-0000-0000-000000000001"), new Guid("12121212-3434-5656-7878-909090909090"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "A-102", 1, 780000m, 8.1f, null },
                    { new Guid("77777777-0000-0000-0000-000000000004"), true, new Guid("bead0000-0000-0000-0000-000000000002"), true, new Guid("cafe0000-0000-0000-0000-000000000002"), new Guid("32323232-5454-7676-9898-020202020202"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "A-103", 1, 990000m, 8.3f, null },
                    { new Guid("77777777-0000-0000-0000-000000000005"), true, new Guid("bead0000-0000-0000-0000-000000000003"), true, new Guid("cafe0000-0000-0000-0000-000000000003"), new Guid("43434343-6565-8787-0909-030303030303"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "A-104", 2, 1650000m, 8.9f, null },
                    { new Guid("77777777-0000-0000-0000-000000000006"), true, new Guid("bead0000-0000-0000-0000-000000000004"), false, new Guid("cafe0000-0000-0000-0000-000000000004"), new Guid("54545454-7676-9898-1010-040404040404"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "B-202", 1, 880000m, 8.7f, null },
                    { new Guid("77777777-0000-0000-0000-000000000007"), true, new Guid("bead0000-0000-0000-0000-000000000005"), true, new Guid("cafe0000-0000-0000-0000-000000000005"), new Guid("65656565-8787-0909-1111-050505050505"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "B-203", 2, 1120000m, 8.8f, null },
                    { new Guid("77777777-0000-0000-0000-000000000008"), true, new Guid("bead0000-0000-0000-0000-000000000006"), false, new Guid("cafe0000-0000-0000-0000-000000000006"), new Guid("76767676-9898-1010-1212-060606060606"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "G-301", 1, 720000m, 8f, null },
                    { new Guid("77777777-0000-0000-0000-000000000009"), true, new Guid("bead0000-0000-0000-0000-000000000007"), true, new Guid("cafe0000-0000-0000-0000-000000000007"), new Guid("87878787-0909-1111-1313-070707070707"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "D-401", 1, 1320000m, 8.6f, null },
                    { new Guid("77777777-0000-0000-0000-000000000010"), true, new Guid("bead0000-0000-0000-0000-000000000008"), true, new Guid("cafe0000-0000-0000-0000-000000000008"), new Guid("98989898-1010-1212-1414-080808080808"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "E-501", 2, 980000m, 8.2f, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accom_Facilities_AccomId_FacilityId",
                table: "Accom_Facilities",
                columns: new[] { "AccomId", "FacilityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accom_Facilities_FacilityId",
                table: "Accom_Facilities",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Accom_Images_AccomId_ImageId",
                table: "Accom_Images",
                columns: new[] { "AccomId", "ImageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accom_Images_ImageId",
                table: "Accom_Images",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Accom_RR_AccomId",
                table: "Accom_RR",
                column: "AccomId");

            migrationBuilder.CreateIndex(
                name: "IX_Accom_RR_RRId",
                table: "Accom_RR",
                column: "RRId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_AccomTypeId",
                table: "Accommodations",
                column: "AccomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecords_PaymentMethodId",
                table: "PaymentRecords",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecords_RoomId",
                table: "PaymentRecords",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecords_UserId",
                table: "PaymentRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsAndRatings_UserId",
                table: "ReviewsAndRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Facilities_FacilityId",
                table: "Room_Facilities",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Facilities_RoomCategoryId_FacilityId",
                table: "Room_Facilities",
                columns: new[] { "RoomCategoryId", "FacilityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_Images_ImageId",
                table: "Room_Images",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Images_RoomCategoryId_ImageId",
                table: "Room_Images",
                columns: new[] { "RoomCategoryId", "ImageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomCategories_AccomId",
                table: "RoomCategories",
                column: "AccomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCategories_AccommodationId",
                table: "RoomCategories",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BedTypeId",
                table: "Rooms",
                column: "BedTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CancelPolicyId",
                table: "Rooms",
                column: "CancelPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CategoryId",
                table: "Rooms",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accom_Facilities");

            migrationBuilder.DropTable(
                name: "Accom_Images");

            migrationBuilder.DropTable(
                name: "Accom_RR");

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
                name: "GeneralInfos");

            migrationBuilder.DropTable(
                name: "PaymentRecords");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Room_Facilities");

            migrationBuilder.DropTable(
                name: "Room_Images");

            migrationBuilder.DropTable(
                name: "ReviewsAndRatings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BedTypes");

            migrationBuilder.DropTable(
                name: "CancelPolicies");

            migrationBuilder.DropTable(
                name: "RoomCategories");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "AccomTypes");
        }
    }
}
