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
            ShoppingCart shoppingCart = new ShoppingCart(new ProductDao());
            //IProductDao productdao = new ProductDao();
            //var product = productdao.GetProduct(1);
            var expected = 100;
            // act
            shoppingCart.Add(1, 1);
            shoppingCart.Checkout();
            // assert
            int actual = shoppingCart.TotalFee;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the buy 1x e p1 1x e p2 total fee should be 190.
        /// </summary>
        [TestMethod]
        public void Test_Buy_1xEP1_1xEP2_TotalFee_Should_be_190()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart(new ProductDao());
            var expected = 100;
            // act
            shoppingCart.Add(1, 1);
            shoppingCart.Add(2, 1);
            shoppingCart.Checkout();
            // assert
            int actual = shoppingCart.TotalFee;
            Assert.AreEqual(expected, actual);
        }
    }
}
