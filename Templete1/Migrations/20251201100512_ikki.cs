using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyiha_dars.Migrations
{
    /// <inheritdoc />
    public partial class ikki : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mualliflar_AspNetUsers_IdentityUserId1",
                table: "Mualliflar");

            migrationBuilder.DropIndex(
                name: "IX_Mualliflar_IdentityUserId1",
                table: "Mualliflar");

            migrationBuilder.DropColumn(
                name: "IdentityUserId1",
                table: "Mualliflar");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Mualliflar",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Mualliflar_IdentityUserId",
                table: "Mualliflar",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mualliflar_AspNetUsers_IdentityUserId",
                table: "Mualliflar",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mualliflar_AspNetUsers_IdentityUserId",
                table: "Mualliflar");

            migrationBuilder.DropIndex(
                name: "IX_Mualliflar_IdentityUserId",
                table: "Mualliflar");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityUserId",
                table: "Mualliflar",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId1",
                table: "Mualliflar",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mualliflar_IdentityUserId1",
                table: "Mualliflar",
                column: "IdentityUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Mualliflar_AspNetUsers_IdentityUserId1",
                table: "Mualliflar",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
