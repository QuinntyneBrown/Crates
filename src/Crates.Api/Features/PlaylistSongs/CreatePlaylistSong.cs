using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Crates.Api.Models;
using Crates.Api.Core;
using Crates.Api.Interfaces;

namespace Crates.Api.Features
{
    public class CreatePlaylistSong
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.PlaylistSong).NotNull();
                RuleFor(request => request.PlaylistSong).SetValidator(new PlaylistSongValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public PlaylistSongDto PlaylistSong { get; set; }
        }

        public class Response : ResponseBase
        {
            public PlaylistSongDto PlaylistSong { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;

            public Handler(ICratesDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var playlistSong = new PlaylistSong();

                _context.PlaylistSongs.Add(playlistSong);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    PlaylistSong = playlistSong.ToDto()
                };
            }

        }
    }
}
