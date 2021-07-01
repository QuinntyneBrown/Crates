using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Crates.Api.Core;
using Crates.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crates.Api.Features
{
    public class GetCssVariableById
    {
        public class Request: IRequest<Response>
        {
            public Guid CssVariableId { get; set; }
        }

        public class Response: ResponseBase
        {
            public CssVariableDto CssVariable { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
        
            public Handler(ICratesDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    CssVariable = (await _context.CssVariables.SingleOrDefaultAsync(x => x.CssVariableId == request.CssVariableId)).ToDto()
                };
            }
            
        }
    }
}
