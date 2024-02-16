using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cities.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Daily = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hotels_Cities_CityId1",
                        column: x => x.CityId1,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lunch = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restaurants_Cities_CityId1",
                        column: x => x.CityId1,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TouristPackages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalDays = table.Column<int>(type: "int", nullable: false),
                    MealsPerDay = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristPackages_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TouristPackages_Cities_CityId1",
                        column: x => x.CityId1,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TouristPackages_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TouristPackages_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CityId",
                table: "Hotels",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CityId1",
                table: "Hotels",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CityId",
                table: "Restaurants",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CityId1",
                table: "Restaurants",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_TouristPackages_CityId",
                table: "TouristPackages",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristPackages_CityId1",
                table: "TouristPackages",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_TouristPackages_HotelId",
                table: "TouristPackages",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristPackages_RestaurantId",
                table: "TouristPackages",
                column: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TouristPackages");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
