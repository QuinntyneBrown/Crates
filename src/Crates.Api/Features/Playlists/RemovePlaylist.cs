using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Crates.Api.Models;
using Crates.Api.Core;
using Crates.Api.Interfaces;

namespace Crates.Api.Features
{
    public class RemovePlaylist
    {
        public class Request: IRequest<Response>
        {
            public Guid PlaylistId { get; set; }
        }

        public class Response: ResponseBase
        {
            public PlaylistDto Playlist { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
        
            public Handler(ICratesDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var playlist = await _context.Playlists.SingleAsync(x => x.PlaylistId == request.PlaylistId);
                
                _context.Playlists.Remove(playlist);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Playlist = playlist.ToDto()
                };
            }
            
        }
    }
}
