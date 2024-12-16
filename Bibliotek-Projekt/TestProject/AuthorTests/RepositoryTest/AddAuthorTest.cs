using Application.Authors.Commands.CreateAuthor;
using Application.Interfaces.RepositoryInterfaces;
using Domain;
using FakeItEasy;

namespace TestProject;

public class AddAuthorTest
{

    private IAuthorRepository _fakeAuthorRepository;
    private CreateAuthorCommandHandler _handler;

    [SetUp]
    public void Setup()
    {
        _fakeAuthorRepository = A.Fake<IAuthorRepository>();
        _handler = new CreateAuthorCommandHandler(_fakeAuthorRepository);
    }

    [Test]
    public async Task Handle_Should_Call_AddAuthor_On_Repository()
    {
        // Arrange
        var command = new CreateAuthorCommand("Test Author");

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        A.CallTo(() => _fakeAuthorRepository.AddAuthor(A<Author>.That.Matches(a => a.Name == "Test Author")))
         .MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task Handle_Should_Return_Author_From_Repository()
    {
        // Arrange
        var command = new CreateAuthorCommand("Test Author");
        var expectedAuthor = new Author("Test Author");
        A.CallTo(() => _fakeAuthorRepository.AddAuthor(A<Author>.Ignored))
         .Returns(expectedAuthor);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        Assert.AreEqual(expectedAuthor.Name, result.Name);
    }
}
