using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<List<Book>>
    {
        public DeleteBookCommand(int bookId)
        {
            BookId = bookId; 
        }

        public int BookId { get; }

    }

}
