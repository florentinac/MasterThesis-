using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ChaosServerCore.Model
{
    [XmlRoot ("Request")]
    public class Request : IIndexable
    {
        [XmlAttribute ("ID")]
        public string Id { get; set; }
        [XmlElement ("Sender")]
        public Sender Sender { get; set; }
        [XmlElement("Receiver")]
        public Receiver Receiver { get; set; }
        [XmlElement("Image")]
        public string Image { get; set; }
        [XmlElement("Parameters")]
        public Parameters Parameters { get; set; }
    }
}
