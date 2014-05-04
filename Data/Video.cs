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
        public String _path { get; set; }

        [XmlElement("preview")]
        public String _preview { get; set; }

        [XmlElement("rotated")]
        public Boolean Rotated { get; set; }

        [XmlElement("duration")]
        public int duration { get; set; }

        [XmlElement("video-backup")]
        public BackupInfo VideoBackup { get; set; }
        
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
        public String Preview
        {
            get
            {
                return "/shared/transfers/" + _preview;
            }
            set
            {
                _preview = value;
            }
        }
    }
}
