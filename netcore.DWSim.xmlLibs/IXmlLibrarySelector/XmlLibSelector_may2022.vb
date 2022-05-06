Public Class XmlLibSelector_may2022

Implements IXmlLibrarySelector


    Private Property _xmlLibraryList As IXmlLibraryList
	Private Property _xmlLibLoader As IXmlLibLoader

    ' Constructor for dependency Injection 
	' not quite dependency injection
	' but it should be easy to switch with this
	' structure
    Public Sub New()

		Me._xmlLibraryList = new XmlLibraryList_May2022
		
	End Sub



    Public Function getXmlLibLoader(ByVal desiredLibrary As String) As IXmlLibLoader Implements IXmlLibrarySelector.getXmlLibLoader


		'' if we run the function more than once, 
		'i want to be able to dipose and delete _xmlLibLoader

		If(Me._xmlLibLoader IsNot Nothing)
			Me._xmlLibLoader.Dispose()
			Me._xmlLibLoader = Nothing
		End If


		' first we get the library list object from _xmlLibraryList
		Dim libList As List(Of (libraryName As String, xmlLibLoader As IXmlLibLoader))
		libList = Me._xmlLibraryList.returnXmlLibraryList()

		'' i set a boolean, that checks if the desired library is invalid
		' it's default is true
		' but if i found the library, the boolean becomes false
		Dim IsDesiredLibraryInvalid As Boolean
		IsDesiredLibraryInvalid = True


		' second, we search for the libLoader Object in the library list
		' using a For Each loop
		
		For Each libListTuple In libList

			'' here i am comparing the library name in the libraryList
			' to the library name i supplied
			' i convert both to lowercase using the String.ToLower() method
			' so as to avoid case sensitivity
			If libListTuple.libraryName.ToLower() = desiredLibrary.ToLower()
				IsDesiredLibraryInvalid = False
				Me._xmlLibLoader = libListTuple.xmlLibLoader
			End If

		Next
		

		If (IsDesiredLibraryInvalid = True)

			throw new IndexOutOfRangeException("the library name you supplied to the XmlLibSelector Class (in the netcore.dwSim.xmlLibs module) is invalid, please check spelling or if library is available")

		End If


		return Me._xmlLibLoader

	End Function

	' destructor or finaliser
	' this frees up memory in event the object is destroyed
	' or the garbage collector is called to finalize
	' this is for memory management

	Protected Overrides Sub Finalize()

		If(Me._xmlLibLoader IsNot Nothing)
			Me._xmlLibLoader.Dispose()
			Me._xmlLibLoader = Nothing
		End If

		If(Me._xmlLibraryList IsNot Nothing)
			Me._xmlLibraryList.Dispose()
			Me._xmlLibraryList= Nothing
		End If

	End Sub

End Class
