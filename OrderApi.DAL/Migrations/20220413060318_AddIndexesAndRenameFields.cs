using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderApi.DAL.Migrations
{
    public partial class AddIndexesAndRenameFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Terminals_PostTerminalNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryTerminalNumber",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "PostTerminalNumber",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_Number",
                table: "Terminals",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Number",
                table: "Orders",
                column: "Number");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Terminals_PostTerminalNumber",
                table: "Orders",
                column: "PostTerminalNumber",
                principalTable: "Terminals",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Terminals_PostTerminalNumber",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Terminals_Number",
                table: "Terminals");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Number",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "PostTerminalNumber",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryTerminalNumber",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Terminals_PostTerminalNumber",
                table: "Orders",
                column: "PostTerminalNumber",
                principalTable: "Terminals",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
