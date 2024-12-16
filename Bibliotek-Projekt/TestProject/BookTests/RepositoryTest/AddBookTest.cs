using Application.Books.Commands;
using Application.Books.Commands.CreateBook;
using Application.Interfaces.RepositoryInterfaces;
using Domain;
using FakeItEasy;

namespace TestProject;

public class AddBookTest
{
    private IBookRepository _fakeBookRepository;
    private CreateBookCommandHandler _handler;

    [SetUp]
    public void Setup()
    {
        _fakeBookRepository = A.Fake<IBookRepository>();
        _handler = new CreateBookCommandHandler(_fakeBookRepository);
    }

    [Test]
    public async Task CreateBookCommandHandler_Should_CreateBookSuccessfully()
    {
        // Arrange
        var fakeBookRepository = A.Fake<IBookRepository>();
        var handler = new CreateBookCommandHandler(fakeBookRepository);

        var newBook = new Book("Test Title", "Test Description");
        A.CallTo(() => fakeBookRepository.AddBook(A<Book>.That.Matches(b => b.Title == "Test Title" && b.Description == "Test Description")))
            .Returns(newBook);

        var command = new CreateBookCommand("Test Title", "Test Description");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.AreEqual("Test Title", result.Title);
        Assert.AreEqual("Test Description", result.Description);
        A.CallTo(() => fakeBookRepository.AddBook(A<Book>.That.Matches(b => b.Title == "Test Title" && b.Description == "Test Description")))
            .MustHaveHappenedOnceExactly();
    }
}
