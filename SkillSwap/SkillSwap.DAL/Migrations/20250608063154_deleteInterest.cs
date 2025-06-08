using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillSwap.DAL.Migrations
{
    /// <inheritdoc />
    public partial class deleteInterest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Interests_InterestID",
                table: "UserAccounts");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_InterestID",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "InterestID",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "PartnerAmount",
                table: "UserAccounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InterestID",
                table: "UserAccounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartnerAmount",
                table: "UserAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterestName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_InterestID",
                table: "UserAccounts",
                column: "InterestID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Interests_InterestID",
                table: "UserAccounts",
                column: "InterestID",
                principalTable: "Interests",
                principalColumn: "InterestID");
        }
    }
}
