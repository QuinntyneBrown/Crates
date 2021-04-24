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
    public class RemoveSong
    {
        public class Request: IRequest<Response>
        {
            public Guid SongId { get; set; }
        }

        public class Response: ResponseBase
        {
            public SongDto Song { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
        
            public Handler(ICratesDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var song = await _context.Songs.SingleAsync(x => x.SongId == request.SongId);
                
                _context.Songs.Remove(song);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Song = song.ToDto()
                };
            }
            
        }
    }
}
