using MediatR;
using MyWebApi.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace MyWebApi.Application.Features
{
    public class DeleteBookRequest : IRequest
    {
        public int BookId { get; set; }

        public DeleteBookRequest(int bookId)
        {
            BookId = bookId;
        }
    }

    public class DeleteBookRequestHandler : IRequestHandler<DeleteBookRequest>
    {
        private readonly BooksContext _booksContext;

        public DeleteBookRequestHandler(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        async Task IRequestHandler<DeleteBookRequest>.Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {
            var book = await _booksContext.Books.FindAsync(request.BookId);

            if (book == null)
            {
                throw new KeyNotFoundException($"Book with id {request.BookId} not found");

            }

            _booksContext.Books.Remove(book);
            await _booksContext.SaveChangesAsync(cancellationToken);
        }
    }
}
