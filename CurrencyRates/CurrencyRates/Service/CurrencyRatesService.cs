using System.IO;
using System.Net;

namespace CurrencyRates.Service
{
    public class CurrencyRatesService
    {
        public static string GetExchangesRatesRequest(string date)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.lb.lt/webservices/ExchangeRates/ExchangeRates.asmx/getExchangeRatesByDate?Date=" + date);

            request.CookieContainer = new CookieContainer();
            request.AllowAutoRedirect = false;
            request.Method = "GET";
            request.ContentType = "text/xml; charset=utf-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                return responseStr;
            }

            return null;
        }

    }
}