using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace zadanie10.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    IDdoctor = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Doctor_pk", x => x.IDdoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Medicament_pk", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Patient_pk", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prescription_pk", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "Prescription_Doctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IDdoctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Prescription_Patient",
                        column: x => x.IdPatient,
                        principalTable: "Patient",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrescriptionMedicament_pk", x => new { x.IdPrescription, x.IdMedicament });
                    table.ForeignKey(
                        name: "PrescriptionMedicament_Medicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicament",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PrescriptionMedicament_Prescription",
                        column: x => x.IdPrescription,
                        principalTable: "Prescription",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IDdoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "jan.kowalski@gmail.com", "Jan", "Kowalski" },
                    { 2, "tomasz.problem@gmail.com", "Tomasz", "Problem" },
                    { 3, "ala.makota@gmail.com", "Ala", "Makota" }
                });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "słabe", "APAP", "przeciwbólowe" },
                    { 2, "średnie", "Smecta", "na biegunkę" },
                    { 3, "mocne", "Forlax", "na zaparcia" },
                    { 4, "delikatne", "Bepanthen", "na podrażnienie skóry" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ula", "Mapsa" },
                    { 2, new DateTime(1995, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ela", "Manic" },
                    { 3, new DateTime(1998, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrzej", "Towalnie" }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 4, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 5, new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 6, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 7, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "onie", 3 },
                    { 2, 1, "o t a k", 2 },
                    { 4, 1, "otak", 1 },
                    { 2, 2, "ojej", 1 },
                    { 3, 2, "o j e j", 3 },
                    { 1, 3, "omatko", 1 },
                    { 4, 3, "o matko", 5 },
                    { 1, 4, "o", 5 },
                    { 3, 5, "a", 1 },
                    { 1, 6, "aaaa", 2 },
                    { 4, 6, "oooo", 6 },
                    { 1, 7, "yyy", 6 },
                    { 2, 7, "eee", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdDoctor",
                table: "Prescription",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdPatient",
                table: "Prescription",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_IdMedicament",
                table: "Prescription_Medicament",
                column: "IdMedicament");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament");

            migrationBuilder.DropTable(
                name: "Medicament");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
