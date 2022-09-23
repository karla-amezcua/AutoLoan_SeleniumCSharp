using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace AutoLoan_SeleniumCSharp.PageObjects 
{
    public class HomePage
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Open Loan & Mortageges dropdown menu
        [FindsBy(How = How.XPath, Using = "//a[text()= 'Loans & Mortgages' and contains(@class, 'dropdown')]")]
        public IWebElement LoansDropdown { get; set; } = default!;

        // Select Auto Loans
        [FindsBy(How = How.XPath, Using = "//a[@title='Auto Loans']")]
        public IWebElement AutoLoan { get; set; } = default!;

        public AutoLoanPage NavigateToAutoLoanPage()
        {
            LoansDropdown.Click();
            AutoLoan.Click();
            return new AutoLoanPage(driver);
        }
          
        


    }
}
