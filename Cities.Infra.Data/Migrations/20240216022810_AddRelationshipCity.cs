using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cities.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Cities_CityId1",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Cities_CityId1",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristPackages_Cities_CityId1",
                table: "TouristPackages");

            migrationBuilder.DropIndex(
                name: "IX_TouristPackages_CityId1",
                table: "TouristPackages");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_CityId1",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_CityId1",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "TouristPackages");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Hotels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CityId1",
                table: "TouristPackages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CityId1",
                table: "Restaurants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CityId1",
                table: "Hotels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TouristPackages_CityId1",
                table: "TouristPackages",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CityId1",
                table: "Restaurants",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CityId1",
                table: "Hotels",
                column: "CityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Cities_CityId1",
                table: "Hotels",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Cities_CityId1",
                table: "Restaurants",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPackages_Cities_CityId1",
                table: "TouristPackages",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}
