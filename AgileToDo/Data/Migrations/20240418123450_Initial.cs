using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgileToDo.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deadline = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Resolved = table.Column<bool>(type: "INTEGER", nullable: false),
                    ResolvedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ResolvedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a1e8296-a7fe-411e-935d-9027f41c91d4", null, "Admin", "ADMIN" },
                    { "5fa32b7d-e8e1-4c3e-b4c3-28c3c4a5db7e", null, "Manager", "MANAGER" },
                    { "821ebd06-ad83-4a68-80ab-ef644738aaec", null, "CS", "CS" },
                    { "ff532278-82c6-4090-b532-6cbd66fe64ac", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8452489a-7451-4523-85bb-de8643bb5296", 0, "e29e3600-9846-4220-a842-9e7dae1832c1", "cs@agiletodo.com", true, false, null, "CS@AGILETODO.COM", "CS@AGILETODO.COM", "AQAAAAIAAYagAAAAECjnLDnNDPMQ3H72HMtRWVmMG6Ustl5E3XszsAzj+6IPaVcwh7ulWqw4TEOgj14mmQ==", null, false, "e71f239e-4fcb-472d-9d22-ae47ba7839f2", false, "cs@agiletodo.com" },
                    { "8e07ff69-eb9c-4a31-ae54-2ad6b24f276e", 0, "dc7181db-34e5-43c8-b4c1-731e5ffaaeeb", "manager@agiletodo.com", true, false, null, "MANAGER@AGILETODO.COM", "MANAGER@AGILETODO.COM", "AQAAAAIAAYagAAAAEM7E8V3w1DaLdGRvHGQfjRyYW7e72kP+vmuIxlGncCRaotUbL8itgJHtluagazJ86w==", null, false, "70937fc3-286a-4148-a31c-8e9e74c33ab6", false, "manager@agiletodo.com" },
                    { "cb5e8084-5d7f-42cf-85df-4b4ff844b034", 0, "a9e38b7a-6132-4a62-8b10-231bac800bae", "admin@agiletodo.com", true, false, null, "ADMIN@AGILETODO.COM", "ADMIN@AGILETODO.COM", "AQAAAAIAAYagAAAAEFugNRn6kX8i3uWeTqKTL7NM30rr8J9wXeBmLuWbdNcqZM1fAClOAMVWuPwlcjXQPQ==", null, false, "4350d393-06cd-43cf-8f61-26062b7f9030", false, "admin@agiletodo.com" },
                    { "e3e532ed-1c5d-4e71-b16b-f37782c1d39a", 0, "aa6987c8-900e-474d-bf21-b9ca6ae61654", "user@agiletodo.com", true, false, null, "USER@AGILETODO.COM", "USER@AGILETODO.COM", "AQAAAAIAAYagAAAAEETAlG22dE88VyYxz7tTkd95CRBwuGgx6pR8WRpKsPKO1MjW/VDxd9BZvKfTT5wFWA==", null, false, "96ece27d-b0fe-4213-a32f-7483f109c3e2", false, "user@agiletodo.com" }
                });

            migrationBuilder.InsertData(
                table: "IssueModel",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deadline", "Description", "Resolved", "ResolvedAt", "ResolvedBy", "Title" },
                values: new object[,]
                {
                    { new Guid("002d2620-fea1-4431-baa4-d660bc30ba22"), new DateTime(2024, 4, 7, 9, 34, 50, 259, DateTimeKind.Local).AddTicks(3521), null, new DateTime(2024, 4, 13, 22, 41, 50, 259, DateTimeKind.Local).AddTicks(3521), "Computer crashes and displays a blue screen error message, indicating a serious system error. This could be caused by hardware issues, driver conflicts, or software bugs.", false, null, null, "Blue Screen of Death (BSOD)" },
                    { new Guid("4118a13d-1d06-4f1e-9130-234e501e5136"), new DateTime(2024, 4, 14, 13, 53, 50, 259, DateTimeKind.Local).AddTicks(3521), null, new DateTime(2024, 4, 14, 22, 39, 50, 259, DateTimeKind.Local).AddTicks(3521), "User is having trouble setting up their email account on their computer or mobile device. They may be experiencing issues with incoming or outgoing mail, authentication errors, or incorrect server settings.", false, null, null, "Email Configuration Problems" },
                    { new Guid("53d21c15-651f-4f48-a608-0846cfcb7773"), new DateTime(2024, 4, 8, 18, 50, 50, 259, DateTimeKind.Local).AddTicks(3521), null, new DateTime(2024, 4, 12, 8, 2, 50, 259, DateTimeKind.Local).AddTicks(3521), "User's application keeps crashing or freezing during use, making it difficult to work efficiently.", false, null, null, "Application Crashes" },
                    { new Guid("7a7c99f8-c087-4a94-99c2-d2a91953ad4e"), new DateTime(2024, 4, 15, 11, 14, 50, 259, DateTimeKind.Local).AddTicks(3521), null, new DateTime(2024, 4, 26, 0, 42, 50, 259, DateTimeKind.Local).AddTicks(3521), "Component of the computer hardware (e.g., hard drive, RAM, graphics card) has failed, resulting in system instability, data loss, or inability to boot up.", false, null, null, "Hardware Failure" },
                    { new Guid("7dbcc617-2fb3-4ee0-b36f-517b0b69ee30"), new DateTime(2024, 4, 18, 13, 30, 50, 259, DateTimeKind.Local).AddTicks(3521), null, new DateTime(2024, 4, 20, 17, 7, 50, 259, DateTimeKind.Local).AddTicks(3521), "User's files or documents have gone missing or become corrupted. This could be due to accidental deletion, hardware failure, or malware infection.", false, null, null, "Data Loss or Corruption" },
                    { new Guid("9844f256-d7a6-4f99-9d69-9e55b1e9c32c"), new DateTime(2024, 4, 14, 2, 13, 50, 259, DateTimeKind.Local).AddTicks(3521), null, new DateTime(2024, 4, 28, 1, 6, 50, 259, DateTimeKind.Local).AddTicks(3521), "User is experiencing problems with network connectivity, such as intermittent disconnections, slow speeds, or limited access to network resources.", false, null, null, "Network Connectivity Issues" },
                    { new Guid("9aaf2fbd-e595-466f-90fa-1afe90a62e47"), new DateTime(2024, 4, 16, 8, 48, 50, 259, DateTimeKind.Local).AddTicks(3521), null, new DateTime(2024, 4, 28, 9, 11, 50, 259, DateTimeKind.Local).AddTicks(3521), "User requests a password reset for their account due to forgetting their current password or security concerns.", false, null, null, "Password Reset Request" },
                    { new Guid("d5958260-7028-4ae0-896d-1429c1a91b11"), new DateTime(2024, 4, 16, 3, 11, 50, 259, DateTimeKind.Local).AddTicks(3521), null, new DateTime(2024, 4, 29, 15, 19, 50, 259, DateTimeKind.Local).AddTicks(3521), "User encounters errors or issues while trying to install new software on their computer. This could be due to compatibility issues, insufficient disk space, or corrupted installation files.", false, null, null, "Software Installation Failure" },
                    { new Guid("d71d95ef-e48e-4b0e-a41c-c8ba3c67dc45"), new DateTime(2024, 4, 7, 20, 23, 50, 259, DateTimeKind.Local).AddTicks(3521), null, new DateTime(2024, 4, 18, 9, 49, 50, 259, DateTimeKind.Local).AddTicks(3521), "Computer or network has been compromised by malware, ransomware, or a security breach. Users may notice unusual behavior, unauthorized access, or files being encrypted.", false, null, null, "Security Breach or Virus Infection" },
                    { new Guid("dbd47ba3-800f-445f-b01a-722094ecc49a"), new DateTime(2024, 4, 11, 9, 30, 50, 259, DateTimeKind.Local).AddTicks(3521), null, new DateTime(2024, 4, 14, 14, 27, 50, 259, DateTimeKind.Local).AddTicks(3521), "User is experiencing problems with their web browser, such as slow performance, frequent crashes, or unexpected behavior (e.g., pop-up ads, redirects).", false, null, null, "Web Browser Issues" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "821ebd06-ad83-4a68-80ab-ef644738aaec", "8452489a-7451-4523-85bb-de8643bb5296" },
                    { "5fa32b7d-e8e1-4c3e-b4c3-28c3c4a5db7e", "8e07ff69-eb9c-4a31-ae54-2ad6b24f276e" },
                    { "0a1e8296-a7fe-411e-935d-9027f41c91d4", "cb5e8084-5d7f-42cf-85df-4b4ff844b034" },
                    { "ff532278-82c6-4090-b532-6cbd66fe64ac", "e3e532ed-1c5d-4e71-b16b-f37782c1d39a" }
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
                name: "IssueModel");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
