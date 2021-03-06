﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CoPilot.Core.Data
{
    [XmlRoot("circuit")]
    public class Circuit : NotifyObject
    {
        [XmlElement("duration")]
        public int duration { get; set; }

        [XmlElement("states")]
        public List<State> States { get; set; }

        [XmlElement("laps")]
        public List<Double> Laps { get; set; }

        [XmlElement("id")]
        public String Id { get; set; }

        [XmlElement("name")]
        public String Name { get; set; }

        [XmlElement("start")]
        public DateTime Start { get; set; }




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
        public TimeSpan FastestLap
        {
            get
            {
                TimeSpan best = TimeSpan.MaxValue;
                foreach (var lap in Laps)
                {
                    TimeSpan lapTime = new TimeSpan(0, 0, 0, 0, (int)lap);
                    if (lapTime < best)
                    {
                        best = lapTime;
                    }
                }
                return best;
            }
        }

        [XmlIgnore]
        public Odometer AvarageSpeed
        {
            get
            {
                var sum = States.Sum(e => e.Speed);
                return new Odometer(Math.Round(sum / States.Count, 1), Distance.Km);
            }
        }
    }
}
