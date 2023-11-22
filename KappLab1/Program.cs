using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KappLab1.AppDataFile;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace KappLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            var driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://forum.autodata.ru/264/31036/");
            var ListEliment = driver.FindElements(By.XPath("//table[@class='innertable posttable'][@cellspacing='1']"));
            foreach (var item in ListEliment)
            {
                var name = item.FindElement(By.XPath(".//a[@class='username']")).Text;
                var message = item.FindElement(By.XPath(".//div[@class='postmsg']")).Text;
                var numberMessage = item.FindElement(By.XPath(".//div[@class='descr postlinks2']//a[1]")).Text;
                var objTable = new TableLab4
                {
                    message = message,
                    name = name
                };
                ConnectDB.db.TableLab4.Add(objTable);
                ConnectDB.db.SaveChanges();
            }
            driver.Quit();
        }
    }
}
