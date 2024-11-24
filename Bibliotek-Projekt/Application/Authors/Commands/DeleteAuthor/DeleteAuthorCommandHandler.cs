using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, List<Author>>
    {
        private readonly FakeDatabase _fakeDatabase;

        public DeleteAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<List<Author>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorToRemove = _fakeDatabase.AuthorsFromDB.FirstOrDefault(a => a.Id == request.AuthorId);
            if (authorToRemove == null)
            {
                return Task.FromResult(_fakeDatabase.AuthorsFromDB);
            }

            _fakeDatabase.AuthorsFromDB.Remove(authorToRemove);

            return Task.FromResult(_fakeDatabase.AuthorsFromDB);
        }
    }
}
