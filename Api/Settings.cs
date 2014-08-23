using CoPilot.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoPilot.Core.Api
{
    public class Settings
    {
        /// <summary>
        /// Currency
        /// </summary>
        public String Currency { get; set; }

        /// <summary>
        /// Distance
        /// </summary>
        public String Distance { get; set; }

        /// <summary>
        /// Consumption
        /// </summary>
        public String Consumption { get; set; }

        public Double SummaryFuelPrice { get; set; }
        public Double SummaryRepairPrice { get; set; }
        public Double Liters { get; set; }

        public Int32 Repairs { get; set; }
        public Int32 Maintenances { get; set; }
        public Int32 Fills { get; set; }
        public Int32 Videos { get; set; }
        public Int32 Pictures { get; set; }
        public Int32 Paths { get; set; }

    }
}
