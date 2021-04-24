using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Crates.Api.Core;
using Crates.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crates.Api.Features
{
    public class GetPlaylistSongs
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<PlaylistSongDto> PlaylistSongs { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
        
            public Handler(ICratesDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    PlaylistSongs = await _context.PlaylistSongs.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
