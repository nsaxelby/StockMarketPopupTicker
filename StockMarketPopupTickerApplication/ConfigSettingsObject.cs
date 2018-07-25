using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketPopupTickerApplication
{
    public class ConfigSettingsObject
    {
        public List<string> watchedStock { get; set; }
        public int popupFrequencySeconds { get; set; }
        public int popupDurationSeconds { get; set; }
        public bool onlyPopupDuringTradingHours { get; set; }
    }
}
