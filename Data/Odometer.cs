using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CoPilot.Core.Data
{
    public class Odometer
    {
        [XmlAttribute("distance")]
        public Distance Distance { get; set; }
        [XmlText]
        public Double Value { get; set; }

        /// <summary>
        /// Odometer default
        /// </summary>
        public Odometer()
        {
        }

        /// <summary>
        /// Odometer
        /// </summary>
        /// <param name="odometer"></param>
        /// <param name="distance"></param>
        public Odometer(Double odometer, Distance distance)
        {
            this.Value = odometer;
            this.Distance = distance;
        }
    }
}
