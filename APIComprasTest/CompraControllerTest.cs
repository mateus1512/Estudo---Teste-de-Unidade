using APICompras.Controllers;
using APICompras.Models;
using APICompras.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;
namespace APIComprasTest
{
    public class CompraControllerTest
    {
        CompraController _controller;
        ICompraService _service;
        public CompraControllerTest()
        {
            _service = new CompraServiceFake();
            _controller = new CompraController(_service);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<CompraItem>>(okResult.Value);
            Assert.Equal(5, items.Count);
        }
    }
}