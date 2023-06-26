using MyWebApi.Infra.Models;
using MyWebApi.Infra;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MyWebApi.Application.DTO;
using AutoMapper;

namespace MyWebApi.Application.Features
{
    public class CreateBookRequest : IRequest<Dto>
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }

    public class CreateBookRequestHandler : IRequestHandler<CreateBookRequest, Dto>
    {
        private readonly BooksContext _booksContext;
        private readonly IMapper _mapper;

        public CreateBookRequestHandler(BooksContext booksContext, IMapper mapper)
        {
            _booksContext = booksContext;
            _mapper = mapper;
        }

        public async Task<Dto> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<CreateBookRequest, Book>(request);
            _booksContext.Books.Add(book);
            await _booksContext.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<Book, Dto>(book);
            return dto;
        }
    }
}
