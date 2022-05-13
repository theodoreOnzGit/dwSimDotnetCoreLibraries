Imports System.Xml
Imports System.Xml.Linq
Imports System

Imports System.Collections.Generic

Public Interface IXmlHumanReadablePropertyList

Inherits IXmlPropertyList

	Property propertyMenu As IEnumerable (Of String)

	Function getMenu() As IEnumerable(Of String)
	
	' this overload of return list allows the user
	' to obtain a filtered list of quantities pertaining
	' to what he/she desires, eg heat capacity quantities
	' i can either choose a property from a menu of all properties in the list
	' or choose a property directly available in the xml file
	' in the latter case, only one item will be in the enumerable
	Overloads Function returnList(ByVal desiredQuantity As String) As IEnumerable (Of String)
	
	
	
End Interface

