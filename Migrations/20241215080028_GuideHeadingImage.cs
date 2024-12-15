using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropConnect.Migrations
{
    /// <inheritdoc />
    public partial class GuideHeadingImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "HeadingImage",
                table: "Guide",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HeadingImage",
                table: "Guide",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);
        }
    }
}
