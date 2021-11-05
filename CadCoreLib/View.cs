using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Xml;
using System.Xml.Schema;

namespace CadCoreLib
{
    public class View : CadObject, IDrawableCadObject
    {
        public List<Layer> Layers { get; private set; }
        public Matrix4x4 TransformMatrix { get; set; }

        public float Scale
        {
            get
            {
                return TransformMatrix.M44;
            }

            set
            {
                Matrix4x4 matrix = TransformMatrix;
                matrix.M44 = value;
                TransformMatrix = matrix;
            }
        }

        public View()
        {
            Layers = new List<Layer>();
            TransformMatrix = new Matrix4x4(1, 0, 0, 0,
                                            0, 1, 0, 0,
                                            0, 0, 1, 0,
                                            0, 0, 0, 1);
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
            writer.WriteStartElement("View");

            if (!string.IsNullOrEmpty(Name))
                writer.WriteAttributeString("Name", Name);

            if (Scale < 1)
            {
                float a = 1 / Scale;
                if (a % 1 == 0)
                    writer.WriteAttributeString("Scale", $"1:{a}");
                else
                    writer.WriteAttributeString("Scale", Scale.ToString());
            }
            
            if (Scale > 1)
            {
                if (Scale % 1 == 0)
                    writer.WriteAttributeString("Scale", $"{Scale}:1");
                else
                    writer.WriteAttributeString("Scale", Scale.ToString());
            }

            if (!string.IsNullOrEmpty(Description))
                writer.WriteElementString("Description", Description);

            foreach (Layer lay in this.Layers)
                lay.WriteXml(writer);

            writer.WriteEndElement();
        }

        public void Draw(Graphics g)
        {
            foreach (Layer lay in this.Layers)
                lay.Draw(g);
        }
    }
}
