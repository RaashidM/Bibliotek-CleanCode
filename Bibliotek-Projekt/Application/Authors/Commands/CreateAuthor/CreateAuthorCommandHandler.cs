using Application.Interfaces.RepositoryInterfaces;
using Domain;

using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<CreateAuthorCommandHandler> _logger;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, ILogger<CreateAuthorCommandHandler> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating author: {AuthorName}", request.Name);
            var author = new Author(request.Name);
            var result = await _authorRepository.AddAuthor(author);
            _logger.LogInformation("Author {AuthorName} created successfully with ID {AuthorId}", result.Name, result.Id);
            return result;


        }
    }
}
