using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLoan_SeleniumCSharp.BaseClass;
using AutoLoan_SeleniumCSharp.DataFile;
using AutoLoan_SeleniumCSharp.PageObjects;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;

namespace AutoLoan_SeleniumCSharp.TestScripts
{
    [TestFixture]
    public class TestModule : BaseTest 
    {

        [Test]
        public void TestMethod()
        {
            var homepage = new HomePage(driver);
            var autoloanpage = homepage.NavigateToAutoLoanPage();
            var calculator = autoloanpage.OpenCalculator();

            var exceldata = new ExcelData(xlApp, xlWorkbook);

            int numTestCase = 10;
            string[] data;
            bool check;

            Thread.Sleep(1000);

            for (int i = 1; i <= numTestCase; i++)
            {
                data = exceldata.TestData(i);

                try
                {
                    check = calculator.MakeCalculations(data);

                    if (check)
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
    }
}
