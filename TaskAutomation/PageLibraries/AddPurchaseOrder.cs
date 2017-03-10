using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TaskAutomation.HelperClasses;

namespace TaskAutomation.PageLibraries
{
    public class AddPurchaseOrder
    {
        public void ReceiptPO()
        {
            SeleniumExtensions.WaitFor(5000);
            SeleniumExtensions.FindElement(Setup.Driver, By.Id("ReceiptOrderButton"), 5).Click();
            SeleniumExtensions.WaitFor(5000);
            SeleniumExtensions.FindElement(Setup.Driver, By.Id("ReceiptButton"), 5).Click();
            SeleniumExtensions.WaitFor(1000);
        }

        public void AddPO(String prod, String qty, String price)
        {
            SeleniumExtensions.FindElement(Setup.Driver, By.Id("ProductAddLine"), 5).SendKeys(prod);
            SeleniumExtensions.WaitFor(1000);
            SeleniumExtensions.FindElement(Setup.Driver, By.Id("ProductAddLine"), 5).SendKeys(Keys.Tab);
            SeleniumExtensions.FindElement(Setup.Driver, By.Id("QtyAddLine"), 5).SendKeys(qty);
            SeleniumExtensions.FindElement(Setup.Driver, By.Id("PriceAddLine"), 5).SendKeys(price);
             Setup.Driver.FindElement(By.Id("addPurchaseOrderLine")).Click();
            SeleniumExtensions.FindElement(Setup.Driver, By.Id("PlaceOrderButton"), 5).Click();
           
        }


    }
}
