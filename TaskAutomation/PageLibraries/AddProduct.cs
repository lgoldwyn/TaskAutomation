using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TaskAutomation.HelperClasses;
using NUnit.Framework;

namespace TaskAutomation.PageLibraries
{
    public class AddProduct
    {
        public string pcode;
        public void NavigateToAddProduct()
        {

            Setup.Driver.FindElement(By.XPath("//div[@id='main-nav']/div/ul/li[3]/a/span")).Click();                     
            SeleniumExtensions.FindElement(Setup.Driver, By.XPath("//div[@id='main-nav']/div/ul/li[3]/ul/li[2]/a/span"), 5).Click();
            SeleniumExtensions.FindElement(Setup.Driver, By.XPath("//div[@id='main-nav']/div/ul/li[3]/ul/li[2]/ul/li/a"), 5).Click();
                      
        }

        public void NavigateToViewProduct()
        {

            Setup.Driver.FindElement(By.XPath("//div[@id='main-nav']/div/ul/li[3]/a/span")).Click();
            SeleniumExtensions.FindElement(Setup.Driver, By.XPath("//div[@id='main-nav']/div/ul/li[3]/ul/li[2]/a/span"), 5).Click();
            Setup.Driver.FindElement(By.XPath("//div[@id='main-nav']/div[1]/ul/li[3]/ul/li[2]/ul/li[2]/a/span")).Click();
           // SeleniumExtensions.FindElement(Setup.Driver, By.XPath("//div[@id='main-nav']/div/ul/li[3]/ul/li[3]/a"), 5).Click();
        }

        public void InputProductDetails(Table ptable)
        {
            IEnumerable<dynamic> pvalues = ptable.CreateDynamicSet();
            foreach (var product in pvalues)
            {
                pcode = product.Code + Guid.NewGuid();
                pcode = pcode.Substring(0, 8);
                Setup.Driver.FindElement(By.Id("Product_ProductCode")).SendKeys(pcode);
                Setup.Driver.FindElement(By.Id("Product_ProductDescription")).SendKeys(product.Description);

            }
        }

        public void InputProductDetails(String prod, String desc)
        {
                pcode = prod;
                Setup.Driver.FindElement(By.Id("Product_ProductCode")).SendKeys(pcode);
                Setup.Driver.FindElement(By.Id("Product_ProductDescription")).SendKeys(desc);

            
        }

        public void SaveProduct()
        {
            Setup.Driver.FindElement(By.Id("btnSave")).Click();
        }

        public void SearchProduct()
        {
            Setup.Driver.FindElement(By.XPath("//div[@id='main-nav']/div[1]/ul/li[3]/ul/li[2]/ul/li[2]/a/span")).Click();
            SeleniumExtensions.FindElement(Setup.Driver, By.Id("ProductFilter"), 5).SendKeys(pcode);
            Setup.Driver.FindElement(By.Id("ProductFilter")).SendKeys(Keys.Return);
            Setup.Driver.FindElement(By.Id("ProductFilter")).SendKeys(Keys.Enter);
            SeleniumExtensions.FindElement(Setup.Driver, By.LinkText(pcode), 5).Click();
        }

        public void SearchProductStock(string srcode)
        {

            NavigateToViewProduct();
            SeleniumExtensions.FindElement(Setup.Driver,By.Id("ProductFilter"),5).SendKeys(srcode);
            Setup.Driver.FindElement(By.Id("ProductFilter")).SendKeys(Keys.Return);
            Setup.Driver.FindElement(By.Id("ProductFilter")).SendKeys(Keys.Enter);
            SeleniumExtensions.FindElement(Setup.Driver, By.LinkText(pcode), 5).Click();
        }

        public void ValidateProductStock(string expectedStock)
        {

            true.Equals(SeleniumExtensions.FindElement(Setup.Driver, By.Id("AvailableQty"), 5).Text == expectedStock) ;
            
        }
    }
}