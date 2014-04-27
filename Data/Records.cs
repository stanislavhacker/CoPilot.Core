using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CoPilot.Core.Data
{
    /// <summary>
    /// Currency
    /// </summary>
    public enum Currency
    {
        CZK,
        USD
    }

    /// <summary>
    /// Distance
    /// </summary>
    public enum Distance
    {
        Km,
        Mi
    }

    /// <summary>
    /// Consumption
    /// </summary>
    public enum Consumption
    {
        LitersPer100Distance,
        DistanceOnGallon
    }


    [XmlRoot("copilot")]
    public class Records
    {

        /// <summary>
        /// Load
        /// </summary>
        /// <returns></returns>
        public static Records Load(String name, IsolatedStorageFile storage)
        {
            Stream stream;
            Records tmpRecords = null;
            var fileExists = storage.FileExists(name);

            if (fileExists)
            {
                //stream
                stream = storage.OpenFile(name, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);

                //data
                tmpRecords = Deserialize(stream);

                stream.Close();
                stream.Dispose();
            }

            if (!fileExists || tmpRecords == null)
            {
                //new data
                tmpRecords = new Records();

                tmpRecords.GpsAllowed = true;
                tmpRecords.ObdAllowed = true;
                tmpRecords.DriveModeAllowed = true;
                tmpRecords.BackupOnStart = false;
                tmpRecords.Id = newGuid();

                tmpRecords.Backup = new BackupInfo();
                tmpRecords.Backup.DeleteUrl = String.Empty;
                tmpRecords.Backup.DownloadUrl = String.Empty;
                tmpRecords.Backup.Date = DateTime.Now;
                tmpRecords.Backup.Id = String.Empty;

                tmpRecords.Currency = Currency.USD;
                tmpRecords.Distance = Distance.Mi;
                tmpRecords.Consumption = Consumption.LitersPer100Distance;
                tmpRecords.ObdDevice = String.Empty;

                tmpRecords.States = new ObservableCollection<State>();
                tmpRecords.Videos = new ObservableCollection<Video>();
                tmpRecords.Pictures = new ObservableCollection<Picture>();
                tmpRecords.Fills = new ObservableCollection<Fill>();
                tmpRecords.Repairs = new ObservableCollection<Repair>();
            }

            return tmpRecords;
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Records Deserialize(Stream stream)
        {
            Records tmpRecords;
            try
            {
                var settings = new XmlReaderSettings();
                settings.Async = true;

                XmlReader reader = XmlReader.Create(stream, settings);
                XmlSerializer xml = new XmlSerializer(typeof(Records));
                tmpRecords = xml.Deserialize(reader) as Records;
            }
            catch
            {
                tmpRecords = null;
            }
            return tmpRecords;
        }

        /// <summary>
        /// Get guid
        /// </summary>
        /// <returns></returns>
        private static string newGuid()
        {
            var array = new List<string>();
            array.Add(Guid.NewGuid().ToString());
            array.Add(Guid.NewGuid().ToString());
            array.Add(Guid.NewGuid().ToString());

            return String.Join("-", array);
        }


        //////////////////////////////////////////////////////////// XML

        //Attributes

        [XmlAttribute("gps")]
        public Boolean GpsAllowed { get; set; }

        [XmlAttribute("obd")]
        public Boolean ObdAllowed { get; set; }

        [XmlAttribute("drive-mode")]
        public Boolean DriveModeAllowed { get; set; }

        [XmlAttribute("backup-on-start")]
        public Boolean BackupOnStart { get; set; }

        [XmlAttribute("email-on-backup")]
        public Boolean EmailOnBackup { get; set; }

        [XmlAttribute("currency")]
        public Currency Currency { get; set; }

        [XmlAttribute("distance")]
        public Distance Distance { get; set; }

        [XmlAttribute("consumption")]
        public Consumption Consumption { get; set; }

        [XmlAttribute("obd-device")]
        public String ObdDevice { get; set; }

        [XmlAttribute("backup-email")]
        public String BackupEmail { get; set; }

        [XmlAttribute("change")]
        public DateTime Change { get; set; }


        //Elements

        [XmlElement("app-id")]
        public String Id { get; set; }

        [XmlElement("backup")]
        public BackupInfo Backup { get; set; }

        [XmlElement("states")]
        public ObservableCollection<State> States { get; set; }

        [XmlElement("videos")]
        public ObservableCollection<Video> Videos { get; set; }

        [XmlElement("pictures")]
        public ObservableCollection<Picture> Pictures { get; set; }

        [XmlElement("fills")]
        public ObservableCollection<Fill> Fills { get; set; }

        [XmlElement("repairs")]
        public ObservableCollection<Repair> Repairs { get; set; }

        //////////////////////////////////////////////////////////// XML

        public void Save(Stream stream)
        {
            XmlSerializer xml = new XmlSerializer(GetType());
            xml.Serialize(stream, this);
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="name"></param>
        public void Save(String name, IsolatedStorageFile storage)
        {
            Stream stream;
            if (storage.FileExists(name))
            {
                stream = storage.OpenFile(name, FileMode.Truncate, FileAccess.ReadWrite, FileShare.Read);
            } 
            else 
            {
                stream = storage.OpenFile(name, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            }

            this.Save(stream);

            stream.Close();
            stream.Dispose();
        }
    }
}
