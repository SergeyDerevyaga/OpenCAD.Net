using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;

namespace CadCoreLib
{
    public class Document : CadObject
    {
        public List<Sheet> Sheets { get; private set; }
        public bool MakeZones { get; set; }
        public string FileName { get; private set; }

        protected bool modified;
        public bool Modified
        {
            get
            {
                return modified;
            }
        }

        public Document()
        {
            Sheets = new List<Sheet>();
        }

        public static Document Open(string filename)
        {
            Document document = new Document();
            XmlReaderSettings settings = new XmlReaderSettings();
            XmlReader reader = XmlReader.Create(filename, settings);

            reader.Close();
            document.FileName = filename;
            return document;
        }

        public void Save(string filename)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(filename, settings);
            this.WriteXml(writer);
            writer.Close();
            this.FileName = filename;
        }

        public void Save()
        {
            if (!string.IsNullOrEmpty(this.FileName))
                Save(FileName);
        }

        public void Print(string printername)
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
            writer.WriteStartDocument();
            writer.WriteStartElement("CadDocument");

            if (!string.IsNullOrEmpty(Name))
                writer.WriteAttributeString("Name", Name);

            if (!string.IsNullOrEmpty(Description))
                writer.WriteElementString("Description", Description);

            if (MakeZones)
                writer.WriteElementString("MakeZones", MakeZones.ToString());

            foreach (Sheet sh in this.Sheets)
                sh.WriteXml(writer);

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
    }
}
