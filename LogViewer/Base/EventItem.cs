using System.Xml.Serialization;
using System;

namespace LogViewer.Base
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "event", Namespace = "", IsNullable = false)]
    public class EventItem
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("l")]
        public string Mode { get; set; }

        [XmlAttribute("t")]
        public int Thread { get; set; }

        [XmlAttribute("src")]
        public string Source { get; set; }

        [XmlAttribute("cor_id")]
        public string CorId { get; set; }

        [XmlElement("date")]
        public string LogDate { get; set; }

        [XmlElement("caller")]
        public string Caller { get; set; }

        [XmlElement("msg")]
        public string Msg { get; set; }

    }
}