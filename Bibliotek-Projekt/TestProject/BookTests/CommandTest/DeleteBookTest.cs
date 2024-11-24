using Application.Books.Commands.DeleteBook;
using Infrastructure.Database;

namespace TestProject;

public class DeleteBookTest
{
    private FakeDatabase _fakeDatabase;
    private DeleteBookCommandHandler _handler;

    [SetUp]
    public void SetUp()
    {
        
        _fakeDatabase = new FakeDatabase();

        
        _handler = new DeleteBookCommandHandler(_fakeDatabase);
    }

    [Test]
    public async Task DeleteBook_ShouldRemoveBookWhenExists()
    {
        //Arrange
        var command = new DeleteBookCommand(2);

        //Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.AreEqual(2, result.Count);  
        Assert.IsFalse(result.Any(b => b.Id == 2)); 
    }

    [Test]
    public async Task DeleteBook_ShouldNotModifyDatabaseWhenBookDoesNotExist()
    {
        //Arrange
        var command = new DeleteBookCommand(99);

        //Act
        var result = await _handler.Handle(command, CancellationToken.None);

        //Assert
        Assert.AreEqual(3, result.Count);  
        Assert.IsTrue(result.Any(b => b.Id == 1 && b.Title == "First Book"));
        Assert.IsTrue(result.Any(b => b.Id == 2 && b.Title == "Second Book"));
        Assert.IsTrue(result.Any(b => b.Id == 3 && b.Title == "Third Book"));
    }
}
