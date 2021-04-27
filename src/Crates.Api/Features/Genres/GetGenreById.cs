using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Crates.Api.Core;
using Crates.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crates.Api.Features
{
    public class GetGenreById
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
                return new () {
                    Genre = (await _context.Genres.SingleOrDefaultAsync(x => x.GenreId == request.GenreId)).ToDto()
                };
            }
            
        }
    }
}
