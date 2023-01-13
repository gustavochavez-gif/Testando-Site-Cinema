using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RazorEngine.Compilation.ImpromptuInterface.InvokeExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject123.Configurations.Factories;
using TestProject123.Configurations.Helpers;

namespace TestProject123
{
    public class ValidarAcessoSite
    {
        public ActionFactory Actions;
        public User _User;
        public By InputEmail = By.Id("email");
        public By InputSenha = By.Id("senha");
        public By BtnEntrar = By.XPath("xpath");
        public By MsgEmaiObg = By.XPath("xpath");
        public By MsgSenhaObg = By.XPath("xpath");
        public By MsgEmail = By.XPath("xpath");

        [SetUp]
        public void Init()
        {
            Actions = new ActionFactory();
            Actions._driver = Actions.CreateDriver(Browsers.CHROME);
            Actions.Maximize();
            Actions.Navigate("https://www.cinemark.com.br/cinemark-mania/acesse-sua-conta");
            _User = new User();

        }

        [TearDown]
        public void ClearUp() => Actions.Quit();
        [Test]
        public void TC01_ValidarCamposObrigatorios()
        {
            Actions.Click(BtnEntrar);
            //Actions.ExistsElement(MsgEmailObg, "texto do msg");
            //Actions.ExistsElement(MsgSenhaObg, "texto msg");

        }

        [Test]
        public void TC02_ValidarLoginInvalido()
        {
            Actions.SendKeys(InputEmail, _User.InvalidEmail);
            Actions.SendKeys(InputSenha, _User.Password);
            Actions.Click(BtnEntrar);
            //Actions.ExistsElement(MsgLoginInv, "Invalid message was not displayed");
        }
        [Test]
        public void TC03_RealizarLogin()
        {
            Actions.SendKeys(InputEmail, _User.Email);
            Actions.SendKeys(InputSenha, _User.Password);
            Actions.Click(BtnEntrar);
            //Actions.ExistsElement(By.XPath($"//div[contains(text(),'Bem vindo, {_User.Name}')]"),"An error ocurred while logging in to the system");
        }
    }
}
