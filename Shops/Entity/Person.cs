using System;
using System.Collections.Generic;
using Shops.Exceptions;

namespace Shops.Entity
{
    public class Person
    {
        private string _name;
        private int _money;
        private Dictionary<Product, int> _bag;
        public Person(string name, int money)
        {
            _name = name;
            _money = money;
            _bag = new Dictionary<Product, int>();
        }

        public int ShowAmountProductInBag(Product product)
        {
            return _bag[product];
        }

        public void SpentMoney(int cost)
        {
            if (_money >= cost)
            {
                _money -= cost;
            }
            else
            {
                throw new ShopException("У покупателя недостаточно денег.");
            }
        }

        public void AddProduct(Product addingProduct, int amount)
        {
            if (_bag.ContainsKey(addingProduct))
            {
                _bag[addingProduct] += amount;
            }
            else
            {
                _bag.Add(addingProduct, amount);
            }
        }

        public string GetName()
        {
            return _name;
        }

        public int GetMoney()
        {
            return _money;
        }

        public void ShowInformation()
        {
            Console.WriteLine($"Имя: {_name}");
            Console.WriteLine($"Денег: {_money}");
            Console.WriteLine("Список покупок: ");
            foreach (var product in _bag)
            {
                Console.WriteLine($"    Наименование: {product.Key.GetName()}, Количество: {product.Value}");
            }
        }
    }
}
