using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CoPilot.Core.Data
{
    public class Price
    {
        [XmlAttribute("currency")]
        public Currency Currency { get; set; }
        [XmlText]
        public Double Value { get; set; }

        /// <summary>
        /// Price default
        /// </summary>
        public Price()
        {
        }

        /// <summary>
        /// Price
        /// </summary>
        /// <param name="price"></param>
        /// <param name="currency"></param>
        public Price(Double price, Currency currency)
        {
            this.Value = price;
            this.Currency = currency;
        }
    }
}
