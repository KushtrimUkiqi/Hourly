#nullable disable

namespace IDP.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
