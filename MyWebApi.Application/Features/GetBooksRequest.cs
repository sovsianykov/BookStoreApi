using MediatR;
using MyWebApi.Infra;
using MyWebApi.Infra.Models;
using MyWebApi.Application.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyWebApi.Application.Features
{
    public class GetBooksRequest : IRequest<List<Dto>>
    {

    }

    public class GetBooksRequestHandler : IRequestHandler<GetBooksRequest, List<Dto>>
    {
        private readonly BooksContext _booksContext;

        public GetBooksRequestHandler(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        public Task<List<Dto>> Handle(GetBooksRequest request, CancellationToken cancellationToken)
        {
            var books = _booksContext.Books.ToList();
            var Dtos = books.Select(book => new Dto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            }).ToList();

            return Task.FromResult(Dtos);
        }
    }
}
