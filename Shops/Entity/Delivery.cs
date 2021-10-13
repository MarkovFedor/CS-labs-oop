using System;
using System.Collections.Generic;
using Shops.Exceptions;

namespace Shops.Entity
{
    public class Delivery
    {
        private static int iD;
        private Dictionary<Product, Item> _itemsInDelivery;
        private int _id;
        public Delivery()
        {
            _id = ++iD;
            _itemsInDelivery = new Dictionary<Product, Item>();
        }

        public int GetId()
        {
            return _id;
        }

        public void AddProduct(Product product, int price, int amount)
        {
            if (price < 0 || amount < 0)
            {
                throw new ShopException("Некорректная цена или количество.");
            }

            if (!_itemsInDelivery.ContainsKey(product))
            {
                _itemsInDelivery.Add(product, new Item(product, price, amount));
            }
            else
            {
                _itemsInDelivery[product].AddAmount(amount);
            }
        }

        public Dictionary<Product, Item> GetItems()
        {
            return _itemsInDelivery;
        }
    }
}
