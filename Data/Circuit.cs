using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CoPilot.Core.Data
{
    [XmlRoot("circuit")]
    public class Circuit : NotifyObject
    {
        [XmlElement("duration")]
        public int duration { get; set; }

        [XmlAttribute("positions")]
        public List<String> Positions { get; set; }

        [XmlAttribute("speeds")]
        public List<Double> Speeds { get; set; }

        [XmlAttribute("laps")]
        public List<Double> Laps { get; set; }

        [XmlElement("id")]
        public String Id { get; set; }

        [XmlAttribute("start")]
        public DateTime Start { get; set; }

        [XmlIgnore]
        public TimeSpan Duration
        {
            get
            {
                return new TimeSpan(0, 0, duration);
            }
            set
            {
                duration = Convert.ToInt32(value.TotalSeconds);
            }
        }
    }
}
