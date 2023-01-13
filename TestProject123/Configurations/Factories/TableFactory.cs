using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using TestProject123.Configurations.Factories;

namespace TestProject123.Configurations.Factories
{
    public class TableFactory : ActionFactory
    {
        public TableFactory(IWebDriver driver) : base(driver) { }

        
        public TableFactory UpdateTable() => new TableFactory(Driver());

        
        public ReadOnlyCollection<IWebElement> ReturnTrs(int tableIndex = 0) => FindElements(By.TagName("tbody"))[tableIndex].FindElements(By.TagName("tr"));

        
        public ReadOnlyCollection<IWebElement> ReturnTrs(ReadOnlyCollection<IWebElement> elements, int tableIndex = 0) => elements[tableIndex].FindElements(By.TagName("tbody"))[tableIndex].FindElements(By.TagName("tr"));


        
        public IWebElement ReturnTr(int index, int tableIndex = 0) => ReturnTrs(tableIndex)[index];

        
        public IWebElement ReturnTd(IWebElement tr, int index) => tr.FindElements(By.TagName("td"))[index];

        
        public IWebElement ReturnButton(IWebElement column, int index) => column.FindElements(By.TagName("button"))[index];

        
        public IWebElement ReturnSpan(IWebElement column, int index) => column.FindElements(By.TagName("span"))[index];

        
        public IWebElement ReturnButtonLink(IWebElement column, int index) => column.FindElements(By.TagName("a"))[index];

        
        public void VerifyIfIsLastRegister(int index, string errorMessage)
        {
            if (ReturnTrs().Count == (index + 1)) Assert.Fail(errorMessage);
        }

    }
}