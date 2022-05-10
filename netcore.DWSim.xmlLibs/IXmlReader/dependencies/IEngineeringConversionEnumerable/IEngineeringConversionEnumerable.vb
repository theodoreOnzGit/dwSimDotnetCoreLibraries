Imports System.Collections.Generic

Imports EngineeringUnits
Imports EngineeringUnits.Units

Public Interface IEngineeringConversionEnumerable


' for this interface, i want to be able to create an EngineeringEnumerable
' it should be able to create the delegate 
' and set it to some function
'
' i will tightly couple the class to the delegate but
' only couple the class to IEngineeringConversionEnumerable
'
' the setDelegate function will perform delegate injection
' and getEnumerable will return an IEnumerable of BaseUnit
'
' the last function will be an Add function
' because i don't want to tightly couple the interface to the EngineeringList
'
' but i like that there is an Add function
' though i am tempted to just make this inherit IList
' instead of IEnumerable
' so that I can use List functions like Add()
'
' note: the difference between sub and function
' sub is essentially a replacement for void in C#
' Function means that my method or function must return an object

Inherits IList
	
	Property _conversionFunction As EngineeringConversion
	
	Sub setDelegate(ByVal conversionFunction As EngineeringConversion)

	Function getEnumerable As IEnumerable (Of BaseUnit)


End Interface
