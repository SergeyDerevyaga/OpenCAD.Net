using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;

namespace CadCoreLib
{
    public class Layer : CadObject
    {
        public List<DrawingElement> Elements { get; private set; }

        public Layer()
        {
            Elements = new List<DrawingElement>();
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
