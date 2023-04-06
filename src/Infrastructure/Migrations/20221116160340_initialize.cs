using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractMng.Infrastructure.Migrations;

public partial class initialize : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "ContractBudgets",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PlaceOfBudget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                SchemaNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ContractBudgets", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ContractDocuments",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ContractDocuments", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ContractLastStatuses",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ContractLastStatuses", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ContractLetters",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                LetterType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ContractLetters", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ContractParties",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ContractTypeId = table.Column<int>(type: "int", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ContractParties", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ContractPaymentMethods",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ContractPaymentMethods", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ContractTypes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ContractTypes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Contracts",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Party = table.Column<string>(type: "nvarchar(max)", nullable: false),
                StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                FinalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                BudgetPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Deleted = table.Column<bool>(type: "bit", nullable: false),
                ContractPartyId = table.Column<int>(type: "int", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Contracts", x => x.Id);
                table.ForeignKey(
                    name: "FK_Contracts_ContractParties_ContractPartyId",
                    column: x => x.ContractPartyId,
                    principalTable: "ContractParties",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "LastStatuses",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Progress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                AmountNumber = table.Column<int>(type: "int", nullable: false),
                ContractId = table.Column<int>(type: "int", nullable: false),
                Deleted = table.Column<bool>(type: "bit", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_LastStatuses", x => x.Id);
                table.ForeignKey(
                    name: "FK_LastStatuses_Contracts_ContractId",
                    column: x => x.ContractId,
                    principalTable: "Contracts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Letters",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LetterDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ContractId = table.Column<int>(type: "int", nullable: false),
                Deleted = table.Column<bool>(type: "bit", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Letters", x => x.Id);
                table.ForeignKey(
                    name: "FK_Letters_Contracts_ContractId",
                    column: x => x.ContractId,
                    principalTable: "Contracts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "TechnicalAttachments",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ContractId = table.Column<int>(type: "int", nullable: false),
                FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Deleted = table.Column<bool>(type: "bit", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TechnicalAttachments", x => x.Id);
                table.ForeignKey(
                    name: "FK_TechnicalAttachments_Contracts_ContractId",
                    column: x => x.ContractId,
                    principalTable: "Contracts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Contracts_ContractPartyId",
            table: "Contracts",
            column: "ContractPartyId");

        migrationBuilder.CreateIndex(
            name: "IX_LastStatuses_ContractId",
            table: "LastStatuses",
            column: "ContractId");

        migrationBuilder.CreateIndex(
            name: "IX_Letters_ContractId",
            table: "Letters",
            column: "ContractId");

        migrationBuilder.CreateIndex(
            name: "IX_TechnicalAttachments_ContractId",
            table: "TechnicalAttachments",
            column: "ContractId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ContractBudgets");

        migrationBuilder.DropTable(
            name: "ContractDocuments");

        migrationBuilder.DropTable(
            name: "ContractLastStatuses");

        migrationBuilder.DropTable(
            name: "ContractLetters");

        migrationBuilder.DropTable(
            name: "ContractPaymentMethods");

        migrationBuilder.DropTable(
            name: "ContractTypes");

        migrationBuilder.DropTable(
            name: "LastStatuses");

        migrationBuilder.DropTable(
            name: "Letters");

        migrationBuilder.DropTable(
            name: "TechnicalAttachments");

        migrationBuilder.DropTable(
            name: "Contracts");

        migrationBuilder.DropTable(
            name: "ContractParties");
    }
}
