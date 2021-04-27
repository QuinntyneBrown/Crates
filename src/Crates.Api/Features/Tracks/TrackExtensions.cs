using Crates.Api.Models;
using System.Linq;

namespace Crates.Api.Features
{
    public static class TrackExtensions
    {
        public static TrackDto ToDto(this Track track)
        {
            return new ()
            {
                TrackId = track.TrackId,
                Name = track.Name,
                Artists = track.Artists.Select(x => x.ToDto()).ToList(),
                Playlists = track.Playlists.Select(x => x.ToDto()).ToList(),
                Spotify = track.Spotify,
                AppleMusic = track.AppleMusic,
                Album = track.Album.ToDto(),
                CoverArtDigitalAssetId = track.CoverArtDigitalAssetId
            };
        }
        
    }
}
