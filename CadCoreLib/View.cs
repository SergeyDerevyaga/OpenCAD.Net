using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;

namespace CadCoreLib
{
    public class View : CadObject
    {
        public List<Layer> Layers { get; private set; }

        public View()
        {
            Layers = new List<Layer>();
        }

        public override XmlSchema GetSchema()
        {
            return null;
        }

        public override void ReadXml(XmlReader reader)
        {
        }

        public override void WriteXml(XmlWriter writer)
        {
        }
    }
}
