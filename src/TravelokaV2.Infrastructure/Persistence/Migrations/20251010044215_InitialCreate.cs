using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelokaV2.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    RoomCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_BedTypes_BedTypeId",
                        column: x => x.BedTypeId,
                        principalTable: "BedTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_CancelPolicies_CancelPolicyId",
                        column: x => x.CancelPolicyId,
                        principalTable: "CancelPolicies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_RoomCategories_RoomCategoryId",
                        column: x => x.RoomCategoryId,
                        principalTable: "RoomCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccomTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
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
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Hotel", null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Resort", null }
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
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Queen", null },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Twin", null }
                });

            migrationBuilder.InsertData(
                table: "CancelPolicies",
                columns: new[] { "Id", "CreatedAt", "ModifyAt", "Type", "UpdateBy" },
                values: new object[] { new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Flexible (24h)", null });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "CreatedAt", "Icon", "ModifyAt", "Name", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "wifi", null, "Free Wi-Fi", null },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "pool", null, "Pool", null },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "dumbbell", null, "Gym", null }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Alt", "CreatedAt", "ModifyAt", "UpdateBy", "Url" },
                values: new object[,]
                {
                    { new Guid("99999999-0000-0000-0000-000000000001"), "Lobby", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1018/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000002"), "Room", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1015/600/400" }
                });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "AccomTypeId", "Address", "CreatedAt", "DeletedAt", "DeletedBy", "Description", "Email", "GgMapsQuery", "IsDeleted", "Ll", "Location", "ModifyAt", "Name", "Phone", "Rating", "Star", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("11111111-1111-1111-1111-111111111111"), "01 Main St, District 1, HCMC", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "contact@alpha.example", "Alpha+Hotel+HCMC", false, "10.776,106.700", "Ho Chi Minh City", null, "Alpha Hotel", "+84 123 456 789", 8.6f, 4, null },
                    { new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("22222222-2222-2222-2222-222222222222"), "Beach Rd, Nha Trang", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "hello@beta.example", "Beta+Resort+Nha+Trang", false, "12.245,109.195", "Nha Trang", null, "Beta Resort", "+84 987 654 321", 9.1f, 5, null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Available", "BedTypeId", "Breakfast", "CancelPolicyId", "CategoryId", "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted", "ModifyAt", "Name", "NumberOfBeds", "Rating", "RoomCategoryId", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("77777777-0000-0000-0000-000000000001"), true, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), true, new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"), new Guid("12121212-3434-5656-7878-909090909090"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "A-101", 1, 8.5f, null, null },
                    { new Guid("77777777-0000-0000-0000-000000000002"), true, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), true, new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"), new Guid("23232323-4545-6767-8989-010101010101"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "B-201", 2, 9.2f, null, null }
                });

            migrationBuilder.InsertData(
                table: "Accom_Facilities",
                columns: new[] { "Id", "AccomId", "FacilityId" },
                values: new object[,]
                {
                    { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"), new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") },
                    { new Guid("c3c3c3c3-c3c3-c3c3-c3c3-c3c3c3c3c3c3"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("d4d4d4d4-d4d4-d4d4-d4d4-d4d4d4d4d4d4"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") }
                });

            migrationBuilder.InsertData(
                table: "Accom_Images",
                columns: new[] { "Id", "AccomId", "ImageId" },
                values: new object[,]
                {
                    { new Guid("e1e1e1e1-e1e1-e1e1-e1e1-e1e1e1e1e1e1"), new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000001") },
                    { new Guid("e2e2e2e2-e2e2-e2e2-e2e2-e2e2e2e2e2e2"), new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000002") },
                    { new Guid("e3e3e3e3-e3e3-e3e3-e3e3-e3e3e3e3e3e3"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "RoomCategories",
                columns: new[] { "Id", "About", "AccomId", "AccommodationId", "BasicFacilities", "BathAmenities", "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted", "ModifyAt", "Name", "RoomFacilities", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("12121212-3434-5656-7878-909090909090"), "Cozy 20m2", new Guid("aaaa1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Standard", "[]", null },
                    { new Guid("23232323-4545-6767-8989-010101010101"), "Spacious 32m2, balcony", new Guid("bbbb1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Deluxe Sea View", "[]", null }
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
                name: "IX_Rooms_RoomCategoryId",
                table: "Rooms",
                column: "RoomCategoryId");
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
