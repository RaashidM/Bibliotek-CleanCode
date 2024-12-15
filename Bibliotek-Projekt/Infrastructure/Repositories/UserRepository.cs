using Application.Interfaces.RepositoryInterfaces;
using Domain;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<User> AddUser(User user)
        {
            _realDatabase.Users.Add(user);
            _realDatabase.SaveChanges();
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await Task.FromResult(_realDatabase.Users.ToList());
            return users;
        }

        public async Task<User> LoginUser(string username, string password)
        {
            var user = await _realDatabase.Users.FirstOrDefaultAsync(u =>u.UserName == username 
                && u.Password == password);
            return user;
        }
    }
}
