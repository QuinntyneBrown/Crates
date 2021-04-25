using Crates.Api.Core;
using Crates.Api.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Crates.Api.Features
{
    public class GetCurrentUser
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public UserDto User { get; init; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
            private readonly IHttpContextAccessor _httpContextAccessor;
            public Handler(ICratesDbContext context, IHttpContextAccessor httpContextAccessor)
            {
                _context = context;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    return new()
                    {
                        User = UserDto.Anonymous
                    };
                }

                var userId = new System.Guid(_httpContextAccessor.HttpContext.User.FindFirst(Constants.ClaimTypes.UserId).Value);

                var user = await _context.Users
                    .SingleOrDefaultAsync(x => x.UserId == userId, cancellationToken);

                return new()
                {
                    User = user == null ? UserDto.Anonymous : user.ToDto()
                };
            }
        }
    }
}
