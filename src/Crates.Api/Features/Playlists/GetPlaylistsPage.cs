using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Crates.Api.Extensions;
using Crates.Api.Core;
using Crates.Api.Interfaces;
using Crates.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Crates.Api.Features
{
    public class GetPlaylistsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<PlaylistDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
        
            public Handler(ICratesDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from playlist in _context.Playlists
                    select playlist;
                
                var length = await _context.Playlists.CountAsync();
                
                var playlists = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = playlists
                };
            }
            
        }
    }
}
