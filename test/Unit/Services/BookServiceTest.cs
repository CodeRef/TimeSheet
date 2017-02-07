using Moq;
using Ploeh.AutoFixture;
using RestMeet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestMeet.Service;
using Xunit;

namespace RestMeet.Test.Services
{
    public class BookServiceTest
    {
        private Mock<IBookRepository> _bookRepository;
        private Mock<IUnitOfWork> _mockUnitWork;
        private IBook _bookServ;
        private List<Model.Book> bookCollection;
        public BookServiceTest()
        {
            _bookRepository = new Mock<IBookRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _bookServ = new Service.BookService(_mockUnitWork.Object, _bookRepository.Object);

            var fixture = new Fixture();
            var myInstances = fixture.Build<Model.Book>()
                .Without(m => m.UpdateUser)
                .Without(m => m.CreateUser)
                .CreateMany(10).ToList();
            bookCollection = new List<Model.Book>();
            bookCollection.AddRange(myInstances);
        }
        [Fact]
        public void GetAll__Expect_Collection_Of_Book_WhenCall()
        {
            //Arrange
            IQueryable<Model.Book> queryableToDo = bookCollection.AsQueryable();//listToDo.AsQueryable();
            _bookRepository.Setup(x => x.GetAll()).Returns(queryableToDo);

            //Act
            var results = _bookServ.GetAll().ToList();

            //Assert
            Assert.NotNull(results);
            Assert.Equal(10, results.Count);
        }
        [Fact]
        public void CreateBook_Expect_TrueOrFalse_WhenCall()
        {
            //Arrange
            var Id = 1;
            var book = new Model.Book { Name = "Clean Code" };
            _bookRepository.Setup(m => m.Add(book)).Returns((Model.Book e) =>
            {
                e.Id = Id;
                return e;
            });

            //Act
            _bookServ.Create(book);

            //Assert
            Assert.Equal(Id, book.Id);
            _mockUnitWork.Verify(m => m.Commit(), Times.Once);
        }
    }
}
