using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CoPilot.Core.Data
{
    [XmlRoot("fill")]
    public class Fill : NotifyObject
    {
        [XmlElement("odometer")]
        public Odometer Odometer { get; set; }

        [XmlElement("price")]
        public Price Price { get; set; }

        [XmlElement("refueled")]
        public Double Refueled { get; set; }

        [XmlElement("unit")]
        public Price UnitPrice { get; set; }

        [XmlElement("full")]
        public Boolean Full { get; set; }

        [XmlElement("date")]
        public DateTime Date { get; set; }
    }
}
