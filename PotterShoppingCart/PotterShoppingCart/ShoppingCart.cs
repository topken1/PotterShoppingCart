using System;
using System.Collections.Generic;
using System.Linq;
namespace PotterShoppingCart
{
    /// <summary>
    /// 
    /// </summary>
    public class ShoppingCart
    {
        public ShoppingCart()
        {

        }
        public ShoppingCart(IProductDao productdao)
        {
            this._productdao = productdao;
        }
        private List<Item> _items = new List<Item>();

        private IProductDao _productdao;

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
        public void Add(int ID, int quantity)
        {
            var product = _productdao.GetProduct(ID);
            var item = _items.Where(i => i.Product.ID == product.ID).FirstOrDefault();
            if (item == null)
            {
                this._items.Add(new Item() { Product = product, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        /// <summary>
        /// Checkouts this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Checkout()
        {
            int minQuantity = _items.Min(i => i.Quantity);
            double discount = this._discountDictionary[_items.Count];
            TotalFee = (int)(_items.Sum(i => i.Product.Price * minQuantity) * discount);
            TotalFee += _items.Where(i => i.Quantity > minQuantity)
                .Sum(s => s.Product.Price * (s.Quantity - minQuantity));
        }

        private IDictionary<int, double> _discountDictionary = new Dictionary<int, double>()
        {
            { 1, 1 },
            { 2, 0.95 },
            { 3, 0.9 },
            { 4, 0.8 },
            { 5, 0.75 },
        };
       
    }

    public class Item
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        internal Product Product { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        internal int Quantity { get; set; }
    }
}