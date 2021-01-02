using System.Collections.Generic;
using CrmBl.Model;
using NUnit.Framework;

namespace CrmBlTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CartTest()
        {
            // arrange
            var customer = new Customer
            {
                CustomerId = 1,
                Name = "testName"
            };

            var product1 = new Product
            {
                ProductId = 1,
                Name = "first product",
                Price = 100,
                Count = 10
            };

            var product2 = new Product
            {
                ProductId = 2,
                Name = "second product",
                Price = 200,
                Count = 20
            };

            var cart = new Cart(customer);
            var expectedResult = new List<Product>
            {
                product1, product2
            };
            // act 
            cart.Add(product1);
            cart.Add(product2);

            var carResult = cart.GetAll();
            // assert
            Assert.AreEqual(expectedResult.Count, carResult.Count);
            for (var i = 0; i < expectedResult.Count; i++) Assert.AreEqual(expectedResult[i], carResult[i]);
        }
    }
}