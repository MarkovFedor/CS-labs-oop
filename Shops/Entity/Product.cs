using System;
using System.Collections.Generic;

namespace Shops.Entity
{
    public class Product
    {
        private string _productName;
        public Product(string productName)
        {
            _productName = productName;
        }

        public string GetName()
        {
            return _productName;
        }
    }
}
