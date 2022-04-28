Imports System.Xml
Imports System.Xml.Linq


Public Interface IXmlLibLoader

Inherits IDisposable

    Function getXmlDoc() As XmlDocument

    Function getXDoc() As XDocument

End Interface

