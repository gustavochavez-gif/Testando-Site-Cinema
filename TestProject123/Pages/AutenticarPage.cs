using OpenQA.Selenium;
using TestProject123.Configurations.Factories;
using TestProject123.Configurations.Helpers;

namespace TestProject123.Pages
{
    public class AutenticarPage : ActionFactory
    {
        public AutenticarPage(IWebDriver driver) : base(driver) { }

        public By EmailInput = By.Id("email");
        public By PasswordInput = By.Id("senha");
        public By EntrarBtn = By.XPath("//button[contains(text(),'Entrar')]");
        public By CadastroLink = By.XPath("//a[contains(text(),'Novo usuário?')]");

        public void AccessPageLogin(string url)
        {
            Navigate(url);
            ExistsElement(EmailInput, "Error accessing the authentication page");            
        }

        public RegisterPage AccessRegisterUser()
        {
            Click(CadastroLink);
            return new RegisterPage(Driver());
        }

        public void LogIn(string user, string password)
        {
            SendKeys(EmailInput, user);
            SendKeys(PasswordInput, password);
        }

        public HomePage VerifyAuthenticatedUserWithSuccess()
        {
            Click(EntrarBtn);
            ExistsElement(
                By.XPath("//div[contains(text(),'" + Messages.LoginReallySuccessful + "')]"),
                "An error occurred while logging in to the system"
            );
            return new HomePage(Driver());
        }

        public void ValidateInvalidLogin()
        {
            Click(EntrarBtn);
            ExistsElement(
                By.XPath("//div[contains(text(),'" + Messages.InvalidLogin + "')]"),
                "Invalid login message was not displayed"
            );
        }

        public void ValidateMandatoryFields(string email, string password)
        {
            Click(EntrarBtn);
            if (string.IsNullOrEmpty(email))
            {
                ExistsElement(
                    By.XPath("//div[contains(text(), 'Email é um " + Messages.MandatoryField + "')]"),
                    "No mandatory email message was displayed"
                );
            }
            if (string.IsNullOrEmpty(password))
            {
                ExistsElement(
                    By.XPath("//div[contains(text(), 'Senha é um " + Messages.MandatoryField + "')]"),
                    "No mandatory password message was displayed"
                );
            }
        }

    }
}
