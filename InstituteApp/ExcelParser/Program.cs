using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Excel.Application ex = new Excel.Application();
            Console.WriteLine("Hello World!");
        }
    }
}
