using Crates.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crates.Api.Data
{
    public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.HasMany(x => x.Songs)
                            .WithMany(x => x.Playlists)
                            .UsingEntity<PlaylistSong>(
                                x => x.HasOne(x => x.Song)
                                .WithMany().HasForeignKey(x => x.SongId),
                                x => x.HasOne(x => x.Playlist)
                               .WithMany().HasForeignKey(x => x.PlaylistId));
        }

    }
}
