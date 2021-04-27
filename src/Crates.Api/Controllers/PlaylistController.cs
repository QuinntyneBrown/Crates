using Crates.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Crates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController
    {
        private readonly IMediator _mediator;

        public PlaylistController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{playlistId}", Name = "GetPlaylistByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPlaylistById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPlaylistById.Response>> GetById([FromRoute] GetPlaylistById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Playlist == null)
            {
                return new NotFoundObjectResult(request.PlaylistId);
            }

            return response;
        }

        [HttpGet(Name = "GetPlaylistsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPlaylists.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPlaylists.Response>> Get()
        {
            try
            {
                return await _mediator.Send(new GetPlaylists.Request());
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost(Name = "CreatePlaylistRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreatePlaylist.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatePlaylist.Response>> Create([FromBody] CreatePlaylist.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetPlaylistsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPlaylistsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPlaylistsPage.Response>> Page([FromRoute] GetPlaylistsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdatePlaylistRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdatePlaylist.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdatePlaylist.Response>> Update([FromBody] UpdatePlaylist.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{playlistId}", Name = "RemovePlaylistRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemovePlaylist.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemovePlaylist.Response>> Remove([FromRoute] RemovePlaylist.Request request)
            => await _mediator.Send(request);

    }
}
