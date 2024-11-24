using Application.Books.Commands.CreateBook;
using Application.Books.Commands;
using Domain;
using Infrastructure.Database;

namespace TestProject;

public class CreateBookTest
{
    private FakeDatabase _fakeDatabase;
    private CreateBookCommandHandler _handler;

    [SetUp]
    public void SetUp()
    {
        
        _fakeDatabase = new FakeDatabase();

       
        _handler = new CreateBookCommandHandler(_fakeDatabase);
    }

    [Test]
    public async Task CreateBook_ShouldAddNewBookToDatabase()
    {
        //Arrange
        var newBook = new Book(4, "Fourth Book", "Fourth Description");
        var command = new CreateBookCommand(newBook);

        //Act
        var result = await _handler.Handle(command, CancellationToken.None);

        //Assert
        Assert.AreEqual(4, result.Count);  
        Assert.Contains(newBook, result);  
    }

    [Test]
    public async Task CreateBook_ShouldNotModifyExistingBooks()
    {
        //Arrange
        var newBook = new Book(4, "Fourth Book", "Fourth Description");
        var command = new CreateBookCommand(newBook);

        //Act
        var result = await _handler.Handle(command, CancellationToken.None);

        //Assert
        Assert.IsTrue(result.Exists(b => b.Id == 1 && b.Title == "First Book"));
        Assert.IsTrue(result.Exists(b => b.Id == 2 && b.Title == "Second Book"));
        Assert.IsTrue(result.Exists(b => b.Id == 3 && b.Title == "Third Book"));

       
        Assert.IsTrue(result.Exists(b => b.Id == 4 && b.Title == "Fourth Book"));
    }

}
