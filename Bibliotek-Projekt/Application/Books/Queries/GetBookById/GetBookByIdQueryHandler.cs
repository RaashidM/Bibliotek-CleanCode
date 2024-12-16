using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, OperationResult<Book>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<GetBookByIdQueryHandler> _logger;

        public GetBookByIdQueryHandler(IBookRepository bookRepository, ILogger<GetBookByIdQueryHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<OperationResult<Book>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.BookId.Equals(Guid.Empty))
            {
                _logger.LogWarning("Attempted to get book with an empty Guid.");
                return OperationResult<Book>.Failure("The book Id was an empty guid");
            }
            _logger.LogInformation("Fetching book with ID: {BookId}", request.BookId);
            var book = (await _bookRepository.GetBookById(request.BookId)).FirstOrDefault();
            if (book == null)
            {
                _logger.LogWarning("No book found with ID: {BookId}", request.BookId);
                return OperationResult<Book>.Failure("No book found with the provided ID.");
            }
            _logger.LogInformation("Successfully fetched book: {BookTitle}", book.Title);
            return OperationResult<Book>.Successfull(book);
        }
    }
}
