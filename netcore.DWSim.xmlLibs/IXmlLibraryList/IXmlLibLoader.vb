Imports System.Xml
Imports System.Xml.Linq


Public Interface IXmlLibraryList

Inherits IDisposable

    Function getXmlDoc() As XmlDocument

    Function getXDoc() As XDocument

End Interface

