using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestScenario2
{
    public class Tests
    {
        protected IWebDriver driver;
       

        [SetUp]
        public void Setup()        
        {
           
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://qa.sorted.com/newtrack");
        }

        [TestCase("john_smith@sorted.com","Pa55w0rd!", "https://qa.sorted.com/loginSuccess")]
        public void LogIn(string userName, string password, string expectedUrl)
        {
            IWebElement userNameInput = driver.FindElement(By.Id("name"));
            IWebElement passwordInput = driver.FindElement(By.XPath("//input[@name='password']"));
            IWebElement logInBtn = driver.FindElement(By.XPath("//button[@name='submit']"));

            userNameInput.Clear();
            userNameInput.SendKeys(userName);

            passwordInput.Clear();
            passwordInput.SendKeys(password);

            logInBtn.Click();

            Assert.That(driver.Url, Is.EqualTo(expectedUrl));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}