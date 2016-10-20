using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PotterShoppingCart.Tests
{
    [TestClass]
    public class PotterShoppingCartTest
    {
        [TestMethod]
        public void Test_Buy_a_EP1_TotalFee_Should_Be_100()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            Product product = new Product()
            {
                ID = 1,
                Name = "哈利波特(1)：神祕的魔法石",
                Price = 100,
                Type = "Book",
                ISBN = "9573317249"
            };

            shoppingCart.Add(product, 1);

            var expected = 100;
            // act
            shoppingCart.Checkout();
            // assert
            int actual = shoppingCart.TotalFee;
            Assert.AreEqual(expected, actual);
        }
    }
}
