using System.Net;
using System.Threading.Tasks;
using Crates.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Crates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistSongController
    {
        private readonly IMediator _mediator;

        public PlaylistSongController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{playlistSongId}", Name = "GetPlaylistSongByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPlaylistSongById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPlaylistSongById.Response>> GetById([FromRoute]GetPlaylistSongById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.PlaylistSong == null)
            {
                return new NotFoundObjectResult(request.PlaylistSongId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetPlaylistSongsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPlaylistSongs.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPlaylistSongs.Response>> Get()
            => await _mediator.Send(new GetPlaylistSongs.Request());
        
        [HttpPost(Name = "CreatePlaylistSongRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreatePlaylistSong.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatePlaylistSong.Response>> Create([FromBody]CreatePlaylistSong.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetPlaylistSongsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPlaylistSongsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPlaylistSongsPage.Response>> Page([FromRoute]GetPlaylistSongsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdatePlaylistSongRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdatePlaylistSong.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdatePlaylistSong.Response>> Update([FromBody]UpdatePlaylistSong.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{playlistSongId}", Name = "RemovePlaylistSongRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemovePlaylistSong.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemovePlaylistSong.Response>> Remove([FromRoute]RemovePlaylistSong.Request request)
            => await _mediator.Send(request);
        
    }
}
