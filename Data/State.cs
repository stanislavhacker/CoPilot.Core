using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CoPilot.Core.Data
{
    [XmlRoot("state")]
    public class State
    {
        [XmlElement("position")]
        public GeoCoordinate Position { get; set; }

        [XmlElement("time")]
        public DateTime Time { get; set; }

        [XmlElement("rpm")]
        public Double Rpm { get; set; }

        [XmlElement("speed")]
        public Double Speed { get; set; }

        [XmlElement("temperature")]
        public Double Temperature { get; set; }

        [XmlElement("engine-load")]
        public Double EngineLoad { get; set; }

        [XmlElement("max-air-flow-rate")]
        public Double MaxAirFlowRate { get; set; }

        [XmlElement("throttle-position")]
        public Double ThrottlePosition { get; set; }

        [XmlElement("accelerator-pedal-position")]
        public Double AcceleratorPedalPosition { get; set; }

        [XmlElement("engine-oil-temperature")]
        public Double EngineOilTemperature { get; set; }

        [XmlElement("fuel-injection-timing")]
        public Double FuelInjectionTiming { get; set; }

        [XmlElement("engine-reference-torque")]
        public Double EngineReferenceTorque { get; set; }

        [XmlElement("uptime")]
        public Double Uptime { get; set; }
    }
}
