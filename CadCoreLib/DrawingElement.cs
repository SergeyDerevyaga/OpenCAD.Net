using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Xml;
using System.Xml.Schema;
using CadCoreLib.Properties;

namespace CadCoreLib
{
    public abstract class DrawingElement : CadObject, IDrawableCadObject
    {
        public abstract void Draw(Graphics g);
    }

    public class MacroElement : DrawingElement
    {
        private List<DrawingElement> elements;
        public ReadOnlyCollection<DrawingElement> Elements
        {
            get
            {
                return elements.AsReadOnly();
            }
        }

        public MacroElement(DrawingElement[] e)
        {
            if (e.Length == 0)
                throw new System.ArgumentException(Resources.EmptyMacroElementExceptionMsg);

            this.elements = new List<DrawingElement>(e);
        }

        public override void Draw(Graphics g)
        {
            foreach (DrawingElement e in this.Elements)
                e.Draw(g);
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
            writer.WriteStartElement("MacroElement");

            if (!string.IsNullOrEmpty(Name))
                writer.WriteAttributeString("Name", Name);

            if (!string.IsNullOrEmpty(Description))
                writer.WriteElementString("Description", Description);

            foreach (DrawingElement e in this.Elements)
                e.WriteXml(writer);

            writer.WriteEndElement();
        }
    }
}
