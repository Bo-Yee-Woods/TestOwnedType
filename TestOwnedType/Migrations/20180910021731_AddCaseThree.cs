using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestOwnedType.Migrations
{
    public partial class AddCaseThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: false),
                    ValueObject_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: false),
                    DocumentRefNo = table.Column<string>(nullable: false),
                    ComputedStampDuty_PropertyType = table.Column<int>(nullable: false),
                    ComputedStampDuty_SubmitedAt = table.Column<DateTime>(nullable: false),
                    ComputedStampDuty_BuyersStampDuty = table.Column<double>(nullable: false),
                    ComputedStampDuty_AdditionalBuyersStampDuty = table.Column<double>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRecords", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyEntities");

            migrationBuilder.DropTable(
                name: "PaymentRecords");
        }
    }
}
