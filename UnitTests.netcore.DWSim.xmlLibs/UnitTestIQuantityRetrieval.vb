Imports System
Imports Xunit
Imports theoOng.netcore.DWSim.xmlLibs

Imports EngineeringUnits
Imports EngineeringUnits.Units

Namespace UnitTests.netcore.DWSim.xmlLibs

    Public Class UnitTestIQuantityRetrieval

		<Theory>
		<InlineData()>
		Sub IQuantityRetrieval_Sandbox()

			' first the user should 
			' inject the library into IQuantityRetrieval
			' there will be a function checking out what library it is
			' when the library is checked
			'then i will return a List of Properties that can be returned
			' then when returnQuantityList is called
			' i will then check the desired quantity against the string of properties
			'  available
			
			' and based on that string of properties, start creating an engineeringConversionEnumerable object
			' and add create a list one by one
			' i can use IXmlHumanReadablePropertyList to check what properties
			' are available 
			' i can use IXmlPropertyList to categorize the human readable properties
			' or rather just combine them both into one
			' and provide the appropriate return types
			

			' 


			
		End Sub


		Function getPropertyList() As IEnumerable (Of (propertyName As String, attachedList As IEnumerable (Of String)))

			Dim tupleToAdd As (propertyName As String, attachedList As IEnumerable (Of String))
			Dim propertyList As IList (Of (propertyName As String, attachedList As IEnumerable (Of String)))

			propertyList = new List (Of (propertyName As String, attachedList As IEnumerable (Of String)))

			Dim propertyName As String
			Dim attachedList As IList(Of String)
			attachedList = new List(Of String)

			'' first let's have the name category

			propertyName = "Name"

			attachedList.Add("Name")
			attachedList.Add("CAS_Number")
			attachedList.Add("ID")
			attachedList.Add("COSMODBName")

			tupleToAdd = (propertyName, attachedList)
			propertyList.Add(tupleToAdd)


			propertyName = "criticalProperties"
'    <Critical_Temperature>190.564</Critical_Temperature>
'    <Critical_Pressure>4599000</Critical_Pressure>
'    <Critical_Volume>0.0986</Critical_Volume>
'    <Critical_Compressibility>0.286</Critical_Compressibility>


'    <Formula>CH4</Formula>
'    <Molar_Weight>16.043</Molar_Weight>
			propertyName = "criticalProperties"
