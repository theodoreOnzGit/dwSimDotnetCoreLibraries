Imports System.Xml
Imports System.Xml.Linq


Public Interface IXmlData

Inherits IDisposable

	Property xDoc As XDocument

	Sub loadXDoc()

End Interface
