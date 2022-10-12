﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cSharp_netflix.Migrations
{
    public partial class InitialCreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisualisationCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TvSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonsCount = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisualisationCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    TvSeriesId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisualisationCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaInfos",
                columns: table => new
                {
                    MediaInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    TvSeriesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaInfos", x => x.MediaInfoId);
                    table.ForeignKey(
                        name: "FK_MediaInfos_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaInfos_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActorMediaInfo",
                columns: table => new
                {
                    CastId = table.Column<int>(type: "int", nullable: false),
                    MediaInfosMediaInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMediaInfo", x => new { x.CastId, x.MediaInfosMediaInfoId });
                    table.ForeignKey(
                        name: "FK_ActorMediaInfo_Actors_CastId",
                        column: x => x.CastId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMediaInfo_MediaInfos_MediaInfosMediaInfoId",
                        column: x => x.MediaInfosMediaInfoId,
                        principalTable: "MediaInfos",
                        principalColumn: "MediaInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureMediaInfo",
                columns: table => new
                {
                    FeaturesId = table.Column<int>(type: "int", nullable: false),
                    MediaInfosMediaInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureMediaInfo", x => new { x.FeaturesId, x.MediaInfosMediaInfoId });
                    table.ForeignKey(
                        name: "FK_FeatureMediaInfo_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureMediaInfo_MediaInfos_MediaInfosMediaInfoId",
                        column: x => x.MediaInfosMediaInfoId,
                        principalTable: "MediaInfos",
                        principalColumn: "MediaInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMediaInfo",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MediaInfosMediaInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMediaInfo", x => new { x.GenresId, x.MediaInfosMediaInfoId });
                    table.ForeignKey(
                        name: "FK_GenreMediaInfo_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMediaInfo_MediaInfos_MediaInfosMediaInfoId",
                        column: x => x.MediaInfosMediaInfoId,
                        principalTable: "MediaInfos",
                        principalColumn: "MediaInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMediaInfo_MediaInfosMediaInfoId",
                table: "ActorMediaInfo",
                column: "MediaInfosMediaInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_TvSeriesId",
                table: "Episodes",
                column: "TvSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureMediaInfo_MediaInfosMediaInfoId",
                table: "FeatureMediaInfo",
                column: "MediaInfosMediaInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMediaInfo_MediaInfosMediaInfoId",
                table: "GenreMediaInfo",
                column: "MediaInfosMediaInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaInfos_MovieId",
                table: "MediaInfos",
                column: "MovieId",
                unique: true,
                filter: "[MovieId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MediaInfos_TvSeriesId",
                table: "MediaInfos",
                column: "TvSeriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMediaInfo");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "FeatureMediaInfo");

            migrationBuilder.DropTable(
                name: "GenreMediaInfo");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MediaInfos");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "TvSeries");
        }
    }
}
