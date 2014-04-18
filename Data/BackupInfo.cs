using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CoPilot.Core.Data
{
    public class BackupInfo
    {
        [XmlAttribute("download-url")]
        public String DownloadUrl { get; set; }

        [XmlAttribute("delete-url")]
        public String DeleteUrl { get; set; }

        [XmlAttribute("date")]
        public DateTime Date { get; set; }

        [XmlAttribute("id")]
        public String Id { get; set; }
    }
}
