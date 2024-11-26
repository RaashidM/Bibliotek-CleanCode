using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    internal sealed class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, User>
    {
        private readonly FakeDatabase _fakeDatabas;
        public AddNewUserCommandHandler(FakeDatabase fakeDatabas)
        {
            _fakeDatabas = fakeDatabas;
        }

        public Task<User> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
        {
            User userToCreate = new()
            {
                Id = Guid.NewGuid(),
                UserName = request.NewUser.UserName,
                Password = request.NewUser.Password,
            };

            _fakeDatabas.UsersFromDB.Add(userToCreate);
            return Task.FromResult(userToCreate);
        }
    }
}
