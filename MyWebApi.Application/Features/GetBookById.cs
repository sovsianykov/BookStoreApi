using MyWebApi.Infra.Models;
using MyWebApi.Infra;
using MyWebApi.Application.DTO;

using MediatR;

using System;
namespace MyWebApi.Application.Features
{
    public class GetBookById : IRequest<Book>
    {
        public int Id { get; set; }

        public GetBookById(int id)
        {
            Id = id;
        }
    }

    public class GetBookByIdHandler : IRequestHandler<GetBookById, Book>
    {

        private readonly BooksContext _booksContext;

        public GetBookByIdHandler(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }


        public Task<Book> Handle(GetBookById request, CancellationToken cancellationToken)
        {
            var book = _booksContext.Books.FirstOrDefault(b => b.Id == request.Id);

            if (book == null)
            {
                throw new KeyNotFoundException($"Book with id {request.Id} not found");
            }
            return Task.FromResult(book);
        }

    }
}

