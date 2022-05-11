Imports System.Xml
Imports System.Xml.Linq
Imports System

Imports EngineeringUnits
Imports EngineeringUnits.Units

Public Class dwSimXmlQuantityRetrieval 

Implements IXmlQuantityRetrieval


    Private Property _xmlLibLoader As IXmlLibLoader Implements IXmlQuantityRetrieval._xmlLibLoader

    Function returnQuantityList(ByVal desiredQuantity As String) As IEnumerable (Of Double) Implements IXmlQuantityRetrieval.returnQuantityList

	End Function


    Function returnDimensionedQuantityList(ByVal desiredQuantity As String) As IEnumerable (Of BaseUnit) Implements IXmlQuantityRetrieval.returnDimensionedQuantityList

	End Function

    Sub injectLib(xmlLibLoaderObj As IXmlLibLoader) Implements IXmlQuantityRetrieval.injectLib

	End Sub

    Public Sub Dispose() Implements IDisposable.Dispose

		_xmlLibLoader.Dispose()
		_xmlLibLoader = Nothing

	End Sub


	


End Class

