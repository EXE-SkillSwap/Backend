using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillSwap.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MembershipSubscriptions_MembershipID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MembershipID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MembershipID",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MembershipID",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MembershipID",
                table: "Orders",
                column: "MembershipID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MembershipSubscriptions_MembershipID",
                table: "Orders",
                column: "MembershipID",
                principalTable: "MembershipSubscriptions",
                principalColumn: "MembershipID");
        }
    }
}
