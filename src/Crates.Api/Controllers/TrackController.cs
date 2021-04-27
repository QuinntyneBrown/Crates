using System.Net;
using System.Threading.Tasks;
using Crates.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Crates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackController
    {
        private readonly IMediator _mediator;

        public TrackController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{trackId}", Name = "GetTrackByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTrackById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTrackById.Response>> GetById([FromRoute]GetTrackById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Track == null)
            {
                return new NotFoundObjectResult(request.TrackId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetTracksRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTracks.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTracks.Response>> Get()
            => await _mediator.Send(new GetTracks.Request());
        
        [HttpPost(Name = "CreateTrackRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateTrack.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateTrack.Response>> Create([FromBody]CreateTrack.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetTracksPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTracksPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTracksPage.Response>> Page([FromRoute]GetTracksPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateTrackRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateTrack.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateTrack.Response>> Update([FromBody]UpdateTrack.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{trackId}", Name = "RemoveTrackRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveTrack.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveTrack.Response>> Remove([FromRoute]RemoveTrack.Request request)
            => await _mediator.Send(request);
        
    }
}
