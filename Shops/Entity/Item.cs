using System;
using System.Collections.Generic;
using Shops.Exceptions;

namespace Shops.Entity
{
    public class Item
    {
        private Product _product;
        private int _price;
        private int _amount;
        public Item(Product product, int price, int amount)
        {
            _product = product;
            if (price > 0 && amount > 0)
            {
                _price = price;
                _amount = amount;
            }
            else
            {
                throw new ShopException("Некорректная цена или количество");
            }
        }

        public int GetAmount()
        {
            return _amount;
        }

        public void AddAmount(int amount)
        {
            _amount += amount;
        }

        public int GetPrice()
        {
            return _price;
        }

        public void SetPrice(int newPrice)
        {
            if (newPrice > 0)
            {
                _price = newPrice;
            }
            else
            {
                throw new ShopException("Некорректная цена");
            }
        }

        public Product GetProduct()
        {
            return _product;
        }

        public void SubstractAmount(int amount)
        {
            if (_amount >= amount)
            {
                _amount -= amount;
            }
            else
            {
                throw new ShopException("В магазине недостаточно товаров.");
            }
        }
    }
}
