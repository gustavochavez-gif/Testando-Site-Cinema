using OpenQA.Selenium;
using TestProject123.Configurations.Factories;
using TestProject123.Configurations.Helpers;

namespace TestProject123.Pages
{
    public class ChangeAccountPage : TableFactory
    {
        public ChangeAccountPage(IWebDriver driver) : base(driver) { }

        public void ChangeAccount(string account)
        {
            Clear(By.Id("nome"));
            SendKeys(By.Id("nome"), account);
        }

        public void VerifyChangeSuccessfully(string account)
        {
            Click(By.XPath("//button[@class='btn btn-primary']"));
            ExistsElement(
                By.XPath("//div[contains(text(),'" + Messages.AccountChangedSuccessfully + "')]"),
                "No account message successfully changed!"
            );
            ValidateAccountChange(account);
        }

        public void ValidateMandatoryFields()
        {
            Clear(By.Id("nome"));
            Click(By.XPath("//button[@class='btn btn-primary']"));
            ExistsElement(
                By.XPath("//div[contains(text(),'" + Messages.MandatoryAccount + "')]"),
                "No mandatory account name message was displayed"
            );
        }

        public void ValidateDuplicateRecord()
        {
            Click(By.XPath("//button[@class='btn btn-primary']"));
            ExistsElement(
                By.XPath("//div[contains(text(),'" + Messages.AccountIncluded + "')]"),
                "No duplicate registration message was displayed"
            );
        }

        public void ValidateAccountChange(string account)
        {
            for (int index = 0; index < ReturnTrs().Count; index++)
            {
                string accountname = ReturnTd(ReturnTr(index), 0).Text;
                if (accountname.Equals(account)) return;
                VerifyIfIsLastRegister(index, "Account was not changed correctly");
            }
        }

    }
}