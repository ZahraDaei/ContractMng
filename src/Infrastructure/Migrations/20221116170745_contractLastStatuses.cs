using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractMng.Infrastructure.Migrations;

public partial class contractLastStatuses : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "ContractLastStatusId",
            table: "LastStatuses",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.CreateIndex(
            name: "IX_LastStatuses_ContractLastStatusId",
            table: "LastStatuses",
            column: "ContractLastStatusId");

        migrationBuilder.AddForeignKey(
            name: "FK_LastStatuses_ContractLastStatuses_ContractLastStatusId",
            table: "LastStatuses",
            column: "ContractLastStatusId",
            principalTable: "ContractLastStatuses",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_LastStatuses_ContractLastStatuses_ContractLastStatusId",
            table: "LastStatuses");

        migrationBuilder.DropIndex(
            name: "IX_LastStatuses_ContractLastStatusId",
            table: "LastStatuses");

        migrationBuilder.DropColumn(
            name: "ContractLastStatusId",
            table: "LastStatuses");
    }
}
