using Application.Interfaces.RepositoryInterfaces;
using Domain;
using Infrastructure.Database;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly RealDatabase _realDatabase;
        private readonly ILogger<BookRepository> _logger;


        public BookRepository(RealDatabase realDatabase, ILogger<BookRepository> logger)
        {
            _realDatabase = realDatabase;
            _logger = logger;

        }
        public async Task<Book> AddBook(Book book)
        {
            _logger.LogInformation("Adding book: {BookTitle}", book.Title);
            _realDatabase.Books.Add(book);
            _realDatabase.SaveChanges();

            _logger.LogInformation("Book {BookTitle} added successfully.", book.Title);
            return book;
        }

        public Task<string> DeleteBookById(Guid id)
        {
            _logger.LogInformation("Attempting to delete book with ID {BookId}", id);
            var bookToDelete = _realDatabase.Books.Where(book => book.Id == id).First();
            if (bookToDelete is not null)
            {
                _realDatabase.Books.Remove(bookToDelete);
                _realDatabase.SaveChanges();
                _logger.LogInformation("Book with ID {BookId} deleted successfully.", id);
                return Task.FromResult("Succes");
            }
            else
            {
                _logger.LogWarning("Attempted to delete book with ID {BookId}, but not found.", id);
                return Task.FromResult("Fail");
            }
        }

        public async Task<List<Book>> GetAllBooks()
        {
            _logger.LogInformation("Fetching all books from the database.");
            var books = await Task.FromResult(_realDatabase.Books.ToList());
            _logger.LogInformation("Fetched {Count} books from the database.", books.Count);
            return books;
        }

        public async Task<List<Book>> GetBookById(Guid id)
        {
            _logger.LogInformation("Fetching book with ID {BookId}", id);
            var book = await Task.FromResult(_realDatabase.Books.Where(book => book.Id == id).ToList());
            if (book.Count == 0)
            {
                _logger.LogWarning("No book found with ID {BookId}", id);
            }
            return book;
        }

        public async Task<Book> UpdateBook(Guid id, Book book)
        {
            _logger.LogInformation("Updating book with ID {BookId}", id);
            var bookToUpdate = _realDatabase.Books.FirstOrDefault(a => a.Id == id);
            if (bookToUpdate != null)
            {

                bookToUpdate.Title = book.Title;
                _realDatabase.SaveChanges();
                _logger.LogInformation("Book with ID {BookId} updated successfully.", id);
                return bookToUpdate;
            }
            _logger.LogWarning("Attempted to update book with ID {BookId}, but not found.", id);
            return null;
        }
    }
}
