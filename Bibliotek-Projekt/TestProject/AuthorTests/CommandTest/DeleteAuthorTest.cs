using Application.Authors.Commands.DeleteAuthor;
using Infrastructure.Database;

namespace TestProject;

public class DeleteAuthorTest
{
    private FakeDatabase _fakeDatabase;
    private DeleteAuthorCommandHandler _handler;

    [SetUp]
    public void SetUp()
    {
        _fakeDatabase = new FakeDatabase();
        _handler = new DeleteAuthorCommandHandler(_fakeDatabase);
    }

    [Test]
    public async Task DeleteAuthor_ShouldRemoveAuthor_WhenAuthorExists()
    {
        //Arrange
        var authorIdToDelete = 2;
        var command = new DeleteAuthorCommand(authorIdToDelete);

        //Act
        var authorsList = await _handler.Handle(command, CancellationToken.None);

        //Assert
        Assert.AreEqual(2, authorsList.Count);
        Assert.IsFalse(authorsList.Any(a => a.Id == authorIdToDelete)); 
    }

    [Test]
    public async Task DeleteAuthor_ShouldNotChangeList_WhenAuthorDoesNotExist()
    {
        //Arrange
        var authorIdToDelete = 99;
        var command = new DeleteAuthorCommand(authorIdToDelete);

        //Act
        var authorsList = await _handler.Handle(command, CancellationToken.None);

        //Assert 
        Assert.AreEqual(3, authorsList.Count);
    }
}
