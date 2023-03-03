using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediaDatabaseCreator.Migrations
{
    /// <inheritdoc />
    public partial class addedSeededData : Migration
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
                    movieId = table.Column<int>(type: "int", nullable: true)
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
                    characterId = table.Column<int>(type: "int", nullable: true),
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
                name: "MovieCharacter",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCharacter", x => new { x.MovieId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_MovieCharacter_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCharacter_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "Alias", "FullName", "Gender", "PictureUrl", "movieId" },
                values: new object[,]
                {
                    { 1, "Iron Man", "Tony Stark", "Male", "https://www.imdb.com/title/tt0371746/mediaviewer/rm1006248448/", 1 },
                    { 2, "Captain America", "Steve Rogers", "Male", "https://www.imdb.com/title/tt0458339/mediaviewer/rm2483030016/", 1 },
                    { 3, "Thor", "Thor Odinson", "Male", "https://www.imdb.com/title/tt0800369/mediaviewer/rm1346871297/", 1 },
                    { 4, "Jedi Knight", "Luke Skywalker", "Male", "https://www.imdb.com/title/tt0076759/mediaviewer/rm2446233600/", 2 },
                    { 5, "General Leia Organa", "Princess Leia Organa", "Female", "https://www.imdb.com/title/tt0076759/mediaviewer/rm1222220800/", 2 },
                    { 6, "Ring bearer", "Frodo Baggins", "Male", "https://example.com/frodo.jpg", 3 }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "FranchiseId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A series of superhero films produced by Marvel Studios", "Marvel Cinematic Universe" },
                    { 2, "An epic space opera media franchise created by George Lucas", "Star Wars" },
                    { 3, "An epic high fantasy novel by J.R.R. Tolkien", "The Lord of the Rings" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Director", "FranchiseId", "Genre", "MoviePictureUrl", "MovieTitle", "MovieTrailerUrl", "ReleaseYear", "characterId" },
                values: new object[,]
                {
                    { 1, "Anthony Russo, Joe Russo", null, "Action, Adventure, Drama", "https://www.imdb.com/title/tt4154796/mediaviewer/rm1057017345/", "Avengers: Endgame", "https://www.youtube.com/watch?v=TcMBFSGVi1c", 2019, null },
                    { 2, "George Lucas", null, "Action, Adventure, Fantasy", "https://www.imdb.com/title/tt0076759/mediaviewer/rm3500569857/", "Star Wars: Episode IV - A New Hope", "https://www.youtube.com/watch?v=1g3_CFmnU7k", 1977, null },
                    { 3, "Peter Jackson", null, "Action, Adventure, Drama", "https://www.imdb.com/title/tt0120737/mediaviewer/rm3693752064/", "The Lord of the Rings: The Fellowship of the Ring", "https://www.youtube.com/watch?v=V75dMMIW2B4", 2001, null }
                });

            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 2, 3 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCharacter_CharacterId",
                table: "MovieCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FranchiseId",
                table: "Movies",
                column: "FranchiseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCharacter");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Franchises");
        }
    }
}
