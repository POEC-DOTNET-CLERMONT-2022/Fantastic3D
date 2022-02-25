using AutoMapper;
using Fantastic3D.API.Controllers;
using Fantastic3D.Dto;
using Fantastic3D.DataManager;
using Fantastic3D.Persistence.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace Fantastic3D.Tests.API
{
    [TestClass]
    public class CrudOnUserControllerTest
    {
        private readonly UserController _controller;
        private readonly Mock<IDataManager<UserDto, UserEntity>> _mockData;

        public CrudOnUserControllerTest()
        {
            _mockData = new Mock<IDataManager<UserDto, UserEntity>>();
            _controller = new UserController(_mockData.Object);
        }
        [TestInitialize]
        public void InitTest()
        {
            _mockData.Setup(

                );
        }

        [TestMethod]
        public async Task GetAllAsync_OkResultWithObject()
        {
            // Arrange : done in InitTest()


            // Act
            var actionResult = await _controller.Get();

            // Assert
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var returnedObject = okObjectResult.Value as 

        }
    }
}