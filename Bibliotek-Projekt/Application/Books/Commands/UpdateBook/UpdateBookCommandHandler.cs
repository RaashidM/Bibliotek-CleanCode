//using Domain;
//using Infrastructure.Database;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Books.Commands.UpdateBook
//{
//    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
//    {
//        private readonly FakeDatabase _fakeDatabase;

//        public UpdateBookCommandHandler(FakeDatabase fakeDatabase)
//        {
//            _fakeDatabase = fakeDatabase;
//        }

//        public Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
//        {
//             var BookToUpdate = _fakeDatabase.BooksFromDB.FirstOrDefault(b => b.Id == request.BookId);

//            if (BookToUpdate == null)
//            {
//                throw new KeyNotFoundException($"Book with ID {request.BookId} was not found.");
//            }

//            BookToUpdate.Title = request.NewTitle;
//            BookToUpdate.Description = request.NewDescription;

//            return Task.FromResult(BookToUpdate);
//        }
//    }
//}
