using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CoPilot.Core.Data
{
    [XmlRoot("video")]
    public class Video : NotifyObject
    {
        [XmlElement("time")]
        public DateTime Time { get; set; }

        [XmlElement("path")]
        public String Path { get; set; }

        [XmlElement("preview")]
        public String Preview { get; set; }

        [XmlElement("rotated")]
        public Boolean Rotated { get; set; }

        [XmlElement("duration")]
        public int duration { get; set; }

        [XmlElement("video-backups")]
        public ObservableCollection<BackupInfo> VideoBackups { get; set; }

        [XmlElement("preview-backups")]
        public ObservableCollection<BackupInfo> PreviewBackups { get; set; }
        
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
