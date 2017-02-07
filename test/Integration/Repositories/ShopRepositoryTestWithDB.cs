using System;
using System.Linq;
using RestMeet.Model;
using RestMeet.Repository;
using RestMeet.Test;
using Xunit;


namespace RestMeet.Unit.Repositories
{
    public class ShopRepositoryTestWithDB
    {
        private TestContext databaseContext;
        private ShopRepository objRepo;
        public ShopRepositoryTestWithDB()
        {
            databaseContext = new TestContext();
            objRepo = new ShopRepository(databaseContext);
        }

        [Fact]
        public void Shop_Repository_Get_ALL()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            ////Assert

            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal("Shop Q", result[0].Name);
            Assert.Equal("Shop W", result[1].Name);
            Assert.Equal("Shop B", result[2].Name);
        }

        [Fact]
        public void Shop_Repository_Create()
        {
            //Arrange
            var c = new Shop { Name = "Shop Z" };

            //Act
            var result = objRepo.Add(c);
            databaseContext.SaveChanges();

            var lst = objRepo.GetAll().ToList();

            //Assert

            Assert.Equal(4, lst.Count);
            Assert.Equal("Shop Z", lst.Last().Name);
        }

        [Fact]
        public void Shop_Repository_Find_By_Id()
        {
            //Act
            var result = objRepo.FindBy(a => a.Id == 1).FirstOrDefault();
            //Assert
            Assert.NotNull(result);
            Assert.Equal("Shop Q", result.Name);
        }

        [Fact]
        public void Shop_Repository_Delete()
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
        public void Shop_Repository_Edit()
        {
            //Act
            var result = objRepo.GetAll().ToList();
            // Assert 
            result[0].Name = "Thailand";
            objRepo.Edit(result[0]);
            databaseContext.SaveChanges();

            //var result2 = objRepo.GetAll().ToList();
            //Assert.Equal("Thailand", result2[0].Name);
        }
    }
}