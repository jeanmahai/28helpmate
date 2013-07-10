using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace Utility.Update
{
    [XmlRoot("manifest")]
    public class Manifest
    {
        [XmlElement("version")]
        public string Version { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("fileBytes")]
        public long FileBytes { get; set; }

        [XmlElement("application")]
        public Application Application { get; set; }

        [XmlElement("files")]
        public ManifestFiles ManifestFiles { get; set; }
    }

    public class ManifestFiles
    {
        [XmlElement("file")]
        public ManifestFile[] Files { get; set; }

        [XmlAttribute("base")]
        public string BaseUrl { get; set; }
    }

    public class ManifestFile
    {
        [XmlAttribute("source")]
        public string Source
        {
            get;
            set;
        }

        [XmlAttribute("hash")]
        public string Hash
        {
            get;
            set;
        }
    }

    public class Application
    {
        [XmlAttribute("applicationId")]
        public string ApplicationId { get; set; }

        [XmlElement("location")]
        public string Location { get; set; }

        [XmlElement("entryPoint")]
        public EntryPoint EntryPoint { get; set; }
    }

    public class EntryPoint
    {
        [XmlAttribute("file")]
        public string File { get; set; }

        [XmlAttribute("parameters")]
        public string Parameters { get; set; }
    }

    public class UpdaterConfigurationView
    {
        private static XmlDocument document = new XmlDocument();
        private static readonly string xmlFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config/Version.config");

        static UpdaterConfigurationView()
        {
            document.Load(xmlFileName);
        }

        public string Version
        {
            get
            {
                return document.SelectSingleNode("applicationUpdater").Attributes["version"].Value;
            }
            set
            {
                document.SelectSingleNode("applicationUpdater").Attributes["version"].Value = value;
                document.Save(xmlFileName);
            }
        }

        public string ApplicationId
        {
            get
            {
                return document.SelectSingleNode("applicationUpdater").Attributes["applicationId"].Value;
            }
            set
            {
                document.SelectSingleNode("applicationUpdater").Attributes["applicationId"].Value = value;
                document.Save(xmlFileName);
            }
        }

        public string ManifestUri
        {
            get
            {
                return document.SelectSingleNode("applicationUpdater").Attributes["manifestUri"].Value;
            }
            set
            {
                document.SelectSingleNode("applicationUpdater").Attributes["manifestUri"].Value = value;
                document.Save(xmlFileName);
            }
        }
    }
}
