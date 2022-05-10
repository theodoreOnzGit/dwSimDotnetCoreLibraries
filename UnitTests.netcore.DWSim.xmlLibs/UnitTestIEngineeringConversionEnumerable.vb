Imports System
Imports Xunit
Imports theoOng.netcore.DWSim.xmlLibs

Imports EngineeringUnits
Imports EngineeringUnits.Units

Namespace UnitTests.netcore.DWSim.xmlLibs

    Public Class UnitTestIEngineeringConversionEnumerable


		<Fact>
		Function TestIEngineeringConversionEnumerable_ShouldImplementIEnumerable() As IEnumerable (Of Double)

			' this test is here to see if the IEnumerable (Of Double) type can be returned


			Dim A As Double
			Dim B As Double
			Dim C As Double
			Dim D As Double
			Dim E As Double

			A = 2.98E+01
			B = -7.01E-03
			C = 1.74E-05
			D = -8.48E-09
			E = 9.34E-13

			Dim engineeringConvEnumerable As IEngineeringConversionEnumerable
			engineeringConvEnumerable = new EngineeringConversionList()

			engineeringConvEnumerable.Add(A)
			engineeringConvEnumerable.Add(B)
			engineeringConvEnumerable.Add(C)
			engineeringConvEnumerable.Add(D)
			engineeringConvEnumerable.Add(E)

			Dim engineeringEnumerable As IEnumerable
			engineeringEnumerable = engineeringConvEnumerable

			return engineeringConvEnumerable

		End Function


		<Theory>
		<InlineData()>
		Sub TestIEngineeringConversionEnumerable_ShouldConvert_setDelegate()

			' Description:
			' In this test, i will make an IEnumerable Of BaseUnits Manually
			' First by making a List of Base Units
			'the units are as follows:
			''Cp = A + B*T + C*T^2 + D*T^3 + E*T^4 where Cp in kJ/kg-mol*K , T in K
			'
			
			'' Setup
			Dim Ideal_Gas_Heat_Capacity_Const_A As BaseUnit
			Dim Ideal_Gas_Heat_Capacity_Const_B As BaseUnit
			Dim Ideal_Gas_Heat_Capacity_Const_C As BaseUnit
			Dim Ideal_Gas_Heat_Capacity_Const_D As BaseUnit
			Dim Ideal_Gas_Heat_Capacity_Const_E As BaseUnit

			Dim cpUnit As UnitSystem
			cpUnit = (EnergyUnit.SI/AmountOfSubstanceUnit.SI/TemperatureUnit.SI)

			Ideal_Gas_Heat_Capacity_Const_A = new BaseUnit(2.98E+01,cpUnit)
			Ideal_Gas_Heat_Capacity_Const_B = new BaseUnit(-7.01E-03,cpUnit/TemperatureUnit.SI)
			Ideal_Gas_Heat_Capacity_Const_C = new BaseUnit(1.74E-05,cpUnit/(TemperatureUnit.SI.pow(2)))
			Ideal_Gas_Heat_Capacity_Const_D = new BaseUnit(-8.48E-09,cpUnit/(TemperatureUnit.SI.pow(3)))
			Ideal_Gas_Heat_Capacity_Const_E = new BaseUnit(9.34E-13,cpUnit/(TemperatureUnit.SI.pow(4)))

			' here i create a refEnumerable, which is my eventual return type
			Dim refEnumerable As IEnumerable (Of BaseUnit)

			' however, when creating IEnumerables, it is almost always
			' easier to have a list
			' so here is a reference list of BaseUnits,
			' which i will then pass back to refEnumerable when done
			' and Console.WriteLine that
			Dim refList As List (Of BaseUnit)
			refList = new List (Of BaseUnit)

			refList.Add(Ideal_Gas_Heat_Capacity_Const_A)
			refList.Add(Ideal_Gas_Heat_Capacity_Const_B)
			refList.Add(Ideal_Gas_Heat_Capacity_Const_C)
			refList.Add(Ideal_Gas_Heat_Capacity_Const_D)
			refList.Add(Ideal_Gas_Heat_Capacity_Const_E)

			refEnumerable = refList

			Dim A As Double
			Dim B As Double
			Dim C As Double
			Dim D As Double
			Dim E As Double

			A = 2.98E+01
			B = -7.01E-03
			C = 1.74E-05
			D = -8.48E-09
			E = 9.34E-13
			' now we have our refList ready
			' we can then start working with our interface

			' for this i have constructor injection
			' i inject the convertCp function inside this class
			' to set the delegate there

			Dim engConvDelegate As EngineeringConversion
			engConvDelegate = new EngineeringConversion(AddressOf Me.convertCp)

			Dim engineeringConvEnumerable As IEngineeringConversionEnumerable
			Dim engineeringConvList As EngineeringConversionList
			engineeringConvList = new EngineeringConversionList()
			engineeringConvList.setDelegate(engConvDelegate)

			'' now we have instantiated the list

			engineeringConvList.Add(A)
			engineeringConvList.Add(B)
			engineeringConvList.Add(C)
			engineeringConvList.Add(D)
			engineeringConvList.Add(E)

			engineeringConvEnumerable = engineeringConvList

			Dim resultEnumerable As IEnumerable (Of BaseUnit)
			'' Act
			'
			resultEnumerable = engineeringConvEnumerable.getEnumerable()
			'' Assert

			Dim AreEnumerablesEqual As Boolean
			AreEnumerablesEqual = Enumerable.SequenceEqual(refEnumerable,resultEnumerable)

			Assert.True(AreEnumerablesEqual)

		End Sub


		'' this test is to see if the user injects a null value into the
		'setDelegate method
		' an  exception will be thrown if this happens
	    <Theory>
		<InlineData()>
		Sub TestIEngineeringConversionEnumerable_exceptionSetDelegate()

			Dim engineeringEnum As IEngineeringConversionEnumerable
			engineeringEnum = new EngineeringConversionlist()

			Dim A As Double
			Dim B As Double
			Dim C As Double
			Dim D As Double
			Dim E As Double

			A = 2.98E+01
			B = -7.01E-03
			C = 1.74E-05
			D = -8.48E-09
			E = 9.34E-13


			engineeringEnum.Add(A)
			engineeringEnum.Add(B)
			engineeringEnum.Add(C)
			engineeringEnum.Add(D)
			engineeringEnum.Add(E)

			Dim refErrorMsg As String
			refErrorMsg = "you need inject a proper EngineeringConversion "
			refErrorMsg += VbCrLf & "Delegate into EngineeringConversionList"

			Dim engConvDelegate As EngineeringConversion
			engConvDelegate = new EngineeringConversion(AddressOf Me.convertCp)
			engConvDelegate = Nothing

			Try 
				engineeringEnum.setDelegate(engConvDelegate)
				Catch ex As InvalidOperationException
				Assert.Equal(refErrorMsg, ex.Message)
			End Try


		End Sub

		' this next test is to check for the exception error message
		' if the user doesn't set the delegate and tries to convert the enumerable
		' a default exception is thrown
		' complaining that the user should use the setDelegate method
		' to set the conversion delegate before starting the conversion procedure
	    <Theory>
		<InlineData()>
		Sub TestIEngineeringConversionEnumerable_exceptionConstructorTest()

			Dim engineeringEnum As IEngineeringConversionEnumerable
			engineeringEnum = new EngineeringConversionlist()

			Dim A As Double
			Dim B As Double
			Dim C As Double
			Dim D As Double
			Dim E As Double

			A = 2.98E+01
			B = -7.01E-03
			C = 1.74E-05
			D = -8.48E-09
			E = 9.34E-13


			engineeringEnum.Add(A)
			engineeringEnum.Add(B)
			engineeringEnum.Add(C)
			engineeringEnum.Add(D)
			engineeringEnum.Add(E)

			Dim refErrorMsg As String
			refErrorMsg = "==== Invalid Operation Exception ==== "
			refErrorMsg += VbCrLf & "Please use the EngineeringConversionList.setDelegate Method"
			refErrorMsg += VbCrLf & "to set the way you want to convert the IEnumerable<Double> to IEnumerable<BaseUnit>" 

			Try 
				engineeringEnum.getEnumerable()
				Catch ex As InvalidOperationException
				Assert.Equal(refErrorMsg,ex.Message)
			End Try


		End Sub

	    '<Theory>
		<InlineData()>
		Sub TestIEngineeringConversionEnumerable_exceptionSandbox()

			' the IEngineeringConversionEnumerables implementations should give an exception
			' if one gives a rubbish method
			' As a delegate
			' or one forgets to inject the delegate in the first place
			'' setup

			Dim engineeringEnum As IEngineeringConversionEnumerable
			engineeringEnum = new EngineeringConversionlist()

			Dim A As Double
			Dim B As Double
			Dim C As Double
			Dim D As Double
			Dim E As Double

			A = 2.98E+01
			B = -7.01E-03
			C = 1.74E-05
			D = -8.48E-09
			E = 9.34E-13


			engineeringEnum.Add(A)
			engineeringEnum.Add(B)
			engineeringEnum.Add(C)
			engineeringEnum.Add(D)
			engineeringEnum.Add(E)

			Try 
				engineeringEnum.getEnumerable()
				Catch ex As InvalidOperationException
				Console.WriteLine(ex.Message)
			End Try


			Dim engConvDelegate As EngineeringConversion
			engConvDelegate = new EngineeringConversion(AddressOf Me.convertCp)
			engConvDelegate = Nothing

			Try 
				engineeringEnum.setDelegate(engConvDelegate)
				Catch ex As InvalidOperationException
				Console.WriteLine(ex.Message)
			End Try

			
			    


		End Sub

		<Theory>
		<InlineData()>
		Sub TestIEngineeringConversionEnumerable_ShouldConvert_constructorInjection()

			' Description:
			' In this test, i will make an IEnumerable Of BaseUnits Manually
			' First by making a List of Base Units
			'the units are as follows:
			''Cp = A + B*T + C*T^2 + D*T^3 + E*T^4 where Cp in kJ/kg-mol*K , T in K
			'
			
			'' Setup
			Dim Ideal_Gas_Heat_Capacity_Const_A As BaseUnit
			Dim Ideal_Gas_Heat_Capacity_Const_B As BaseUnit
			Dim Ideal_Gas_Heat_Capacity_Const_C As BaseUnit
			Dim Ideal_Gas_Heat_Capacity_Const_D As BaseUnit
			Dim Ideal_Gas_Heat_Capacity_Const_E As BaseUnit

			Dim cpUnit As UnitSystem
			cpUnit = (EnergyUnit.SI/AmountOfSubstanceUnit.SI/TemperatureUnit.SI)

			Ideal_Gas_Heat_Capacity_Const_A = new BaseUnit(2.98E+01,cpUnit)
			Ideal_Gas_Heat_Capacity_Const_B = new BaseUnit(-7.01E-03,cpUnit/TemperatureUnit.SI)
			Ideal_Gas_Heat_Capacity_Const_C = new BaseUnit(1.74E-05,cpUnit/(TemperatureUnit.SI.pow(2)))
			Ideal_Gas_Heat_Capacity_Const_D = new BaseUnit(-8.48E-09,cpUnit/(TemperatureUnit.SI.pow(3)))
			Ideal_Gas_Heat_Capacity_Const_E = new BaseUnit(9.34E-13,cpUnit/(TemperatureUnit.SI.pow(4)))

			' here i create a refEnumerable, which is my eventual return type
			Dim refEnumerable As IEnumerable (Of BaseUnit)

			' however, when creating IEnumerables, it is almost always
			' easier to have a list
			' so here is a reference list of BaseUnits,
			' which i will then pass back to refEnumerable when done
			' and Console.WriteLine that
			Dim refList As List (Of BaseUnit)
			refList = new List (Of BaseUnit)

			refList.Add(Ideal_Gas_Heat_Capacity_Const_A)
			refList.Add(Ideal_Gas_Heat_Capacity_Const_B)
			refList.Add(Ideal_Gas_Heat_Capacity_Const_C)
			refList.Add(Ideal_Gas_Heat_Capacity_Const_D)
			refList.Add(Ideal_Gas_Heat_Capacity_Const_E)

			refEnumerable = refList

			Dim A As Double
			Dim B As Double
			Dim C As Double
			Dim D As Double
			Dim E As Double

			A = 2.98E+01
			B = -7.01E-03
			C = 1.74E-05
			D = -8.48E-09
			E = 9.34E-13
			' now we have our refList ready
			' we can then start working with our interface

			' for this i have constructor injection
			' i inject the convertCp function inside this class
			' to set the delegate there

			Dim engConvDelegate As EngineeringConversion
			engConvDelegate = new EngineeringConversion(AddressOf Me.convertCp)

			Dim engineeringConvEnumerable As IEngineeringConversionEnumerable
			Dim engineeringConvList As EngineeringConversionList
			engineeringConvList = new EngineeringConversionList(engConvDelegate)

			'' now we have instantiated the list

			engineeringConvList.Add(A)
			engineeringConvList.Add(B)
			engineeringConvList.Add(C)
			engineeringConvList.Add(D)
			engineeringConvList.Add(E)

			engineeringConvEnumerable = engineeringConvList

			Dim resultEnumerable As IEnumerable (Of BaseUnit)
			'' Act
			'
			resultEnumerable = engineeringConvEnumerable.getEnumerable()
			'' Assert

			Dim AreEnumerablesEqual As Boolean
			AreEnumerablesEqual = Enumerable.SequenceEqual(refEnumerable,resultEnumerable)

			Assert.True(AreEnumerablesEqual)

		End Sub


	    '<Theory>
		<InlineData()>
		Sub TestIEngineeringEnumerableSandbox()

			' Description:
			' this is a sandbox for me to test all the methods
			' in dealing with lists
			
			'' Setup
			Dim Ideal_Gas_Heat_Capacity_Const_A As BaseUnit
			Dim Ideal_Gas_Heat_Capacity_Const_B As BaseUnit
			Dim Ideal_Gas_Heat_Capacity_Const_C As BaseUnit
			Dim Ideal_Gas_Heat_Capacity_Const_D As BaseUnit
			Dim Ideal_Gas_Heat_Capacity_Const_E As BaseUnit

			Dim cpUnit As UnitSystem
			cpUnit = (EnergyUnit.SI/AmountOfSubstanceUnit.SI/TemperatureUnit.SI)

			Ideal_Gas_Heat_Capacity_Const_A = new BaseUnit(2.98E+01,cpUnit)
			Ideal_Gas_Heat_Capacity_Const_B = new BaseUnit(-7.01E-03,cpUnit/TemperatureUnit.SI)
			Ideal_Gas_Heat_Capacity_Const_C = new BaseUnit(1.74E-05,cpUnit/(TemperatureUnit.SI.pow(2)))
			Ideal_Gas_Heat_Capacity_Const_D = new BaseUnit(-8.48E-09,cpUnit/(TemperatureUnit.SI.pow(3)))
			Ideal_Gas_Heat_Capacity_Const_E = new BaseUnit(9.34E-13,cpUnit/(TemperatureUnit.SI.pow(4)))

			' here i create a refEnumerable, which is my eventual return type
			Dim refEnumerable As IEnumerable (Of BaseUnit)

			' however, when creating IEnumerables, it is almost always
			' easier to have a list
			' so here is a reference list of BaseUnits,
			' which i will then pass back to refEnumerable when done
			' and Console.WriteLine that
			Dim refList As List (Of BaseUnit)
			refList = new List (Of BaseUnit)

			refList.Add(Ideal_Gas_Heat_Capacity_Const_A)
			refList.Add(Ideal_Gas_Heat_Capacity_Const_B)
			refList.Add(Ideal_Gas_Heat_Capacity_Const_C)
			refList.Add(Ideal_Gas_Heat_Capacity_Const_D)
			refList.Add(Ideal_Gas_Heat_Capacity_Const_E)

			refEnumerable = refList

			' now i just want to test how to access members within the list

			'For Each constant in refList
			'	Console.WriteLine(constant)
			'Next

			'For i As Integer = 0 To refList.Count - 1
			'	Console.WriteLine(refList(i))
			'Next


			Dim A As Double
			Dim B As Double
			Dim C As Double
			Dim D As Double
			Dim E As Double

			A = 2.98E+01
			B = -7.01E-03
			C = 1.74E-05
			D = -8.48E-09
			E = 9.34E-13
			' now we have our refList ready
			' we can then start working with our interface

			' for this i have constructor injection
			' i inject the convertCp function inside this class
			' to set the delegate there

			Dim engConvDelegate As EngineeringConversion
			engConvDelegate = new EngineeringConversion(AddressOf Me.convertCp)

			Dim engineeringConvEnumerable As IEngineeringConversionEnumerable
			Dim engineeringConvList As EngineeringConversionList
			engineeringConvList = new EngineeringConversionList(engConvDelegate)

			'' now we have instantiated the list

			engineeringConvList.Add(A)
			engineeringConvList.Add(B)
			engineeringConvList.Add(C)
			engineeringConvList.Add(D)
			engineeringConvList.Add(E)

			For Each item in engineeringConvList
				Console.WriteLine(item)
			Next

			engineeringConvEnumerable = engineeringConvList




			Dim resultEnumerable As IEnumerable (Of BaseUnit)
			'' Act
			'
			resultEnumerable = engineeringConvEnumerable.getEnumerable()
			'' Assert
			'
			For Each item in resultEnumerable
				Console.WriteLine(item)
			Next

			For Each item in refEnumerable
				Console.WriteLine(item)
			Next


			Dim AreEnumerablesEqual As Boolean
			AreEnumerablesEqual = Enumerable.SequenceEqual(refEnumerable,resultEnumerable)

			Assert.True(AreEnumerablesEqual)
		End Sub


		'' here is the function i will use as the 
		' function delegate for heat capacity
		Private Function convertCp(ByVal quantityEnumerable As IEnumerable (Of Double)) As IEnumerable (Of BaseUnit)

			' first i set my unit systems
			Dim cpUnit As UnitSystem
			cpUnit = (EnergyUnit.SI/AmountOfSubstanceUnit.SI/TemperatureUnit.SI)

			Dim constantUnit As UnitSystem
			Dim constantQuantity As BaseUnit

			' next thing i do, is to instantiate a list
			Dim heatCapacityConstList As List (Of BaseUnit)
			heatCapacityConstList = new List (Of BaseUnit)


			'	Next I initiate the for loop to return the list

			For i As Integer = 0 To quantityEnumerable.Count - 1
				constantUnit = cpUnit/TemperatureUnit.SI.pow(i)
				constantQuantity = new BaseUnit(quantityEnumerable(i),constantUnit)
								
				heatCapacityConstList.Add(constantQuantity)

				constantUnit = Nothing
				constantQuantity = Nothing
			Next

			return heatCapacityConstList

		End Function


		<Theory>
		<InlineData()>
		Sub BaseUnit_ComparisonTest()

			'' this test checks if two base unit types can be 
			' compared to each other using Assert.Equal
			Dim t1 As BaseUnit
			Dim t2 As BaseUnit

			t1 = new Temperature(0,TemperatureUnit.DegreeCelsius)
			t2  = new Temperature(0,TemperatureUnit.DegreeCelsius)

			Assert.Equal(t1,t2)

			'' this seems to work well!
		End Sub



		'<Theory>
		<InlineData()>
		Sub TestIEngineeringConversion_ManualEngineeringUnitsTest()

			'' this is testing the new engineeringunits stuff
			Dim roomTemp As Temperature
			roomTemp = new Temperature(293, TemperatureUnit.Kelvin)
			Console.WriteLine(roomTemp)


			'' now i want to test specific energy
			Dim heatValue As SpecificEnergy
			heatValue = new SpecificEnergy(200, SpecificEnergyUnit.JoulePerKilogram)

			Console.WriteLine(heatValue)

			'' now, the thing is heat capacity is not included
			' but technically i don't need to make a new unit
			' i can just perform calculations like that
			' or so i thought, i'm getting wrong units
			' i need to Dim this As an object, let's see what the type is

			Dim heatCapacity As Object
			heatCapacity = heatValue/roomTemp
			Console.WriteLine(heatCapacity)
			Console.WriteLine(heatCapacity.GetType)


			'' now let's try to get back specific energy
			'
			
			Dim resultEnergy As Object
			resultEnergy = heatCapacity*roomTemp
			Console.WriteLine(resultEnergy)
			UnknownUnitExtensions.IntelligentCast(resultEnergy)
			Console.WriteLine(resultEnergy.GetType)


			'' test ToString
		    Console.WriteLine(resultEnergy.ToString())
			Console.WriteLIne(heatValue.ToString())


			'' test the Unit of each type
			Console.WriteLine(resultEnergy.Unit)
			Console.WriteLine(heatValue.Unit)
			
			'Dim sum As Object
			'sum = resultEnergy + heatValue
			'Console.WriteLine(sum)

			' this is the unitCheck method for two quantities
			BaseUnit.UnitCheck(resultEnergy,heatValue)
			Try 
			    BaseUnit.UnitCheck(roomTemp,resultEnergy)
			Catch ex As WrongUnitException

			    Console.WriteLine(ex.Message)

		    End Try


			' i want to check if we can typecast base unit as unknown unit
			Dim quantity As UnknownUnit
			quantity = heatValue
			Console.WriteLine(quantity.GetType)
			Console.WriteLine(quantity.Unit)
			Console.WriteLine(quantity.ToString())

			' can you do math with unknown units? yes
			' but you cannot do Console writeline
			' until you convert it to a double manually
			Dim quantity2 As UnknownUnit
			quantity2 = quantity*quantity
			quantity2 = quantity+quantity
			Console.WriteLine(" ")
			Console.WriteLine(quantity2.ToString())
			Console.WriteLine(quantity2.GetType)

			'' i get exceptions if i print UnknownUnit types directly
			' that is a norm
			Try 
			    Console.WriteLine(quantity2)
			Catch ex As exception
				Console.WriteLine("this is that happens if you try to print
				Unknown Quantities")
			    Console.WriteLine(ex.Message)
				Console.WriteLine()
			End Try
			
			'' perhaps the correct way to typecast is this:
			Dim quantity3 As SpecificEnergy
			quantity3 = quantity2 + heatValue
			Console.WriteLine(quantity3)
			Console.WriteLine(quantity3.GetType)

			'' during the typecast, all the checks will be performed

			' to get the value, use the As command and specify the units
			' you want to use
			' you will just get a double
			Console.WriteLine(quantity.As(SpecificEnergyUnit.SI))

			' so we can typecast any unit as an unknown unit but not in reverse
			' what i meant is that it's not so simple to typecast in reverse

			' so i guess the algorithm is this,
			
			' first check the units
			' there should be no error if this is okay
			BaseUnit.UnitCheck(heatValue,quantity)
			
			Dim quantityValue As Double
			quantityValue = quantity.As(SpecificEnergyUnit.JoulePerKilogram)

			resultEnergy = new SpecificEnergy(quantityValue,SpecificEnergyUnit.JoulePerKilogram)
			'' result energy will become a double
			Console.WriteLine(resultEnergy)
			Console.WriteLine(resultEnergy.GetType)


			
	


			Assert.Equal(heatValue.ToString(),resultEnergy.ToString())



		End Sub

	    '<Fact>
		Sub IXmlLibrarySelector_executeMoreThanOnceTest()

			
			Dim resultLib As IXmlLibLoader


			Dim xmlLibrarySelector As IXmlLibrarySelector
			xmlLibrarySelector = new XmlLibSelector_may2022

			resultLib = xmlLibrarySelector.getXmlLibLoader("dwsIm")
			resultLib = xmlLibrarySelector.getXmlLibLoader("dwsIm")
			resultLib = xmlLibrarySelector.getXmlLibLoader("dwsIm")

			xmlLibrarySelector = Nothing

		End Sub







	    '<Fact> 
		Sub IXmlLibrarySelector_ExceptionTest()

	    End Sub

        '<Fact>
        Sub IXmlLibrarySelector_ShouldLoadDWSimLibrary()

		End Sub


    End Class

End Namespace

