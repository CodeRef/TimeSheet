using System;
using System.Linq;
using RestMeet.Model;
using RestMeet.Repository;
using RestMeet.Test;
using Xunit;
using Ploeh.AutoFixture;
using RestMeet.Service;

namespace RestMeet.Unit.Repositories
{
    public class GroupServiceTestWithDB
    {
        private TestContext databaseContext;
        private IGroupRepository objRepo;
        private readonly GroupService groupServe;
        public GroupServiceTestWithDB()
        {
            databaseContext = new TestContext();
            var unitOfwork = new UnitOfWork(databaseContext);

            objRepo = new GroupRepository(databaseContext);
            groupServe = new GroupService(unitOfwork, objRepo);
        }

        //[Fact]
        //public void Group_Repository_Get_ALL()
        //{
        //    //Act
        //    var result = objRepo.GetAll().ToList();

        //    ////Assert

        //    Assert.NotNull(result);
        //    Assert.Equal(3, result.Count);
        //    Assert.Equal("Group Q", result[0].Name);
        //    Assert.Equal("Group W", result[1].Name);
        //    Assert.Equal("Group B", result[2].Name);
        //}

        [Fact]
        public void Group_Repository_Create()
        {
            ////Arrange
            //var c = new Group { Name = "Group Z" };


            var fixture = new Fixture();
            var group = fixture.Build<ps_group>().With(p => p.Id, 1).Create<ps_group>();

            //Act
            var result = groupServe.Create(group);// objRepo.Add(c);
            //databaseContext.SaveChanges();

            var lst = objRepo.GetAll().ToList();

            //Assert

            Assert.Equal(4, lst.Count);
            //Assert.Equal("Group Z", lst.Last().Name);

        }

        //[Fact]
        //public void Group_Repository_Find_By_Id()
        //{
        //    //Act
        //    var result = objRepo.FindBy(a => a.Id == 1).FirstOrDefault();
        //    //Assert
        //    Assert.NotNull(result);
        //    Assert.Equal("Group Q", result.Name);
        //}

        //[Fact]
        //public void Group_Repository_Delete()
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
        //public void Group_Repository_Edit()
        //{
        //    //Act
        //    var result = objRepo.GetAll().ToList();
        //    // Assert 
        //    result[0].Name = "Thailand";
        //    objRepo.Edit(result[0]);
        //    databaseContext.SaveChanges();

        //    //var result2 = objRepo.GetAll().ToList();
        //    //Assert.Equal("Thailand", result2[0].Name);
        //}
    }
}