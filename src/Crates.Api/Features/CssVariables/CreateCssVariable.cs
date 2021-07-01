using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Crates.Api.Models;
using Crates.Api.Core;
using Crates.Api.Interfaces;

namespace Crates.Api.Features
{
    public class CreateCssVariable
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.CssVariable).NotNull();
                RuleFor(request => request.CssVariable).SetValidator(new CssVariableValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public CssVariableDto CssVariable { get; set; }
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
                var cssVariable = new CssVariable(request.CssVariable.Name, request.CssVariable.Value);
                
                _context.CssVariables.Add(cssVariable);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    CssVariable = cssVariable.ToDto()
                };
            }
            
        }
    }
}
