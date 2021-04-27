using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Crates.Api.Core;
using Crates.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crates.Api.Features
{
    public class UpdateGenre
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Genre).NotNull();
                RuleFor(request => request.Genre).SetValidator(new GenreValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public GenreDto Genre { get; set; }
        }

        public class Response: ResponseBase
        {
            public GenreDto Genre { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICratesDbContext _context;
        
            public Handler(ICratesDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var genre = await _context.Genres.SingleAsync(x => x.GenreId == request.Genre.GenreId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Genre = genre.ToDto()
                };
            }
            
        }
    }
}
