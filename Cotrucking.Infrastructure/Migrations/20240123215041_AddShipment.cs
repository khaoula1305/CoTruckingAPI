using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrucking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddShipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransporterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OriginAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CargoDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateTimeOfShipment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_Addresses_DestinationAddressId",
                        column: x => x.DestinationAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shipments_Addresses_OriginAddressId",
                        column: x => x.OriginAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipments_CustomerDataModel_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerDataModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shipments_Transporters_TransporterId",
                        column: x => x.TransporterId,
                        principalTable: "Transporters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CustomerId",
                table: "Shipments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_DestinationAddressId",
                table: "Shipments",
                column: "DestinationAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_OriginAddressId",
                table: "Shipments",
                column: "OriginAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_TransporterId",
                table: "Shipments",
                column: "TransporterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
