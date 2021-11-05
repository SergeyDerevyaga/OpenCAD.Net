using System.Collections.Generic;
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
        public SortedList<string, string> KeyValuePairs { get; private set; }

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
        }
    }

    public interface IDrawableCadObject
    {
        void Draw(Graphics g);
    }
}
