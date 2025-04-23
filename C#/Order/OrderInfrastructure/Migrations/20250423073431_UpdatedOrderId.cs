using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedOrderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Details_Orders_OrderId1",
                table: "Order_Details");

            migrationBuilder.DropIndex(
                name: "IX_Order_Details_OrderId1",
                table: "Order_Details");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "Order_Details");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_OrderId",
                table: "Order_Details",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Details_Orders_OrderId",
                table: "Order_Details",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Details_Orders_OrderId",
                table: "Order_Details");

            migrationBuilder.DropIndex(
                name: "IX_Order_Details_OrderId",
                table: "Order_Details");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "OrderId1",
                table: "Order_Details",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_OrderId1",
                table: "Order_Details",
                column: "OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Details_Orders_OrderId1",
                table: "Order_Details",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
