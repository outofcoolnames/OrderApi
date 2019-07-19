using AutoFixture;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderApi.Controllers;
using OrderApi.DAL;
using OrderApi.Entities;
using OrderApi.ModelFactory;
using OrderApi.Utils;
using System;
using System.Threading.Tasks;

namespace OrderApi.Tests
{
    [TestClass]
    public class ProductControllerTests
    {
        private Fixture _fixture;
        private Mock<IOrderEntityFactory> _iorderEntityFactoryMock;
        private Mock<ICreateOrderFactory> _iCreateOrderFactoryMock;        
        private Mock<IRequestUtils> _requestUtilsMock;
        private Mock<IOrderApiDAL> _dalMock;
        private ProductController _controller;
        [TestInitialize]
        public void TestInitialize()
        {
            _fixture = new Fixture();
            _iorderEntityFactoryMock = new Mock<IOrderEntityFactory>();
            _iCreateOrderFactoryMock = new Mock<ICreateOrderFactory>();
            _requestUtilsMock = new Mock<IRequestUtils>();
            _dalMock = new Mock<IOrderApiDAL>();
            
        }
        [TestMethod]
        public async Task GivenAProductOrder_WhenThePayloadIsValid_ThenVerifyTheControllerReturnsOk()
        {
            //arrange
            var dto = _fixture.Create<CreateOrder>();
            var orderEntity = _fixture.Create<OrderEntity>();
            orderEntity.OrderId = Guid.NewGuid();
            string client = string.Empty;
            _requestUtilsMock.Setup(r => r.GetClient(It.IsAny<HttpRequest>())).Returns(client);
            _iorderEntityFactoryMock.Setup(f => f.GetOrderEntity(It.IsAny<CreateOrder>(), It.IsAny<string>())).Returns(orderEntity);
            

            _dalMock.Setup(d => d.Insert(It.IsAny<OrderEntity>())).Returns(orderEntity);
            _controller = new ProductController(_iorderEntityFactoryMock.Object, _iCreateOrderFactoryMock.Object, _dalMock.Object, _requestUtilsMock.Object);

            //act
            var actionResult = _controller.Post(dto);

            //assert
            Assert.IsInstanceOfType(actionResult, typeof(CreatedAtRouteResult));
        }
        [TestMethod]
        public void GivenAProductOrder_WhenTheClientHasOutstandingOrdersWithATotalValueInExcessOfOneHundredEuro_ThenVerifyTheControllerReturnsBadRequest()
        {
            //todo... more tests
            //arrange

            //acct

            //assert
        }
    }
}
