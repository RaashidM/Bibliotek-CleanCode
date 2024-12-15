using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<Author>
    {
        public Guid AuthorId {  get; }
        public string NewName {  get; }

        public UpdateAuthorCommand(Guid authorId, string newName)
        {
            AuthorId = authorId;
            NewName = newName;
        }
    }
}
