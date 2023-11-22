using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotekarz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookController()
        {

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooks()
        {
            //return StatusCode(StatusCodes.Status201Created);
            //return NoContent();
            //return BadRequest();
            //return NotFound();


            return Ok();
        }
            

    }
}
