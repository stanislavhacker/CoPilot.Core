using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CoPilot.Core.Data
{
    [XmlRoot("repair")]
    public class Repair : NotifyObject
    {
        [XmlElement("odometer")]
        public Odometer Odometer { get; set; }

        [XmlElement("price")]
        public Price Price { get; set; }

        [XmlElement("description")]
        public String Description { get; set; }

        [XmlElement("service")]
        public String ServiceName { get; set; }

        [XmlElement("date")]
        public DateTime Date { get; set; }
    }
}
