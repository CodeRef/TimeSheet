using Moq;
using Ploeh.AutoFixture;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.Model;
using TimeTracker.Repository.Common;
using TimeTracker.Repository.IRepository;
using TimeTracker.Service.IService;
using Xunit;

namespace RestMeet.Test.Services
{
    public class BookServiceTest
    {
        private Mock<IBookRepository> _bookRepository;
        private Mock<IUnitOfWork> _mockUnitWork;
        private IBookService _bookServ;
        private List<Book> bookCollection;
        public BookServiceTest()
        {
            _bookRepository = new Mock<IBookRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _bookServ = new TimeTracker.Service.BookService(_mockUnitWork.Object, _bookRepository.Object);

            var fixture = new Fixture();
            var myInstances = fixture.Build<Book>()
                .Without(m => m.UpdateUser)
                .Without(m => m.CreateUser)
                .CreateMany(10).ToList();
            bookCollection = new List<Book>();
            bookCollection.AddRange(myInstances);
        }
        [Fact]
        public void GetAll__Expect_Collection_Of_Book_WhenCall()
        {
            //Arrange
            IQueryable<Book> queryableToDo = bookCollection.AsQueryable();//listToDo.AsQueryable();
            _bookRepository.Setup(x => x.GetAll()).Returns(queryableToDo);

            //Act
            var results = _bookServ.All().ToList();

            //Assert
            Assert.NotNull(results);
            Assert.Equal(10, results.Count);
        }
        [Fact]
        public void CreateBook_Expect_TrueOrFalse_WhenCall()
        {
            //Arrange
            var Id = 1;
            var book = new Book { Name = "Clean Code" };
            _bookRepository.Setup(m => m.Add(It.IsAny<Book>())).Returns(book);

            //Act
            _bookServ.Create(book);

            //Assert
            Assert.Equal(Id, book.Id);
            _mockUnitWork.Verify(m => m.Commit(), Times.Once);
        }
    }
}
