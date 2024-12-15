using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropConnect.Migrations
{
    /// <inheritdoc />
    public partial class FixProdImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ProductImage",
                table: "Posting",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ProductImage",
                table: "Posting",
                type: "varbinary(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);
        }
    }
}
