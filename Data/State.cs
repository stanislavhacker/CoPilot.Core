using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CoPilot.Core.Data
{
    [XmlRoot("state")]
    public class State
    {
        [DefaultValue("Unknown"), XmlAttribute("position")]
        public String Position { get; set; }

        [XmlAttribute("time")]
        public DateTime Time { get; set; }

        [DefaultValue(0), XmlAttribute("rpm")]
        public Double Rpm { get; set; }

        [DefaultValue(0), XmlAttribute("speed")]
        public Double Speed { get; set; }

        [DefaultValue(0), XmlAttribute("temperature")]
        public Double Temperature { get; set; }

        [DefaultValue(0), XmlAttribute("load")]
        public Double EngineLoad { get; set; }

        [DefaultValue(0), XmlAttribute("flowrate")]
        public Double MaxAirFlowRate { get; set; }

        [DefaultValue(0), XmlAttribute("throttle")]
        public Double ThrottlePosition { get; set; }

        [DefaultValue(0), XmlAttribute("pedal")]
        public Double AcceleratorPedalPosition { get; set; }

        [DefaultValue(0), XmlAttribute("oil-temperature")]
        public Double EngineOilTemperature { get; set; }

        [DefaultValue(0), XmlAttribute("injection")]
        public Double FuelInjectionTiming { get; set; }

        [DefaultValue(0), XmlAttribute("torque")]
        public Double EngineReferenceTorque { get; set; }

        [DefaultValue(0), XmlAttribute("uptime")]
        public Double Uptime { get; set; }
    }
}
