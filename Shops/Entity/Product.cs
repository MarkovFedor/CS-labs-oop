using System;
using System.Collections.Generic;

namespace Shops.Entity
{
    public class Product
    {
        private static int iD = 1;
        private int _id;
        private string _productName;
        public Product(string productName)
        {
            _id = iD++;
            _productName = productName;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _productName;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Product);
        }

        public bool Equals(Product other)
        {
            return _id == other.GetId();
        }

        public override int GetHashCode()
        {
            return _id;
        }
    }
}
