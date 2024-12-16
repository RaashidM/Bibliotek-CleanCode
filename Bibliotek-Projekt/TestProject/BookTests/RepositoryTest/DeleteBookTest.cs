using Application.Books.Commands.DeleteBook;
using Application.Interfaces.RepositoryInterfaces;
using FakeItEasy;

namespace TestProject;

public class DeleteBookTest
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
    public async Task DeleteBookCommandHandler_Should_DeleteBookSuccessfully()
    {
        // Arrange
        var bookId = Guid.NewGuid();
        A.CallTo(() => _fakeBookRepository.DeleteBookById(bookId)).Returns("Succes");

        var command = new DeleteBookCommand(bookId);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.AreEqual("Succesfully deleted", result);
        A.CallTo(() => _fakeBookRepository.DeleteBookById(bookId)).MustHaveHappenedOnceExactly();
    }
}
