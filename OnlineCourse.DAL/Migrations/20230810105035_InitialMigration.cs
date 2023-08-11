using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineCourse.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    IsPaymment = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Speciality = table.Column<string>(type: "text", nullable: false),
                    TeacherLevel = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Experince = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseCategories_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "IsPaymment", "PaymentMethod", "UpdatedAt" },
                values: new object[] { 1L, new DateTime(2023, 8, 10, 10, 50, 35, 824, DateTimeKind.Utc).AddTicks(8986), null, true, 2, null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "DateOfBirth", "Email", "FirstName", "IsDeleted", "LastName", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 8, 10, 10, 50, 35, 824, DateTimeKind.Utc).AddTicks(8663), new DateTime(2001, 9, 10, 19, 0, 0, 0, DateTimeKind.Utc), "farruhulashov@gmail.com", "Farruh", null, "Ulashov", "+998905201669", null },
                    { 2L, new DateTime(2023, 8, 10, 10, 50, 35, 824, DateTimeKind.Utc).AddTicks(8667), new DateTime(2002, 8, 9, 19, 0, 0, 0, DateTimeKind.Utc), "samandaraliyev@gmail.com", "Samandar", null, "Aliyev", "+998912024099", null },
                    { 3L, new DateTime(2023, 8, 10, 10, 50, 35, 824, DateTimeKind.Utc).AddTicks(8669), new DateTime(2003, 8, 5, 19, 0, 0, 0, DateTimeKind.Utc), "nurullonurmatov@gmail.com", "Nurullo", null, "Nurmatov", "+998942240816", null },
                    { 4L, new DateTime(2023, 8, 10, 10, 50, 35, 824, DateTimeKind.Utc).AddTicks(8671), new DateTime(2002, 4, 12, 19, 0, 0, 0, DateTimeKind.Utc), "nodirbeknorboyev@gmail.com", "Nodirbek", null, "Norboyev", "+998903446861", null },
                    { 5L, new DateTime(2023, 8, 10, 10, 50, 35, 824, DateTimeKind.Utc).AddTicks(8674), new DateTime(2003, 9, 10, 19, 0, 0, 0, DateTimeKind.Utc), "abbosxonrisqulov1@gmail.com", "Abbosxon", null, "Risqulov", "+998911473900", null },
                    { 6L, new DateTime(2023, 8, 10, 10, 50, 35, 824, DateTimeKind.Utc).AddTicks(8676), new DateTime(2003, 6, 9, 19, 0, 0, 0, DateTimeKind.Utc), "elbekabdumannonov@gmail.com", "Elbek", null, "Abdumannonov", "+998916861910", null },
                    { 7L, new DateTime(2023, 8, 10, 10, 50, 35, 824, DateTimeKind.Utc).AddTicks(8679), new DateTime(2003, 4, 3, 19, 0, 0, 0, DateTimeKind.Utc), "manguberdimominov@gmail.com", "Manguberdi", null, "Mo'minov", "+998999941696", null },
                    { 8L, new DateTime(2023, 8, 10, 10, 50, 35, 824, DateTimeKind.Utc).AddTicks(8681), new DateTime(2002, 7, 10, 19, 0, 0, 0, DateTimeKind.Utc), "mansurjonmoydinov1@gmail.com", "Mansurjon", null, "Mo'ydinov", "+998908515979", null },
                    { 9L, new DateTime(2023, 8, 10, 10, 50, 35, 824, DateTimeKind.Utc).AddTicks(8683), new DateTime(2003, 11, 10, 19, 0, 0, 0, DateTimeKind.Utc), "xayrullaeshqobilov1@gmail.com", "Xayrulla", null, "Eshqobilov", "+998942224468", null },
                    { 10L, new DateTime(2023, 8, 10, 10, 50, 35, 824, DateTimeKind.Utc).AddTicks(8686), new DateTime(2003, 3, 3, 19, 0, 0, 0, DateTimeKind.Utc), "samandarabdunazarov@gmail.com", "Samandar", null, "Abdunazarov", "+998888103636", null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedAt", "DateOfBirth", "Email", "Experince", "FirstName", "IsDeleted", "LastName", "Phone", "Speciality", "TeacherLevel", "UpdatedAt" },
                values: new object[,]
                {
                    { 2L, new DateTime(2023, 8, 10, 10, 50, 35, 824, DateTimeKind.Utc).AddTicks(9008), new DateTime(1998, 2, 1, 19, 0, 0, 0, DateTimeKind.Utc), "jamshidmaruf@gmail.com", 3, "Jamshid", null, "Maruf", "+998 97 577 75 52", ".Net", 1, null },
                    { 3L, new DateTime(2023, 8, 10, 10, 50, 35, 824, DateTimeKind.Utc).AddTicks(9012), new DateTime(1986, 9, 8, 19, 0, 0, 0, DateTimeKind.Utc), "alisherkasimov@gmail.com", 7, "Alisher", null, "Kasimov", "+998990787878", "Foundation", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "EndDate", "IsDeleted", "OrderId", "Price", "StartDate", "StudentId", "TeacherId", "UpdatedAt" },
                values: new object[] { 1L, new DateTime(2023, 8, 10, 10, 50, 35, 824, DateTimeKind.Utc).AddTicks(9029), new DateTime(2023, 10, 27, 19, 0, 0, 0, DateTimeKind.Utc), null, 1L, 11150000.0, new DateTime(2023, 6, 6, 19, 0, 0, 0, DateTimeKind.Utc), 8L, 2L, null });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "Id", "CourseId", "CreatedAt", "Description", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 8, 10, 15, 50, 35, 824, DateTimeKind.Local).AddTicks(9046), ".Net is Cross Platform", null, ".Net", null },
                    { 2L, 1L, new DateTime(2023, 8, 10, 15, 50, 35, 824, DateTimeKind.Local).AddTicks(9055), "Foundation is beginner program!", null, "Foundation", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_CourseId",
                table: "CourseCategories",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OrderId",
                table: "Courses",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentId",
                table: "Courses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
