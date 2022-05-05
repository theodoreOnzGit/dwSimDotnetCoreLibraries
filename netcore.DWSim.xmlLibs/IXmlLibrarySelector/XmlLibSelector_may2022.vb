Public Class XmlLibSelector_may2022

Implements IXmlLibrarySelector


    Private Property _xmlLibraryList As IXmlLibraryList

    ' Constructor for dependency Injection 
	' not quite dependency injection
	' but it should be easy to switch with this
	' structure
    Public Sub New()

		Me._xmlLibraryList = new XmlLibraryList_May2022
		
	End Sub



    Public Function getXmlLibLoader(ByVal desiredLibrary As String) As IXmlLibLoader Implements IXmlLibrarySelector.getXmlLibLoader

		' first we get the library list object from _xmlLibraryList
		Dim libList As List(Of (libraryName As String, xmlLibLoader As IXmlLibLoader))
		libList = Me._xmlLibraryList.returnXmlLibraryList()

		Dim xmlLibLoader As IXmlLibLoader

		' second, we search for the libLoader Object in the library list
		' using a For Each loop
		
		For Each libListTuple In libList

			'' here i am comparing the library name in the libraryList
			' to the library name i supplied
			' i convert both to lowercase using the String.ToLower() method
			' so as to avoid case sensitivity
			If libListTuple.libraryName.ToLower() = desiredLibrary.ToLower()
				xmlLibLoader = libListTuple.xmlLibLoader
			End If

		Next
		
		return xmlLibLoader

	End Function



End Class
