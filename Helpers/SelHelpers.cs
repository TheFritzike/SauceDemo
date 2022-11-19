using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SauceDemo.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SauceDemo.Helpers
{
    public class HelpingMethods : Setup
    {
        public void WaitSeconds(int time)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
            Thread.Sleep(time);
        }

        public void ValidateTexInClass(string clasa, string titlu)
        {
            IWebElement titlulCautat = driver.FindElement(By.XPath("//span[contains(@class,'" + clasa + "') and text()='" + titlu + "']"));
            try
            {
                Assert.AreEqual(titlu, titlulCautat.Text);
                Console.WriteLine("Searched Title found.");

            }
            catch
            {
                Assert.AreEqual(titlu.ToUpper(), titlulCautat.Text);
                Console.WriteLine("Title found with BIG letters.");
            }
        }

        public void SelectDropDownElement(string clasaDropDown, string selectByValue, string selectByText)
        {
            var dropDown = driver.FindElement(By.ClassName(clasaDropDown));
            var selectElement = new SelectElement(dropDown);

            if (selectByValue == null)
            {
                Console.WriteLine("Select by value parameter is null.");
            }
            else
            {
                selectElement.SelectByValue(selectByValue);
            }
            if (selectByText == null)
            {
                Console.WriteLine("Select by text parameter is null.");
            }
            else
            {
                selectElement.SelectByText(selectByText);
            }
        }

        public void LogIn(string utilizator, string parola)
        {
            IWebElement user = driver.FindElement(By.Id("user-name"));
            IWebElement pass = driver.FindElement(By.Id("password"));
            IWebElement submit = driver.FindElement(By.Id("login-button"));
            user.Clear();
            user.SendKeys(utilizator);
            pass.Clear();
            pass.SendKeys(parola);
            submit.Submit();
        }

        public void AddElementsTextToArray(string numeClasa, string textulCautat, int nrProdus)
        {
            IList<IWebElement> all = driver.FindElements(By.ClassName(numeClasa));

            String[] allText = new String[all.Count];
            int i = 0;
            foreach (IWebElement element in all)
            {
                allText[i++] = element.Text;
            }

            Assert.AreEqual(textulCautat, allText[0]);
            Console.WriteLine("First article text is:{0}", allText[0]);
            Console.WriteLine("Text for article {0} is:{1}", nrProdus, allText[nrProdus - 1]);
        }

        public void AddItemToBasket(string elementId)
        {
            driver.FindElement(By.Id(elementId)).Click();

            IWebElement nrCos = driver.FindElement(By.XPath("//span[@class='shopping_cart_badge']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(nrCos);
            actions.Perform();

            var numarCos = driver.FindElement(By.XPath("//span[@class='shopping_cart_badge']")).Text;
            Assert.AreEqual("1", numarCos);
        }

        public void CheckAndRemoveFromBasket(string basketId, string searchedArticle, string articleClass)
        {
            driver.FindElement(By.Id(basketId)).Click();
            var article = driver.FindElement(By.ClassName(articleClass)).Text;
            Assert.AreEqual(searchedArticle, article);
            Console.WriteLine("Article located in basket.");

            driver.FindElement(By.Id("remove-sauce-labs-bike-light")).Click();
            driver.FindElement(By.Id("continue-shopping")).Click();
        }

        public void LogOutFromWebsite()
        {
            driver.FindElement(By.Id("react-burger-menu-btn")).Click();
            WaitSeconds(1000);
            driver.FindElement(By.Id("logout_sidebar_link")).Click();
        }
    }
}
