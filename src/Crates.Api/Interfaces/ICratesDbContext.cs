using Crates.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Crates.Api.Interfaces
{
    public interface ICratesDbContext
    {
        DbSet<Song> Songs { get; }
        DbSet<DigitalAsset> DigitalAssets { get; }
        DbSet<User> Users { get; }
        DbSet<Playlist> Playlists { get; }
        DbSet<PlaylistSong> PlaylistSongs { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
