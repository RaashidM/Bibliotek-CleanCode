using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Author>
    {
        private readonly FakeDatabase _fakeDatabase;

        public UpdateAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorToUpdate = _fakeDatabase.AuthorsFromDB.FirstOrDefault(a => a.Id == request.AuthorId);

            if (authorToUpdate == null)
            {
                throw new KeyNotFoundException($"Author with ID {request.AuthorId} was not found.");
            }

            authorToUpdate.Name = request.NewName;
            
            return Task.FromResult(authorToUpdate);
        }
    }
}
