using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V103.IndexedDB;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLoan_SeleniumCSharp.PageObjects
{
    public class Calculations
    {
        IWebDriver driver;

        public Calculations(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@title='Auto_What vehicle can I afford']")));
        }

        // Copy Loan Data
        public IWebElement value { get; set; } = default!;
        public IWebElement valuechange { get; set; } = default!;

        // Define Inputs
        [FindsBy(How = How.XPath, Using = "//input[@id='lf_Auto_MonthlyPayment']")]
        public IWebElement monthly { get; set; } = default!;

        [FindsBy(How = How.XPath, Using = "//input[@id='lf_Global_AutoDownPayment']")]
        public IWebElement downpayment { get; set; } = default!;

        [FindsBy(How = How.XPath, Using = "//input[@id='lf_Global_AutoLoanTerm']")]
        public IWebElement loan { get; set; } = default!;
        
        [FindsBy(How = How.XPath, Using = "//input[@id='lf_Global_AutoInterestRate']")]
        public IWebElement interest { get; set; } = default!;



        public bool MakeCalculations(string[] x)
        {
            // Get current value for loan
            value = driver.FindElement(By.ClassName("answer_highlight"));

            // Enter new test data
            monthly.SendKeys(Keys.Control+"a"+Keys.Delete);
            monthly.SendKeys(x[0]);

            downpayment.SendKeys(Keys.Control + "a" + Keys.Delete);
            downpayment.SendKeys(x[1]);

            loan.SendKeys(Keys.Control + "a" + Keys.Delete);
            loan.SendKeys(x[2]);

            interest.SendKeys(Keys.Control + "a" + Keys.Delete);
            interest.SendKeys(x[3]);

            // Get new loan value
            valuechange = driver.FindElement(By.ClassName("answer_highlight"));

            // Check if value change
            if (value != valuechange)

            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
