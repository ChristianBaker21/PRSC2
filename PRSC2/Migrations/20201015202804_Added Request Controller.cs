using Microsoft.EntityFrameworkCore.Migrations;

namespace PRSC2.Migrations
{
    public partial class AddedRequestController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Justification = table.Column<string>(nullable: true),
                    RejectionReason = table.Column<string>(nullable: true),
                    DeliveryMode = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Total = table.Column<decimal>(nullable: false),
                    UserIdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Request_User_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(maxLength: 30, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: false),
                    Zip = table.Column<string>(maxLength: 5, nullable: false),
                    Phone = table.Column<string>(maxLength: 12, nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNbr = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true),
                    VendorIdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Vendor_VendorIdId",
                        column: x => x.VendorIdId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_VendorIdId",
                table: "Product",
                column: "VendorIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_UserIdId",
                table: "Request",
                column: "UserIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
