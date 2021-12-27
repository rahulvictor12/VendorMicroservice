using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductMicroservice.Migrations
{
    public partial class _2021_12_18_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] {"Price","Description", "Image_Name", "Name", "Rating" },
                values: new object[,]
                {
                    { 80000.00, "Some example text.", "1.jfif", "Iphone", 2 },
                    { 2000.00, "Some example text.", "1.jfif", "Bracelet", 3 },
                    { 40000.00, "Some example text.", "1.jfif", "Oneplus8", 3 },
                    { 15000.00, "Some example text.", "1.jfif", "Apple Watch", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
