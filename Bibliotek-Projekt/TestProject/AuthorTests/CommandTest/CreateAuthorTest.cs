using Application.Authors.Commands.CreateAuthor;
using Domain;
using Infrastructure.Database;

namespace TestProject;

public class CreateAuthorTest
{
    private FakeDatabase _fakeDatabase;
    private CreateAuthorCommandHandler _handler;

    [SetUp]
    public void SetUp()
    {
        
        _fakeDatabase = new FakeDatabase();

       
        _handler = new CreateAuthorCommandHandler(_fakeDatabase);
    }

    [Test]
    public async Task CreateAuthor_ShouldAddAuthorToDatabase_WhenValidDataIsProvided()
    {
        //Arrange
        var newAuthor = new Author(4, "New Author");
        var command = new CreateAuthorCommand(newAuthor);

        //Act
        var authorsList = await _handler.Handle(command, CancellationToken.None);

        //Assert
        Assert.AreEqual(4, authorsList.Count); 
        Assert.IsTrue(authorsList.Any(a => a.Id == 4 && a.Name == "New Author"));  
    }

    [Test]
    public async Task CreateAuthor_ShouldNotModifyOtherAuthors_WhenNewAuthorIsAdded()
    {
        //Arrange
        var newAuthor = new Author(4, "New Author");
        var command = new CreateAuthorCommand(newAuthor);

        //Act
        var authorsList = await _handler.Handle(command, CancellationToken.None);

        //Assert
        Assert.IsTrue(authorsList.Any(a => a.Id == 1 && a.Name == "First Author"));
        Assert.IsTrue(authorsList.Any(a => a.Id == 2 && a.Name == "Second Author"));
        Assert.IsTrue(authorsList.Any(a => a.Id == 3 && a.Name == "Third Author"));
    }
}
