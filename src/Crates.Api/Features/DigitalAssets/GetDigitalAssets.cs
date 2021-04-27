using Crates.Api.Core;
using Crates.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Crates.Api.Features
{
    public class GetDigitalAssets
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<SimplifiedDigitalAssetDto> DigitalAssets { get; set; }
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
                    DigitalAssets = await _context.DigitalAssets.Select(x => x.ToSimplifiedDto()).ToListAsync()
                };
            }
        }
    }
}
