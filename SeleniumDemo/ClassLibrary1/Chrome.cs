using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo
{
    internal class Chrome
    {

        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("C:\\Users\\uyj\\source\\repos\\SeleniumDemo\\ClassLibrary1\\Drivers\\chromedriver.exe");

        }

        [Test]
        public void test()
        {
            driver.Url = "https://www.trademe.co.nz";
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
