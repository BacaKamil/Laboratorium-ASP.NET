using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class HotelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "19be5c1f-2eac-4315-91a7-4d63652e5098", "6ba65d64-ccc0-414f-86e4-dc7319bf77a8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0c437ad0-08a5-4f9a-af3c-5349095357f6", "c5941961-0cdc-48b8-b1fe-9cad55805589" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c437ad0-08a5-4f9a-af3c-5349095357f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19be5c1f-2eac-4315-91a7-4d63652e5098");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ba65d64-ccc0-414f-86e4-dc7319bf77a8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5941961-0cdc-48b8-b1fe-9cad55805589");

            migrationBuilder.DropColumn(
                name: "Miasto",
                table: "reservations");

            migrationBuilder.AddColumn<int>(
                name: "TownId",
                table: "reservations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Town",
                table: "hotels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "towns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Town = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_towns", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "717e752f-babb-40ca-b8a9-e3ad3f8f8422", "717e752f-babb-40ca-b8a9-e3ad3f8f8422", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7003e02-35f6-4960-b429-70adbf46a282", "f7003e02-35f6-4960-b429-70adbf46a282", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46441f30-3ab9-4060-9047-8217ec8c61e2", 0, "e2a3599a-b9be-43d3-9a20-c5a902973e70", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEJK13gTYwUXQ6/os9O3HbDYn6G0+WBJGzdvFnaa2MelNVdVxxnHfuiAUBx2VBRLwFg==", null, false, "0149a90b-7e5a-43d8-9dde-1d304fbd4860", false, "adam" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fe841a40-3919-463f-b0d4-15ad18a37b6e", 0, "92136670-0ae3-407b-bd7d-6fb9982ccc30", "ewa@wsei.edu.pl", true, false, null, "EWA@WSEI.EDU.PL", "EWA", "AQAAAAEAACcQAAAAEGJzIt70ISO9zEA1X5/8KrWayEDn3H0UKaIpuZHgjUZwT43Ui3tiprwVwmjkyz7g3w==", null, false, "04cbeccb-f6e0-4740-bc45-a1413a8441eb", false, "ewa" });

            migrationBuilder.UpdateData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Name", "Town" },
                values: new object[] { "Marii Konopnickiej 33, 30-302 Kraków", "Hilton Garden Inn", 1 });

            migrationBuilder.UpdateData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Name", "Town" },
                values: new object[] { "Bolesława Prusa 2, 00-493 Warszawa", "Sheraton Grand", 2 });

            migrationBuilder.UpdateData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Name", "Town" },
                values: new object[] { "Żywiecka 93, 43-300 Bielsko-Biała", "Ibis Styles", 4 });

            migrationBuilder.UpdateData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "Name", "Town" },
                values: new object[] { "Świętej Marii Magdaleny 2, 50-103 Wrocław", "Qubus", 3 });

            migrationBuilder.InsertData(
                table: "towns",
                columns: new[] { "Id", "Town" },
                values: new object[] { 1, "Kraków" });

            migrationBuilder.InsertData(
                table: "towns",
                columns: new[] { "Id", "Town" },
                values: new object[] { 2, "Warszawa" });

            migrationBuilder.InsertData(
                table: "towns",
                columns: new[] { "Id", "Town" },
                values: new object[] { 3, "Wrocław" });

            migrationBuilder.InsertData(
                table: "towns",
                columns: new[] { "Id", "Town" },
                values: new object[] { 4, "Bielsko-Biała" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "717e752f-babb-40ca-b8a9-e3ad3f8f8422", "46441f30-3ab9-4060-9047-8217ec8c61e2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f7003e02-35f6-4960-b429-70adbf46a282", "fe841a40-3919-463f-b0d4-15ad18a37b6e" });

            migrationBuilder.CreateIndex(
                name: "IX_reservations_TownId",
                table: "reservations",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_towns_TownId",
                table: "reservations",
                column: "TownId",
                principalTable: "towns",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_towns_TownId",
                table: "reservations");

            migrationBuilder.DropTable(
                name: "towns");

            migrationBuilder.DropIndex(
                name: "IX_reservations_TownId",
                table: "reservations");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "717e752f-babb-40ca-b8a9-e3ad3f8f8422", "46441f30-3ab9-4060-9047-8217ec8c61e2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f7003e02-35f6-4960-b429-70adbf46a282", "fe841a40-3919-463f-b0d4-15ad18a37b6e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "717e752f-babb-40ca-b8a9-e3ad3f8f8422");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7003e02-35f6-4960-b429-70adbf46a282");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46441f30-3ab9-4060-9047-8217ec8c61e2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe841a40-3919-463f-b0d4-15ad18a37b6e");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "hotels");

            migrationBuilder.AddColumn<string>(
                name: "Miasto",
                table: "reservations",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c437ad0-08a5-4f9a-af3c-5349095357f6", "0c437ad0-08a5-4f9a-af3c-5349095357f6", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19be5c1f-2eac-4315-91a7-4d63652e5098", "19be5c1f-2eac-4315-91a7-4d63652e5098", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6ba65d64-ccc0-414f-86e4-dc7319bf77a8", 0, "3ef2412a-b930-49da-9d45-1b221bedf950", "ewa@wsei.edu.pl", true, false, null, "EWA@WSEI.EDU.PL", "EWA", "AQAAAAEAACcQAAAAEHZVSLD9M7K8XhvvLwgBs/MGQDRZ1tpyQKM4lUx2KfsSbeCWQ0MVSHI9w+YwTHs2iQ==", null, false, "b0a77420-7ad1-4259-8953-38601119da49", false, "ewa" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c5941961-0cdc-48b8-b1fe-9cad55805589", 0, "62df2e52-9b8f-42f6-96b1-2523cd96abd9", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEC8wzkfzN3iSc9QFbh1oqLOE+TpHgj/To6EWC6O+N95T6vmP6VysZkUrfE9kyBxeWA==", null, false, "82d0f146-c9d8-4831-a290-c665bded8c0a", false, "adam" });

            migrationBuilder.UpdateData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Name" },
                values: new object[] { "Uczelnia", "WSEI" });

            migrationBuilder.UpdateData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Name" },
                values: new object[] { "Uczelnia", "UJ" });

            migrationBuilder.UpdateData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Name" },
                values: new object[] { "Uczelnia", "AGH" });

            migrationBuilder.UpdateData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "Name" },
                values: new object[] { "Firma", "NOKIA" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "19be5c1f-2eac-4315-91a7-4d63652e5098", "6ba65d64-ccc0-414f-86e4-dc7319bf77a8" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0c437ad0-08a5-4f9a-af3c-5349095357f6", "c5941961-0cdc-48b8-b1fe-9cad55805589" });
        }
    }
}
