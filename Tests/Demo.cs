using NUnit.Framework;
using SauceDemo.Helpers;
using System;
using System.Threading;

namespace SauceDemo.Tests
{
    public class Demo : HelpingMethods
    {
        [Test]
        public void SouceTest()
        {
            SetupTest();
            LogIn("standard_user", "secret_sauce");
            Console.WriteLine("\nLogin OK!");
            ValidateTexInClass("title", "Products");
            Console.WriteLine("Product found OK!");
            SelectDropDownElement("product_sort_container", "hilo", null);
            Console.WriteLine("Arranged product from high to low price!");
            AddElementsTextToArray("inventory_item_name", "Sauce Labs Fleece Jacket", 3);
            Console.WriteLine("Search for product: Sauce Labs Fleece Jacket OK!");
            AddItemToBasket("add-to-cart-sauce-labs-bike-light");
            //Thread.Sleep(1500);
            Console.WriteLine("Added to basket OK.");
            CheckAndRemoveFromBasket("shopping_cart_container", "Sauce Labs Bike Light", "inventory_item_name");
            Console.WriteLine("Checked and removed from basket. OK");
            LogOutFromWebsite();
            Console.WriteLine("Log-Out executed. OK");
            CloseTest();
        }
    }
}
