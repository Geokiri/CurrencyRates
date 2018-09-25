using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CurrencyRatesBL
    {
        public static string GetExchangesRatesRequest(string date)
        {
            string url = "http://www.lb.lt/webservices/ExchangeRates/ExchangeRates.asmx/getExchangeRatesByDate?Date=" + date;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text/xml; charset=utf-8";
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());

            return sr.ReadToEnd();
        }
    }
}
