using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyWebApi.Application.Features;
namespace MyWebApi.WebApp.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{

    public readonly IMediator _mediator;

    public BooksController(IMediator mediator) =>
        _mediator = mediator;


    private static readonly GetBooksRequest _getBooksRequest = new GetBooksRequest();


    [HttpGet]
    public async Task<IActionResult> GetBook()
    {
        var result = await _mediator.Send(_getBooksRequest, HttpContext.RequestAborted);
        return Ok(result);
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var request = new GetBookById(id);
        var book = await _mediator.Send(request, HttpContext.RequestAborted);
        return Ok(book);
    }


    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookRequest request)
    {
        var createdBook = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetBookById), new { id = createdBook.id }, createdBook);
    }

}