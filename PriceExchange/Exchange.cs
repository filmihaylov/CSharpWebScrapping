using Newtonsoft.Json;
using PriceExchange.DTOs;
using PriceExchange.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PriceExchange
{
    public static class Exchange
    {
        // access key  http://data.fixer.io/api/latest?access_key=3f02108c7353ff0dc1bd5d6d0469309b
        private static string exchangeRateUrl = "http://data.fixer.io/api/latest?access_key=3f02108c7353ff0dc1bd5d6d0469309b&symbols=BGN,GBP";
        private static BGGBPCurrencyDTO exhangeRate = getExchangeRate();


        public static decimal convertFromPoundsToBGN(decimal ammount)
        {
            decimal poundsToEur = ammount / exhangeRate.Rates.GBP;
            decimal BGN = poundsToEur * exhangeRate.Rates.BGN;
            return BGN;
        }

        public static decimal convertFromBGNToPounds(decimal ammount)
        {
            decimal BGNToEur = ammount / exhangeRate.Rates.BGN;
            decimal GBP = BGNToEur * exhangeRate.Rates.GBP;
            return GBP;
        }

        private static BGGBPCurrencyDTO getExchangeRate()
        {
            try
            {
                using (var w = new WebClient())
                {
                    var json_data = string.Empty;
                    json_data = w.DownloadString(exchangeRateUrl);
                    BGGBPCurrencyDTO currencyObject = JsonConvert.DeserializeObject<BGGBPCurrencyDTO>(json_data);
                    return currencyObject;
                }
            }
            catch(Exception e)
            {
                throw new UnableToGetExchangeRateException(e.Message);
            }
        }
    }
}
