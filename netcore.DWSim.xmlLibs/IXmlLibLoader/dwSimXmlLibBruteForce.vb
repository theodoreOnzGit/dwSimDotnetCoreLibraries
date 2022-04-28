Imports System.Xml
Imports System.Xml.Linq


Public Class dwSimXmlLibBruteForce

Implements IXmlLibLoader

' description
' this class uses brute force to bring in the xml file
' , ie copy and paste the xml file into a visual basic, 
' define the whole thing as a string and return it


' constructors

    Private Property _xmlDataObj As IXmlData


    Public Sub New()

		' dependency loading (not quite injection)
		Me._xmlDataObj = new dwSimComponentXmlData

    End Sub


	Public Sub New(Byval xmlDataObj As IXmlData)

		'this overloaded constructor allows for dependency
		'injection if one so wishes

		Me._xmlDataObj = xmlDataObj

	End Sub

' functions to retrieve xml data

    Public Function getXmlDoc() As XmlDocument Implements IXmlLibLoader.getXmlDoc

		Dim xmlDoc As XmlDocument

		xmlDoc = Me._xmlDataObj.xmlDoc

	    return xmlDoc


    End Function

    Public Function getXDoc() As XDocument Implements IXmlLibLoader.getXDoc

		Dim xDoc as XDocument

		xDoc = Me._xmlDataObj.xDoc

	    return xDoc

    End Function

    Public Sub Dispose() Implements IDisposable.Dispose

		_xmlDataObj.Dispose()

	End Sub


End Class
