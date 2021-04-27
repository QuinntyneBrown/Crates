using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Crates.Api.Core;
using Crates.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crates.Api.Features
{
    public class UpdateAlbum
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Album).NotNull();
                RuleFor(request => request.Album).SetValidator(new AlbumValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public AlbumDto Album { get; set; }
        }

        public class Response: ResponseBase
        {
            public AlbumDto Album { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
        
            public Handler(ICratesDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var album = await _context.Albums.SingleAsync(x => x.AlbumId == request.Album.AlbumId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Album = album.ToDto()
                };
            }
            
        }
    }
}
