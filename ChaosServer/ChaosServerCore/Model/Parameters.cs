using ChaosServerCore.Controller;
using System.Xml.Serialization;

namespace ChaosServerCore.Model
{
    [XmlRoot ("Parameters")]
    public class Parameters : IIndexable
    {
        private RandomParameters randome = new RandomParameters();

        [XmlAttribute ("ID")]
        public string Id { get; set;}
        [XmlAttribute ("X")]
        public double X
        {
            get { return randome.GenerateXRandomNumber(); }
            set { }
        }
        [XmlAttribute ("Lambda")]
        public double Lambda
        {
            get { return randome.GenerateLambdaRandomNumber(); }
            set { }
        }    
    }
}
