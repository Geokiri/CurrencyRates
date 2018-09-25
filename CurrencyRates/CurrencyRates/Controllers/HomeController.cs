using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml;
using CurrencyRates.Helpers;
using CurrencyRates.Models;
using CurrencyRates.Service;

namespace CurrencyRates.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 100, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 100, VaryByParam = "date")]
        public ActionResult GetList(string date)
        {
            string response1 = CurrencyRatesService.GetExchangesRatesRequest(DateTime.Parse(date).ToString());
            string response2 = CurrencyRatesService.GetExchangesRatesRequest(DateTime.Parse(date).AddDays(-1).ToString());

            CurrencyRatesModel model = new CurrencyRatesModel();

            List<CurrencieRateList> currencies = Helper.ParseXml(response1);
            List<CurrencieRateList> olderCurrencies = Helper.ParseXml(response2);

            model.CurrencieList = currencies.Select(x => new CurrencieRateList { Currencie = x.Currencie, Date = x.Date, Rates = x.Rates - olderCurrencies.FirstOrDefault(y => y.Currencie == x.Currencie)?.Rates ?? 0 }).ToList();

            return Json(new { data = model.CurrencieList }, JsonRequestBehavior.AllowGet);
        }

    }
}