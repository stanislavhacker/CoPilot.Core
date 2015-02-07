using CoPilot.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoPilot.Core.Utils
{
    public static class UnitExchange
    {
        /// <summary>
        /// Unit
        /// </summary>
        private static Unit currentUnit;
        public static Unit CurrentUnit
        {
            get
            {
                return currentUnit;
            }
            set
            {
                currentUnit = value;
            }
        }


        /// <summary>
        /// Get exchange unit for unit
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Double GetExchangeUnitFor(Unit from, Unit to)
        {
            //Liters => Gallons
            if (from == Unit.Liters && to == Unit.Gallons)
            {
                return 0.264172052;
            }
            //Gallons => Liters
            if (from == Unit.Gallons && to == Unit.Liters)
            {
                return 3.78541178;
            }

            return 1;
        }
    }
}
