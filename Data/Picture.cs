using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CoPilot.Core.Data
{
    [XmlRoot("picture")]
    public class Picture : NotifyObject
    {
        [XmlElement("time")]
        public DateTime Time { get; set; }

        [XmlElement("path")]
        public String _path { get; set; }

        [XmlElement("rotated")]
        public Boolean Rotated { get; set; }

        [XmlElement("backup")]
        public BackupInfo Backup { get; set; }

        [XmlIgnore]
        public String Path 
        {
            get
            {
                return "/shared/transfers/" + _path;
            }
            set
            {
                _path = value;
            }
        }

        [XmlIgnore]
        public object Data { get; set; }
    }
}
