using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Crates.Api.Models;
using Crates.Api.Core;
using Crates.Api.Interfaces;

namespace Crates.Api.Features
{
    public class CreatePlaylist
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Playlist).NotNull();
                RuleFor(request => request.Playlist).SetValidator(new PlaylistValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public PlaylistDto Playlist { get; set; }
        }

        public class Response: ResponseBase
        {
            public PlaylistDto Playlist { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
        
            public Handler(ICratesDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var playlist = new Playlist();
                
                _context.Playlists.Add(playlist);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Playlist = playlist.ToDto()
                };
            }
            
        }
    }
}
