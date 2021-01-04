using System.Threading;
using CrmBl.Model;
using NUnit.Framework;

namespace CrmBlTests
{
    [TestFixture]
    public class ShopComputerModelTests
    {
        [Test]
        public void StartTest()
        {
            var model = new ShopComputerModel();
            model.Start();
            Thread.Sleep(10000);
        }
    }
}