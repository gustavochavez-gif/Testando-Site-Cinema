using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestProject123.Configurations.Factories
{
    public class ActionFactory : DriverFactory
    {
        public ActionFactory(IWebDriver driver) : base(driver) { }

        public ActionFactory()
        {
        }

        public IWebElement FindElement(By by, int timeout = 10) => timeout > 0
            ? new WebDriverWait(Driver(), TimeSpan.FromSeconds(timeout)).Until(drv => drv.FindElement(by))
            : Driver().FindElement(by);

        
        public ReadOnlyCollection<IWebElement> FindElements(By by, int timeout = 10) => timeout > 0
            ? new WebDriverWait(Driver(), TimeSpan.FromSeconds(timeout)).Until(drv => drv.FindElements(by))
            : Driver().FindElements(by);
     
        public bool ExistsElement(By by, int timeout = 10)
        {
            try
            {
                FindElement(by, timeout);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ExistsElement(By by, string text, int timeout = 10)
        {
            if (!ExistsElement(by, timeout)) Assert.Fail(text);
        }
        
        public void Clear(By by) => FindElement(by).Clear();

        public void SendKeys(By by, string text, int timeout = 10)
        {
            if (!string.IsNullOrEmpty(text)) FindElement(by, timeout).SendKeys(text);
        }

        public void SendKeys(IWebElement element, string text)
        {
            if (!string.IsNullOrEmpty(text)) element.SendKeys(text);
        }

        public void Click(By by, int timeout = 10) => FindElement(by, timeout).Click();

        public void Click(IWebElement element) => element.Click();
        
        public void ClickByIndex(By by, int index, int timeout = 10) => Click(FindElements(by, timeout)[index]);
        
        public void Select(By by, string text, int timeout = 10) => new SelectElement(FindElement(by, timeout)).SelectByText(text);

        public void Select(By by, int index, int timeout = 10) => new SelectElement(FindElement(by, timeout)).SelectByIndex(index);

        public string ReturnText(By by, int timeout = 10) => FindElement(by, timeout).Text;

        public string ReturnTextByIndex(By by, int index, int timeout = 10) => FindElements(by, timeout)[index].Text;

        public string ReturnTextByAttribute(By by, string attr, int timeout = 10) => FindElement(by, timeout).GetAttribute(attr);

        public void VerifyText(string expectedMessage, string currentMessage, string errorMessage) => 
            Assert.AreEqual(expectedMessage, currentMessage, errorMessage);

        public void ContainsText(string expectedMessage, string currentMessage, string errorMessage) => 
            Assert.IsTrue(currentMessage.Contains(expectedMessage), errorMessage);

        public IWebDriver ChangeTab(string tab = null) => !string.IsNullOrEmpty(tab) && tab.Equals("Last")
            ? Driver().SwitchTo().Window(Driver().WindowHandles.Last())
            : Driver().SwitchTo().Window(Driver().WindowHandles.First());

        public void ZoomIn() => new Actions(Driver()).SendKeys(Keys.Control).SendKeys(Keys.Add).Perform();

        public void ZoomOut() => new Actions(Driver()).SendKeys(Keys.Control).SendKeys(Keys.Subtract).Perform();

        public void ZoomPercentage(int percent) => ((IJavaScriptExecutor)Driver()).ExecuteScript("document.body.style.zoom = ' " + percent + "%';");

        public void MouseHouver(IWebElement element) => new Actions(Driver()).MoveToElement(element).Perform();

        public void ScrollToElement(IWebElement element, int up = 0, int down = 0) => ((IJavaScriptExecutor)Driver()).ExecuteScript("arguments[0].scrollIntoView(true);window.scrollBy(" + up + "," + down + ")", element);

        public void AcceptAlert() => Driver().SwitchTo().Alert().Accept();

    }
}