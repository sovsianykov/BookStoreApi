using MyWebApi.Application.Models;
using MediatR;

using System;
namespace MyWebApi.Application.Features
{
	public class GetBooksRequest : IRequest<List<BookDto>>
	{
		
	}

	public class GetBooksRequestHandler : IRequestHandler<GetBooksRequest,List<BookDto>>
	{

		private readonly IBookStorage _bookStorage;

		public GetBooksRequestHandler(IBookStorage bookStorage)
		{
			_bookStorage = bookStorage;
		}


		public Task<List<BookDto>> Handle(GetBooksRequest request, CancellationToken cancellationToken)
		{

			return Task.FromResult(_bookStorage.Books);
		}

	}
}

