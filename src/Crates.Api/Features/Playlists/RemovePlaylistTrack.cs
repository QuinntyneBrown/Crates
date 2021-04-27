using Crates.Api.Core;
using Crates.Api.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Crates.Api.Features
{
    public class RemovePlaylistTrack
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {

            }
        }

        public class Request : IRequest<Response>
        {
            public Guid PlaylistId { get; set; }
            public Guid TrackId { get; set; }
        }

        public class Response : ResponseBase
        {
            public PlaylistDto Playlist { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;

            public Handler(ICratesDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var playlist = await _context.Playlists
                    .Include(x => x.Tracks)
                    .SingleAsync(x => x.PlaylistId == request.PlaylistId);

                var track = await _context.Tracks.FindAsync(request.TrackId);

                playlist.RemoveTrack(track);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Playlist = playlist.ToDto()
                };
            }
        }
    }
}
