using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemo.Extensions
{
  public class Setup
  {
    public IWebDriver driver;

    [SetUp]
    public void SetupTest()
    {
      //Start Browser
      driver = new ChromeDriver();
      driver.Manage().Window.Maximize();
      driver.Navigate().GoToUrl("http://www.saucedemo.com");
    }

    [TearDown]
    public void CloseTest()
    {
      //Quit Browser
      driver.Quit();
    }
  }
}
