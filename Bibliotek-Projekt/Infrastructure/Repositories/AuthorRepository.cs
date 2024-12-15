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

        public Task<string> DeleteAuthorById(Guid id)
        {
            var authorToDelete = _realDatabase.Authors.Where(author => author.Id == id).First();
            if (authorToDelete is not null)
            {
                _realDatabase.Authors.Remove(authorToDelete);
                _realDatabase.SaveChanges();
                return Task.FromResult("Succes");
            }
            else
            {
                return Task.FromResult("Fail");
            }
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            var authors = await Task.FromResult(_realDatabase.Authors.ToList());
            return authors;
        }

        public async Task<List<Author>> GetAuthorById(Guid id)
        {
            var author = await Task.FromResult(_realDatabase.Authors.Where(author => author.Id == id).ToList());
            return author;
        }

        public async Task<Author> UpdateAuthor(Guid id, Author author)
        {
            var authorToUpdate = _realDatabase.Authors.FirstOrDefault(a => a.Id == id);
            if (authorToUpdate != null)
            {

                authorToUpdate.Name = author.Name;
                _realDatabase.SaveChanges();
                return authorToUpdate;
            }
            return null;
        }
    }
}
