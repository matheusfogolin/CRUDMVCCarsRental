using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDMVCCarsRental.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Registration_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Model = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Fabrication_Year = table.Column<int>(type: "int", nullable: false),
                    Model_Year = table.Column<int>(type: "int", nullable: false),
                    Engine = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Rent_Value_Per_Day = table.Column<decimal>(type: "money", nullable: false),
                    Rented = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Starting_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ending_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<decimal>(type: "money", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CarId",
                table: "Rents",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
