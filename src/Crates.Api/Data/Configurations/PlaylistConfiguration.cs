using Crates.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crates.Api.Data
{
    public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.HasMany(x => x.Tracks)
                            .WithMany(x => x.Playlists)
                            .UsingEntity<PlaylistTrack>(
                                x => x.HasOne(x => x.Track)
                                .WithMany().HasForeignKey(x => x.TrackId),
                                x => x.HasOne(x => x.Playlist)
                               .WithMany().HasForeignKey(x => x.PlaylistId));
        }

    }
}
