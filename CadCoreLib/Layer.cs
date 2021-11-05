using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using System.Xml.Schema;

namespace CadCoreLib
{
    public class Layer : CadObject, IDrawableCadObject
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
            writer.WriteStartElement("Layer");

            if (!string.IsNullOrEmpty(Name))
                writer.WriteAttributeString("Name", Name);

            if (!string.IsNullOrEmpty(Description))
                writer.WriteElementString("Description", Description);

            foreach (DrawingElement e in this.Elements)
                e.WriteXml(writer);

            writer.WriteEndElement();
        }

        public void Draw(Graphics g)
        {
            foreach (DrawingElement e in this.Elements)
                e.Draw(g);
        }
    }
}
