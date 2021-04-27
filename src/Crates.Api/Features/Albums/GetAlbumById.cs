using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Crates.Api.Core;
using Crates.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crates.Api.Features
{
    public class GetAlbumById
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
                return new () {
                    Album = (await _context.Albums.SingleOrDefaultAsync(x => x.AlbumId == request.AlbumId)).ToDto()
                };
            }
            
        }
    }
}
