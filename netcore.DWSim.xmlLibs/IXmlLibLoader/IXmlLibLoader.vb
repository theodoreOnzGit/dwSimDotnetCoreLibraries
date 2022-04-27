Imports System.Xml
Imports System.Xml.Linq


Public Interface IXmlLibLoader

    Property filepath As String

    Function getXmlDoc() As XmlDocument

    Function getXDoc() As XDocument

End Interface

