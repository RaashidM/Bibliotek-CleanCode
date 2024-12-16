using Application.Books.Commands.UpdateBook;
using Application.Interfaces.RepositoryInterfaces;
using Domain;
using FakeItEasy;

namespace TestProject;

public class UpdateBookTest
{
    private IBookRepository _fakeBookRepository;
    private UpdateBookCommandHandler _handler;

    [SetUp]
    public void Setup()
    {
        _fakeBookRepository = A.Fake<IBookRepository>();
        _handler = new UpdateBookCommandHandler(_fakeBookRepository);
    }

    [Test]
    public async Task Handle_Should_Update_Book_In_Repository()
    {
        // Arrange
        var bookId = Guid.NewGuid();
        var command = new UpdateBookCommand(bookId, "New Title", "New Description");
        var updatedBook = new Book("New Title", "New Description") { Id = bookId };

        A.CallTo(() => _fakeBookRepository.UpdateBook(bookId, A<Book>.Ignored))
         .Returns(updatedBook);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        A.CallTo(() => _fakeBookRepository.UpdateBook(bookId, A<Book>.That.Matches(b => b.Title == "New Title" && b.Description == "New Description")))
         .MustHaveHappenedOnceExactly();
        Assert.AreEqual("New Title", result.Title);
    }
}
