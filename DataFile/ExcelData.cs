using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp;

namespace AutoLoan_SeleniumCSharp.DataFile
{
    public class ExcelData
    {
        Excel._Worksheet xlWorksheet;
        Excel.Range xlRange;

        public ExcelData(Excel.Application xlApp, Excel.Workbook xlWorkbook)
        {
            // Create reference to Excel File
            xlWorksheet = (Excel.Worksheet)xlWorkbook.ActiveSheet;
            xlRange = xlWorksheet.UsedRange;

        }

        public string[] TestData(int x)
        {
            string[] data = new string[4];

            for (int i = 2; i <= 5; i++)
            {
                // Get test case values
                var value = xlRange.Cells[x + 1, i].Value2;
                if (value != null)
                { 
                    data[i - 2] = Convert.ToString(value);
                }
                
            }
            return data;

        }
    }
}
