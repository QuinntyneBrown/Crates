using System.Net;
using System.Threading.Tasks;
using Crates.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Crates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController
    {
        private readonly IMediator _mediator;

        public SongController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{songId}", Name = "GetSongByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSongById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSongById.Response>> GetById([FromRoute] GetSongById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Song == null)
            {
                return new NotFoundObjectResult(request.SongId);
            }

            return response;
        }

        [HttpGet(Name = "GetSongsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSongs.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSongs.Response>> Get()
            => await _mediator.Send(new GetSongs.Request());

        [HttpPost(Name = "CreateSongRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateSong.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateSong.Response>> Create([FromBody] CreateSong.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetSongsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSongsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSongsPage.Response>> Page([FromRoute] GetSongsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateSongRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateSong.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateSong.Response>> Update([FromBody] UpdateSong.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{songId}", Name = "RemoveSongRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveSong.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveSong.Response>> Remove([FromRoute] RemoveSong.Request request)
            => await _mediator.Send(request);

    }
}
