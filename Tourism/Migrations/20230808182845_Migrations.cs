using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourism.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    AId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.AId);
                });

            migrationBuilder.CreateTable(
                name: "agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<double>(type: "float", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gallery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trips",
                columns: table => new
                {
                    TId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatesPerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RatesPerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RatesPerTourPack = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Itinerary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodAndAccommodation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trips", x => x.TId);
                    table.ForeignKey(
                        name: "FK_trips_agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "agents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfTravelers = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accommodation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TripId = table.Column<int>(type: "int", nullable: true),
                    TripsTId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_bookings_trips_TripsTId",
                        column: x => x.TripsTId,
                        principalTable: "trips",
                        principalColumn: "TId");
                });

            migrationBuilder.CreateTable(
                name: "travelers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<double>(type: "float", nullable: true),
                    TripId = table.Column<int>(type: "int", nullable: true),
                    BookingTripBookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_travelers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_travelers_bookings_BookingTripBookingId",
                        column: x => x.BookingTripBookingId,
                        principalTable: "bookings",
                        principalColumn: "BookingId");
                });

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    FId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedBackTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.FId);
                    table.ForeignKey(
                        name: "FK_feedbacks_travelers_TravelerID",
                        column: x => x.TravelerID,
                        principalTable: "travelers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_TripsTId",
                table: "bookings",
                column: "TripsTId");

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_TravelerID",
                table: "feedbacks",
                column: "TravelerID");

            migrationBuilder.CreateIndex(
                name: "IX_travelers_BookingTripBookingId",
                table: "travelers",
                column: "BookingTripBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_trips_AgentId",
                table: "trips",
                column: "AgentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "gallery");

            migrationBuilder.DropTable(
                name: "travelers");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "trips");

            migrationBuilder.DropTable(
                name: "agents");
        }
    }
}
