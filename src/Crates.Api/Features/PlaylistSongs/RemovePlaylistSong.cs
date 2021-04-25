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
    public class RemovePlaylistSong
    {
        public class Request : IRequest<Response>
        {
            public Guid PlaylistSongId { get; set; }
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
                var playlistSong = await _context.PlaylistSongs.SingleAsync(x => x.PlaylistSongId == request.PlaylistSongId);

                _context.PlaylistSongs.Remove(playlistSong);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    PlaylistSong = playlistSong.ToDto()
                };
            }

        }
    }
}
