Imports System.Xml
Imports System.Xml.Linq


Public Class dwSimXmlLibLoader

Implements IXmlLibLoader


' properties

    Private Property filepath as String 

' constructors

    Public Sub New()

	    ' the default option is the dwsim library
	    ' this implementation does NOT work
	    ' because the binary file will look for the relative
	    ' filepath compared to the bin folder
	    Me.filepath = "../DWSIM.Thermodynamics/Assets/Databases/dwsim.xml"

    End Sub

' functions to retrieve xml data

    Public Function getXmlDoc() As XmlDocument Implements IXmlLibLoader.getXmlDoc


	    Dim xmlDoc as XmlDocument
	    xmlDoc = new XmlDocument
	    xmlDoc.Load(Me.filepath)

	    return xmlDoc


    End Function

    Public Function getXDoc() As XDocument Implements IXmlLibLoader.getXDoc


	    Dim xDoc As XDocument
	    xDoc = xDocument.Load(Me.filepath)

	    return xDoc

    End Function

    Public Sub Dispose() Implements IDisposable.Dispose

	    throw new NotImplementedException()

    End Sub

End Class
