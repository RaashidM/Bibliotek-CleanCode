using Application.Interfaces.RepositoryInterfaces;
using Domain;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly RealDatabase _realDatabase;


        public BookRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;

        }
        public async Task<Book> AddBook(Book book)
        {

            _realDatabase.Books.Add(book);
            _realDatabase.SaveChanges();

            return book;
        }

        public Task<string> DeleteBookById(Guid id)
        {
            var bookToDelete = _realDatabase.Books.Where(book => book.Id == id).First();
            if (bookToDelete is not null)
            {
                _realDatabase.Books.Remove(bookToDelete);
                _realDatabase.SaveChanges();
                return Task.FromResult("Succes");
            }
            else
            {
                return Task.FromResult("Fail");
            }
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await Task.FromResult(_realDatabase.Books.ToList());
            return books;
        }

        public async Task<List<Book>> GetBookById(Guid id)
        {
            var book = await Task.FromResult(_realDatabase.Books.Where(book => book.Id == id).ToList());
            return book;
        }

        public async Task<Book> UpdateBook(Guid id, Book book)
        {
            var bookToUpdate = _realDatabase.Books.FirstOrDefault(a => a.Id == id);
            if (bookToUpdate != null)
            {

                bookToUpdate.Title = book.Title;
                _realDatabase.SaveChanges();
                return bookToUpdate;
            }
            return null;
        }
    }
}