'    <Critical_Temperature>190.564</Critical_Temperature>
'    <Critical_Pressure>4599000</Critical_Pressure>
'    <Critical_Volume>0.0986</Critical_Volume>
'    <Critical_Compressibility>0.286</Critical_Compressibility>
'    <Acentric_Factor>0.01155</Acentric_Factor>
'    <Z_Rackett>2.89E-01</Z_Rackett>
'    <PR_Volume_Translation_Coefficient>-0.1595</PR_Volume_Translation_Coefficient>
'    <SRK_Volume_Translation_Coefficient>0.0234</SRK_Volume_Translation_Coefficient>
propertyName = "chaoSeaderProperties"
'    <CS_Acentric_Factor>0</CS_Acentric_Factor>
'    <CS_Solubility_Parameter>5.68</CS_Solubility_Parameter>
'    <CS_Liquid_Molar_Volume>52</CS_Liquid_Molar_Volume>
propertyName = "formationProperties"
'    <IG_Entropy_of_Formation_25C>2.58324</IG_Entropy_of_Formation_25C>
'    <IG_Enthalpy_of_Formation_25C>-4645.1</IG_Enthalpy_of_Formation_25C>
'    <IG_Gibbs_Energy_of_Formation_25C>-3147.21</IG_Gibbs_Energy_of_Formation_25C>
'    <Dipole_Moment>0</Dipole_Moment>
propertyName = "vaporPressure"
'    <DIPPR_Vapor_Pressure_Constant_A>39.205</DIPPR_Vapor_Pressure_Constant_A>
'    <DIPPR_Vapor_Pressure_Constant_B>-1324.4</DIPPR_Vapor_Pressure_Constant_B>
'    <DIPPR_Vapor_Pressure_Constant_C>-3.44</DIPPR_Vapor_Pressure_Constant_C>
'    <DIPPR_Vapor_Pressure_Constant_D>3.10E-05</DIPPR_Vapor_Pressure_Constant_D>
'    <DIPPR_Vapor_Pressure_Constant_E>2</DIPPR_Vapor_Pressure_Constant_E>
'    <DIPPR_Vapor_Pressure_TMIN>90.64</DIPPR_Vapor_Pressure_TMIN>
'    <DIPPR_Vapor_Pressure_TMAX>190.56</DIPPR_Vapor_Pressure_TMAX>
propertyName = "heatCapacity"
'    <Ideal_Gas_Heat_Capacity_Const_A>3.62E+01</Ideal_Gas_Heat_Capacity_Const_A>
'    <Ideal_Gas_Heat_Capacity_Const_B>-5.11E-02</Ideal_Gas_Heat_Capacity_Const_B>
'    <Ideal_Gas_Heat_Capacity_Const_C>2.21E-04</Ideal_Gas_Heat_Capacity_Const_C>
'    <Ideal_Gas_Heat_Capacity_Const_D>-1.82E-07</Ideal_Gas_Heat_Capacity_Const_D>
'    <Ideal_Gas_Heat_Capacity_Const_E>4.89E-11</Ideal_Gas_Heat_Capacity_Const_E>
propertyName = "liquidViscosity"
'    <Liquid_Viscosity_Const_A>-61.572</Liquid_Viscosity_Const_A>
'    <Liquid_Viscosity_Const_B>178.15</Liquid_Viscosity_Const_B>
'    <Liquid_Viscosity_Const_C>-0.95239</Liquid_Viscosity_Const_C>
'    <Liquid_Viscosity_Const_D>-9.06E-24</Liquid_Viscosity_Const_D>
'    <Liquid_Viscosity_Const_E>10</Liquid_Viscosity_Const_E>
propertyName = "boilingPoint"
'    <Normal_Boiling_Point>111.66</Normal_Boiling_Point>
'    <isPf>0</isPf>
'    <isHYP>0</isHYP>
propertyName = "Hvap"
'    <HVapA>10194000</HVapA>
'    <HVapB>0.26087</HVapB>
'    <HvapC>-0.14694</HvapC>
'    <HVapD>0.22154</HVapD>
'    <HvapTmin>90</HvapTmin>
'    <HvapTMAX>190</HvapTMAX>
propertyName = "UNIQUAC"
'    <UNIQUAC_r>1.1239</UNIQUAC_r>
'    <UNIQUAC_q>1.152</UNIQUAC_q>
'    <UNIFAC>
'      <group name="CH4">1</group>
'    </UNIFAC>
'    <elements>
'      <element name="C">1</element>
'      <element name="H">4</element>
'    </elements>
'




		End Function




	    '<Theory>
		<InlineData()>
		Sub IXmlReader_IEnumerableTest()

			' Description:
			' In this test, i will make an IEnumerable Of BaseUnits Manually
			' First by making a List of Base Units
			' then manually fitting them into the IEnumerable
			' First i need to know how to compare two base unit types
			'
			' In the BaseUnit_ComparisonTest, i have seen that 
			' comparing two differently instantiated objects of temperature
			' using Assert.Equal is ok!
			'
			'
			' So okay, i want to make a comparison of the heat capacity constants
			' of air and their units
			'
			' Well closest thing is nitrogen, 
			' so let me get nitrogen
			'
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

			For Each quantity in refEnumerable
				Console.WriteLine(quantity)
			Next

			' now we have our refList ready
			' we can then start working with our interface

			Dim xmlReader As IXmlReader
			' please declare new object here, and do proper Dependency Injection

			' here are our dependencies
			Dim xmlLibrarySelector As IXmlLibrarySelector
			xmlLibrarySelector = new XmlLibSelector_may2022

			' now we instantiate class with proper dependency injection
			xmlReader = new DWSimXmlReader(xmlLibrarySelector)

			Dim resultEnumerable As IEnumerable (Of BaseUnit)
			'' Act
			resultEnumerable = xmlReader.getQuantityList("nitrogen","heatCapacityConstants")
			'' Assert

			Dim AreEnumerablesEqual As Boolean
			AreEnumerablesEqual = Enumerable.SequenceEqual(refEnumerable,resultEnumerable)

			Assert.True(AreEnumerablesEqual)
		End Sub


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
			Console.WriteLIne(freezingPointWater.ToUnit(TemperatureUnit.DegreeRankine))
			Console.WriteLine(freezingPointWater)
			
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

			Cp = Nothing
			Console.WriteLIne(Cp)

			'' now we can start calculating
			'
			Dim T1 As Temperature
			T1 = new Temperature(373, TemperatureUnit.SI)
			Console.WriteLine(T1)

			Cp = A + B*T1 +C*T1.pow(2) + D*T1.pow(3) + E*T1.pow(4)

			Console.WriteLine(Cp)


			'' purposely try wrong units

			Try
				Cp = A + B*T1 +C*T1.pow(1) + D*T1.pow(3) + E*T1.pow(4)
			Catch ex As Exception
			    Console.WriteLine(ex.Message)
			End Try

			'' trying to work with unknown units
			Dim Cp2 As Object
			Cp2 = A+B*T1
			Console.WriteLine(Cp2.GetType)
			
			Dim Cp3 As Object
			Cp3 = Cp2 + Cp2
			Cp3 = Cp2*3
			Console.WriteLine(Cp3)
			Console.WriteLine(Cp3.GetType)

			'' you can check units with unknown units
			BaseUnit.UnitCheck(Cp3,Cp)

			Try 
			    BaseUnit.UnitCheck(Cp3,T1)
			Catch ex As Exception
				Console.WriteLine(ex.Message)
			End Try


			'' testing unknown units with combined units
			Dim heatValue As SpecificEnergy
			heatValue = new SpecificEnergy(100,SpecificEnergyUnit.SI)
			Console.WriteLine(heatValue)

			Dim cp4 As Object

			cp4 = heatValue/T1
			Console.WriteLine(cp4)
			Console.WriteLine(cp4.GetType)
			Console.WriteLine(cp4.unit)
			Console.WriteLine(cp4.unit.GetType)
			Console.WriteLine(cp4.Value)
			Console.WriteLine(cp4.Value.GetType)

			Dim cp4Value As Double
			cp4Value = cp4.Value

			Dim cp4Unit As UnitSystem
			cp4Unit = cp4.unit


			'''''''''''''''''''''''''''''''''''''''''''''''
			'' this is a code block to help typecast unknown units to
			' known units
			'' check units
			Dim unit4 As SpecificHeat
			unit4 = new SpecificHeat(0,SpecificEntropyUnit.SI)

			BaseUnit.UnitCheck(cp4,unit4)


			'' converting unknown unit types to BaseUnit/CombinedUnit

			'' use existing SpecificEntropyUnit when working with Specific Entropy
			' using base units here will result in error!
			Dim unit5 As BaseUnit
			unit5 = new SpecificHeat(cp4Value,SpecificEntropyUnit.JoulePerKilogramKelvin) 
			
			'' use a new UnitSystem when working with BaseUnit
			' using some combined units here may result in error
			Dim unit5Unit As UnitSystem
			unit5Unit = EnergyUnit.SI/MassUnit.SI/TemperatureUnit.SI

			unit5 = new BaseUnit(cp4Value,unit5Unit)


			Console.WriteLine(unit5)
			Console.WriteLine(unit5.GetType)

			'' we test the function to help us typecast a base unit

			Dim testUnitObj As BaseUnit
			testUnitObj = Me.typeCastUnknownUnit(cp4,unit5Unit)
			Console.WriteLine(testUnitObj)
			Console.WriteLine(testUnitObj)

			'' It is better to work with base units
			' rather than typecast an object as an unknown unit and try
			' typecasting it to a base unit


			Console.WriteLine(cp4.GetType)
			Console.WriteLine(unit5.GetType)

			' this is okay
			' meaning assign the calculated value to a base unit straightaway
			unit5 = heatValue/T1
			cp4 = heatValue/T1

			'' this is not okay
			' meaning if a type is already an unknown unit object
			' casting it to a base unit is problematic

			Try
			    unit5 =cp4

			Catch ex As Exception
				Console.WriteLine(ex.Message)

			End Try


			'' i want to check if assigning a known unit as base unit is ok
			
			unit5 = T1
			Console.WriteLine(unit5.GetType)
			Console.WriteLine(unit5)

			Dim unitbase6 As BaseUnit

			'' this does not even compile right
			'' 
			''unitbase6 = new BaseUnit(10, TemperatureUnit.SI)
			' however, if the base unit is some new quantity, this is OK
			unitbase6 = new BaseUnit(10, TemperatureUnit.SI.pow(4))




		End Sub


		Public Function typeCastUnknownUnit(x As UnknownUnit,desiredUnits As UnitSystem) As BaseUnit

			'' check whether unknownUnit x has the same units as the desired Units
			Dim unitCheckObject As BaseUnit
			unitCheckObject = new BaseUnit(0,desiredUnits)
			BaseUnit.UnitCheck(unitCheckObject, x)

			' if this checks out, i mean units check out
			' i will then make a new baseunit object
			' use UnkownUnit.SI to extract the decimal value
			dim xValue As Double
			xValue = x.SI

			return new BaseUnit(xValue,desiredUnits)

		End Function


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







    End Class

End Namespace

