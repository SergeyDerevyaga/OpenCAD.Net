using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CadCoreLib
{
    public abstract class CadObject : IXmlSerializable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CadObjectAttribute> Attributes { get; } = new List<CadObjectAttribute>();

        public abstract XmlSchema GetSchema();
        public abstract void ReadXml(XmlReader reader);
        public abstract void WriteXml(XmlWriter writer);
    }

    public class CadObjectAttribute : CadObject
    {
        [EditorAttribute(typeof(SortedListTypeEditor<string, string>), typeof(System.Drawing.Design.UITypeEditor))]
        public SortedList<string, string> KeyValuePairs { get; set; }

        public CadObjectAttribute()
        {
            KeyValuePairs = new SortedList<string, string>();
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
            writer.WriteStartElement("Attribute");

            if (!string.IsNullOrEmpty(Name))
                writer.WriteAttributeString("Name", Name);

            if (!string.IsNullOrEmpty(Description))
                writer.WriteElementString("Description", Description);

            foreach (KeyValuePair<string, string> kvp in this.KeyValuePairs)
            {
                writer.WriteStartElement("Parameter");
                writer.WriteAttributeString("Name", kvp.Key);
                writer.WriteString(kvp.Value);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }

    public interface IDrawableCadObject
    {
        void Draw(Graphics g);
    }
}
