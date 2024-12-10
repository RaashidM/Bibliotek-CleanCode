//using Application.Authors.Queries.GetAllAuthors;
//using Infrastructure.Database;

//namespace TestProject;

//public class GetAllAuthorsTest
//{
//    private FakeDatabase _fakeDatabase;
//    private GetAllAuthorsQueryHandler _handler;

//    [SetUp]
//    public void SetUp()
//    {
//        _fakeDatabase = new FakeDatabase();
//        _handler = new GetAllAuthorsQueryHandler(_fakeDatabase);
//    }

//    [Test]
//    public async Task GetAllAuthors_ShouldReturnAllAuthors()
//    {
       

//        // Act
//        var authorsList = await _handler.Handle(new GetAllAuthorsQuery(), CancellationToken.None);

//        // Assert
//        Assert.AreEqual(3, authorsList.Count); // Det bör finnas exakt 3 författare
//        Assert.IsTrue(authorsList.Any(a => a.Id == 1 && a.Name == "First Author"));
//        Assert.IsTrue(authorsList.Any(a => a.Id == 2 && a.Name == "Second Author"));
//        Assert.IsTrue(authorsList.Any(a => a.Id == 3 && a.Name == "Third Author"));
//    }
//}
