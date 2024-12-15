using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand :IRequest<Book>
    {
        public Guid BookId { get; }
        public string NewTitle { get; }
        public string NewDescription { get; }

        public UpdateBookCommand(Guid bookId, string newTitle, string newDescription)
        {
            BookId = bookId;
            NewTitle = newTitle;
            NewDescription = newDescription;
        }
    }
}
