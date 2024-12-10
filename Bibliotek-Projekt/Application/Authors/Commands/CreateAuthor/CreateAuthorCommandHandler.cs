using Application.Interfaces.RepositoryInterfaces;
using Domain;

using MediatR;
using MediatR.Pipeline;
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

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _authorRepository.AddAuthor(request.NewAuthor);
                return await Task.FromResult(request.NewAuthor);
            }
            catch
            {
                throw new Exception("Author not added.");
            }
            
        }
    }
}
