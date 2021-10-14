using Microsoft.EntityFrameworkCore.Migrations;

namespace SaitynasLab1.Migrations
{
    public partial class Addedforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "memberId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClanId",
                table: "Members",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_memberId",
                table: "Posts",
                column: "memberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ClanId",
                table: "Members",
                column: "ClanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Clans_ClanId",
                table: "Members",
                column: "ClanId",
                principalTable: "Clans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Members_memberId",
                table: "Posts",
                column: "memberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Clans_ClanId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Members_memberId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_memberId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Members_ClanId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "memberId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "ClanId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
