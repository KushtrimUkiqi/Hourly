#nullable disable

namespace IDP.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("3239c7ed-c443-4175-ab15-0c582b358398"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("409f2351-e659-40cd-bc09-e19ada62810f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("6791c2eb-dae8-481f-a6fc-b36871b57582"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("8250dfb1-9521-4665-8156-e7058e8a6545"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a890c04c-6082-4f63-9b2a-4be7970ebb4a"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d59cb0a0-b385-40c7-82d7-889c940f99fd"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e6b7b84d-ba24-4ad3-883a-72126947a69a"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("fd36f637-ff53-49c9-bc5c-b930d1ed577c"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecurityCodeExpirationDate",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                columns: new[] { "ConcurrencyStamp", "Email" },
                values: new object[] { "665860c8-f335-4042-8500-f91ac9b3afdd", "david@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                columns: new[] { "ConcurrencyStamp", "Email" },
                values: new object[] { "1f276a21-f3ab-46f3-93c1-e91186dfad12", "emma@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCodeExpirationDate",
                table: "Users");

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("3239c7ed-c443-4175-ab15-0c582b358398"), "a4c2ccad-5f5a-4430-9a00-a7a0dd637f6b", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("409f2351-e659-40cd-bc09-e19ada62810f"), "f8473fc6-41da-450d-8e4f-5a2d797e42ac", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("6791c2eb-dae8-481f-a6fc-b36871b57582"), "978f396e-7d66-4e0f-af27-eab661792503", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("8250dfb1-9521-4665-8156-e7058e8a6545"), "00358fbb-3e15-4fd0-85a8-f8f5bac55445", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Albania" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("a890c04c-6082-4f63-9b2a-4be7970ebb4a"), "35eee564-24a0-4cdf-821e-3baca4ff4bb9", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Admin" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("d59cb0a0-b385-40c7-82d7-889c940f99fd"), "92952860-ef2d-4136-98b8-39253706c940", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Employee" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("e6b7b84d-ba24-4ad3-883a-72126947a69a"), "77db09e4-00da-4fad-ad41-81ad008d219f", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("fd36f637-ff53-49c9-bc5c-b930d1ed577c"), "0a603330-e522-48cc-bc27-949ec4112c29", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Kosovo" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "144e2125-80fd-4b72-ae9c-8e3582bbf8a0");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "672ad707-69a8-460d-a534-2d154a88016b");
        }
    }
}
