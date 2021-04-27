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
    public class RemoveAlbum
    {
        public class Request: IRequest<Response>
        {
            public Guid AlbumId { get; set; }
        }

        public class Response: ResponseBase
        {
            public AlbumDto Album { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
        
            public Handler(ICratesDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var album = await _context.Albums.SingleAsync(x => x.AlbumId == request.AlbumId);
                
                _context.Albums.Remove(album);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Album = album.ToDto()
                };
            }
            
        }
    }
}
