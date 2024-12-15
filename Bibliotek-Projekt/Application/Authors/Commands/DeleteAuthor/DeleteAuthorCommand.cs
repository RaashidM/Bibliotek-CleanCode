using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<string>
    {
        public DeleteAuthorCommand(Guid authorId)
        {
            AuthorId = authorId;
        }

        public Guid AuthorId { get; }
    }
}
