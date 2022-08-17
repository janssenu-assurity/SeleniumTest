using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest;

namespace AutomationPracticeSpecflow.StepDefinitions
{
    [Binding]
    public sealed class AutomationPracticeStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        Tests sT = new SeleniumTest.Tests();
        bool acc;
        string emailAddress;
        

        [Given(@"I do not have an account")]
        public void GivenIDoNotHaveAnAccount()
        {
            sT.Setup();
            acc = false;
        }

        [When(@"I open the app")]
        public void WhenIOpenTheApp()
        {
            IWebElement page = sT.driver.FindElement(By.Id("page"));
            

        }

        [When(@"I sign up with my email")]
        public void WhenISignUpWithMyEmail()
        { 
            emailAddress = DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds + "@janssentest.com";

            IWebElement loginButton = sT.driver.FindElement(By.ClassName("header_user_info"));
            loginButton.Click();

            IWebElement createEmail = sT.driver.FindElement(By.Id("email_create"));
            createEmail.Clear();
            createEmail.SendKeys(emailAddress);

            IWebElement createAccountButton = sT.driver.FindElement(By.Id("SubmitCreate"));
            createAccountButton.Click();

        }

        [When(@"Fill in my personal information")]
        public void WhenFillInMyPersonalInformation()
        {
            IWebElement title;
            //Thread.Sleep(8000);
            IWebElement firstName = sT.driver.FindElement(By.Id("customer_firstname"));
            IWebElement lastName = sT.driver.FindElement(By.Id("customer_lastname"));
            IWebElement email = sT.driver.FindElement(By.Id("email"));
            IWebElement password = sT.driver.FindElement(By.Id("passwd"));
            SelectElement dobDay = new SelectElement(sT.driver.FindElement(By.Id("days")));
            SelectElement dobMonth = new SelectElement(sT.driver.FindElement(By.Id("months")));
            SelectElement dobYear = new SelectElement(sT.driver.FindElement(By.Id("years")));



            title = sT.driver.FindElement(By.Name("id_gender"));
            firstName = sT.driver.FindElement(By.Id("customer_firstname"));


            title.Click();
            firstName.Clear();
            firstName.SendKeys("Janssen");
            lastName.Clear();
            lastName.SendKeys("Uy");
            email.Clear();
            email.SendKeys(emailAddress);
            password.SendKeys("randomlygenerate"); // todo
            dobDay.SelectByValue("11");
            dobMonth.SelectByValue("1");
            dobYear.SelectByValue("1997");
        }

        [When(@"Fill in my address information")]
        public void WhenFillInMyAddressInformation()
        {
            IWebElement firstName = sT.driver.FindElement(By.Id("firstname"));
            IWebElement lastName = sT.driver.FindElement(By.Id("lastname"));
            IWebElement company = sT.driver.FindElement(By.Id("company"));
            IWebElement address = sT.driver.FindElement(By.Id("address1"));
            IWebElement city = sT.driver.FindElement(By.Id("city"));
            SelectElement state = new SelectElement(sT.driver.FindElement(By.Id("id_state")));
            IWebElement zip = sT.driver.FindElement(By.Id("postcode"));
            SelectElement country = new SelectElement(sT.driver.FindElement(By.Id("id_country")));
            IWebElement mobile = sT.driver.FindElement(By.Id("phone_mobile"));
            IWebElement alias = sT.driver.FindElement(By.Id("alias"));

            firstName.Clear();
            firstName.SendKeys("Janssen");
            lastName.Clear();
            lastName.SendKeys("Uy");
            company.Clear();
            company.SendKeys("TestCo");
            address.Clear();
            address.SendKeys("123 Fake Street");
            city.SendKeys("Auckland");
            state.SelectByText("Alabama");
            zip.SendKeys("01234");
            country.SelectByText("United States");
            mobile.SendKeys("0800 66 66 39");
            alias.SendKeys("Home");

        }

        [When(@"Register for an account")]
        public void WhenRegisterForAnAccount()
        {
            IWebElement registerButton = sT.driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();
        
        }

        [Then(@"I will have an account")]
        public void ThenIWillHaveAnAccount()
        {
            ReadOnlyCollection<IWebElement> accountElements = sT.driver.FindElements(By.Id("my-account"));

            Assert.That(accountElements.Count, Is.GreaterThan(0));

            sT.TearDown();
            
        }

        
        [Then(@"I can see my account is logged in")]
        public void ThenICanSeeMyAccountIsLoggedIn()
        {
            ReadOnlyCollection<IWebElement> accountElements = sT.driver.FindElements(By.Id("my-account"));

            Assert.That(accountElements.Count, Is.GreaterThan(0));

            sT.TearDown();
        }

        [Given(@"I have an account")]
        public void GivenIHaveAnAccount()
        {
            sT.Setup();
            acc = true;
        }

        [When(@"I log into my account")]
        public void WhenILogIntoMyAccount()
        {

            IWebElement signIn = sT.driver.FindElement(By.ClassName("header_user_info"));
            signIn.Click();

            IWebElement email = sT.driver.FindElement(By.Id("email"));
            IWebElement password = sT.driver.FindElement(By.Id("passwd"));
            IWebElement logInButton = sT.driver.FindElement(By.Id("SubmitLogin"));

            email.Clear();
            email.SendKeys("janssen.uy@assurity.co.nz"); // TODO
            password.Clear();
            password.SendKeys("randomlygenerate");

            logInButton.Click();

        }


        [When(@"I log into my account with incorrect details")]
        public void WhenILogIntoMyAccountWithIncorrectDetails()
        {
            IWebElement signIn = sT.driver.FindElement(By.ClassName("header_user_info"));
            signIn.Click();

            IWebElement email = sT.driver.FindElement(By.Id("email"));
            IWebElement password = sT.driver.FindElement(By.Id("passwd"));
            IWebElement logInButton = sT.driver.FindElement(By.Id("SubmitLogin"));

            email.Clear();
            email.SendKeys("janssen.uy@assurity.co.nz"); // TODO
            password.Clear();
            password.SendKeys("this is the wrong password");

            logInButton.Click();
        }

        [Then(@"I cannot log in")]
        public void ThenICannotLogIn()
        {
            ReadOnlyCollection<IWebElement> authenticationIssue = sT.driver.FindElements(By.ClassName("alert-danger"));

            Assert.That(authenticationIssue.Count, Is.GreaterThan(0));
            Assert.That(authenticationIssue[0].Text.Contains("Authentication failed"), Is.True);

            sT.TearDown();
        }


    }


}