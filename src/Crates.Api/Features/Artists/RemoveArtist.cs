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
    public class RemoveArtist
    {
        public class Request : IRequest<Response>
        {
            public Guid ArtistId { get; set; }
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
                var artist = await _context.Artists.SingleAsync(x => x.ArtistId == request.ArtistId);

                _context.Artists.Remove(artist);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Artist = artist.ToDto()
                };
            }

        }
    }
}
