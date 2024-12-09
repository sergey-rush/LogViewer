using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LogViewer.Base
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "root", Namespace = "", IsNullable = false)]
    public class EventItemList
    {
        [XmlElement("event")]
        public List<EventItem> EventItems { get; set; }
    }
}