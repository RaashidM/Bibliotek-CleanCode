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


        public FakeDatabase()
        {
            BooksFromDB = new List<Book>
            {
                new Book(1, "First Book", "First Description"),
                new Book(2, "Second Book", "Second Description"),
                new Book(3, "Third Book", "Third Description")
            };

            AuthorsFromDB = new List<Author>
            {
                new Author(1, "First Author"),
                new Author(2, "Second Author"),
                new Author(3, "Third Author")

            };
        }
    };

  
}
