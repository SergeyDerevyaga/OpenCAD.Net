using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;

namespace CadCoreLib
{
    public class Document : CadObject
    {
        public List<Sheet> Sheets { get; private set; }
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
            XmlReader reader = XmlReader.Create(filename);

            reader.Close();
            document.FileName = filename;
            return document;
        }

        public void Save(string filename)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            XmlWriter writer = XmlWriter.Create(filename, settings);

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
        }
    }
}
