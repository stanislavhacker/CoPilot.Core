using CoPilot.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoPilot.Core.Utils
{
    public static class DistanceExchange
    {
        /// <summary>
        /// Distance
        /// </summary>
        private static Distance currentDistance;
        public static Distance CurrentDistance
        {
            get
            {
                return currentDistance;
            }
            set
            {
                currentDistance = value;
            }
        }


        /// <summary>
        /// Get exchange distance for distance
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Double GetExchangeDistanceFor(Distance from, Distance to)
        {
            //Mi => Km
            if (from == Distance.Mi && to == Distance.Km)
            {
                return 1.609344;
            }
            //Km => Mi
            if (from == Distance.Km && to == Distance.Mi)
            {
                return 0.621371192;
            }

            return 0;
        }

        /// <summary>
        /// Get odometer with right sitance
        /// </summary>
        /// <param name="odometer"></param>
        /// <returns></returns>
        public static Double GetOdometerWithRightDistance(Odometer odometer)
        {
            if (odometer.Distance == currentDistance)
            {
                return odometer.Value;
            }

            var rate = GetExchangeDistanceFor(odometer.Distance, currentDistance);
            return Math.Round(odometer.Value * rate, 2);
        }
    }
}
