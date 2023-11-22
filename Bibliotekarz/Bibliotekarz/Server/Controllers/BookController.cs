using Bibliotekarz.Server.Context;
using Bibliotekarz.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bibliotekarz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BookController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooks()
        {
            //return StatusCode(StatusCodes.Status201Created);
            //return NoContent();
            //return BadRequest();
            //return NotFound();

            List<Book> booksList = await dbContext.Books
                //.Where(x => x.Title.Contains(filter) || x.Author.Contains(filter))
                //.Any(x => x.PageCount > 10)
                .OrderBy(x => x.Author).ThenBy(x => x.Title)
                .ToListAsync();


            return Ok(booksList);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddBook(Book book)
        {
            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
