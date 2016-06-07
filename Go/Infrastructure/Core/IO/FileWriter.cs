using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Go.Infrastructure.Core.IO
{
    public class FileWriter
    {
        #region Fields

        private StreamWriter streamWriter;

        private XmlWriter xmlTextWriter;

        private FileStream fileStream;

        #endregion

        #region Constructors

        public FileWriter(FileStream fileStream)
        {
            this.fileStream = fileStream;
            this.streamWriter = new StreamWriter(this.fileStream);
            this.streamWriter.AutoFlush = true;
            this.xmlTextWriter = XmlWriter.Create(Console.Out, new XmlWriterSettings());
            //this.xmlTextWriter = XmlWriter.Create(Console.Out);// = new XmlTextWriter(this.fileStream, System.Text.Encoding.UTF8);

            this.SaveGame();
        }

        #endregion

        #region Methods

        public void SaveGame()
        {
            var doc = this.CreateContent();

            this.xmlTextWriter.WriteStartDocument(true);
            this.xmlTextWriter.WriteStartElement("data","www.alpineskihouse.com");
            
            doc.WriteContentTo(this.xmlTextWriter);
            this.xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteFullEndElement();

            xmlTextWriter.WriteEndElement();

            // Write the XML to file and close the writer
            xmlTextWriter.Close();  
            //this.xmlTextWriter.WriteFullEndElementAsync();
            this.fileStream.Close();
        }

        private XmlDocument CreateContent()
        {
            XmlDocument xmlDocument = new XmlDocument();

            XmlElement element = xmlDocument.CreateElement("Atrybut");

            xmlDocument.CreateTextNode("Go");

            XmlText text = xmlDocument.CreateTextNode("Rozgrywka przebiegała....");

            element.AppendChild(text);
            xmlDocument.AppendChild(element);

            return xmlDocument;
        }

        #endregion
    }
}
