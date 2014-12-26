
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
                    case Currency.SEK:
                        return 0.343265699;
                    case Currency.CHF:
                        return 0.0432849734;
                    case Currency.RUB:
                        return 2.23066348;
                    case Currency.TRY:
                        return 0.101557864;
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
                    case Currency.SEK:
                        return 7.85071088;
                    case Currency.CHF:
                        return 0.987474869;
                    case Currency.RUB:
                        return 50.9190896;
                    case Currency.TRY:
                        return 2.31824926;
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
                    case Currency.SEK:
                        return 9.53781216;
                    case Currency.CHF:
                        return 1.20269502;
                    case Currency.RUB:
                        return 61.9990835;
                    case Currency.TRY:
                        return 2.82363606;
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
                    case Currency.SEK:
                        return 12.1850944;
                    case Currency.CHF:
                        return 1.53614633;
                    case Currency.RUB:
                        return 79.2301034;
                    case Currency.TRY:
                        return 3.60522533;
                }
            }

            //SEK => to
            if (from == Currency.SEK)
            {
                switch (to)
                {
                    case Currency.CZK:
                        return 2.9258;
                    case Currency.USD:
                        return 0.1284;
                    case Currency.GBP:
                        return 0.08253;
                    case Currency.EUR:
                        return 0.1051;
                    case Currency.SEK:
                        return 1;
                    case Currency.CHF:
                        return 0.1266;
                    case Currency.RUB:
                        return 6.8097;
                    case Currency.TRY:
                        return 0.298;
                }
            }

            //CHF => to
            if (from == Currency.CHF)
            {
                switch (to)
                {
                    case Currency.CZK:
                        return 23.1133;
                    case Currency.USD:
                        return 1.0144;
                    case Currency.GBP:
                        return 0.6519;
                    case Currency.EUR:
                        return 0.8318;
                    case Currency.SEK:
                        return 7.9321;
                    case Currency.CHF:
                        return 1;
                    case Currency.RUB:
                        return 53.7958;
                    case Currency.TRY:
                        return 2.3543;
                }
            }

            //RUB => to
            if (from == Currency.RUB)
            {
                switch (to)
                {
                    case Currency.CZK:
                        return 0.4299;
                    case Currency.USD:
                        return 0.01887;
                    case Currency.GBP:
                        return 0.01213;
                    case Currency.EUR:
                        return 0.01547;
                    case Currency.SEK:
                        return 0.1475;
                    case Currency.CHF:
                        return 0.0186;
                    case Currency.RUB:
                        return 1;
                    case Currency.TRY:
                        return 0.04379;
                }
            }

            //TRY => to
            if (from == Currency.TRY)
            {
                switch (to)
                {
                    case Currency.CZK:
                        return 9.8497;
                    case Currency.USD:
                        return 0.4323;
                    case Currency.GBP:
                        return 0.2778;
                    case Currency.EUR:
                        return 0.3545;
                    case Currency.SEK:
                        return 3.3803;
                    case Currency.CHF:
                        return 0.4263;
                    case Currency.RUB:
                        return 22.925;
                    case Currency.TRY:
                        return 1;
                }
            }

            return 1;
        }
    }
}
