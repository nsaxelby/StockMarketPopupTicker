using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockMarketPopupTickerApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketPopupTickerApplication.Tests
{
    [TestClass()]
    public class IEXHelperTests
    {
        [TestMethod()]
        public void GetPercentageForStockTestValidSymbol()
        {
            decimal percentage = IEXHelper.GetStockData("AAPL", "YOUR KEY HERE").PercentageChange;
            Assert.IsNotNull(percentage);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void GetPercentageForStockTestInvalidSymbol()
        {
            IEXHelper.GetStockData("EXXAMPLE", "YOUR KEY HERE");
        }
    }
}