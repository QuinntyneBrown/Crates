using Crates.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Crates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController
    {
        private readonly IMediator _mediator;

        public ArtistController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{artistId}", Name = "GetArtistByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetArtistById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetArtistById.Response>> GetById([FromRoute] GetArtistById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Artist == null)
            {
                return new NotFoundObjectResult(request.ArtistId);
            }

            return response;
        }

        [HttpGet(Name = "GetArtistsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetArtists.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetArtists.Response>> Get()
            => await _mediator.Send(new GetArtists.Request());

        [HttpPost(Name = "CreateArtistRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateArtist.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateArtist.Response>> Create([FromBody] CreateArtist.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetArtistsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetArtistsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetArtistsPage.Response>> Page([FromRoute] GetArtistsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateArtistRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateArtist.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateArtist.Response>> Update([FromBody] UpdateArtist.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{artistId}", Name = "RemoveArtistRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveArtist.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveArtist.Response>> Remove([FromRoute] RemoveArtist.Request request)
            => await _mediator.Send(request);
    }
}
