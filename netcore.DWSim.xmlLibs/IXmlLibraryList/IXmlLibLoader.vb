Imports System.Xml
Imports System.Xml.Linq
Imports System


Public Interface IXmlLibraryList

Inherits IDisposable

    Function returnXmlLibraryList() As List(Of (libraryName As String, xmlLibLoader As IXmlLibLoader))

End Interface

