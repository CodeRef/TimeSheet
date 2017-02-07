
﻿using System;
using System.Collections.Generic;
using Moq;
using RestMeet.Model;
using RestMeet.Repository;
using RestMeet.Service;
using Xunit;
using System.Linq;

namespace RestMeet.Test.Services
{
    public class ToDoServiceTest
    {
        private Mock<IToDoRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitWork;
        private IToDoService _service;
        private List<ToDo> listToDo;


        private ApplicationUser appUser;
        public ToDoServiceTest()
        {
            _mockRepository = new Mock<IToDoRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new ToDoService(_mockUnitWork.Object, _mockRepository.Object);

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
        public void GetAll__ExpectListOfToDo_WhenCall()
        {
            //Arrange
            IQueryable<ToDo> queryableToDo = listToDo.AsQueryable();
            _mockRepository.Setup(x => x.GetAll()).Returns(queryableToDo);

            //Act
            var results = _service.GetAll().ToList();

            //Assert
            Assert.NotNull(results);
            Assert.Equal(3, results.Count);
        }

        [Fact]
        public void Create_ExpectVerifyTrue_WhenCallWithNewToDoObjectParaMeter()
        {
            //Arrange
            var Id = 1;
            var emp = new ToDo { Name = "UK" };
            _mockRepository.Setup(m => m.Add(emp)).Returns((ToDo e) =>
            {
                e.Id = Id;
                return e;
            });

            //Act
            _service.Create(emp);

            //Assert
            Assert.Equal(Id, emp.Id);
        }

        [Fact]
        public void Update_ExpectUpdateObject_WhenCallWithExistsToDoObjectParameter()
        {
            // Arrang
            _mockRepository.Setup(x => x.GetById(1)).Returns(listToDo[0]);

            // Act
            var td = _service.GetById(1);
            td.Name = "Hello World";
            _service.Update(td);

            // Assert
            var result = _service.GetById(1);
            Assert.Equal(result.Name, td.Name);
        }

        [Fact]
        public void Update_ExpectArgumentNullException_WhenCallWithNullObjectParameter()
        {
            // Arrang
            _mockRepository.Setup(x => x.GetById(1)).Returns(listToDo[0]);

            // Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => _service.Update(null));
            // Assert
            Assert.IsType(typeof(ArgumentNullException), ex);
        }

        [Fact]
        public void Delete_ExpectDeletedObject_WhenCallWithExistsToDoObjectParameter()
        {
            // Arrang
            _mockRepository.Setup(x => x.GetById(1)).Returns(listToDo[0]);

            // Act
            var td = _service.GetById(1);
            _service.Delete(td);

            //// Assert
            //// var result = _service.GetById(1);
            //// moAssert.IsNull(_service.GetAll());
            ////_mockRepository.Verify(a => a.Delete(td), Times.Once);
            //_mockRepository.Verify(a => a.GetById(1), Times.Once);
        }

        [Fact]
        public void SetExpire_ExpectObject_WhenCallWithExistsToDoObjectParameter()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetById(1)).Returns(listToDo[0]);

            //Act
            var expireObject = _service.SetExpire(1);

            //Assert
            Assert.NotNull(expireObject);
        }
        [Fact]
        public void GetToDoByOwnerId_Expect_ListOfToDo()
        {
            //Arrange
            IQueryable<ToDo> queryToDo = listToDo.AsQueryable();
            _mockRepository.Setup(x => x.GetAll()).Returns(queryToDo);

            //Act
            var results = _service.GetToDoByOwnerId(appUser.Id);

            //Assert
            Assert.NotNull(results);
            Assert.Equal(3, results.Count);
        }
    }
}
