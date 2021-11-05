using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using System.Xml.Schema;
using CadCoreLib.Properties;

namespace CadCoreLib
{
    public enum Formats { A4, A3, A2, A1, A0, A5 }

    public class Sheet : CadObject, IDrawableCadObject
    {
        public List<View> Views { get; private set; }

        private Formats format;
        public Formats Format
        {
            get
            {
                return format;
            }

            set
            {
                format = value;
                CalcSize();
            }
        }

        private uint multiplier = 1;
        public uint Multiplier
        {
            get
            {
                return multiplier;
            }

            set
            {
                if (value < 1)
                    throw new System.ArgumentException(Resources.InvalidFormatMultiplierExceptionMsg);

                multiplier = value;
                CalcSize();
            }
        }

        private bool landscape;
        public bool Landscape
        {
            get
            {
                return landscape;
            }

            set
            {
                landscape = value;
                CalcSize();
            }
        }

        private SizeF size = new SizeF(210, 297);
        public SizeF Size
        {
            get
            {
                return size;
            }
        }

        private void CalcSize()
        {
            switch (format)
            {
                case Formats.A4:
                    size = new SizeF(210, 297);
                    break;

                case Formats.A3:
                    size = new SizeF(297, 420);
                    break;

                case Formats.A2:
                    size = new SizeF(420, 594);
                    break;

                case Formats.A1:
                    size = new SizeF(594, 841);
                    break;

                case Formats.A0:
                    size = new SizeF(841, 1189);
                    break;

                case Formats.A5:
                    size = new SizeF(148, 210);
                    break;
            }

            size = new SizeF(size.Width * multiplier, size.Height);

            if (landscape)
                size = new SizeF(size.Height, size.Width);
        }

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
            writer.WriteStartElement("Sheet");

            if (!string.IsNullOrEmpty(Name))
                writer.WriteAttributeString("Name", Name);

            if (Format != Formats.A4)
                if (Multiplier > 1)
                    writer.WriteAttributeString("Format", $"{Format}x{Multiplier}");
                else
                    writer.WriteAttributeString("Format", $"{Format}");

            if (Landscape)
                writer.WriteAttributeString("Landscape", Landscape.ToString());

            if (!string.IsNullOrEmpty(Description))
                writer.WriteElementString("Description", Description);

            foreach (View vw in this.Views)
                vw.WriteXml(writer);

            writer.WriteEndElement();
        }

        public void Draw(Graphics g)
        {
            foreach (View vw in this.Views)
                vw.Draw(g);
        }
    }
}
