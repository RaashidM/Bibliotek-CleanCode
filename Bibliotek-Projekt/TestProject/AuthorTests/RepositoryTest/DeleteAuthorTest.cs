using Application.Books.Commands.DeleteBook;
using Application.Interfaces.RepositoryInterfaces;
using FakeItEasy;

namespace TestProject;

public class DeleteAuthorTest
{
    private IBookRepository _fakeBookRepository;
    private DeleteBookCommandHandler _handler;

    [SetUp]
    public void Setup()
    {
        _fakeBookRepository = A.Fake<IBookRepository>();
        _handler = new DeleteBookCommandHandler(_fakeBookRepository);
    }

    [Test]
    public async Task Handle_Should_Call_DeleteBookById_On_Repository()
    {
        // Arrange
        var bookId = Guid.NewGuid();
        var command = new DeleteBookCommand(bookId);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        A.CallTo(() => _fakeBookRepository.DeleteBookById(bookId))
         .MustHaveHappenedOnceExactly();
        Assert.AreEqual("Succesfully deleted", result);
    }
}
