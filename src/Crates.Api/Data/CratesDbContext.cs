using Crates.Api.Models;
using Crates.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crates.Api.Data
{
    public class CratesDbContext: DbContext, ICratesDbContext
    {
        public DbSet<Song> Songs { get; private set; }
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<Playlist> Playlists { get; private set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; private set; }
        public CratesDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CratesDbContext).Assembly);
        }
        
    }
}
