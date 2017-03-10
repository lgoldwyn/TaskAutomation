using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TaskAutomation.HelperClasses
{
    public static class Setup
    {
        public static IWebDriver Driver { set; get; }
        public static bool Initialised { get; set; }
        public static void Initialize()
        {
            Driver = new ChromeDriver();
            Initialised = true;
            Driver.Manage().Window.Maximize();
        }

        public static void Quit()
        {
            Driver.Quit();
            Initialised = false;
        }

        public static void InitializeDriver()
        {
            if (!(Initialised)) Setup.Initialize();
        }

        public static void CleanUp()
        {

           if (Driver != null)
            {
                Driver.Dispose();
                Driver = null;
            }
        }

    }
}

