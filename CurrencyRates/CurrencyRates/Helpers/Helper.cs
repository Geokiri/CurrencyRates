using CurrencyRates.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Xml;

namespace CurrencyRates.Helpers
{
    public class Helper
    {
        public static List<CurrencieRateList> ParseXml(string document)
        {
            List<CurrencieRateList> currencies = new List<CurrencieRateList>();

            XmlDocument xml = new XmlDocument();

            xml.LoadXml(document);

            XmlNodeList nodeList = xml.SelectNodes("ExchangeRates/item");

            foreach (XmlNode node in nodeList)
            {
                currencies.Add(new CurrencieRateList { Currencie = node.SelectSingleNode("currency").InnerText, Rates = decimal.Parse(node.SelectSingleNode("rate").InnerText, CultureInfo.InvariantCulture) });
            }

            return currencies;
        }
    }
}