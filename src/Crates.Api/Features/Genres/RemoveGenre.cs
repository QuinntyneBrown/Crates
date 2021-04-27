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
    public class RemoveGenre
    {
        public class Request: IRequest<Response>
        {
            public Guid GenreId { get; set; }
        }

        public class Response: ResponseBase
        {
            public GenreDto Genre { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
        
            public Handler(ICratesDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var genre = await _context.Genres.SingleAsync(x => x.GenreId == request.GenreId);
                
                _context.Genres.Remove(genre);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Genre = genre.ToDto()
                };
            }
            
        }
    }
}
