using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ChaosServerCore.Model
{
    [XmlRoot ("Receiver")]
    public class Receiver
    {
        [XmlAttribute ("ID")]
        public string Id { get; set; }
        [XmlAttribute ("Name")]
        public string Name { get; set; }
    }
}
