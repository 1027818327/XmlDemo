using System.Collections.Generic;
using System.Xml.Serialization;

public class HuiYiXml
{
    [XmlAttribute(AttributeName = "m_Name")]
    public string m_Name { set; get; }
    [XmlAttribute(AttributeName = "m_Times")]
    public string m_Times { set; get; }
    [XmlAttribute(AttributeName = "m_Address")]
    public string m_Address { set; get; }
    [XmlAttribute(AttributeName = "m_Player")]
    public string m_Player { set; get; }
    [XmlAttribute(AttributeName = "m_Event")]
    public string m_Event { set; get; }
    [XmlAttribute(AttributeName = "m_Meaning")]
    public string m_Meaning { set; get; }
    [XmlAttribute(AttributeName = "m_Info")]
    public string m_Info { set; get; }
}
[XmlRoot("HuiYiList")]
public class HuiYiList
{
    [XmlElement("HuiYiXml")]
    public List<HuiYiXml> Ins;
}
