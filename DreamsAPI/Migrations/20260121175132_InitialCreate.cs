using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DreamsAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuestName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    CheckInDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RoomType = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CheckInDate", "CheckOutDate", "CreatedAt", "Email", "GuestName", "NumberOfGuests", "RoomType", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 2, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 1, 21, 17, 51, 29, 344, DateTimeKind.Utc).AddTicks(3447), "john.smith@example.com", "John Smith", 2, "Deluxe", 1 },
                    { 2, new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 1, 21, 17, 51, 29, 344, DateTimeKind.Utc).AddTicks(3931), "mary@example.com", "Mary Johnson", 3, "Suite", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
