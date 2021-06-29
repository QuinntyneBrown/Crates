using Crates.Api.Models;
using System.Linq;

namespace Crates.Api.Features
{
    public static class PlaylistExtensions
    {
        public static PlaylistDto ToDto(this Playlist playlist)
        {
            return new()
            {
                PlaylistId = playlist.PlaylistId,
                Name = playlist.Name,
                Created = playlist.Created,
                Released = playlist.Released,
                Tracks = playlist.Tracks.Select(x => x.ToDto()).ToList(),
                Spotify = playlist.Spotify,
                CoverArtDigitalAssetId = playlist.CoverArtDigitalAssetId
            };
        }
    }
}
