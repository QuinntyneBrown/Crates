using Crates.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Crates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{genreId}", Name = "GetGenreByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetGenreById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetGenreById.Response>> GetById([FromRoute]GetGenreById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Genre == null)
            {
                return new NotFoundObjectResult(request.GenreId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetGenresRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetGenres.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetGenres.Response>> Get()
            => await _mediator.Send(new GetGenres.Request());
        
        [HttpPost(Name = "CreateGenreRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateGenre.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateGenre.Response>> Create([FromBody]CreateGenre.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetGenresPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetGenresPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetGenresPage.Response>> Page([FromRoute]GetGenresPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateGenreRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateGenre.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateGenre.Response>> Update([FromBody]UpdateGenre.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{genreId}", Name = "RemoveGenreRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveGenre.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveGenre.Response>> Remove([FromRoute]RemoveGenre.Request request)
            => await _mediator.Send(request);
        
    }
}
