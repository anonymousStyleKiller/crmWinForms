using CrmBl.Model;
using NUnit.Framework;

namespace CrmBlTests
{
    [TestFixture]
    public class CashDeskTests
    {
        [Test]
        public void CashDeskTest()
        {
           // arrange 
           var customer1 = new Customer()
           {
               Name = "testUser1",
               CustomerId = 2
           };
           
           var customer2 = new Customer()
           {
               Name = "testUser2",
               CustomerId = 2
           };

           var seller = new Seller()
           {
               Name = "testSeller",
               SellerId = 1
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
           
           var cart1 = new Cart(customer1);
           cart1.Add(product1);
           cart1.Add(product2);
           
           
           var cart2 = new Cart(customer2);
           cart1.Add(product1);
           cart1.Add(product1);

           var cashDesk = new CashDesk(1, seller);
           cashDesk.MaxQueueLenght = 10;
           cashDesk.Endqueue(cart1);
           cashDesk.Endqueue(cart2);

           var cartExpectedRes1 = 300;
           var cartExpectedRes2 = 200;
           
           // act
           var carActualRes1 = cashDesk.Dequeue();
           var carActualRes2 = cashDesk.Dequeue();
           // assert
           Assert.AreEqual(carActualRes1, cartExpectedRes1);
           Assert.AreEqual(carActualRes2, cartExpectedRes2);
           Assert.AreEqual(8, product1.Count);
           Assert.AreEqual(18, product1.Count);
        }
    }
}