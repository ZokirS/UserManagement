using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    LastSignInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SignUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastSignInDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SignUpDate", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1939778d-c3ad-4d7f-9c34-be8fc6c86b10", 0, "73206de9-fb2e-428a-94be-4d449c3c7277", "london_lesc3@gmail.com", false, new DateTime(2022, 11, 28, 17, 32, 21, 241, DateTimeKind.Local).AddTicks(5404), false, null, null, null, null, null, false, "7b7fa2c7-17ec-42ce-bd0e-5dbb75014692", new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(6285), 1, false, "Genie" },
                    { "a5292202-0cb2-4abd-8d9b-c871c406d10d", 0, "9f9d4ef5-a9ad-4416-a283-4facadab2e59", "haylee.nitzsc@yahoo.com", false, new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(7108), false, null, null, null, null, null, false, "a046ea03-da3a-4046-93a4-bc0ee240c4c9", new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(7113), 0, false, "Anthony" },
                    { "21d06dad-c583-4bc1-8ffc-d8c2226017d9", 0, "267a0ece-6e6d-4517-8d1b-e43d30572c70", "harvey1982@hotmail.com", false, new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(7208), false, null, null, null, null, null, false, "5928625a-7b85-4a7e-9bf7-3b628b238c05", new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(7209), 0, false, "Kelly" },
                    { "b82f5249-2132-4d22-bce1-4f9e238c9a76", 0, "4bcd521e-a5f9-4d7a-bf25-897ca9f44060", "daisy_bernha@gmail.com", false, new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(7218), false, null, null, null, null, null, false, "30656a76-7efc-44a6-951e-ef845d920af7", new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(7219), 0, false, "Paul" },
                    { "60e896b8-5e63-4163-afb3-c72bd6d37e3b", 0, "03843170-c232-4185-9fce-cae3052e695c", "rosa_turne6@gmail.com", false, new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(7227), false, null, null, null, null, null, false, "1ecc58a3-48a5-40ed-a430-68aac7c1603e", new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(7228), 0, false, "Freida" },
                    { "0b8c8ba2-564e-4939-b824-1031667e1a72", 0, "30d794e5-5879-4f48-a64d-c814659f6646", "colin_lin6@hotmail.com", false, new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(7242), false, null, null, null, null, null, false, "8cf34973-9f13-497a-9a1c-02f427d83580", new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(7244), 0, false, "Margaret" },
                    { "9d9fb9d9-5555-4912-8555-e00011ce25b7", 0, "5182dfb6-8f2c-4bea-b6a7-9793439cb3d1", "arjun_kertzma@gmail.com", false, new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(7251), false, null, null, null, null, null, false, "fc28bb00-4f23-4d0f-b3a0-7c7259bd16c7", new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(7253), 0, false, "Peter" },
                    { "cbd5272d-8232-4f11-887b-7638b4ae6fbd", 0, "e2129aa4-3f3a-42c7-bd94-7ebe56ea1954", "emil2002@hotmail.com", false, new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(7264), false, null, null, null, null, null, false, "80f4e502-8fe6-4e2c-bc6e-d373154e441b", new DateTime(2022, 11, 28, 17, 32, 21, 242, DateTimeKind.Local).AddTicks(7265), 0, false, "Deloris" }
                });

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
        }

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
