using System;
using System.Collections.Generic;
using Shops.Exceptions;

namespace Shops.Entity
{
    public class Shop
    {
        private static int iD;
        private int _id;
        private string _name;
        private string _address;
        private Dictionary<Product, Item> _shopItems;
        public Shop(string name, string address)
        {
            _name = name;
            _address = address;
            _id = ++iD;
            _shopItems = new Dictionary<Product, Item>();
        }

        public void Deliver(Delivery delivery)
        {
            foreach (var item in delivery.GetItems())
            {
                if (_shopItems.ContainsKey(item.Key))
                {
                    _shopItems[item.Key].AddAmount(item.Value.GetAmount());
                }
                else
                {
                    _shopItems[item.Key] = item.Value;
                }
            }
        }

        public void Buy(Person buyer, Product product, int amount)
        {
            if (_shopItems.ContainsKey(product))
            {
                if (_shopItems[product].GetAmount() >= amount)
                {
                    buyer.SpentMoney(_shopItems[product].GetPrice() * amount);
                    _shopItems[product].Substract(amount);
                    buyer.AddProduct(product, amount);
                }
            }
            else
            {
                throw new ShopException("В ассортименте магазина такого товара нет.");
            }
        }

        public void Buy(Person buyer, Dictionary<Product, int> products)
        {
            foreach (var product in products)
            {
                Buy(buyer, product.Key, product.Value);
            }
        }

        public string GetAddress()
        {
            return _address;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public int GetAmountOfProduct(Product product)
        {
            return _shopItems[product].GetAmount();
        }

        public int GetPriceOfProduct(Product product)
        {
            return _shopItems[product].GetPrice();
        }

        public void ShowInformation()
        {
            Console.WriteLine($"Магазин: {_name}");
            Console.WriteLine($"Всего категорий товаров: {_shopItems.Count}");
            foreach (var item in _shopItems)
            {
                Console.WriteLine($"Название: {item.Value.GetProduct().GetName()}");
                Console.WriteLine($"         Цена: {item.Value.GetPrice()}");
                Console.WriteLine($"         К-во: {item.Value.GetAmount()}");
            }
        }
    }
}
