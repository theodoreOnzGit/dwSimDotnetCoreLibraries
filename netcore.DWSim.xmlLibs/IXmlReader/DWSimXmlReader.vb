Imports EngineeringUnits
Imports EngineeringUnits.Units


Public Class DWSimXmlReader

'Implements IXmlReader


    Private Property _xmlLibrarySelector As IXmlLibrarySelector

    ' Constructor for dependency Injection 
	' not quite dependency injection
	' but it should be easy to switch with this
	' structure
    Public Sub New(xmlLibrarySelector As IXmlLibrarySelector)

		Me._xmlLibrarySelector = xmlLibrarySelector
		
	End Sub



	Public Function getQuantityList(ByVal fluidType As String, desiredQuantityList As String) As IEnumerable (Of UnknownUnit) 'Implements IXmlReader.getQuantityList


	End Function

	' destructor or finaliser
	' this frees up memory in event the object is destroyed
	' or the garbage collector is called to finalize
	' this is for memory management

	Protected Overrides Sub Finalize()

		Me._xmlLibrarySelector = Nothing

	End Sub

End Class
