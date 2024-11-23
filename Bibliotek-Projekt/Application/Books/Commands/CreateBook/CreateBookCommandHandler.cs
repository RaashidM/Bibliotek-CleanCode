using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, List<Book>>
    {
        private readonly FakeDatabase _fakeDatabase;

        public CreateBookCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<List<Book>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            _fakeDatabase.BooksFromDB.Add(request.NewBook);
            return Task.FromResult(_fakeDatabase.BooksFromDB);
        }
    }
}
