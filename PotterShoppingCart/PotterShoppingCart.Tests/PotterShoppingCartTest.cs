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
            shoppingCart.Add(ID:1, quantity:1);
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
            var expected = 190;
            // act
            shoppingCart.Add(ID: 1, quantity: 1);
            shoppingCart.Add(ID: 2, quantity: 1);
            shoppingCart.Checkout();
            // assert
            int actual = shoppingCart.TotalFee;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1xEP1_1xEP2_1xEP3_TotalFee_Should_be_270()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart(new ProductDao());
            var expected = 270;
            // act
            shoppingCart.Add(ID: 1, quantity: 1);
            shoppingCart.Add(ID: 2, quantity: 1);
            shoppingCart.Add(ID: 3, quantity: 1);
            shoppingCart.Checkout();
            // assert
            int actual = shoppingCart.TotalFee;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1xEP1_1xEP2_1xEP3_1xEP4_TotalFee_Should_be_320()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart(new ProductDao());
            var expected = 320;
            // act
            shoppingCart.Add(ID: 1, quantity: 1);
            shoppingCart.Add(ID: 2, quantity: 1);
            shoppingCart.Add(ID: 3, quantity: 1);
            shoppingCart.Add(ID: 4, quantity: 1);
            shoppingCart.Checkout();
            // assert
            int actual = shoppingCart.TotalFee;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_EachOne_TotalFee_Should_Be_375()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart(new ProductDao());
            var expected = 375;
            // act
            shoppingCart.Add(ID: 1, quantity: 1);
            shoppingCart.Add(ID: 2, quantity: 1);
            shoppingCart.Add(ID: 3, quantity: 1);
            shoppingCart.Add(ID: 4, quantity: 1);
            shoppingCart.Add(ID: 5, quantity: 1);
            shoppingCart.Checkout();
            // assert
            int actual = shoppingCart.TotalFee;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1xEP1_1xEP2_2xEP3_TotalFee_Should_Be_370()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart(new ProductDao());
            var expected = 370;
            // act
            shoppingCart.Add(ID: 1, quantity: 1);
            shoppingCart.Add(ID: 2, quantity: 1);
            shoppingCart.Add(ID: 3, quantity: 2);
            shoppingCart.Checkout();
            // assert
            int actual = shoppingCart.TotalFee;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1xEP1_2xEP2_2xEP3_TotalFee_Should_Be_460()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart(new ProductDao());
            var expected = 460;
            // act
            shoppingCart.Add(ID: 1, quantity: 1);
            shoppingCart.Add(ID: 2, quantity: 1);
            shoppingCart.Add(ID: 3, quantity: 2);
            shoppingCart.Checkout();
            // assert
            int actual = shoppingCart.TotalFee;
            Assert.AreEqual(expected, actual);
        }
    }
}
