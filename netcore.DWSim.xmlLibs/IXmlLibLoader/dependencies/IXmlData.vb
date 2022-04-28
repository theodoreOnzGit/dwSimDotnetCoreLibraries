Imports System.Xml
Imports System.Xml.Linq


Public Interface IXmlData

Inherits IDisposable

    Property xmlDoc As XmlDocument
	
	Property xDoc As XDocument

	Sub loadXDoc()

	Sub loadXmlDoc()

End Interface
