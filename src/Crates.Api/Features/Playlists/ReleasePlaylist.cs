using Crates.Api.Core;
using Crates.Api.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Crates.Api.Features
{
    public class ReleasePlaylist
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Playlist).NotNull();
                RuleFor(request => request.Playlist).SetValidator(new PlaylistValidator());
            }
        }

        public class Request : IRequest<Response> { 
            public PlaylistDto Playlist { get; set; }        
        }

        public class Response: ResponseBase
        {
            public PlaylistDto Playlist { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
            private readonly IClock _clock;

            public Handler(ICratesDbContext context, IClock clock){
                _context = context;
                _clock = clock;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
            
                var playlist = await _context.Playlists
                    .FindAsync(request.Playlist.PlaylistId);

                playlist.Release(_clock.UtcNow);

                await _context.SaveChangesAsync(cancellationToken);
			    
                return new () { 
                    Playlist = playlist.ToDto()
                };
            }
        }
    }
}
