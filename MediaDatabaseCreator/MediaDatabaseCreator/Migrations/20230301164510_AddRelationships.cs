using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediaDatabaseCreator.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_Characters_CharactersCharacterId",
                table: "CharacterMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_Movies_MoviesMovieId",
                table: "CharacterMovie");

            migrationBuilder.RenameColumn(
                name: "MoviesMovieId",
                table: "CharacterMovie",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "CharactersCharacterId",
                table: "CharacterMovie",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterMovie_MoviesMovieId",
                table: "CharacterMovie",
                newName: "IX_CharacterMovie_MovieId");

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

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: -3,
                column: "FranchiseId",
                value: -3);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: -2,
                column: "FranchiseId",
                value: -2);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: -1,
                column: "FranchiseId",
                value: -2);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_Characters_CharacterId",
                table: "CharacterMovie",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_Movies_MovieId",
                table: "CharacterMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_Characters_CharacterId",
                table: "CharacterMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_Movies_MovieId",
                table: "CharacterMovie");

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { -6, -1 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { -3, -2 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { -2, -3 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { -2, -2 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { -2, -1 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { -1, -2 });

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "CharacterMovie",
                newName: "MoviesMovieId");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "CharacterMovie",
                newName: "CharactersCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterMovie_MovieId",
                table: "CharacterMovie",
                newName: "IX_CharacterMovie_MoviesMovieId");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: -3,
                column: "FranchiseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: -2,
                column: "FranchiseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: -1,
                column: "FranchiseId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_Characters_CharactersCharacterId",
                table: "CharacterMovie",
                column: "CharactersCharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_Movies_MoviesMovieId",
                table: "CharacterMovie",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
