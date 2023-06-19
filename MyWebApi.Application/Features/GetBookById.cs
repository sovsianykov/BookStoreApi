using MyWebApi.Infra.Models;
using MyWebApi.Infra;
using MediatR;

using System;
namespace MyWebApi.Application.Features
{
    public class GetBookById : IRequest<BookDto>
    {
        public int Id { get; set; }
    }

    public class GetBookByIdHandler : IRequestHandler<GetBookById, BookDto>
    {

        private readonly BooksContext _booksContext;

        public GetBookByIdHandler(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }


        public Task<BookDto> Handle(GetBookById request, CancellationToken cancellationToken)
        {
            var book = _booksContext.Books.FirstOrDefault(b => b.id == request.Id);

            return Task.FromResult(book);
        }

    }
}

