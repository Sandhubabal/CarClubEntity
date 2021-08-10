using Microsoft.EntityFrameworkCore.Migrations;

namespace CarClub.Migrations
{
    public partial class car_club : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // table creation 
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(nullable: true),
                    CarModel = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });
            // create table booking cars

            migrationBuilder.CreateTable(
                name: "BookingCars",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    CarId = table.Column<int>(nullable: true),
                    BookingDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingCars", x => x.id);
                    table.ForeignKey(
                         name: "FK_PK_BookingCars_Car_CarId",
                         column: x => x.CarId,
                         principalTable: "Car",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CarModel = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.id);
                });
        }

        //adding migration

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingCars");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "ContactUs");
        }
    }
}
