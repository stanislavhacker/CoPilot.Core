
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
        /// Get exchange rate for currency
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Double GetExchangeRateFor(Currency from, Currency to)
        {
            //CZK => USD
            //{"to": "USD", "rate": 0.050727399999999999, "from": "CZK"}
            if (from == Currency.CZK && to == Currency.USD)
            {
                return 0.050727399999999999;
            }
            //USD => CZK
            //{"to": "CZK", "rate": 19.713200000000001, "from": "USD"}
            if (from == Currency.USD && to == Currency.CZK)
            {
                return 19.713200000000001;
            }

            return 1;
        }
    }
}
