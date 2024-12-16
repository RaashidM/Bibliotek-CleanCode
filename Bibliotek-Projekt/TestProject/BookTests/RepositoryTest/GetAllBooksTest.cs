using Application.Books.Queries.GetBook;
using Application.Books.Queries.GetBooks;
using Application.Interfaces.RepositoryInterfaces;
using Domain;
using FakeItEasy;

namespace TestProject;

public class GetAllBooksTest
{
    private IBookRepository _fakeBookRepository;
    private GetAllBooksQueryHandler _handler;

    [SetUp]
    public void Setup()
    {
        _fakeBookRepository = A.Fake<IBookRepository>();
        _handler = new GetAllBooksQueryHandler(_fakeBookRepository);
    }

    [Test]
    public async Task GetAllBooksQueryHandler_Should_ReturnAllBooks()
    {
        // Arrange
        var books = new List<Book>
        {
            new Book("Book 1", "Description 1"),
            new Book("Book 2", "Description 2")
        };

        A.CallTo(() => _fakeBookRepository.GetAllBooks()).Returns(books);

        var query = new GetAllBooksQuery();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.AreEqual(2, result.Count);
        A.CallTo(() => _fakeBookRepository.GetAllBooks()).MustHaveHappenedOnceExactly();
    }
}
