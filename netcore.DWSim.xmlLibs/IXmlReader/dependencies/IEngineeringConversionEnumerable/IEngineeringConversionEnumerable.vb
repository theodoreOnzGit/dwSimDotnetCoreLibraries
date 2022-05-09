Imports System.Collections.Generic

Imports EngineeringUnits
Imports EngineeringUnits.Units

Public Interface IEngineeringConversionEnumerable

Inherits IEnumerable
	
	Property _conversionFunction As EngineeringConversion

	Function getEnumerable As IEnumerable (Of BaseUnit)


End Interface
