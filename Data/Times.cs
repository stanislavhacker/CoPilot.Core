using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CoPilot.Core.Data
{
    [XmlRoot("time")]
    public class Times : NotifyObject
    {

        [XmlElement("circuits")]
        public ObservableCollection<Circuit> Circuits { get; set; }

        //[XmlElement("maintenances")]
        //public ObservableCollection<Drag> Drags { get; set; }
    }
}
