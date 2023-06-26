using MediatR;
using MyWebApi.Infra;
using MyWebApi.Infra.Models;
using MyWebApi.Application.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace MyWebApi.Application.Features
{
    public class GetBooksRequest : IRequest<List<Dto>>
    {

    }

    public class GetBooksRequestHandler : IRequestHandler<GetBooksRequest, List<Dto>>
    {
        private readonly BooksContext _booksContext;
        private readonly IMapper _mapper;

        public GetBooksRequestHandler(BooksContext booksContext, IMapper mapper)
        {
            _booksContext = booksContext;
            _mapper = mapper;
        }

        public Task<List<Dto>> Handle(GetBooksRequest request, CancellationToken cancellationToken)
        {
            var books = _booksContext.Books.ToList();
            var DTOs = _mapper.Map<List<Book>, List<Dto>>(books);

            return Task.FromResult(DTOs);
        }
    }
}

