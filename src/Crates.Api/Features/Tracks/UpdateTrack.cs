using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Crates.Api.Core;
using Crates.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crates.Api.Features
{
    public class UpdateTrack
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Track).NotNull();
                RuleFor(request => request.Track).SetValidator(new TrackValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public TrackDto Track { get; set; }
        }

        public class Response: ResponseBase
        {
            public TrackDto Track { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
        
            public Handler(ICratesDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var track = await _context.Tracks.SingleAsync(x => x.TrackId == request.Track.TrackId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Track = track.ToDto()
                };
            }
            
        }
    }
}
