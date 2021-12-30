using System;
using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using UnitTest.Pages;
using UnitTest.Pages.Base;

namespace UnitTest
{
    public class KrakenTest
    {
        private IWebDriver _webDriver;
        private WebDriverWait _webDriverWait;

        private const string ExpectedFavoritedMarketName = "ETH/USD";
        MainPage mainPage;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Size = new Size(1920, 1080);
            _webDriver.Navigate().GoToUrl("https://demo-futures.kraken.com/futures/PI_ETHUSD");

            _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(35));

            mainPage = new MainPage(_webDriver);
            mainPage.RegIn();
            mainPage.SubmitAuthorization();
        }
        [Test]
        public void AddMarketToFavoriteTest()
        {
            mainPage.ChooseMarket();
            mainPage.ChooseCurrency();
            mainPage.ChooseDate();
            mainPage.CommitCurrency();

            // 
            mainPage.ChooseOrderFromOrderbook();
            mainPage.CommitOrderFromOrderbook();
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}