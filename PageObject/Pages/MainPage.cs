using Docker.DotNet.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Pages
{
    class MainPage : Base.Page
    {
        private By RegInBtnLocator = By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/main/app-toolbar/section/div[1]/button[2]");
        private By submitBtnLocator = By.CssSelector("#mat-dialog-0 > demo-credentials > pro-dialog > mat-card > mat-card-content > div > form > button");
        private By marketBtnLocator = By.CssSelector("body > app-root > mat-sidenav-container > mat-sidenav-content > main > app-toolbar > section > div.main > section > market-dropdowns > div.desktop-dropdown > button");
        private By currencyBtnLocator = By.CssSelector("#cdk-overlay-12 > div > div > market-picker > section > div.assets.ng-star-inserted > market-picker-asset:nth-child(3)");
        private By dateBtnLocator = By.CssSelector("#cdk-overlay-12 > div > div > market-picker > section > cdk-virtual-scroll-viewport > div.cdk-virtual-scroll-content-wrapper > market-picker-ticker:nth-child(2) > section");
        private By commitFavoriteBtnLocator = By.CssSelector("#cdk-overlay-12 > div > div > market-picker > section > cdk-virtual-scroll-viewport > div.cdk-virtual-scroll-content-wrapper > market-picker-ticker:nth-child(2) > section > div.icon.global__text.global__text-body > fa-icon > svg");
        private By orderFromOrderbookLocator = By.CssSelector("body > app-root > mat-sidenav-container > mat-sidenav-content > main > div > futures-trading > gridster > gridster-item:nth-child(40) > draggable-container > section > div.content > orderbook > mat-card > mat-card-content > div.book.bids.global__text.global__text-body.ng-star-inserted > div:nth-child(12)");
        private By commitOrderFromOrderbookLocator = By.CssSelector("body > app-root > mat-sidenav-container > mat-sidenav-content > main > div > futures-trading > gridster > gridster-item:nth-child(37) > draggable-container > section > div.content > order-form > mat-card > mat-card-content > basic-order-form > form > section.footer > section > button");
        private By iframeLocator = By.XPath("//iframe[starts-with(@id, 'tradingview')]");
        private By fullscreenModLocator = By.Id("header-toolbar-fullscreen");
        private By exitFullscreenButtonLocator = By.ClassName("tv-exit-fullscreen-button");


        public MainPage(IWebDriver driver) : base(driver)
        {
        }


        public void RegIn()
        {
            IWebElement logInBtn = FindElement(RegInBtnLocator);
            logInBtn.Click();
        }
        public void SubmitAuthorization()
        {
            IWebElement submitBtn = FindElement(submitBtnLocator);
            submitBtn.Click();
        }
        //

        public void ChooseMarket()
        {
            IWebElement marketBtn = FindElement(marketBtnLocator);
            marketBtn.Click();
        }

        public void ChooseCurrency()
        {
            IWebElement currencyBtn = FindElement(currencyBtnLocator);
            new Actions(driver).MoveToElement(currencyBtn).Perform();
        }
        public void ChooseDate()
        {
            IWebElement monthBtn = FindElement(dateBtnLocator);
            new Actions(driver).MoveToElement(monthBtn).Perform();
        }
        public void CommitCurrency()
        {
            IWebElement commitFavoriteBtn = FindElement(commitFavoriteBtnLocator);
            commitFavoriteBtn.Click();
            
        }
        public void OpenFullscreenMod()
        {
            SwitchToFrame(iframeLocator);
            IWebElement fullscreenMod = FindElementWithWaitElementToBeClickable(fullscreenModLocator, 30);
            fullscreenMod.Click();
        }

        public void ChooseOrderFromOrderbook()
        {
            IWebElement orderFromOrderbook = FindElement(orderFromOrderbookLocator);
            orderFromOrderbook.Click();
        }
        public void CommitOrderFromOrderbook()
        {
            IWebElement commitOrderFromOrderbook = FindElement(commitOrderFromOrderbookLocator);
            commitOrderFromOrderbook.Click();
        }

        public bool GetComparisonOfExpectedTextAndRealText()
        {
            IWebElement realTextInFullscreenMod = FindElementWithWaitElementExists(exitFullscreenButtonLocator, 30);
            if (realTextInFullscreenMod != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CloseFullscreenMod()
        {
            IWebElement fullscreenMod = FindElementWithWaitElementToBeClickable(exitFullscreenButtonLocator, 30);
            fullscreenMod.Click();
            SwitchToDefaultContent();
        }
    }
}
