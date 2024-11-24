using Domain;
using Infrastructure.Database;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, List<Author>>
    {
        private readonly FakeDatabase _fakeDatabase;

        public CreateAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<List<Author>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            _fakeDatabase.AuthorsFromDB.Add(request.NewAuthor);
            return Task.FromResult(_fakeDatabase.AuthorsFromDB);
        }
    }
}
