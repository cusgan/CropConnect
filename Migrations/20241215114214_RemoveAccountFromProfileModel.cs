using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropConnect.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAccountFromProfileModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Account_AccountId",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_AccountId",
                table: "Profile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Profile_AccountId",
                table: "Profile",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Account_AccountId",
                table: "Profile",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
