using Application.Interfaces.RepositoryInterfaces;
using Domain;
using Infrastructure.Database;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly RealDatabase _realDatabase;
        

        public AuthorRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
           
        }

        public async Task<Author> AddAuthor(Author author)
        {
            
            _realDatabase.Authors.Add(author); 
            _realDatabase.SaveChanges(); 
            
            return author;
        }

        public Task<string> DeleteAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Author>> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public Task<List<Author>> GetAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Author> UpdateAuthor(int id, Author author)
        {
            throw new NotImplementedException();
        }
    }
}
