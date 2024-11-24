using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<List<Author>>
    {
        public DeleteAuthorCommand(int authorId)
        {
            AuthorId = authorId;
        }

        public int AuthorId { get; }
    }
}
