using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nosso_portifolio_api.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Job_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_User_AuthorId",
                table: "Job");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Job",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_AuthorId",
                table: "Job",
                newName: "IX_Job_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_User_UserId",
                table: "Job",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_User_UserId",
                table: "Job");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Job",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_UserId",
                table: "Job",
                newName: "IX_Job_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_User_AuthorId",
                table: "Job",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
