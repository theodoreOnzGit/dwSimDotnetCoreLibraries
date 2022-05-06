Imports System.Collections.Generic

Imports EngineeringUnits
Imports EngineeringUnits.Units

Public Interface IXmlReader

	Function getQuantityList(ByVal fluidType As String, desiredQuantityList As String) As IEnumerable (Of UnknownUnit)

End Interface
