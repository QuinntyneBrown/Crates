using Crates.Api.Core;
using System;
using System.Collections.Generic;

namespace Crates.Api.Models
{
    public class Playlist
    {
        private readonly IClock _clock;
        public Guid PlaylistId { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Released { get; private set; }
        public List<Song> Songs { get; private set; } = new();
        public string Spotify { get; private set; }
        public Guid BoxArtDigitalAssetId { get; private set; }
        public void Release(IClock clock)
        {
            Released = clock.UtcNow;
        }

        public Playlist(IClock clock)
            :base()
        {
            _clock = clock;
        }

        private Playlist()
        {
            _clock ??= new SystemClock();
            Created = _clock.UtcNow;   
        }
    }
}
