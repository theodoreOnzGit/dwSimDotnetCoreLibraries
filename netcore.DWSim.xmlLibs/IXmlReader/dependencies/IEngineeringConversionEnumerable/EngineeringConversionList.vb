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
	
	'' here i am overloading some constructors, so that i can initialise this
	' object without constructor injection
	' constructor injection actually forces me to tightly couple a class
	' using the IEngineeringConversionEnumerable list
	' to use this implementation
	' i don't want any reference to this concrete class inside
	' the subsequent objects
	' but i want to define the delegate objects within the 
	' new class, so no constructor injection here
	

    Public Sub New()

		Dim conversionFunction As EngineeringConversion
		conversionFunction = new EngineeringConversion(AddressOf Me.defaultError)
		Me._conversionFunction = conversionFunction
		
	End Sub

	Private Function defaultError(ByVal quantityEnumerable As IEnumerable (Of Double)) As IEnumerable (Of BaseUnit)


		' this function is only here to throw a new error
		' in case the delgates are not defined

		Dim ErrorMessage As String
		ErrorMessage = "==== Invalid Operation Exception ==== "
		ErrorMessage += VbCrLf & "Please use the EngineeringConversionList.setDelegate Method"
		ErrorMessage += VbCrLf & "to set the way you want to convert the IEnumerable<Double> to IEnumerable<BaseUnit>" 
		throw new InvalidOperationException(ErrorMessage)

	End Function


	Public Sub setDelegate(ByVal conversionFunction As EngineeringConversion) Implements IEngineeringConversionEnumerable.setDelegate

		If conversionFunction = Nothing
			Dim ErrorMessage As String
			ErrorMessage = "you need inject a proper EngineeringConversion "
			ErrorMessage += VbCrLf & "Delegate into EngineeringConversionList"
			throw new InvalidOperationException(ErrorMessage)
		End If

		Me._conversionFunction = conversionFunction

	End Sub

	' destructor or finaliser
	' this frees up memory in event the object is destroyed
	' or the garbage collector is called to finalize
	' this is for memory management

	Protected Overrides Sub Finalize()

		Me._conversionFunction = Nothing

	End Sub

End Class
