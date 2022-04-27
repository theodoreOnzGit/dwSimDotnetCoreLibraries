Imports System.Xml
Imports System.Xml.Linq


Public Class dwSimXmlLibLoader

Implements IXmlLibLoader


' properties

    Private Property filepath as String Implements IXmlLibLoader.filepath

' constructors

    Public Sub New()

	    ' the default option is the dwsim library
	    Me.filepath = "../DWSIM.Thermodynamics/Assets/Databases/dwsim.xml"

    End Sub

' functions to retrieve xml data

    Public Function getXmlDoc() As XmlDocument Implements IXmlLibLoader.getXmlDoc


	    Dim xmlDoc as XmlDocument
	    xmlDoc = new XmlDocument
	    xmlDoc.LoadXml(Me.filepath)

	    return xmlDoc


    End Function

    Public Function getXDoc() As XDocument Implements IXmlLibLoader.getXDoc


	    Dim xDoc As XDocument
	    xDoc = xDocument.Load(Me.filepath)

	    return xDoc

    End Function

End Class
