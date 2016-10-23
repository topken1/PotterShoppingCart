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
        private List<SaleItem> _saleitems = new List<SaleItem>();

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
        public void AddSaleItem(int id, int quantity)
        {
            var product = _productdao.GetProduct(id);
            var item = _saleitems.Where(i => i.Product.ID == product.ID).FirstOrDefault();
            if (item == null)
            {
                this._saleitems.Add(new SaleItem() { Product = product, Quantity = quantity });
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
            //int minQuantity = _items.Min(i => i.Quantity);
            //double discount = this._discountDictionary[_items.Count];
            //TotalFee = (int)(_items.Sum(i => i.Product.Price * minQuantity) * discount);

            //var unSumItems = _items.Select(x => { x.Quantity -= minQuantity; return x; }).Where( o=>o.Quantity >0).ToList();
            //if (unSumItems.Count > 0)
            //{
            //    double unSumDiscount = this._discountDictionary[unSumItems.Count()];
            //    TotalFee += (int)(unSumItems.Sum(i => i.Product.Price * minQuantity) * unSumDiscount);
            //}

            TotalFee += DiscountedItem(_saleitems);
        }

        /// <summary>
        /// Discounteds the item.
        /// </summary>
        /// <param name="_items">The items.</param>
        /// <returns></returns>
        private int DiscountedItem(List<SaleItem> _items)
        {
            // 取出項目中數量最小的量
            int minQuantity = _items.Min(i => i.Quantity);
            // 取出可以打折的折扣數 (先把最大範圍的折扣計數掉)
            double discount = this._discountDictionary[_items.Count];
            // { 5, 1 ,1 ,1 ,1 } ==>  Discounted { 1, 1, 1, 1, 1} 
            // { 5, 4 ,4, 4, 4 } ==>  Discounted { 4, 4, 4, 4, 4}
            int totoalFee = (int)(_items.Sum(i => i.Product.Price * minQuantity) * discount);
            // 取出未處理的項目
            var unSumItems = _items.Select(x => { x.Quantity -= minQuantity; return x; }).Where(o => o.Quantity > 0).ToList();
            if(unSumItems.Count > 0)
            {
                // 計算尚未折扣的項目費用
                totoalFee += DiscountedItem(unSumItems);
            }
            return totoalFee;
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

    public class SaleItem
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