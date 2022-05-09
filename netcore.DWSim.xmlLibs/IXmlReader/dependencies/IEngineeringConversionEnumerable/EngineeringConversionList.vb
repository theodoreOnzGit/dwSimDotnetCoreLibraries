Imports EngineeringUnits
Imports EngineeringUnits.Units

Public Class EngineeringConversionList

Inherits List(Of Double)

Implements IEngineeringConversionEnumerable
Implements IEnumerable



	' this first part denotes the conversionFunction
	' delegate for converting the IEnumerable of Double
	' into IEnumerable of BaseUnit
	
    Private Property _conversionFunction As EngineeringConversion Implements IEngineeringConversionEnumerable._conversionFunction

    ' Constructor for dependency Injection 
	' in this case, it is absolutely required to inject
	' the EngineeringConversion Delegate
	
    Public Sub New(conversionFunction As EngineeringConversion)

		Me._conversionFunction = conversionFunction
		
	End Sub



	Public Function getEnumerable() As IEnumerable (Of BaseUnit) Implements IEngineeringConversionEnumerable.getEnumerable

		Dim resultEnumerable As IEnumerable (Of BaseUnit)

		resultEnumerable = Me._conversionFunction(Me)

		return resultEnumerable

	End Function

	' destructor or finaliser
	' this frees up memory in event the object is destroyed
	' or the garbage collector is called to finalize
	' this is for memory management

	Protected Overrides Sub Finalize()

		Me._conversionFunction = Nothing

	End Sub

End Class
