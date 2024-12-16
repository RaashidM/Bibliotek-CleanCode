using Application.Authors.Queries.GetAllAuthors;
using Application.Interfaces.RepositoryInterfaces;
using Domain;
using FakeItEasy;

namespace TestProject;

public class GetAllAuthorsTest
{
    private IAuthorRepository _fakeAuthorRepository;
    private GetAllAuthorsQueryHandler _handler;

    [SetUp]
    public void Setup()
    {
        _fakeAuthorRepository = A.Fake<IAuthorRepository>();
        _handler = new GetAllAuthorsQueryHandler(_fakeAuthorRepository);
    }

    [Test]
    public async Task Handle_Should_Return_List_Of_Authors()
    {
        // Arrange
        var authors = new List<Author>
            {
                new Author("Author 1"),
                new Author("Author 2")
            };
        A.CallTo(() => _fakeAuthorRepository.GetAllAuthors()).Returns(authors);

        var query = new GetAllAuthorsQuery();

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Author 1", result[0].Name);
        Assert.AreEqual("Author 2", result[1].Name);
    }
}
