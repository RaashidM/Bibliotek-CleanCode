using Application.Authors.Commands.UpdateAuthor;
using Infrastructure.Database;

namespace TestProject;

public class UpdateAuthorTest
{
    private FakeDatabase _fakeDatabase;
    private UpdateAuthorCommandHandler _handler;

    [SetUp]
    public void SetUp()
    {
        _fakeDatabase = new FakeDatabase();
        _handler = new UpdateAuthorCommandHandler(_fakeDatabase);
    }

    [Test]
    public async Task UpdateAuthor_ShouldChangeName_WhenAuthorExists()
    {
        //Arrange
        var authorIdToUpdate = 2;
        var newName = "Updated Author Name";
        var command = new UpdateAuthorCommand(authorIdToUpdate, newName);

        //Act
        var updatedAuthor = await _handler.Handle(command, CancellationToken.None);

        //Assert
        Assert.AreEqual(newName, updatedAuthor.Name);
    }

    [Test]
    public void UpdateAuthor_ShouldThrowKeyNotFoundException_WhenAuthorDoesNotExist()
    {
       
        var authorIdToUpdate = 99;
        var newName = "Nonexistent Author";
        var command = new UpdateAuthorCommand(authorIdToUpdate, newName);

        
        Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            await _handler.Handle(command, CancellationToken.None)
        );
    }
}
