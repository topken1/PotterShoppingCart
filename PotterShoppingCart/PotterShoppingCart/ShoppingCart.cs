using System;

namespace PotterShoppingCart
{
    /// <summary>
    /// 
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Gets or sets the total fee.
        /// </summary>
        /// <value>
        /// The total fee.
        /// </value>
        public int TotalFee { get; set; }

        /// <summary>
        /// Adds the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="number">The number.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Add(Product product, int number)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checkouts this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Checkout()
        {
            throw new NotImplementedException();
        }
    }
}