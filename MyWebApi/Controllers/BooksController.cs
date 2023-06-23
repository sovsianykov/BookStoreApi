using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyWebApi.Application.Features;
using MyWebApi.Application.DTO;
using System.Threading.Tasks;

namespace MyWebApi.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private static readonly GetBooksRequest _getBooksRequest = new GetBooksRequest();

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var result = await _mediator.Send(_getBooksRequest);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var request = new GetBookById(id);
            var book = await _mediator.Send(request);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookRequest request)
        {
            var createdBook = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookRequest request)
        {
            request.Id = id;
            var updatedBook = await _mediator.Send(request);
            return Ok(updatedBook);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var request = new DeleteBookRequest(id);
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
