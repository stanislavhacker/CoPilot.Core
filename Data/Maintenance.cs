using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CoPilot.Core.Data
{
    public enum MaintenanceType
    {
        //odometers
        Filters,
        Oil,
        Maintenance,

        //dates
        Insurance,
        TechnicalInspection
    }

    [XmlRoot("maintenance")]
    public class Maintenance : NotifyObject
    {
        [XmlElement("type")]
        public MaintenanceType Type { get; set; }

        [XmlElement("odometer")]
        public Odometer Odometer { get; set; }

        [XmlElement("date")]
        public DateTime Date { get; set; }

        [XmlElement("description")]
        public String Description { get; set; }

        [XmlElement("warning_distance")]
        public Int16 WarningDistance { get; set; }

        [XmlElement("warning_days")]
        public Int16 WarningDays { get; set; }


        /// <summary>
        /// Is odometer
        /// </summary>
        [XmlIgnore]
        public Boolean IsOdometer
        {
            get
            {
                return Type == MaintenanceType.Filters || Type == MaintenanceType.Oil || Type == MaintenanceType.Maintenance;
            }
        }
    }
}
