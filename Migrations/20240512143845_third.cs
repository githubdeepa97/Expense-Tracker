using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_AspNetUsers_UserId",
                table: "Expenditures");

            migrationBuilder.DropIndex(
                name: "IX_Expenditures_UserId",
                table: "Expenditures");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Expenditures",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Expenditures",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_UserId1",
                table: "Expenditures",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_AspNetUsers_UserId1",
                table: "Expenditures",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_AspNetUsers_UserId1",
                table: "Expenditures");

            migrationBuilder.DropIndex(
                name: "IX_Expenditures_UserId1",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Expenditures");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Expenditures",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_UserId",
                table: "Expenditures",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_AspNetUsers_UserId",
                table: "Expenditures",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
