using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    public class Tests
    {

        public IWebDriver driver;

        public IWebDriver GetDriver()
        {

            return driver;

        }

        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\Drivers\");

            driver.Url = "https://automationpractice.com/index.php";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


        }

        public void TearDown()
        {
            driver.Close();
        }
    }
}