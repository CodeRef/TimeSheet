using System.Data.Common;
using System.Linq;
using Effort;
using RestMeet.Model;
using RestMeet.Repository;
using RestMeet.Test;
using Xunit;

namespace RestMeet.Unit.Repositories
{
    public class BookRepositoryTest
    {
        private DbConnection connection;
        private BookContext databaseContext;
        private TimeTracker.Repository.BookRepository objRepo;


        public BookRepositoryTest()
        {
            connection = DbConnectionFactory.CreateTransient();
            databaseContext = new BookContext(connection);
            objRepo = new TimeTracker.Repository.BookRepository(databaseContext);
        }

        [Fact]
        public void Book_Repository_Get_All()
        {
            //Act
            var result = objRepo.GetAll().ToList();
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Book Q", result[0].Name);
            Assert.Equal("Book W", result[1].Name);
            Assert.Equal("Book B", result[2].Name);
            Assert.Equal(result.Count, 3);
        }

        [Fact]
        public void Book_Repository_Create()
        {
            //Arrange
            var c = new Model.Book { Name = "Book Z" };
            //Act
            var result = objRepo.Add(c);
            databaseContext.SaveChanges();

            var lst = objRepo.GetAll().ToList();

            //Assert
            Assert.Equal(4, lst.Count);
            Assert.Equal("Book Z", lst.Last().Name);
        }

        [Fact]
        public void Book_Repository_Find_By_Id()
        {
            //Act
            var result = objRepo.FindAll(a => a.Id == 1).FirstOrDefault();
            //Assert
            Assert.NotNull(result);
            Assert.Equal("Book Q", result.Name);
        }

        [Fact]
        public void Book_Repository_Delete()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            //Assert
            Assert.NotNull(objRepo.Delete(result[0]));
            databaseContext.SaveChanges();

            var rs = objRepo.GetAll().ToList();
            Assert.Equal(2, rs.Count());
        }

        [Fact]
        public void ToDo_Repository_Edit()
        {
            //Act
            var result = objRepo.GetAll().ToList();
            // Assert 
            result[0].Name = "Book I";
            objRepo.Edit(result[0]);
            databaseContext.SaveChanges();

            var result2 = objRepo.GetAll().ToList();
            // Assert.Equal("Book I", result2[0].Name);
        }
    }
}