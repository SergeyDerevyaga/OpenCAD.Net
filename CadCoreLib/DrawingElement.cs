using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Xml;
using System.Xml.Schema;

namespace CadCoreLib
{
    public abstract class DrawingElement : CadObject
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
            this.elements = new List<DrawingElement>(e);
        }

        public override void Draw(Graphics g)
        {
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
