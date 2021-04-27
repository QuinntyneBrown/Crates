using Crates.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crates.Api.Data
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasMany(x => x.Tracks)
                            .WithMany(x => x.Artists)
                            .UsingEntity<ArtistTrack>(
                                x => x.HasOne(x => x.Track)
                                .WithMany().HasForeignKey(x => x.TrackId),
                                x => x.HasOne(x => x.Artist)
                               .WithMany().HasForeignKey(x => x.ArtistId));
        }

    }
}
