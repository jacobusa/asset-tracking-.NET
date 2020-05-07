using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetTracking.Data.Migrations
{
    public partial class CreateAssetTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagNumber = table.Column<string>(nullable: false),
                    AssetTypeId = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_AssetType_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Computer" });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Monitor" });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Phone" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "AssetTypeId", "Description", "Manufacturer", "Model", "SerialNumber", "TagNumber" },
                values: new object[,]
                {
                    { 1, 1, "A fine laptop", "Dell", "Dell XPS 13", "ERT456SDF", "JU45VD" },
                    { 2, 1, "A finer laptop", "HP", "Surface Studio 2", "MNB678ERT", "JI78RD" },
                    { 3, 1, "The finest laptop", "Acer", "Swift 3", "JRH765RGO", "BN67FT" },
                    { 4, 2, "A fine monitor", "Acer", "K2", "IUY234SDF", "KJ98TY" },
                    { 5, 2, "A finer monitor", "LG", "UltraWide® WQHD Nano IPS Monitor with Thunderbolt™ 3", "JSE678DVH", "JI65ER" },
                    { 6, 2, "The finest monitor", "HP", "E344c 34-inch Curved Monitor", "JEI876RHY", "CD89WQ" },
                    { 7, 3, "A fully refurbished used phone", "Avaya", "Avaya 1408", "KJH678UYT", "IJ87ER" },
                    { 8, 3, "A modern, four-line, basic IP desk phone", "Polycom", "Polycom 250 Ip Phone", "NSH876ERT", "ML82WE" },
                    { 9, 3, "Three-way Calling (Conference)On-hook DialingCall", "Cisco", "Cisco SPA 303 IP Phone", "HUE876ERT", "IJ27RD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetTypeId",
                table: "Asset",
                column: "AssetTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "AssetType");
        }
    }
}
