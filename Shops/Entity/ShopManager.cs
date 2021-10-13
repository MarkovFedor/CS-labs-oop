using System;
using System.Collections.Generic;
using System.Text;

namespace Shops.Entity
{
    public class ShopManager
    {
        public ShopManager() { }
        public Shop CreateShop(string name, string address)
        {
            return new Shop(name, address);
        }

        public Product RegisterProduct(string productName)
        {
            return new Product(productName);
        }
    }
}
