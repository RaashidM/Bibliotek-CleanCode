using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<UpdateBookCommandHandler> _logger;

        public UpdateBookCommandHandler(IBookRepository bookRepository, ILogger<UpdateBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating book with ID: {BookId}", request.BookId);
            var updatedBook = new Book(request.NewTitle, request.NewDescription);

            var result = await _bookRepository.UpdateBook(request.BookId, updatedBook);
            _logger.LogInformation("Book updated successfully: {BookTitle}", result.Title);
            return result;
        }
    }
}
