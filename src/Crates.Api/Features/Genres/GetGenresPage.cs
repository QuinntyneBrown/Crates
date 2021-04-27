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
    public class GetGenresPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<GenreDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
        
            public Handler(ICratesDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from genre in _context.Genres
                    select genre;
                
                var length = await _context.Genres.CountAsync();
                
                var genres = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = genres
                };
            }
            
        }
    }
}
