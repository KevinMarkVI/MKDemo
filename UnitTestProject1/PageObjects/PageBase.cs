using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace UnitTestProject1.PageObjects
{
    class PageBase
    {
        protected IWebDriver webDriver;

        public string title { get; protected set; }
    }
}
