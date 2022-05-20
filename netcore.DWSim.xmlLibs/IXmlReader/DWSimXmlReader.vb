Imports EngineeringUnits
Imports EngineeringUnits.Units


Public Class DWSimXmlReader

Implements IXmlReader


    ' here's the dependency injection

    Private Dim _xmlLibrarySelector As IXmlLibrarySelector
	Private Dim _xmlQuantityRetrieval As IXmlQuantityRetrieval

    ' Constructor for dependency Injection 
	' not quite dependency injection
	' but it should be easy to switch with this
	' structure
    Public Sub New(xmlLibrarySelector As IXmlLibrarySelector)

		Me._xmlLibrarySelector = xmlLibrarySelector
		
	End Sub



	Public Sub setLibrary (ByVal desiredLibrary As String) Implements IXmlReader.setLibrary
		'' in set library i want to use the xmlLibrarySelector to insert a library
		' and return an IXmlQuantityRetreival object

		Dim xmlLibLoaderObj As IXmlLibLoader

		Select desiredLibrary.ToLower()
			Case "dwsim"
				xmlLibLoaderObj = Me._xmlLibrarySelector.getXmlLibLoader(desiredLibrary)
				Me._xmlQuantityRetrieval = new dwSimXmlQuantityRetrieval(new dwSimXmlHumanReadablePropertyList_May2022, xmlLibLoaderObj) 
				xmlLibLoaderObj.Dispose()
				xmlLibLoaderObj = Nothing
		End Select

	End Sub


	Public Function getQuantityList(ByVal fluidType As String, desiredQuantityList As String) As IEnumerable (Of BaseUnit) Implements IXmlReader.getQuantityList



	End Function

	' destructor or finaliser
	' this frees up memory in event the object is destroyed
	' or the garbage collector is called to finalize
	' this is for memory management

	Protected Overrides Sub Finalize()

		Me._xmlLibrarySelector = Nothing

	End Sub

End Class
