Imports System.Collections.Generic

Imports EngineeringUnits
Imports EngineeringUnits.Units


' the sole purpose of this file is to hold definitions of delgates for me
	
Public Delegate Function EngineeringConversion(ByVal quantityEnumerable As IEnumerable (Of Double)) As IEnumerable (Of BaseUnit)

