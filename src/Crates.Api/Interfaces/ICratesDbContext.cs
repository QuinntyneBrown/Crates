using Crates.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Crates.Api.Interfaces
{
    public interface ICratesDbContext
    {
        DbSet<DigitalAsset> DigitalAssets { get; }
        DbSet<User> Users { get; }
        DbSet<Playlist> Playlists { get; }
        DbSet<PlaylistTrack> PlaylistTracks { get; }
        DbSet<Artist> Artists { get; }
        DbSet<Genre> Genres { get; }
        DbSet<Track> Tracks { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
