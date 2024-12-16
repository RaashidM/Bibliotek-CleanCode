using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<OperationResult<Author>>
    {
        public Guid AuthorId { get; }

        public GetAuthorByIdQuery(Guid authorId)
        {
            AuthorId = authorId;
        }
    }
}
