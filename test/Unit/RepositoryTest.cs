
using System.Data.Entity;
using Moq;
using RestMeet.Model;
using RestMeet.Repositories;
using Xunit;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RestMeet.Test
{
    public class RepositoryTest
    {
        [Fact]
        public void Test_Add_Object_By_Generic_Repository()
        {
            var mockSet = new Mock<DbSet<ToDo>>();
            var mockContext = new Mock<RestMeetContext>();

            mockContext.Setup(m => m.ToDoes).Returns(mockSet.Object);
            mockContext.Object.ToDoes.Add(new ToDo() { Description = "test" });
            mockContext.Object.SaveChanges();

            mockSet.Verify(m => m.Add(It.IsAny<ToDo>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            // Assert.True(true);
        }
       
    }
}
