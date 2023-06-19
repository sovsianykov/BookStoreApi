using MyWebApi.Infra.Models;
using MediatR;

using System;
using MyWebApi.Infra;

namespace MyWebApi.Application.Features
{
	public class GetBooksRequest : IRequest<List<BookDto>>
	{
		
	}

	public class GetBooksRequestHandler : IRequestHandler<GetBooksRequest,List<BookDto>>
	{

        private readonly BooksContext _booksContext;

        public GetBooksRequestHandler(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }


        public Task<List<BookDto>> Handle(GetBooksRequest request, CancellationToken cancellationToken)
		{
			var books = _booksContext.Books.ToList();
			return Task.FromResult(books);
		}

	}
}

