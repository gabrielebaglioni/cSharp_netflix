using cSharp_netflix.Models;
using Microsoft.EntityFrameworkCore;


public class ApplicationDbContext : DbContext
{
     public DbSet<Movie> Movies { get; set; }
        public DbSet<TvSeries> TvSeries { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<MediaInfo> MediaInfos { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }

    private const string ConnectionString = "Server=localhost;Database=db_netflix;User=sa;Password=Scheggia12$;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);

    }
    //DATA SEEDING
   

}
