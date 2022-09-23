using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLoan_SeleniumCSharp.PageObjects
{
    public class AutoLoanPage
    {
        IWebDriver driver;

        public AutoLoanPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Open Calculator section
        [FindsBy(How = How.XPath, Using = "//button[contains(@data-bs-target, 'How-much-v')]")]
        public IWebElement Calculator { get; set; } = default!;

        
        public Calculations OpenCalculator()
        { 
            Calculator.Click();
            return new Calculations(driver);
        }

        
    }
}
