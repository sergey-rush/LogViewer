using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System;
using LogViewer.Properties;

namespace LogViewer.Extensions
{
    public static class XmlExtensions
    {
        public static T FromXml<T>(this string xmlString)
        {
            T returnValue = default(T);

            XmlSerializer serial = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xmlString))
            {
                object result = serial.Deserialize(reader);

                if (result is T output)
                {
                    returnValue = output;
                }
            }

            return returnValue;
        }
        public static string ToXml<T>(this T value)
        {
            try
            {
                //var settings = new XmlWriterSettings
                //{
                //    Indent = true,
                //    IndentChars = ("\t"),
                //    OmitXmlDeclaration = false,
                //    Encoding = Encoding.UTF8
                //};

                XmlSerializerNamespaces ns = new XmlSerializerNamespaces(); 
                ns.Add("", "");

                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = ("\t"),
                    OmitXmlDeclaration = true,
                    NamespaceHandling = NamespaceHandling.OmitDuplicates,
                    Encoding = Encoding.UTF8
                };
                var serializer = new XmlSerializer(typeof(T));
                using (var stringWriter = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(stringWriter, settings))
                    //using (var writer = XmlWriter.Create(stringWriter))
                    {
                        serializer.Serialize(writer, value, ns);
                    }

                    return stringWriter.ToString();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while calling ToXml method", ex);
            }
        }
    }
}