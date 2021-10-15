using System;
using System.Collections.Generic;
using Shops.Exceptions;

namespace Shops.Entity
{
    public class Delivery
    {
        private static int iD = 1;
        private List<Item> _itemsInDelivery;
        private int _id;
        public Delivery()
        {
            _id = ++iD;
            _itemsInDelivery = new List<Item>();
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

            foreach (var item in _itemsInDelivery)
            {
                if (item.GetProduct().Equals(product))
                {
                    item.AddAmount(amount);
                    return;
                }
            }

            _itemsInDelivery.Add(new Item(product, price, amount));
        }

        public List<Item> GetItems()
        {
            return _itemsInDelivery;
        }
    }
}
