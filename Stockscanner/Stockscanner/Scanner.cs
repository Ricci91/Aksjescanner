using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.Text;

namespace Stockscanner
{
    public class Scanner
    {

        public DateTime Timestamp { get; set; }
        public decimal Open { get; set; }

        public decimal High { get; set; }
        public decimal Low { get; set; }

        public decimal Close { get; set; }
        public decimal Volume { get; set; }

        public string scan()
        {
            var symbol = "goog";
            var apiKey = "40SZY8FWO4OV4AIN"; // retrieve your api key from https://www.alphavantage.co/support/#api-key
            var monthlyPrices = $"https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY&symbol={symbol}&apikey={apiKey}&datatype=csv"
                .GetStringFromUrl().FromCsv<List<Scanner>>();


            monthlyPrices.PrintDump();

            // some simple stats
            var maxPrice = monthlyPrices.Max(u => u.Close);
            var minPrice = monthlyPrices.Min(u => u.Close);

            var openPrice = monthlyPrices.Max(u => u.Open);
            

            return "openprice for " + symbol + " is: " + openPrice.ToString() + " and minprice is " +  minPrice.ToString();
        }
    }
}
