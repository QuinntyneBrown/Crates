using Crates.Api.Core;
using Crates.Api.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Crates.Api.Features
{
    public class RemoveUser
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.UserId).NotNull().NotEmpty();
            }
        }

        public class Request : IRequest<ResponseBase>
        {
            public System.Guid UserId { get; set; }
        }


        public class Handler : IRequestHandler<Request, ResponseBase>
        {
            private readonly ICratesDbContext _context;

            public Handler(ICratesDbContext context)
            {
                _context = context;
            }

            public async Task<ResponseBase> Handle(Request request, CancellationToken cancellationToken)
            {

                var user = await _context.Users.FindAsync(request.UserId);

                _context.Users.Remove(user);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {

                };
            }
        }
    }
}
