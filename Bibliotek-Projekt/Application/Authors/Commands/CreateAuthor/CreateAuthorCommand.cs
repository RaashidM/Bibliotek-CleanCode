using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<Author>
    {
        public CreateAuthorCommand(Author authorToAdd)
        {
            NewAuthor = authorToAdd;
        }

        public Author NewAuthor { get; }
    }
}
