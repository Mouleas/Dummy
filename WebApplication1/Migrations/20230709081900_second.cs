using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserModel_DeptId",
                table: "UserModel");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_DeptId",
                table: "UserModel",
                column: "DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserModel_DeptId",
                table: "UserModel");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_DeptId",
                table: "UserModel",
                column: "DeptId",
                unique: true);
        }
    }
}
