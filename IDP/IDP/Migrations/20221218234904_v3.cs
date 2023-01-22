using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDP.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("0086355a-e76b-4339-a507-5fc546547a48"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("170fc7f9-4ea4-49a4-a0fb-1c787b89489e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("196c86ce-7fbd-4bd6-8adb-0522c7bcc9f9"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("44a88a9f-5c41-4aa2-93cc-4d2b273acb64"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("9347d386-5500-47d5-9e9d-cc1c8a55fa59"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("bbabf8db-b7bf-4a1c-be8d-e83731edfb8a"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d30b8ddc-3df9-45e0-bb2d-e32c0bcade05"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("fc322185-5124-44b6-b17e-7d15d106dc1a"));

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Provider = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ProviderIdentityKey = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("2b8ec5a2-6713-47d1-b206-0d121dc44c5d"), "41e1d1de-4271-4fe8-91fe-1b79c29fb52e", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Employee" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("455c8fc1-08d6-4683-a16c-5645f419acfd"), "dc55c917-5a20-4628-975c-d674c00f8e59", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Albania" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("7eac1874-635c-44dd-972b-8fc52fda3ec0"), "b7e0cfae-7c37-48da-bd08-b65b461dad24", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Admin" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("9c72ec0c-5992-4f86-9a9b-27b49d631243"), "47d0cfa9-95b3-4473-a232-4ded9d834ab5", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("aaffffe0-368c-401e-81d7-03d5f7f60ccb"), "e5649b5b-9ba8-43da-8e7d-03b23e5fd826", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("ccf8109e-9d40-414a-9a7a-c23b7c209e66"), "ed13a000-5527-4b3a-8f2e-fba318013ce9", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("e547cadc-78b8-427d-9cc6-41120f5ca4e1"), "604173ac-7dc9-4657-a9a6-bfb1053cb878", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("f9297380-61cf-453d-91b9-a9fe373b47df"), "9998b711-0844-46d0-bed8-3bc1499e3a5f", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Kosovo" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "88d3315b-43b2-4e2b-bb3e-47e224d3360f");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "51b9a085-55ac-4347-a148-60e9bc792fc4");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2b8ec5a2-6713-47d1-b206-0d121dc44c5d"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("455c8fc1-08d6-4683-a16c-5645f419acfd"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("7eac1874-635c-44dd-972b-8fc52fda3ec0"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("9c72ec0c-5992-4f86-9a9b-27b49d631243"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("aaffffe0-368c-401e-81d7-03d5f7f60ccb"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("ccf8109e-9d40-414a-9a7a-c23b7c209e66"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e547cadc-78b8-427d-9cc6-41120f5ca4e1"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("f9297380-61cf-453d-91b9-a9fe373b47df"));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("0086355a-e76b-4339-a507-5fc546547a48"), "fd852c75-8a77-499c-96c1-662b5bace37a", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Kosovo" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("170fc7f9-4ea4-49a4-a0fb-1c787b89489e"), "d94a80e3-4664-47fd-9d3b-20ddc1559eb4", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Admin" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("196c86ce-7fbd-4bd6-8adb-0522c7bcc9f9"), "8d63b76c-01ad-4dee-81c8-5d0b2a721e70", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("44a88a9f-5c41-4aa2-93cc-4d2b273acb64"), "73dbd2f3-1afd-400b-84a6-6a83be07ce31", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("9347d386-5500-47d5-9e9d-cc1c8a55fa59"), "a71e3f4c-f338-4e12-8afc-ebdf18a51013", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("bbabf8db-b7bf-4a1c-be8d-e83731edfb8a"), "754003d1-4c7d-4191-80cd-056d998c410a", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Albania" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("d30b8ddc-3df9-45e0-bb2d-e32c0bcade05"), "883549ba-28bf-4625-a964-a5b2b2b553e2", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Employee" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("fc322185-5124-44b6-b17e-7d15d106dc1a"), "811ad5c5-6815-49a7-9380-bac3688f828b", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "665860c8-f335-4042-8500-f91ac9b3afdd");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "1f276a21-f3ab-46f3-93c1-e91186dfad12");
        }
    }
}
