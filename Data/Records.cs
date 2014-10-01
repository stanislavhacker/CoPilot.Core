using CoPilot.Core.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        USD,
        EUR,
        GBP
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
        public static Records Load(Stream stream = null)
        {
            Records tmpRecords = null;

            if (stream != null)
            {
                //data
                tmpRecords = Deserialize(stream);
                tmpRecords.Size = stream.Length;
                stream.Dispose();
            }

            if (tmpRecords == null)
            {
                //new data
                tmpRecords = new Records();

                tmpRecords.GpsAllowed = true;
                tmpRecords.ObdAllowed = true;
                tmpRecords.DriveModeAllowed = true;
                tmpRecords.BackupOnStart = false;
                tmpRecords.Id = newGuid();

                tmpRecords.Backup = new BackupInfo();
                tmpRecords.Backup.Url = String.Empty;
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
                tmpRecords.Maintenances = new ObservableCollection<Maintenance>();
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

        [XmlAttribute("currency")]
        public Currency Currency { get; set; }

        [XmlAttribute("distance")]
        public Distance Distance { get; set; }

        [XmlAttribute("consumption")]
        public Consumption Consumption { get; set; }

        [XmlAttribute("obd-device")]
        public String ObdDevice { get; set; }

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

        [XmlElement("maintenances")]
        public ObservableCollection<Maintenance> Maintenances { get; set; }

        //////////////////////////////////////////////////////////// XML

        [XmlIgnore]
        public Double Size { get; private set; }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="stream"></param>
        public void Save(Stream stream)
        {
            XmlSerializer xml = new XmlSerializer(GetType());
            xml.Serialize(stream, this);
            this.Size = stream.Length;
            stream.Dispose();
        }

        /// <summary>
        /// Get average consuption
        /// </summary>
        /// <returns></returns>
        public Double AverageConsumption()
        {
            var distanceSum = 0.0;
            var fuelSum = 0.0;

            var distanceSumFull = 0.0;
            var fuelSumFull = 0.0;

            if (this.Fills.Count < 2)
            {
                return 0;
            }

            for (var i = this.Fills.Count - 1; i > 0; i--)
            {
                var current = this.Fills[i];
                var next = this.Fills[i - 1];

                var distance = DistanceExchange.GetOdometerWithRightDistance(next.Odometer) - DistanceExchange.GetOdometerWithRightDistance(current.Odometer);
                var l = current.Refueled;

                if (current.Full)
                {
                    distanceSumFull += distance;
                    fuelSumFull += l;
                }
                else
                {
                    distanceSum += distance;
                    fuelSum += l;
                }
            }

            return Math.Round((fuelSum + fuelSumFull) / (distanceSum + distanceSumFull), 4);
        }
    }
}
