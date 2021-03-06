﻿using Effort;
using RestMeet.Test;
using System.Data.Common;
using System.Linq;
using TimeTracker.Repository;
using Xunit;

namespace RestMeet.Unit.Repositories
{
    public class ShopRepositoryTest
    {
        private DbConnection connection;
        private ShopContext databaseContext;
        private ShopRepository objRepo;


        public ShopRepositoryTest()
        {
            connection = DbConnectionFactory.CreateTransient();
            databaseContext = new ShopContext(connection);
            objRepo = new ShopRepository(databaseContext);
        }

        [Fact]
        public void Shop_Repository_Get_All()
        {
            //Act
            var result = objRepo.GetAll().ToList();
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Shop Q", result[0].Name);
            Assert.Equal("Shop W", result[1].Name);
            Assert.Equal("Shop B", result[2].Name);
        }

        //[Fact]
        //public void Shop_Repository_Create()
        //{
        //    //Arrange
        //    var c = new Shop { Name = "Shop Z" };
        //    //Act
        //    var result = objRepo.Add(c);
        //    databaseContext.SaveChanges();

        //    var lst = objRepo.GetAll().ToList();

        //    //Assert
        //    Assert.Equal(4, lst.Count);
        //    Assert.Equal("Shop Z", lst.Last().Name);
        //}

        [Fact]
        public void Shop_Repository_Find_By_Id()
        {
            //Act
            var result = objRepo.FindAll(a => a.Id == 1).FirstOrDefault();
            //Assert
            Assert.NotNull(result);
            Assert.Equal("Shop Q", result.Name);
        }

        //[Fact]
        //public void Shop_Repository_Delete()
        //{
        //    //Act
        //    var result = objRepo.GetAll().ToList();

        //    //Assert
        //    Assert.NotNull(objRepo.Delete(result[0]));
        //    databaseContext.SaveChanges();

        //    var rs = objRepo.GetAll().ToList();
        //    Assert.Equal(2, rs.Count());
        //}

        //[Fact]
        //public void ToDo_Repository_Edit()
        //{
        //    //Act
        //    var result = objRepo.GetAll().ToList();
        //    // Assert 
        //    result[0].Name = "Shop I";
        //    objRepo.Edit(result[0]);
        //    databaseContext.SaveChanges();

        //    var result2 = objRepo.GetAll().ToList();
        //    // Assert.Equal("Shop I", result2[0].Name);
        //}
    }
}