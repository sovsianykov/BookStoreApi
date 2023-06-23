using MediatR;
using MyWebApi.Infra;
using MyWebApi.Infra.Models;
using MyWebApi.Application.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace MyWebApi.Application.Features
{
    public class UpdateBookRequest : IRequest<Dto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class UpdateBookRequestHandler : IRequestHandler<UpdateBookRequest, Dto>
    {
        private readonly BooksContext _booksContext;

        public UpdateBookRequestHandler(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        public async Task<Dto> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var book = await _booksContext.Books.FindAsync(request.Id);

            if (book == null)
            {

                throw new KeyNotFoundException($"Book with ID {request.Id} not found.");
            }

            book.Title = request.Title;
            book.Author = request.Author;

            await _booksContext.SaveChangesAsync();

            var dto = new Dto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            };

            return dto;
        }
    }
}


