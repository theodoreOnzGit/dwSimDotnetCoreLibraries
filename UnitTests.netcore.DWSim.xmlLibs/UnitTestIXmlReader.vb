Imports System
Imports Xunit
Imports theoOng.netcore.DWSim.xmlLibs

Imports EngineeringUnits
Imports EngineeringUnits.Units

Namespace UnitTests.netcore.DWSim.xmlLibs

    Public Class UnitTestIXmlReader


	    <Theory>
		<InlineData()>
		Sub youtubeDemo_engineeringUnits()
			Dim freezingPointWater As Temperature

			freezingPointWater = new Temperature(0,TemperatureUnit.DegreeCelsius)
			freezingPointWater = new Temperature(273.15, TemperatureUnit.SI)
			freezingPointWater = new Temperature(273.15, TemperatureUnit.Kelvin)

			Console.WriteLine(freezingPointWater)

			Dim freezingPointF As Double
			freezingPointF = freezingPointWater.As(TemperatureUnit.DegreeFahrenheit)
			Console.WriteLine(freezingPointF)

			freezingPointWater = new Temperature(freezingPointF, TemperatureUnit.DegreeFahrenheit)

			Console.WriteLine(freezingPointWater)
			Console.WriteLine(freezingPointWater.ToString())
			
			'' more complicated example, ideal gas heat capacity
			''Cp = A + B*T + C*T^2 + D*T^3 + E*T^4 where Cp in kJ/kg-mol*K , T in K


			Dim cpUnit As UnitSystem
			cpUnit = (EnergyUnit.Kilojoule/AmountOfSubstanceUnit.Kilomole/TemperatureUnit.SI)
			Console.WriteLine(cpUnit)
			cpUnit = (EnergyUnit.SI/AmountOfSubstanceUnit.SI/TemperatureUnit.SI)
			Console.WriteLine(cpUnit)
			Console.WriteLine(EnergyUnit.SI)
			Console.WriteLine(EnergyUnit.Kilojoule)

			'' molar heat capacity with units
			' J/mol/K
			Dim Cp As BaseUnit
			Cp = new BaseUnit(200,cpUnit)
			Console.WriteLine(Cp)
			Console.WriteLine(Cp.unit)

			Dim A As BaseUnit
			A = new BaseUnit(10,cpUnit)
			Console.WriteLine(A)

			Dim B As BaseUnit
			B = new BaseUnit(30,Cp.unit/TemperatureUnit.SI)
			Console.WriteLine(B)

			Dim E As BaseUnit
			E = new BaseUnit(50,Cp.unit/(TemperatureUnit.SI.pow(4)))
			Console.WriteLine(E)


			Dim C As BaseUnit
			C = new BaseUnit(-4,Cp.unit/(TemperatureUnit.SI.pow(2)))
			Console.WriteLine(C)

			Dim D As BaseUnit
			D = new BaseUnit(5,Cp.unit/(TemperatureUnit.SI.pow(3)))
			Console.WriteLine(D)


		End Sub


		'<Theory>
		<InlineData()>
		Sub TestIXmlReader_ManualEngineeringUnitsTest()

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
		
			'' Setup

			Dim xmlLibrarySelector As IXmlLibrarySelector
			xmlLibrarySelector = new XmlLibSelector_may2022

			'' Act
			'' Assert
			' credit to: https://groups.google.com/g/nunit-discuss/c/STiMNTVxoPE
			Assert.Throws(Of IndexOutOfRangeException)(Sub() xmlLibrarySelector.getXmlLibLoader("gibberish"))

	    End Sub

        '<Fact>
        Sub IXmlLibrarySelector_ShouldLoadDWSimLibrary()

			'' Setup

			Dim refLib As IXmlLibLoader
			refLib = new dwSimXmlLibBruteForce

			Dim xmlLibrarySelector As IXmlLibrarySelector
			xmlLibrarySelector = new XmlLibSelector_may2022

			Dim resultLib As IXmlLibLoader
			'' Act

			resultLib = xmlLibrarySelector.getXmlLibLoader("dwsIm")
			'' Assert
			'
			'Console.WriteLine(refLib)
			'Console.WriteLine(resultLib)
			Assert.Equal(refLib.GetType,resultLib.GetType)
		End Sub


    End Class

End Namespace

