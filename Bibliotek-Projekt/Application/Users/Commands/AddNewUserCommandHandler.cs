using Application.Interfaces.RepositoryInterfaces;
using Domain;
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
        private readonly IUserRepository _userRepository; 
        
        public AddNewUserCommandHandler(IUserRepository userRepository) 
        { 
            _userRepository = userRepository; 
        }
        public async Task<User> Handle(AddNewUserCommand request, CancellationToken cancellationToken) 
        { 
            User userToCreate = new() { Id = Guid.NewGuid(), UserName = request.NewUser.UserName, Password = request.NewUser.Password}; 
            return await _userRepository.AddUser(userToCreate);
        }
    }
}
