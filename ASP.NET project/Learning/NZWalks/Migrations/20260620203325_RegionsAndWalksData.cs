using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Migrations
{
    /// <inheritdoc />
    public partial class RegionsAndWalksData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("270c8c35-d791-4346-a0af-cf944cecc6e7"), "Hard" },
                    { new Guid("8e482dcb-811b-4abc-873d-8e2bcb092381"), "Medium" },
                    { new Guid("9b1ac5bb-9241-47c8-9217-ac21ae9f1c88"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0529e642-73fa-4937-b127-a8841ab27ec5"), "AKL", "Auckland", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/45/Auckland_Region_location_in_New_Zealand.svg/250px-Auckland_Region_location_in_New_Zealand.svg.png" },
                    { new Guid("2bd150db-ebf5-4420-b4da-39d3ad60f1b1"), "OTA", "Otago", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/94/Otago_Region_location_in_New_Zealand.svg/250px-Otago_Region_location_in_New_Zealand.svg.png" },
                    { new Guid("3b1e32dc-a9ff-4d11-b06c-82e057398b50"), "WKO", "Waikato", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/Waikato_Region_location_in_New_Zealand.svg/250px-Waikato_Region_location_in_New_Zealand.svg.png" },
                    { new Guid("6787889d-7db0-47b0-8c20-7f5fb9c9ff45"), "BOP", "Bay Of Plenty", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/Bay_of_Plenty_Region_location_in_New_Zealand.svg/250px-Bay_of_Plenty_Region_location_in_New_Zealand.svg.png" },
                    { new Guid("8531ecb9-509a-4130-b384-56b9c97b2d56"), "CAN", "Canterbury", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/90/Canterbury_Region_location_in_New_Zealand.svg/250px-Canterbury_Region_location_in_New_Zealand.svg.png" },
                    { new Guid("bba41656-6ba9-4e78-bac6-446ae3597cfc"), "WTC", "West Coast", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/West_Coast_Region_location_in_New_Zealand.svg/250px-West_Coast_Region_location_in_New_Zealand.svg.png" },
                    { new Guid("c2cc249f-ec19-48ba-8898-e71cba88ea1f"), "WGN", "Wellington", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cd/Wellington_Region_location_in_New_Zealand.svg/250px-Wellington_Region_location_in_New_Zealand.svg.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("270c8c35-d791-4346-a0af-cf944cecc6e7"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8e482dcb-811b-4abc-873d-8e2bcb092381"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9b1ac5bb-9241-47c8-9217-ac21ae9f1c88"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0529e642-73fa-4937-b127-a8841ab27ec5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2bd150db-ebf5-4420-b4da-39d3ad60f1b1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3b1e32dc-a9ff-4d11-b06c-82e057398b50"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6787889d-7db0-47b0-8c20-7f5fb9c9ff45"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8531ecb9-509a-4130-b384-56b9c97b2d56"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("bba41656-6ba9-4e78-bac6-446ae3597cfc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c2cc249f-ec19-48ba-8898-e71cba88ea1f"));
        }
    }
}
