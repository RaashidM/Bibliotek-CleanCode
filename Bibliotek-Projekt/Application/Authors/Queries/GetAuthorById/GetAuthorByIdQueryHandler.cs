using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, OperationResult<Author>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<GetAuthorByIdQueryHandler> _logger;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, ILogger<GetAuthorByIdQueryHandler> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        public async Task<OperationResult<Author>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.AuthorId.Equals(Guid.Empty))
            {
                _logger.LogWarning("Attempted to get author with an empty Guid.");
                return OperationResult<Author>.Failure("The author Id was an empty Guid");
            }
            _logger.LogInformation("Fetching author with ID: {AuthorId}", request.AuthorId);
            var author = (await _authorRepository.GetAuthorById(request.AuthorId)).FirstOrDefault();
            if (author == null)
            {
                _logger.LogWarning("No author found with ID: {AuthorId}", request.AuthorId); 
                return OperationResult<Author>.Failure("No author found with the provided ID.");
            }
            _logger.LogInformation("Successfully fetched author: {AuthorName}", author.Name);
            return OperationResult<Author>.Successfull(author);
        }
    }
}
