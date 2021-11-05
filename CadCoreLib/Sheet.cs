using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;

namespace CadCoreLib
{
    public class Sheet : CadObject
    {
        public List<View> Views { get; private set; }

        public Sheet()
        {
            Views = new List<View>();
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
