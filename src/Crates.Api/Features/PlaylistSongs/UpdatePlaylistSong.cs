using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Crates.Api.Core;
using Crates.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crates.Api.Features
{
    public class UpdatePlaylistSong
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
                var playlistSong = await _context.PlaylistSongs.SingleAsync(x => x.PlaylistSongId == request.PlaylistSong.PlaylistSongId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    PlaylistSong = playlistSong.ToDto()
                };
            }

        }
    }
}
