using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PaymentApp;
using PaymentApp.Contracts;
using PaymentApp.Controllers;
using PaymentApp.Models;
using PaymentApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PaymentTest.Controller
{
    public class PaymentControllerTest
    {
        private IPaymentService _service;
        private readonly PaymentController _controller;
      
        public PaymentControllerTest()
        {
            _service = new PaymentServiceFake();
            _controller = new PaymentController(_service);
        }
        [Fact]
        public void ReturnsAllQueryBalances()
        {
            // Act
            var okResult = _controller.QueryBalances() as List<Account>;
            // Assert
            var items = Xunit.Assert.IsType<List<Account>>(okResult);
            Xunit.Assert.Equal(3, items.Count);
        }
    }
}
