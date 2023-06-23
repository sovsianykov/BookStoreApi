using MyWebApi.Infra.Models;
using MyWebApi.Infra;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MyWebApi.Application.DTO;


namespace MyWebApi.Application.Features
{
    public class CreateBookRequest : IRequest<Dto>
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
    }

    public class CreateBookRequestHandler : IRequestHandler<CreateBookRequest, Dto>
    {
        private readonly BooksContext _booksContext;

        public CreateBookRequestHandler(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        public async Task<Dto> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {


            var dto = new Dto
            {
                Id = request.Id,
                Title = request.Title,
                Author = request.Author
            };

            var book = new Book
            {
                Id = request.Id,
                Title = request.Title,
                Author = request.Author
            };

            _booksContext.Books.Add(book);
            await _booksContext.SaveChangesAsync(cancellationToken);
            return dto;
        }
    }
}
