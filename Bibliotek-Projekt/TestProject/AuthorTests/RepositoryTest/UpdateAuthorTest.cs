using Application.Authors.Commands.UpdateAuthor;
using Application.Interfaces.RepositoryInterfaces;
using Domain;
using FakeItEasy;

namespace TestProject;

public class UpdateAuthorTest
{
    private IAuthorRepository _fakeAuthorRepository;
    private UpdateAuthorCommandHandler _handler;

    [SetUp]
    public void Setup()
    {
        _fakeAuthorRepository = A.Fake<IAuthorRepository>();
        _handler = new UpdateAuthorCommandHandler(_fakeAuthorRepository);
    }

    [Test]
    public async Task UpdateAuthorCommandHandler_Should_UpdateAuthorSuccessfully()
    {
        // Arrange
        var fakeAuthorRepository = A.Fake<IAuthorRepository>();
        var handler = new UpdateAuthorCommandHandler(fakeAuthorRepository);

        var authorId = Guid.NewGuid();
        var updatedAuthor = new Author("Updated Name");
        A.CallTo(() => fakeAuthorRepository.UpdateAuthor(authorId, A<Author>.That.Matches(a => a.Name == "Updated Name")))
            .Returns(updatedAuthor);

        var command = new UpdateAuthorCommand(authorId, "Updated Name");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.AreEqual("Updated Name", result.Name);
        A.CallTo(() => fakeAuthorRepository.UpdateAuthor(authorId, A<Author>.That.Matches(a => a.Name == "Updated Name")))
            .MustHaveHappenedOnceExactly();
    }
}
