//using Domain;
//using Infrastructure.Database;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Books.Commands.DeleteBook
//{
//    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, List<Book>>
//    {
//        private readonly FakeDatabase _fakeDatabase;

//        public DeleteBookCommandHandler(FakeDatabase fakeDatabase)
//        {
//            _fakeDatabase = fakeDatabase;
//        }

//        public Task<List<Book>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
//        {
//            var bookToRemove = _fakeDatabase.BooksFromDB.FirstOrDefault(b => b.Id == request.BookId);
//            if (bookToRemove == null)
//            {
//                return Task.FromResult(_fakeDatabase.BooksFromDB);
                
//            }

//            _fakeDatabase.BooksFromDB.Remove(bookToRemove);

//            return Task.FromResult(_fakeDatabase.BooksFromDB);
//        }
//    }
//}
