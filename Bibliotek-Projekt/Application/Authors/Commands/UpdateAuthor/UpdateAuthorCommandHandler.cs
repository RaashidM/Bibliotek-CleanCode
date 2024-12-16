using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<UpdateAuthorCommandHandler> _logger;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, ILogger<UpdateAuthorCommandHandler> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating author with ID {AuthorId} to new name: {NewName}", request.AuthorId, request.NewName);
            var updatedAuthor = new Author( request.NewName);
            var result = await _authorRepository.UpdateAuthor(request.AuthorId, updatedAuthor);

            if (result != null)
            {
                _logger.LogInformation("Successfully updated author with ID {AuthorId}", request.AuthorId); // Logga vid lyckad uppdatering
            }
            else
            {
                _logger.LogWarning("Failed to update author with ID {AuthorId}. Author not found.", request.AuthorId); // Logga vid misslyckad uppdatering
            }


            return result;
        }
    }
}
