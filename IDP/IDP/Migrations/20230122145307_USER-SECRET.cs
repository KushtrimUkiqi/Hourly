
#nullable disable

namespace IDP.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class USERSECRET : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("41b61c65-06ba-4833-9a79-3f7c9cb89049"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("50eb612d-0c4c-4c78-b6e8-c8d191f68249"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("76e44c82-59e8-4f7b-affd-a7a19fd37fd6"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("9d5f43e8-43d0-44b0-94f2-5d6a290fc59b"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a27ccafe-f972-4af7-a17c-0d12b02126fa"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d583a777-a25a-4993-a1d4-1b046874e650"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("eb07fee6-94a3-4d8d-a4f1-d2491796b406"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("f83db466-7bf3-4893-afe3-ddc114bf64e5"));

            migrationBuilder.CreateTable(
                name: "UserSecret",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Secret = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSecret", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSecret_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("25a75dac-3091-4c20-953f-86c9088f8c98"), "9fafd7a5-56ca-4768-a54f-0d423965baf0", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("6cf738e2-c511-4764-bf94-e2f029a545c1"), "3b9297b1-50f4-48e0-9c4b-c870085d03c5", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Albania" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("6d24779e-4461-4981-b985-c3eef2722c23"), "2c3469bb-85a7-4bf3-a0d2-47962a2bd64d", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Admin" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("8304835d-4a2e-412f-9fdf-4a3482bd8557"), "3fa0a687-6923-48d2-95b1-52ad7baae2e0", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("92b6406b-099c-4590-8e58-a4f2a4fcd3bf"), "002136a5-eb2d-4710-96cc-226735545105", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("a4729353-6a43-4d51-bf3d-e0db118d0895"), "c733dbe1-cc2b-488a-a207-df22aa0f2562", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Kosovo" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("e1b088f9-42b9-4083-9ab7-109c2840ee83"), "477550ad-7848-4c13-bbb7-e01299601c39", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("e202f285-5987-4f11-aab4-ae9cd46ccf16"), "6dff9010-b544-4ff5-a30c-20c79074e404", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Employee" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "22ab4f03-ef39-45f2-b555-86770ffcb462");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "ad90f1d2-3305-4e92-862e-592a9286eae5");

            migrationBuilder.CreateIndex(
                name: "IX_UserSecret_UserId",
                table: "UserSecret",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSecret");

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("25a75dac-3091-4c20-953f-86c9088f8c98"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("6cf738e2-c511-4764-bf94-e2f029a545c1"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("6d24779e-4461-4981-b985-c3eef2722c23"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("8304835d-4a2e-412f-9fdf-4a3482bd8557"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("92b6406b-099c-4590-8e58-a4f2a4fcd3bf"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a4729353-6a43-4d51-bf3d-e0db118d0895"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e1b088f9-42b9-4083-9ab7-109c2840ee83"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e202f285-5987-4f11-aab4-ae9cd46ccf16"));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("41b61c65-06ba-4833-9a79-3f7c9cb89049"), "0a783afe-2b1f-4b4e-9e6c-b8920de1f5f4", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("50eb612d-0c4c-4c78-b6e8-c8d191f68249"), "ba3c1930-7e02-4fa3-8ca6-25ca987b26dc", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Albania" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("76e44c82-59e8-4f7b-affd-a7a19fd37fd6"), "319a4bc0-fc41-42dd-87d0-b40a5b590810", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Admin" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("9d5f43e8-43d0-44b0-94f2-5d6a290fc59b"), "72378221-45dd-451e-8751-6cb568270ab5", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("a27ccafe-f972-4af7-a17c-0d12b02126fa"), "9e4d1fd2-6137-4f72-91f5-5c13d7f56e50", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("d583a777-a25a-4993-a1d4-1b046874e650"), "14deb195-0dad-49cd-a6a8-f8a1010122cc", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Kosovo" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("eb07fee6-94a3-4d8d-a4f1-d2491796b406"), "194b8e9b-6520-4a77-b81f-0bb4a9117c93", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("f83db466-7bf3-4893-afe3-ddc114bf64e5"), "3daa98e6-65c7-4515-8e93-6a28c7328f7a", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Employee" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "123f95dd-ef87-4bdf-9dd2-cdebd912dfed");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "d5d31bb8-466d-4da8-8f78-e92124bb1b72");
        }
    }
}
