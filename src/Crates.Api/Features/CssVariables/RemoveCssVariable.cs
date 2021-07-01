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
    public class RemoveCssVariable
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
                var cssVariable = await _context.CssVariables.SingleAsync(x => x.CssVariableId == request.CssVariableId);
                
                _context.CssVariables.Remove(cssVariable);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    CssVariable = cssVariable.ToDto()
                };
            }
            
        }
    }
}
