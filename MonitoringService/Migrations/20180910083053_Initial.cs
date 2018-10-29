using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MonitoringService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MessageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusQueueStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MessageTypeId = table.Column<int>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    ObjectCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusQueueStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusQueueStatistics_MessageTypes_MessageTypeId",
                        column: x => x.MessageTypeId,
                        principalTable: "MessageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusQueueStatistics_MessageTypeId",
                table: "BusQueueStatistics",
                column: "MessageTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusQueueStatistics");

            migrationBuilder.DropTable(
                name: "MessageTypes");
        }
    }
}
