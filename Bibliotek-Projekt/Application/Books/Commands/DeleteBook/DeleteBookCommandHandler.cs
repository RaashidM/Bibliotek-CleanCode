using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, string>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<string> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var deletedBook = _bookRepository.DeleteBookById(request.BookId);
            return Task.FromResult("Succesfully deleted");
        }
    }
}
