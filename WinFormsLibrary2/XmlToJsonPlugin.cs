using System.Xml;
using Newtonsoft.Json;
using WinFormsApp_OOP_2;

public class XmlToJsonPlugin : IShapePlugin
{
    public string Name => "XML to JSON Transformer";

    public void ProcessBeforeSave(ref string data, Type dataType)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(data);
        data = JsonConvert.SerializeXmlNode(doc);
    }

    public void ProcessAfterLoad(ref string data, Type dataType)
    {
        XmlDocument doc = JsonConvert.DeserializeXmlNode(data);
        using (var stringWriter = new StringWriter())
        using (var xmlTextWriter = XmlWriter.Create(stringWriter))
        {
            doc.WriteTo(xmlTextWriter);
            xmlTextWriter.Flush();
            data = stringWriter.GetStringBuilder().ToString();
        }
    }
}
