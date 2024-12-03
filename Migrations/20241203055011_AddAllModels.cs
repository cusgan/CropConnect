using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace CropConnect.Migrations
{
    /// <inheritdoc />
    public partial class AddAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Farm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OwnerAccountId = table.Column<int>(type: "int", nullable: false),
                    FarmName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FarmType = table.Column<int>(type: "int", nullable: false),
                    FarmSize = table.Column<int>(type: "int", nullable: false),
                    ContactInfo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Farm_Account_OwnerAccountId",
                        column: x => x.OwnerAccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Account_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_Account_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Destination = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_Account_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Posting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PosterId = table.Column<int>(type: "int", nullable: false),
                    ProductImage = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ProductName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ProductDescription = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    UnitType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posting_Account_PosterId",
                        column: x => x.PosterId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Bio = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    WorkExperience = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RatedId = table.Column<int>(type: "int", nullable: false),
                    RaterId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<float>(type: "float", nullable: false),
                    Content = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Account_RatedId",
                        column: x => x.RatedId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Account_RaterId",
                        column: x => x.RaterId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Farm_OwnerAccountId",
                table: "Farm",
                column: "OwnerAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ReceiverId",
                table: "Message",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                table: "Message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ReceiverId",
                table: "Notification",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Posting_PosterId",
                table: "Posting",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_AccountId",
                table: "Profile",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_RatedId",
                table: "Rating",
                column: "RatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_RaterId",
                table: "Rating",
                column: "RaterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Farm");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Posting");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Rating");
        }
    }
}
