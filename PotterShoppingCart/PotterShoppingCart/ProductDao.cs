using System;

namespace PotterShoppingCart
{
    public class ProductDao : IProductDao
    {
        public ProductDao()
        {
        }

        public Product GetProduct(int id)
        {
            switch (id)
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
                case 3:
                    return new Product()
                    {
                        ID = 3,
                        Name = "哈利波特(3)：阿茲卡班的逃犯",
                        Price = 100,
                        Type = "Book",
                        ISBN = "9573318008"
                    };
                case 4:
                    return new Product()
                    {
                        ID = 4,
                        Name = "哈利波特(4)：火盃的考驗",
                        Price = 100,
                        Type = "Book",
                        ISBN = "9573318318"
                    };
                case 5:
                    return new Product()
                    {
                        ID = 5,
                        Name = "哈利波特(5)：鳳凰會的密令",
                        Price = 100,
                        Type = "Book",
                        ISBN = "9573319861"
                    };
            }
            return null;

        }
    }
}