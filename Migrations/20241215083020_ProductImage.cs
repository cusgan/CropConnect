using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropConnect.Migrations
{
    /// <inheritdoc />
    public partial class ProductImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ProductImage",
                table: "Posting",
                type: "varbinary(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductImage",
                table: "Posting",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(byte[]),
                oldType: "varbinary(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
