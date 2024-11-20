using Application;
using Domain;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_AddNewBook_Method_IsCalled_Then_BookAddedToList()
        {
            //Arrange
            Book bookToTest = new Book(1, "Harry Potter", "Fantasy Book");

            //Act
            Book bookCreated = BookMethods.AddNewBook();
           
            //Assert
            Assert.That(bookCreated, Is.Not.Null);
            Assert.That(bookCreated.Description, Is.EqualTo(bookToTest.Description));
        }
    }
}