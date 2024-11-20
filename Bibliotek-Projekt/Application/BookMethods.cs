using Domain;

namespace Application
{
    public class BookMethods
    {
        public static Book AddNewBook()
        {
            Book newBookToAdd = new Book(1, "Harry Potter", "Fantasy Book");
            return newBookToAdd;
        }
    }
}
