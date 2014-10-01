
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
            //CZK => to
            if (from == Currency.CZK) {
                switch (to)
                {
                    case Currency.CZK:
                        return 1;
                    case Currency.USD:
                        return 0.050727399999999999;
                    case Currency.GBP:
                        return 0.0283233982;
                    case Currency.EUR:
                        return 0.0363989442;
                }
            }
            //USD => to
            if (from == Currency.USD)
            {
                switch (to)
                {
                    case Currency.CZK:
                        return 19.713200000000001;
                    case Currency.USD:
                        return 1;
                    case Currency.GBP:
                        return 0.616771878;
                    case Currency.EUR:
                        return 0.792625413;
                }
            }
            //EUR => to
            if (from == Currency.EUR)
            {
                switch (to)
                {
                    case Currency.CZK:
                        return 27.4733243;
                    case Currency.USD:
                        return 1.26163;
                    case Currency.GBP:
                        return 0.778137904;
                    case Currency.EUR:
                        return 1;
                }
            }

            //GBP => to
            if (from == Currency.GBP)
            {
                switch (to)
                {
                    case Currency.CZK:
                        return 35.306498;
                    case Currency.USD:
                        return 1.621345;
                    case Currency.GBP:
                        return 1;
                    case Currency.EUR:
                        return 1.28511925;
                }
            }

            return 1;
        }
    }
}
