using System;
using Moq;
using RestMeet.Service;
using RestMeet.Controllers;
using RestMeet.Model;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;
using System.Linq;
using System.Data.Common;
using Effort;
using System.Collections.Specialized;
using RestMeet.Areas.Backend.Controllers;

namespace RestMeet.Test.Controller
{
    public class ToDoControllerTest
    {
        private Mock<IToDoService> _toDoServiceMock;
        ToDoController objController;
        List<ToDo> listToDo;

        private ApplicationUser appUser;
      //  Mock<ControllerContext> controllerContext;
        public ToDoControllerTest()
        {
            //controllerContext = new Mock<ControllerContext>();

            _toDoServiceMock = new Mock<IToDoService>();
            objController = new ToDoController(_toDoServiceMock.Object);

            appUser = new ApplicationUser();
            listToDo = new List<ToDo>
            {
                new ToDo
                {
                    Id = 1,
                    Name = "US",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    OwnerBy=appUser
                },
                new ToDo
                {
                    Id = 2,
                    Name = "India",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    OwnerBy=appUser
                },
                new ToDo
                {
                    Id = 3,
                    Name = "Russia",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    OwnerBy=appUser
                }
            };
        }
        [Fact]
        public void ToDo_Index_Test_Expect_Collection_Of_ToDo()
        {
            //Arrange
            IQueryable<ToDo> queryableToDo = listToDo.AsQueryable();
            _toDoServiceMock.Setup(x => x.GetAll()).Returns(queryableToDo);

            //// Arrang context properties
            //controllerContext.SetupGet(p => p.HttpContext.Request.QueryString).Returns(new NameValueCollection());
            //objController.ControllerContext = controllerContext.Object;

            //Act
            var result = ((objController.Index() as ViewResult).Model) as List<ToDo>;

            //Assert
            Assert.Equal(result.Count, 3);
            Assert.Equal("US", result[0].Name);
            Assert.Equal("India", result[1].Name);
            Assert.Equal("Russia", result[2].Name);
        }
        [Fact]
        public void Valid_ToDo_Create()
        {
            //Arrange
            var td = new ToDo
                {
                    Id = 4,
                    Name = "Thailand",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Start = DateTime.Now,
                    End = DateTime.Now
                };

            //Act
            var result = (RedirectToRouteResult)objController.Create(td);

            ////Assert 
            //_toDoServiceMock.Verify(m => m.Create(td), Times.Once);
            //Assert.Equal("Index", result.RouteValues["action"]);
        }
        [Fact]
        public void Get_ToDo_By_Owner_Id()
        {
            //Arrange
            // IQueryable<ToDo> queryableToDo = listToDo.AsQueryable();
            _toDoServiceMock.Setup(x => x.GetToDoByOwnerId(appUser.Id)).Returns(listToDo);

            //Act
            var result = ((objController.GetToDoByOwnerId(appUser.Id) as ViewResult).Model) as List<ToDo>;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Count, 3);
            Assert.Equal("US", result[0].Name);
            Assert.Equal("India", result[1].Name);
            Assert.Equal("Russia", result[2].Name);
        }
    }
}
