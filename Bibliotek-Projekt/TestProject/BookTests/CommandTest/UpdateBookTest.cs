//using Application.Books.Commands.UpdateBook;
//using Infrastructure.Database;

//namespace TestProject;

//public class UpdateBookTest
//{
//    private FakeDatabase _fakeDatabase;
//    private UpdateBookCommandHandler _handler;

//    [SetUp]
//    public void SetUp()
//    {
        
//        _fakeDatabase = new FakeDatabase();

       
//        _handler = new UpdateBookCommandHandler(_fakeDatabase);
//    }

//    [Test]
//    public async Task UpdateBook_ShouldUpdateBookSuccessfully_WhenBookExists()
//    {
//        //Arrange
//        var updatedTitle = "Updated Second Book";
//        var updatedDescription = "Updated Description";
//        var command = new UpdateBookCommand(2, updatedTitle, updatedDescription);

//        //Act
//        var updatedBook = await _handler.Handle(command, CancellationToken.None);

//        //Assert
//        Assert.AreEqual(2, updatedBook.Id);  
//        Assert.AreEqual(updatedTitle, updatedBook.Title); 
//        Assert.AreEqual(updatedDescription, updatedBook.Description);  

       
//        Assert.IsTrue(_fakeDatabase.BooksFromDB.Any(b => b.Id == 1 && b.Title == "First Book"));
//        Assert.IsTrue(_fakeDatabase.BooksFromDB.Any(b => b.Id == 3 && b.Title == "Third Book"));
//    }

//    [Test]
//    public void UpdateBook_ShouldThrowKeyNotFoundException_WhenBookDoesNotExist()
//    {
//        //Arrange
//        var command = new UpdateBookCommand(99, "Non-Existent Book", "Description");

//        //Act
//        var exception = Assert.ThrowsAsync<KeyNotFoundException>(async () =>
//        await _handler.Handle(command, CancellationToken.None));

//        //Assert
//        Assert.AreEqual("Book with ID 99 was not found.", exception.Message);  
//    }
//}
