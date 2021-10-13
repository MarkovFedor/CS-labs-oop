using NUnit.Framework;
using Shops.Entity;
using System.Collections.Generic;

namespace Shops.Tests
{
    public class Tests
    {
        private ShopManager _shopManager;

        [SetUp]
        public void Setup()
        {
            _shopManager = new ShopManager();
        }

        [Test]
        public void CreateShopAddItemsToSystemDeliverItems_BuyItems()
        {
            Shop ashan = _shopManager.CreateShop("ashan", "mira 113");

            Person Vasya = new Person("Vasya", 100);

            Product apples = _shopManager.RegisterProduct("Apples");

            Delivery delivery = new Delivery();

            delivery.AddProduct(apples, 10, 12);

            ashan.Deliver(delivery);

            ashan.Buy(Vasya, apples, 8);

            Assert.AreEqual(4, ashan.GetAmountOfProduct(apples));
            Assert.AreEqual(20, Vasya.GetMoney());
        }

        [Test]
        public void SettingUpAndUpdatingOfPrices_ItemIsAddWithPrice()
        {
            Shop ashan = _shopManager.CreateShop("ashan", "mira 113");
            Product apples = _shopManager.RegisterProduct("Apples");
            Delivery delivery = new Delivery();
            delivery.AddProduct(apples, 10, 12);
           
            ashan.Deliver(delivery);
            Assert.AreEqual(10, ashan.GetPriceOfProduct(apples));
        }
        [Test]
        public void BuyManyProducts_SpentMoneyAndChangedAmountOfProduct()
        {
            Dictionary<Product, int> products = new Dictionary<Product, int>();

            Product apples = _shopManager.RegisterProduct("Apples");
            Product bananas = _shopManager.RegisterProduct("Banana");

            products.Add(apples, 5);
            products.Add(bananas, 4);

            Shop ashan = _shopManager.CreateShop("Ashan", "Mira 113");

            Delivery delivery = new Delivery();
            delivery.AddProduct(apples, 10, 10);
            delivery.AddProduct(bananas, 11, 10);
            ashan.Deliver(delivery);
            Person Alex = new Person("Alex", 100);

            ashan.Buy(Alex, products);

            Assert.AreEqual(6, Alex.GetMoney());
            Assert.AreEqual(5, Alex.ShowAmountProductInBag(apples));
            Assert.AreEqual(4, Alex.ShowAmountProductInBag(bananas));
            Assert.AreEqual(5, ashan.GetAmountOfProduct(apples));
            Assert.AreEqual(6, ashan.GetAmountOfProduct(bananas));
        }
    }
}
