using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using AutoLoan_SeleniumCSharp.DataFile;

namespace AutoLoan_SeleniumCSharp.BaseClass
{
    public class BaseTest
    {
        public IWebDriver driver;
        public Excel.Application xlApp = new Excel.Application();
        public Excel.Workbook xlWorkbook;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Url = "https://becu.org/";

            xlApp = new Excel.Application();
            xlApp.Visible = false;
            xlWorkbook = xlApp.Workbooks.Open("C:\\Users\\alana\\source\\repos\\AutoLoan_SeleniumCSharp\\DataFile\\LoanData.xlsx");
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
