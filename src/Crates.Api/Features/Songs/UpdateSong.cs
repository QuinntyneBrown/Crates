using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Crates.Api.Core;
using Crates.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crates.Api.Features
{
    public class UpdateSong
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Song).NotNull();
                RuleFor(request => request.Song).SetValidator(new SongValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public SongDto Song { get; set; }
        }

        public class Response: ResponseBase
        {
            public SongDto Song { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
        
            public Handler(ICratesDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var song = await _context.Songs.SingleAsync(x => x.SongId == request.Song.SongId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Song = song.ToDto()
                };
            }
            
        }
    }
}
