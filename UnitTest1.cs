using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Excel = Microsoft.Office.Interop.Excel;

namespace AutoLoan_SeleniumCSharp 
{
    public class Tests
    {
        // Global Items
        public int numTestCase = 10;
        public IWebDriver driver;
        public Excel.Application xlApp = new Excel.Application();
        public Excel.Workbook xlWorkbook;

        [SetUp]
        public void Setup()
        {
            // Driver 
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Url = "https://becu.org/";

            // Excel 
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlApp.Visible = false;
            xlWorkbook = xlApp.Workbooks.Open("C:\\Users\\alana\\source\\repos\\AutoLoan_SeleniumCSharp\\DataFile\\LoanData.xlsx");
        }



        [Test]
        public void Test1()
        {
            
            // Open Loan & Mortageges dropdown menu
            driver.FindElement(By.XPath("//a[text()= 'Loans & Mortgages' and contains(@class, 'dropdown')]")).Click();

            // Select Auto Loans
            driver.FindElement(By.XPath("//a[@title='Auto Loans']")).Click();

            // Open Calculator section
            driver.FindElement(By.XPath("//button[contains(@data-bs-target, 'How-much-v')]")).Click();

            // Switch to calculator frame
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@title='Auto_What vehicle can I afford']")));
            
            // Gather input items
            IWebElement monthly = driver.FindElement(By.XPath("//input[@id='lf_Auto_MonthlyPayment']"));
            IWebElement downpayment = driver.FindElement(By.XPath("//input[@id='lf_Global_AutoDownPayment']"));
            IWebElement loan = driver.FindElement(By.XPath("//input[@id='lf_Global_AutoLoanTerm']"));
            IWebElement interest = driver.FindElement(By.XPath("//input[@id='lf_Global_AutoInterestRate']"));
            
            Excel._Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.ActiveSheet;
            Excel.Range xlRange = xlWorksheet.UsedRange;

            Thread.Sleep(1000);

            // Change data for every test case

            for (int i = 1; i <= numTestCase; i++)
            {
                // Get and store data from Excel
                string[] data = new string[4];

                for (int j = 2; j <= 5; j++)
                {
                    // Get test case values
                    var valuee = xlRange.Cells[i + 1, j].Value2;
                    if (valuee != null)
                    {
                        data[j - 2] = Convert.ToString(valuee);
                    }

                }

                // Send the data to the inputs
                try
                {
                    IWebElement value = driver.FindElement(By.ClassName("answer_highlight"));

                    monthly.SendKeys(Keys.Control + "a" + Keys.Delete);
                    monthly.SendKeys(data[0]);

                    downpayment.SendKeys(Keys.Control + "a" + Keys.Delete);
                    downpayment.SendKeys(data[1]);

                    loan.SendKeys(Keys.Control + "a" + Keys.Delete);
                    loan.SendKeys(data[2]);

                    interest.SendKeys(Keys.Control + "a" + Keys.Delete);
                    interest.SendKeys(data[3]);

                    IWebElement valuechange = driver.FindElement(By.ClassName("answer_highlight"));

                    // Check if loan value change
                    if (value != valuechange)

                    {
                        Console.WriteLine("Test Case " + i + " data change correctly.");
                    }
                    else
                    {
                        Console.WriteLine("Test Case " + i + " data didn't change.");
                    }

                }
                catch (ElementNotInteractableException)
                {
                    Console.WriteLine("Value in Test Case " + i + " not valid");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
            xlWorkbook.Close(true);
            xlApp.Quit();
        }
    }
}