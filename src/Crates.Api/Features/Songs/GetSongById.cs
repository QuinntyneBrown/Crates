using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Crates.Api.Core;
using Crates.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crates.Api.Features
{
    public class GetSongById
    {
        public class Request : IRequest<Response>
        {
            public Guid SongId { get; set; }
        }

        public class Response : ResponseBase
        {
            public SongDto Song { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;

            public Handler(ICratesDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new()
                {
                    Song = (await _context.Songs.SingleOrDefaultAsync(x => x.SongId == request.SongId)).ToDto()
                };
            }

        }
    }
}
