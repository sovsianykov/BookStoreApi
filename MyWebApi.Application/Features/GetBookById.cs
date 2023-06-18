using MyWebApi.Application.Models;
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

        private readonly IBookStorage _bookStorage;

        public GetBookByIdHandler(IBookStorage bookStorage)
        {
            _bookStorage = bookStorage;
        }


        public Task<BookDto> Handle(GetBookById request, CancellationToken cancellationToken)
        {
            var book = _bookStorage.Books.FirstOrDefault(b => b.id == request.Id);

            return Task.FromResult(book);
        }

    }
}

