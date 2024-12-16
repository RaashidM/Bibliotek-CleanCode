using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, string>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<DeleteAuthorCommandHandler> _logger;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, ILogger<DeleteAuthorCommandHandler> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        public Task<string> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Attempting to delete author with ID {AuthorId}", request.AuthorId);
            var deletedAuthor = _authorRepository.DeleteAuthorById(request.AuthorId);
            _logger.LogInformation("Successfully deleted author with ID {AuthorId}", request.AuthorId);
            return Task.FromResult("Succesfully deleted");
        }
    }
}
