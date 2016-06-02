using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ChaosServerCore.Model
{
    [XmlRoot ("Sender")]
    public class Sender
    {
        [XmlElement ("ID")]
        public string Id { get; set; }
        [XmlElement ("Name")]
        public string Name { get; set; }
    }
}
