using API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        [HttpGet("unauthorized")]
        public IActionResult GetUnathorized()
        {
            return Unauthorized();
        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest("Bad Request");
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFound()
        {
            return NotFound();
        }

        [HttpGet("internalerror")]
        public IActionResult GetInternalError()
        {
            throw new Exception("This is a test exception");
        }

        [HttpPost("validationerror")]
        public IActionResult GetValidationError(CreateGenreDto genre)
        {
            return Ok();
        }

        [Authorize]
        [HttpGet("secret")]
        public IActionResult GetSecret() 
        {
            var name = User.FindFirst(ClaimTypes.Name)?.Value;
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok("Hello " + name + " with id of " + id);
        }
    }
}
