using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
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

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Task<string> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
           
            var deletedAuthor = _authorRepository.DeleteAuthorById(request.AuthorId);
            return Task.FromResult("Succesfully deleted");
        }
    }
}
