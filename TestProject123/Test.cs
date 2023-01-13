using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject123.Configurations.Factories;
using NUnit.Framework;

namespace TestProject123
{
    public class Test
    {
        [Test]
        public void DriverTest()
        {
            var driver = new DriverFactory();

            driver._driver = driver.CreateDriver();

            driver.Maximize();

            driver.Navigate("https://www.cinemark.com.br/");

            driver.Quit();
        }
    }
}
