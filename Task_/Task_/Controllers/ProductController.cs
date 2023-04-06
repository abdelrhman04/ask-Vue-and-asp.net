using BLL;
using BLL.Services;
using CORE.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Task_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = "admin")]
        [Consumes("multipart/form-data")]
        [HttpPost("Add-Product", Name = "Add-Product")]
        public async Task<ActionResult<APIResponse>> Add([FromForm]ProductInput Author)
        {
            var success = await _mediator.Send(new AddProductCommand { ProductInput= Author });
            switch (success.Code)
            {
                case 200:
                    return Ok(success);
                case 400:
                    return StatusCode(StatusCodes.Status400BadRequest, success);
                case 404:
                    return StatusCode(StatusCodes.Status404NotFound, success);
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError, success);
            }
        }
        [Authorize(Roles = "admin")]
        [Consumes("multipart/form-data")]
        [HttpPost("Update-Product", Name = "Update-Product")]
        
        public async Task<ActionResult<APIResponse>> Update([FromForm] ProductInputUpdate Author)
        {
            var success = await _mediator.Send(new UpdateProductCommand {ProductInput= Author});
            switch (success.Code)
            {
                case 200:
                    return Ok(success);
                case 400:
                    return StatusCode(StatusCodes.Status400BadRequest, success);
                case 404:
                    return StatusCode(StatusCodes.Status404NotFound, success);
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError, success);
            }
        }
        
        [HttpGet("GetAll-Product", Name = "GetAll-Product")]
        [Authorize]
        public async Task<ActionResult<APIResponse>> GetAll(int page=1)
        {
            var success = await _mediator.Send(new GetAllProductQuery { page  =page} );
            switch (success.Code)
            {
                case 200:
                    return Ok(success);
                case 400:
                    return StatusCode(StatusCodes.Status400BadRequest, success);
                case 404:
                    return StatusCode(StatusCodes.Status404NotFound, success);
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError, success);
            }
        }
        [Authorize]
        [HttpGet("Get-Product", Name = "Get-Product")]
        
        public async Task<ActionResult<APIResponse>> Get(int Id)
        {
            var success = await _mediator.Send(new GetByIdProductQuery { Id = Id });
            switch (success.Code)
            {
                case 200:
                    return Ok(success);
                case 400:
                    return StatusCode(StatusCodes.Status400BadRequest, success);
                case 404:
                    return StatusCode(StatusCodes.Status404NotFound, success);
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError, success);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("Delete-Product", Name = "Delete-Product")]
        public async Task<ActionResult<APIResponse>> Delete(int Id)
        {
            var success = await _mediator.Send(new DeleteProductCommand { Id = Id });
            switch (success.Code)
            {
                case 200:
                    return Ok(success);
                case 400:
                    return StatusCode(StatusCodes.Status400BadRequest, success);
                case 404:
                    return StatusCode(StatusCodes.Status404NotFound, success);
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError, success);
            }
        }
        
    }
}
