using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractMng.Infrastructure.Migrations;

public partial class contractPartyId : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Party",
            table: "Contracts");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Party",
            table: "Contracts",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");
    }
}
