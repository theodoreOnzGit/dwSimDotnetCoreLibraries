Imports System.Xml
Imports System.Xml.Linq
Imports System


Public Class XmlLibraryList_May2022 

Implements IXmlLibraryList


    Private Property xmlLibraryList As List(Of (libraryName As String, xmlLibLoader As IXmlLibLoader))

	

	Sub New()

		Me.xmlLibraryList = new List(Of (libraryName As String, xmlLibLoader As IXmlLibLoader))
		Me.AddLibrary("dwsim", new dwSimXmlLibBruteForce)

	End Sub

	Public Sub AddLibrary(ByVal libraryName As String, ByVal xmlLibLoader As IXmlLibLoader)

		Dim tuple As (libraryName As String, xmlLibLoader As IXmlLibLoader)
		tuple.LibraryName = libraryName
		tuple.xmlLibLoader = xmlLibLoader 
		Me.xmlLibraryList.Add(tuple)

	End Sub


    Function returnXmlLibraryList() As List(Of (libraryName As String, xmlLibLoader As IXmlLibLoader)) Implements IXmlLibraryList.returnXmlLibraryList

		return xmlLibraryList

	End Function

	



	Sub Dispose() Implements IDisposable.Dispose

		For Each xmlLibraryTuple In xmlLibraryList
			xmlLibraryTuple.libraryName = Nothing
			xmlLibraryTuple.xmlLibLoader.Dispose()
			xmlLibraryTuple.xmlLibLoader = Nothing
		Next

	End Sub

End Class

