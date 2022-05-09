Imports System.Collections.Generic

Imports EngineeringUnits
Imports EngineeringUnits.Units

Public Interface IXmlReader

    ' I will return an IEnumerable Of BaseUnit rather than UnknownUnit as i
	' it's less buggy to work with base units
	
	Function getQuantityList(ByVal fluidType As String, desiredQuantityList As String) As IEnumerable (Of BaseUnit)

End Interface
