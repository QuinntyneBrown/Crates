using System;
using System.Collections.Generic;

namespace Crates.Api.Models
{
    public class Playlist
    {
        public Guid PlaylistId { get; private set; }
        public string Name { get; private set; }
        public DateTime Created { get; private set; } = DateTime.UtcNow;
        public DateTime Released { get; private set; }
        public List<PlaylistTrack> PlaylistTracks { get; private set; } = new();
        public List<Track> Tracks { get; private set; } = new();
        public string Spotify { get; private set; }
        public Guid CoverArtDigitalAssetId { get; private set; }

        public Playlist(DateTime created)
        {
            Created = created;
        }

        public Playlist(DateTime created, Guid coverArtDigitalAssetId)
        {
            Created = created;
            CoverArtDigitalAssetId = coverArtDigitalAssetId;
        }

        private Playlist()
        {
   
        }

        public void Release(DateTime released)
        {
            Released = released;
        }

        public void SetName(string  name)
        {
            Name = name;
        }

        public void AddTrack(Track track)
        {
            Tracks.Add(track);
        }

        public void RemoveTrack(Track track)
        {
            Tracks.Remove(track);
        }
    }
}
