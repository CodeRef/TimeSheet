using System;
using System.Linq;
using RestMeet.Model;
using RestMeet.Repository;
using Xunit;

namespace RestMeet.Test
{
    public class ToDoRepositoryTestWithDB
    {
        private TestContext databaseContext;
        private ToDoRepository objRepo;

        public ToDoRepositoryTestWithDB()
        {
            databaseContext = new TestContext();
            objRepo = new ToDoRepository(databaseContext);
        }

        [Fact]
        public void ToDo_Repository_Get_ALL()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            //Assert

            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal("US", result[0].Name);
            Assert.Equal("India", result[1].Name);
            Assert.Equal("Russia", result[2].Name);
        }
        [Fact]
        public void ToDo_Repository_Create()
        {
            //Arrange
            var c = new ToDo
            {
                Name = "UK",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Start = DateTime.Now,
                End = DateTime.Now
            };

            //Act
            var result = objRepo.Add(c);
            databaseContext.SaveChanges();

            var lst = objRepo.GetAll().ToList();

            //Assert

            Assert.Equal(4, lst.Count);
            Assert.Equal("UK", lst.Last().Name);
        }

        [Fact]
        public void ToDo_Repository_Find_By_Id()
        {
            //Act
            var result = objRepo.FindBy(a => a.Id == 1).FirstOrDefault();
            //Assert
            Assert.NotNull(result);
            Assert.Equal("US", result.Name);
        }

        [Fact]
        public void ToDo_Repository_Delete()
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
            result[0].Name = "Thailand";
            objRepo.Edit(result[0]);
            databaseContext.SaveChanges();

            var result2 = objRepo.GetAll().ToList();
            Assert.Equal("Thailand", result2[0].Name);
        }
    }
}