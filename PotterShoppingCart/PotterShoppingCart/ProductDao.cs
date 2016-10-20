using System;

namespace PotterShoppingCart
{
    public class ProductDao : IProductDao
    {
        public ProductDao()
        {
        }

        public Product GetProduct(int ID)
        {
            switch (ID)
            {
                case 1:
                    return new Product()
                    {
                        ID = 1,
                        Name = "哈利波特(1)：神祕的魔法石",
                        Price = 100,
                        Type = "Book",
                        ISBN = "9573317249"
                    };
                case 2:
                    return new Product()
                    {
                        ID = 2,
                        Name = "哈利波特(2)：消失的密室",
                        Price = 100,
                        Type = "Book",
                        ISBN = "9573317583"
                    };
            }
            return null;

        }
    }
}