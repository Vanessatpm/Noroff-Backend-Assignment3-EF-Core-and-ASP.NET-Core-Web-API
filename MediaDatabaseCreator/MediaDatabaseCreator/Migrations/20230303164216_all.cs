using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediaDatabaseCreator.Migrations
{
    /// <inheritdoc />
    public partial class all : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Franchises",
                columns: table => new
                {
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.FranchiseId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTitle = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MoviePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieTrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterId = table.Column<int>(type: "int", nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchises",
                        principalColumn: "FranchiseId");
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.CharacterId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "Alias", "FullName", "Gender", "MovieId", "PictureUrl" },
                values: new object[,]
                {
                    { -6, "Ring bearer", "Frodo Baggins", "Male", null, "https://example.com/frodo.jpg" },
                    { -5, "General Leia Organa", "Princess Leia Organa", "Female", null, "https://www.imdb.com/title/tt0076759/mediaviewer/rm1222220800/" },
                    { -4, "Jedi Knight", "Luke Skywalker", "Male", null, "https://www.imdb.com/title/tt0076759/mediaviewer/rm2446233600/" },
                    { -3, "Thor", "Thor Odinson", "Male", null, "https://www.imdb.com/title/tt0800369/mediaviewer/rm1346871297/" },
                    { -2, "Captain America", "Steve Rogers", "Male", null, "https://www.imdb.com/title/tt0458339/mediaviewer/rm2483030016/" },
                    { -1, "Iron Man", "Tony Stark", "Male", null, "https://www.imdb.com/title/tt0371746/mediaviewer/rm1006248448/" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "FranchiseId", "Description", "Name" },
                values: new object[,]
                {
                    { -3, "An epic high fantasy novel by J.R.R. Tolkien", "The Lord of the Rings" },
                    { -2, "An epic space opera media franchise created by George Lucas", "Star Wars" },
                    { -1, "A series of superhero films produced by Marvel Studios", "Marvel Cinematic Universe" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "CharacterId", "Director", "FranchiseId", "Genre", "MoviePictureUrl", "MovieTitle", "MovieTrailerUrl", "ReleaseYear" },
                values: new object[,]
                {
                    { -3, null, "Peter Jackson", -3, "Action, Adventure, Drama", "https://www.imdb.com/title/tt0120737/mediaviewer/rm3693752064/", "The Lord of the Rings: The Fellowship of the Ring", "https://www.youtube.com/watch?v=V75dMMIW2B4", 2001 },
                    { -2, null, "George Lucas", -2, "Action, Adventure, Fantasy", "https://www.imdb.com/title/tt0076759/mediaviewer/rm3500569857/", "Star Wars: Episode IV - A New Hope", "https://www.youtube.com/watch?v=1g3_CFmnU7k", 1977 },
                    { -1, null, "Anthony Russo, Joe Russo", -2, "Action, Adventure, Drama", "https://www.imdb.com/title/tt4154796/mediaviewer/rm1057017345/", "Avengers: Endgame", "https://www.youtube.com/watch?v=TcMBFSGVi1c", 2019 }
                });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { -6, -1 },
                    { -3, -2 },
                    { -2, -3 },
                    { -2, -2 },
                    { -2, -1 },
                    { -1, -2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_MovieId",
                table: "CharacterMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FranchiseId",
                table: "Movies",
                column: "FranchiseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Franchises");
        }
    }
}
