using Crates.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crates.Api.Data
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasMany(x => x.Songs)
                            .WithMany(x => x.Artists)
                            .UsingEntity<ArtistSong>(
                                x => x.HasOne(x => x.Song)
                                .WithMany().HasForeignKey(x => x.SongId),
                                x => x.HasOne(x => x.Artist)
                               .WithMany().HasForeignKey(x => x.ArtistId));
        }

    }
}
