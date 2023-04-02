using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebQueue.Migrations
{
    /// <inheritdoc />
    public partial class bug_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "messages");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "logs");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "messages",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "messages",
                newName: "body");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "messages",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ReceiptTime",
                table: "messages",
                newName: "receipt_time");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "logs",
                newName: "time");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "logs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastMessageId",
                table: "logs",
                newName: "last_message_id");

            migrationBuilder.RenameColumn(
                name: "Context",
                table: "logs",
                newName: "action_context");

            migrationBuilder.AddPrimaryKey(
                name: "PK_messages",
                table: "messages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_logs",
                table: "logs",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_messages",
                table: "messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_logs",
                table: "logs");

            migrationBuilder.RenameTable(
                name: "messages",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "logs",
                newName: "Logs");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Messages",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "body",
                table: "Messages",
                newName: "Body");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Messages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "receipt_time",
                table: "Messages",
                newName: "ReceiptTime");

            migrationBuilder.RenameColumn(
                name: "time",
                table: "Logs",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Logs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_message_id",
                table: "Logs",
                newName: "LastMessageId");

            migrationBuilder.RenameColumn(
                name: "action_context",
                table: "Logs",
                newName: "Context");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "Id");
        }
    }
}
