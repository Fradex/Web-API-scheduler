using Microsoft.EntityFrameworkCore.Migrations;

namespace MonitoringService.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MessageTypes",
                columns: new[] { "Id", "MessageName" },
                values: new object[] { 1001, "Физические лица" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1001);
        }
    }
}
