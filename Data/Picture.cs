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
        public String Path { get; set; }

        [XmlElement("rotated")]
        public Boolean Rotated { get; set; }

        [XmlElement("backups")]
        public ObservableCollection<BackupInfo> Backups { get; set; }
    }
}
