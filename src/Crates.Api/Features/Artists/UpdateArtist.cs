using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Crates.Api.Core;
using Crates.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crates.Api.Features
{
    public class UpdateArtist
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Artist).NotNull();
                RuleFor(request => request.Artist).SetValidator(new ArtistValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public ArtistDto Artist { get; set; }
        }

        public class Response : ResponseBase
        {
            public ArtistDto Artist { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;

            public Handler(ICratesDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var artist = await _context.Artists.SingleAsync(x => x.ArtistId == request.Artist.ArtistId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Artist = artist.ToDto()
                };
            }

        }
    }
}
