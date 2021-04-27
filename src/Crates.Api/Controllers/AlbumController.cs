using System.Net;
using System.Threading.Tasks;
using Crates.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Crates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController
    {
        private readonly IMediator _mediator;

        public AlbumController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{albumId}", Name = "GetAlbumByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetAlbumById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetAlbumById.Response>> GetById([FromRoute]GetAlbumById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Album == null)
            {
                return new NotFoundObjectResult(request.AlbumId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetAlbumsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetAlbums.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetAlbums.Response>> Get()
            => await _mediator.Send(new GetAlbums.Request());
        
        [HttpPost(Name = "CreateAlbumRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateAlbum.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateAlbum.Response>> Create([FromBody]CreateAlbum.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetAlbumsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetAlbumsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetAlbumsPage.Response>> Page([FromRoute]GetAlbumsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateAlbumRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateAlbum.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateAlbum.Response>> Update([FromBody]UpdateAlbum.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{albumId}", Name = "RemoveAlbumRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveAlbum.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveAlbum.Response>> Remove([FromRoute]RemoveAlbum.Request request)
            => await _mediator.Send(request);
        
    }
}
