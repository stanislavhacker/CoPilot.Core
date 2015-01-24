
using CoPilot.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoPilot.Core.Utils
{
    public static class RateExchange
    {
        /// <summary>
        /// Currency
        /// </summary>
        private static Currency currentCurrency;
        public static Currency CurrentCurrency
        {
            get 
            {
                return currentCurrency;  
            }
            set
            {
                currentCurrency = value;
            }
        }

        /// <summary>
        /// Rates
        /// </summary>
        private static Dictionary<Currency, double> rates;
        public static Dictionary<Currency, double> Rates
        {
            get 
            {
                if (rates == null)
                {
                    rates = new Dictionary<Currency, double>();
                    rates.Add(Currency.CZK, 1);
                    rates.Add(Currency.USD, 19.7132);
                    rates.Add(Currency.GBP, 35.306498);
                    rates.Add(Currency.EUR, 27.4733243);
                    rates.Add(Currency.SEK, 2.9258);
                    rates.Add(Currency.CHF, 23.1133);
                    rates.Add(Currency.RUB, 0.4299);
                    rates.Add(Currency.TRY, 9.8497);
                    rates.Add(Currency.CNY, 3.8680);
                }
                return rates;
            }
        }


        /// <summary>
        /// Get exchange rate for currency
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Double GetExchangeRateFor(Currency from, Currency to)
        {
            var rate = Rates[from] / Rates[to];
            return Math.Round(rate, 10);
        }
    }
}
