//using Application.Books.Queries.GetBook;
//using Application.Books.Queries.GetBooks;
//using Infrastructure.Database;

//namespace TestProject;
//[TestFixture]
//public class GetAllBooksTest
//{
//    private GetAllBooksQueryHandler _handler;
//    private FakeDatabase _fakeDatabase;

//    [SetUp]
//    public void Setup()
//    {
//        _fakeDatabase = new FakeDatabase();
//        _handler = new GetAllBooksQueryHandler(_fakeDatabase);
//    }

//    [Test]
//    public async Task Handle_ShouldReturnBooksFRomDatabase()
//    {
//        //Arrange
//        var expectedBooks = _fakeDatabase.BooksFromDB;
//        var query = new GetAllBooksQuery();

//        //Act
//        var result = await _handler.Handle(query, CancellationToken.None);


//        //Assert
//        Assert.AreEqual(expectedBooks.Count, result.Count);
//        for (int i = 0; i < expectedBooks.Count; i++)
//        {
//            Assert.AreEqual(expectedBooks[i].Id, result[i].Id);
//            Assert.AreEqual(expectedBooks[i].Title, result[i].Title);
//            Assert.AreEqual(expectedBooks[i].Description, result[i].Description);
//        }
//    }

//    [Test]
//    public async Task Handle_ShouldReturnEmptyList_WhenNoBooks()
//    {
//        // Arrange
//        _fakeDatabase.BooksFromDB.Clear();

//        var query = new GetAllBooksQuery();

//        // Act
//        var result = await _handler.Handle(query, CancellationToken.None);

//        // Assert
//        Assert.AreEqual(0, result.Count);
//    }
//}
