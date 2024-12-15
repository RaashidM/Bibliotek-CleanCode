using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class FakeDatabase
    {
        public List<Book> BooksFromDB { get; private set;}
        public List<Author> AuthorsFromDB { get; private set;}
        public List<User> UsersFromDB { get; private set;}


        public FakeDatabase()
        {
            BooksFromDB = new List<Book>
            {
                new Book("First Book", "First Description"),
                new Book("Second Book", "Second Description"),
                new Book("Third Book", "Third Description")
            };

            AuthorsFromDB = new List<Author>
            {
                new Author("First Author"),
                new Author("Second Author"),
                new Author("Third Author")

            };

            UsersFromDB = new List<User>
            {
                new User{Id = Guid.NewGuid(), UserName ="User1"},
                new User{Id = Guid.NewGuid(), UserName ="User2" },
                new User{Id = Guid.NewGuid(), UserName ="User3"}
            };
        }

      
    };

  
}
