using Microsoft.EntityFrameworkCore.Migrations;

namespace _04.EfCodeFirstDemo.Migrations
{
    public partial class AddAuthorToQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Comments_CommentId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CommentId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CommentId",
                table: "Questions",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Comments_CommentId",
                table: "Questions",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
