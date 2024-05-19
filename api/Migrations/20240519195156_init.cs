using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id_films = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Release_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age_rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id_films);
                });

            migrationBuilder.CreateTable(
                name: "Hall",
                columns: table => new
                {
                    Hall_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row_amount = table.Column<int>(type: "int", nullable: false),
                    Amount_seats_in_a_row = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hall", x => x.Hall_Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regestration_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Session_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_film = table.Column<int>(type: "int", nullable: true),
                    Session_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Session_time = table.Column<int>(type: "int", nullable: false),
                    Hall = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount_of_empty_seats = table.Column<int>(type: "int", nullable: false),
                    FilmsId_films = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Session_Id);
                    table.ForeignKey(
                        name: "FK_Session_Films_FilmsId_films",
                        column: x => x.FilmsId_films,
                        principalTable: "Films",
                        principalColumn: "Id_films");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Booking_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: true),
                    Session_Id = table.Column<int>(type: "int", nullable: true),
                    Ticket_amount = table.Column<int>(type: "int", nullable: false),
                    Booking_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hall_Id = table.Column<int>(type: "int", nullable: true),
                    Session_Id1 = table.Column<int>(type: "int", nullable: true),
                    Hall_Id1 = table.Column<int>(type: "int", nullable: true),
                    UsersUser_Id = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Booking_Id);
                    table.ForeignKey(
                        name: "FK_Booking_Hall_Hall_Id1",
                        column: x => x.Hall_Id1,
                        principalTable: "Hall",
                        principalColumn: "Hall_Id");
                    table.ForeignKey(
                        name: "FK_Booking_Session_Session_Id1",
                        column: x => x.Session_Id1,
                        principalTable: "Session",
                        principalColumn: "Session_Id");
                    table.ForeignKey(
                        name: "FK_Booking_User_UsersUser_Id",
                        column: x => x.UsersUser_Id,
                        principalTable: "User",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Hall_Id1",
                table: "Booking",
                column: "Hall_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Session_Id1",
                table: "Booking",
                column: "Session_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UsersUser_Id",
                table: "Booking",
                column: "UsersUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Session_FilmsId_films",
                table: "Session",
                column: "FilmsId_films");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Hall");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
