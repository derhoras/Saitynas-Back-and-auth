using Microsoft.EntityFrameworkCore.Migrations;

namespace SaitynasLab1.Migrations
{
    public partial class UpdForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Clans_ClanId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Members_memberId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "memberId",
                table: "Posts",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_memberId",
                table: "Posts",
                newName: "IX_Posts_MemberId");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClanId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Clans_ClanId",
                table: "Members",
                column: "ClanId",
                principalTable: "Clans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Members_MemberId",
                table: "Posts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Clans_ClanId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Members_MemberId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Posts",
                newName: "memberId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_MemberId",
                table: "Posts",
                newName: "IX_Posts_memberId");

            migrationBuilder.AlterColumn<int>(
                name: "memberId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClanId",
                table: "Members",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
