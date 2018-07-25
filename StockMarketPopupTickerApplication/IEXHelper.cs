using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketPopupTickerApplication
{
    public static class IEXHelper
    {
        private const string IEXURL = "https://api.iextrading.com/1.0/";
        /// <summary>
        /// returns a percentage ( as Decimal ) for a stock ticker
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>StockListObject</returns>
        public static StockListObjectData GetStockData(string symbol)
        {
            StockListObjectData toReturn = new StockListObjectData();
            toReturn.PercentageChange = -1;
            toReturn.StockName = symbol;
            toReturn.StockStockMarketOpen = false;
            // Build query to call against API:
            string paramaters = $"stock/{symbol}/quote?displayPercent=true";
            string objectAsString = APICall(paramaters);

            var data = (JObject)JsonConvert.DeserializeObject(objectAsString);
            toReturn.PercentageChange = data["changePercent"].Value<Decimal>();
            string closedValueString = data["latestSource"].Value<String>();
            if (closedValueString.ToLower().Contains("close"))
            {
                toReturn.StockStockMarketOpen = false;
            }
            else
            {
                toReturn.StockStockMarketOpen = true;
            }
            return toReturn;
        }

        /// <summary>
        /// https://stackoverflow.com/questions/9620278/how-do-i-make-calls-to-a-rest-api-using-c
        /// </summary>
        /// <param name="paramaters"></param>
        /// <returns></returns>
        private static string APICall(string paramaters)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(IEXURL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(paramaters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                throw new Exception("Invalid status response: " + response.StatusCode);
            }
        }
    }
}
