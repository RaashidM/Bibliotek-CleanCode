using Application.Books.Queries.GetBooks;
using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<GetAllAuthorsQueryHandler> _logger;

        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository, ILogger<GetAllAuthorsQueryHandler> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        public async Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all authors from the repository.");
            var authors = await _authorRepository.GetAllAuthors();
            _logger.LogInformation("Fetched {AuthorCount} authors.", authors.Count);
            return authors;
        }
    }
}
