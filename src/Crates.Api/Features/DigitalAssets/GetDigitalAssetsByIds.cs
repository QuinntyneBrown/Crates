using Crates.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Crates.Api.Features
{
    public class GetDigitalAssetsByIds
    {
        public class Request : IRequest<Response>
        {
            public System.Guid[] DigitalAssetIds { get; init; }
        }

        public class Response
        {
            public List<DigitalAssetDto> DigitalAssets { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public ICratesDbContext _context { get; init; }
            public Handler(ICratesDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    DigitalAssets = await _context.DigitalAssets
                    .Where(x => request.DigitalAssetIds.Contains(x.DigitalAssetId))
                    .Select(x => x.ToDto())
                    .ToListAsync()
                };
        }
    }
}