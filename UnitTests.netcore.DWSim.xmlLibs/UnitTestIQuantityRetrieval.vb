Imports System
Imports Xunit
Imports theoOng.netcore.DWSim.xmlLibs

Imports EngineeringUnits
Imports EngineeringUnits.Units

Imports Xunit.Abstractions
Namespace UnitTests.netcore.DWSim.xmlLibs

    Public Class UnitTestIQuantityRetrieval

	Inherits testOutputHelper

		Public Sub New(outputHelper As ITestOutputHelper)
			MyBase.New(outputHelper)
		End Sub

		<Theory>
		<InlineData()>
		Sub IQuantityRetrieval_sandbox_IEngineeringEnumerableComparison()


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

			'' Setup
			'' (1) create object
			Dim testObjectXmlQuantityRetrieval As IXmlQuantityRetrieval
			testObjectXmlQuantityRetrieval = new dwSimXmlQuantityRetrieval(new dwSimXmlHumanReadablePropertyList_May2022, new dwSimXmlLibBruteForce)

			testObjectXmlQuantityRetrieval.injectLib(new dwSimXmlLibBruteForce)

			Dim refEnumerable As IEngineeringConversionEnumerable
			refEnumerable = new EngineeringConversionList()

			Dim conversionDelegate As EngineeringConversion
			conversionDelegate = new EngineeringConversion(AddressOf Me.convertCp)

			' now set the delegate for refEnumerable
			refEnumerable.setDelegate(conversionDelegate)

			'' this is nitrogen heat capacity constants A to E
			' From DWsim.xml
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

			refEnumerable.Add(A)
			refEnumerable.Add(B)
			refEnumerable.Add(C)
			refEnumerable.Add(D)
			refEnumerable.Add(E)


			Dim resultEnumerable As IEngineeringConversionEnumerable


			''Act
			'

			resultEnumerable = testObjectXmlQuantityRetrieval.returnEngineeringEnumerable("heatCapacity")

			'' print
			For Each item in refEnumerable
				Me.cout(item)
			Next
			For Each item in resultEnumerable
				Me.cout(item)
			Next

			' assert
			'' (2) 
			
			Dim areenumerablesequal As Boolean
			areenumerablesequal = Enumerable.Sequenceequal(Of Double)(refenumerable,resultenumerable)

			Assert.True(areenumerablesequal)
		End Sub

		<Theory>
		<InlineData()>
		Sub IQuantityRetrieval_sandbox_IEnumerableComparison()


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

			'' Setup
			'' (1) create object
			Dim testObjectXmlQuantityRetrieval As IXmlQuantityRetrieval
			testObjectXmlQuantityRetrieval = new dwSimXmlQuantityRetrieval(new dwSimXmlHumanReadablePropertyList_May2022, new dwSimXmlLibBruteForce)

			testObjectXmlQuantityRetrieval.injectLib(new dwSimXmlLibBruteForce)

			Dim refList As IEngineeringConversionEnumerable
			refList = new EngineeringConversionList()

			Dim conversionDelegate As EngineeringConversion
			conversionDelegate = new EngineeringConversion(AddressOf Me.convertCp)

			' now set the delegate for refEnumerable
			refList.setDelegate(conversionDelegate)

			'' this is nitrogen heat capacity constants A to E
			' From DWsim.xml
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

			refList.Add(A)
			refList.Add(B)
			refList.Add(C)
			refList.Add(D)
			refList.Add(E)


			Dim resultEnumerable As IEnumerable(Of Double)


			''Act
			'

			resultEnumerable = testObjectXmlQuantityRetrieval.returnQuantityList("heatCapacity")

			'' print
			Dim refEnumerable As IEnumerable(Of Double)
			refEnumerable = refList
			For Each item in refList
				Me.cout(item)
			Next
			For Each item in resultEnumerable
				Me.cout(item)
			Next

			' assert
			'' (2) 
			
			Dim areenumerablesequal As Boolean
			areenumerablesequal = Enumerable.Sequenceequal(Of Double)(refenumerable,resultenumerable)

			Assert.True(areenumerablesequal)
		End Sub


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

	    '<theory>
		<inlinedata()>
		Sub ixmlreader_ienumerabletest()

			' description:
			' in this test, i will make an ienumerable of baseunits manually
			' first by making a list of base units
			' then manually fitting them into the ienumerable
			' first i need to know how to compare two base unit types
			'
			' in the baseunit_comparisontest, i have seen that 
			' comparing two differently instantiated objects of temperature
			' using assert.equal is ok!
			'
			'
			' so okay, i want to make a comparison of the heat capacity constants
			' of air and their units
			'
			' well closest thing is nitrogen, 
			' so let me get nitrogen
			'
			'the units are as follows:
			''cp = a + b*t + c*t^2 + d*t^3 + e*t^4 where cp in kj/kg-mol*k , t in k
			'
			
			'' setup
			dim ideal_gas_heat_capacity_const_a as baseunit
			dim ideal_gas_heat_capacity_const_b as baseunit
			dim ideal_gas_heat_capacity_const_c as baseunit
			dim ideal_gas_heat_capacity_const_d as baseunit
			dim ideal_gas_heat_capacity_const_e as baseunit

			dim cpunit as unitsystem
			cpunit = (energyunit.si/amountofsubstanceunit.si/temperatureunit.si)

			ideal_gas_heat_capacity_const_a = new baseunit(2.98e+01,cpunit)
			ideal_gas_heat_capacity_const_b = new baseunit(-7.01e-03,cpunit/temperatureunit.si)
			ideal_gas_heat_capacity_const_c = new baseunit(1.74e-05,cpunit/(temperatureunit.si.pow(2)))
			ideal_gas_heat_capacity_const_d = new baseunit(-8.48e-09,cpunit/(temperatureunit.si.pow(3)))
			ideal_gas_heat_capacity_const_e = new baseunit(9.34e-13,cpunit/(temperatureunit.si.pow(4)))

			' here i create a refenumerable, which is my eventual return type
			dim refenumerable as ienumerable (of baseunit)

			' however, when creating ienumerables, it is almost always
			' easier to have a list
			' so here is a reference list of baseunits,
			' which i will then pass back to refenumerable when done
			' and console.writeline that
			dim reflist as list (of baseunit)
			reflist = new list (of baseunit)

			reflist.add(ideal_gas_heat_capacity_const_a)
			reflist.add(ideal_gas_heat_capacity_const_b)
			reflist.add(ideal_gas_heat_capacity_const_c)
			reflist.add(ideal_gas_heat_capacity_const_d)
			reflist.add(ideal_gas_heat_capacity_const_e)

			refenumerable = reflist

			for each quantity in refenumerable
				console.writeline(quantity)
			next

			' now we have our reflist ready
			' we can then start working with our interface

			dim xmlreader as ixmlreader
			' please declare new object here, and do proper dependency injection

			' here are our dependencies
			dim xmllibraryselector as ixmllibraryselector
			xmllibraryselector = new xmllibselector_may2022

			' now we instantiate class with proper dependency injection
			xmlreader = new dwsimxmlreader(xmllibraryselector)

			dim resultenumerable as ienumerable (of baseunit)
			'' act
			resultenumerable = xmlreader.getquantitylist("nitrogen","heatcapacityconstants")
			'' assert

			dim areenumerablesequal as boolean
			areenumerablesequal = enumerable.sequenceequal(refenumerable,resultenumerable)

			assert.true(areenumerablesequal)
		end sub


		<theory>
		<inlinedata()>
		sub baseunit_comparisontest()

			'' this test checks if two base unit types can be 
			' compared to each other using assert.equal
			dim t1 as baseunit
			dim t2 as baseunit

			t1 = new temperature(0,temperatureunit.degreecelsius)
			t2  = new temperature(0,temperatureunit.degreecelsius)

			assert.equal(t1,t2)

			'' this seems to work well!
		end sub

	    '<theory>
		<inlinedata()>
		sub youtubedemo_engineeringunits()
			dim freezingpointwater as temperature

			freezingpointwater = new temperature(0,temperatureunit.degreecelsius)
			freezingpointwater = new temperature(273.15, temperatureunit.si)
			freezingpointwater = new temperature(273.15, temperatureunit.kelvin)

			console.writeline(freezingpointwater)

			dim freezingpointf as double
			freezingpointf = freezingpointwater.as(temperatureunit.degreefahrenheit)
			console.writeline(freezingpointf)

			freezingpointwater = new temperature(freezingpointf, temperatureunit.degreefahrenheit)

			console.writeline(freezingpointwater)
			console.writeline(freezingpointwater.tostring())
			console.writeline(freezingpointwater.tounit(temperatureunit.degreerankine))
			console.writeline(freezingpointwater)
			
			'' more complicated example, ideal gas heat capacity
			''cp = a + b*t + c*t^2 + d*t^3 + e*t^4 where cp in kj/kg-mol*k , t in k


			dim cpunit as unitsystem
			cpunit = (energyunit.kilojoule/amountofsubstanceunit.kilomole/temperatureunit.si)
			console.writeline(cpunit)
			cpunit = (energyunit.si/amountofsubstanceunit.si/temperatureunit.si)
			console.writeline(cpunit)
			console.writeline(energyunit.si)
			console.writeline(energyunit.kilojoule)

			'' molar heat capacity with units
			' j/mol/k
			dim cp as baseunit
			cp = new baseunit(200,cpunit)
			console.writeline(cp)
			console.writeline(cp.unit)

			dim a as baseunit
			a = new baseunit(10,cpunit)
			console.writeline(a)

			dim b as baseunit
			b = new baseunit(30,cp.unit/temperatureunit.si)
			console.writeline(b)

			dim e as baseunit
			e = new baseunit(50,cp.unit/(temperatureunit.si.pow(4)))
			console.writeline(e)


			dim c as baseunit
			c = new baseunit(-4,cp.unit/(temperatureunit.si.pow(2)))
			console.writeline(c)

			dim d as baseunit
			d = new baseunit(5,cp.unit/(temperatureunit.si.pow(3)))
			console.writeline(d)

			cp = nothing
			console.writeline(cp)

			'' now we can start calculating
			'
			dim t1 as temperature
			t1 = new temperature(373, temperatureunit.si)
			console.writeline(t1)

			cp = a + b*t1 +c*t1.pow(2) + d*t1.pow(3) + e*t1.pow(4)

			console.writeline(cp)


			'' purposely try wrong units

			try
				cp = a + b*t1 +c*t1.pow(1) + d*t1.pow(3) + e*t1.pow(4)
			catch ex as exception
			    console.writeline(ex.message)
			end try

			'' trying to work with unknown units
			dim cp2 as object
			cp2 = a+b*t1
			console.writeline(cp2.gettype)
			
			dim cp3 as object
			cp3 = cp2 + cp2
			cp3 = cp2*3
			console.writeline(cp3)
			console.writeline(cp3.gettype)

			'' you can check units with unknown units
			baseunit.unitcheck(cp3,cp)

			try 
			    baseunit.unitcheck(cp3,t1)
			catch ex as exception
				console.writeline(ex.message)
			end try


			'' testing unknown units with combined units
			dim heatvalue as specificenergy
			heatvalue = new specificenergy(100,specificenergyunit.si)
			console.writeline(heatvalue)

			dim cp4 as object

			cp4 = heatvalue/t1
			console.writeline(cp4)
			console.writeline(cp4.gettype)
			console.writeline(cp4.unit)
			console.writeline(cp4.unit.gettype)
			console.writeline(cp4.value)
			console.writeline(cp4.value.gettype)

			dim cp4value as double
			cp4value = cp4.value

			dim cp4unit as unitsystem
			cp4unit = cp4.unit


			'''''''''''''''''''''''''''''''''''''''''''''''
			'' this is a code block to help typecast unknown units to
			' known units
			'' check units
			dim unit4 as specificheat
			unit4 = new specificheat(0,specificentropyunit.si)

			baseunit.unitcheck(cp4,unit4)


			'' converting unknown unit types to baseunit/combinedunit

			'' use existing specificentropyunit when working with specific entropy
			' using base units here will result in error!
			dim unit5 as baseunit
			unit5 = new specificheat(cp4value,specificentropyunit.jouleperkilogramkelvin) 
			
			'' use a new unitsystem when working with baseunit
			' using some combined units here may result in error
			dim unit5unit as unitsystem
			unit5unit = energyunit.si/massunit.si/temperatureunit.si

			unit5 = new baseunit(cp4value,unit5unit)


			console.writeline(unit5)
			console.writeline(unit5.gettype)

			'' we test the function to help us typecast a base unit

			dim testunitobj as baseunit
			testunitobj = me.typecastunknownunit(cp4,unit5unit)
			console.writeline(testunitobj)
			console.writeline(testunitobj)

			'' it is better to work with base units
			' rather than typecast an object as an unknown unit and try
			' typecasting it to a base unit


			console.writeline(cp4.gettype)
			console.writeline(unit5.gettype)

			' this is okay
			' meaning assign the calculated value to a base unit straightaway
			unit5 = heatvalue/t1
			cp4 = heatvalue/t1

			'' this is not okay
			' meaning if a type is already an unknown unit object
			' casting it to a base unit is problematic

			try
			    unit5 =cp4

			catch ex as exception
				console.writeline(ex.message)

			end try


			'' i want to check if assigning a known unit as base unit is ok
			
			unit5 = t1
			console.writeline(unit5.gettype)
			console.writeline(unit5)

			dim unitbase6 as baseunit

			'' this does not even compile right
			'' 
			''unitbase6 = new baseunit(10, temperatureunit.si)
			' however, if the base unit is some new quantity, this is ok
			unitbase6 = new baseunit(10, temperatureunit.si.pow(4))




		end sub


		public function typecastunknownunit(x as unknownunit,desiredunits as unitsystem) as baseunit

			'' check whether unknownunit x has the same units as the desired units
			dim unitcheckobject as baseunit
			unitcheckobject = new baseunit(0,desiredunits)
			baseunit.unitcheck(unitcheckobject, x)

			' if this checks out, i mean units check out
			' i will then make a new baseunit object
			' use unkownunit.si to extract the decimal value
			dim xvalue as double
			xvalue = x.si

			return new baseunit(xvalue,desiredunits)

		end function


		'<theory>
		<inlinedata()>
		sub testixmlreader_manualengineeringunitstest()

			'' this is testing the new engineeringunits stuff
			dim roomtemp as temperature
			roomtemp = new temperature(293, temperatureunit.kelvin)
			console.writeline(roomtemp)


			'' now i want to test specific energy
			dim heatvalue as specificenergy
			heatvalue = new specificenergy(200, specificenergyunit.jouleperkilogram)

			console.writeline(heatvalue)

			'' now, the thing is heat capacity is not included
			' but technically i don't need to make a new unit
			' i can just perform calculations like that
			' or so i thought, i'm getting wrong units
			' i need to dim this as an object, let's see what the type is

			dim heatcapacity as object
			heatcapacity = heatvalue/roomtemp
			console.writeline(heatcapacity)
			console.writeline(heatcapacity.gettype)


			'' now let's try to get back specific energy
			'
			
			dim resultenergy as object
			resultenergy = heatcapacity*roomtemp
			console.writeline(resultenergy)
			unknownunitextensions.intelligentcast(resultenergy)
			console.writeline(resultenergy.gettype)


			'' test tostring
		    console.writeline(resultenergy.tostring())
			console.writeline(heatvalue.tostring())


			'' test the unit of each type
			console.writeline(resultenergy.unit)
			console.writeline(heatvalue.unit)
			
			'dim sum as object
			'sum = resultenergy + heatvalue
			'console.writeline(sum)

			' this is the unitcheck method for two quantities
			baseunit.unitcheck(resultenergy,heatvalue)
			try 
			    baseunit.unitcheck(roomtemp,resultenergy)
			catch ex as wrongunitexception

			    console.writeline(ex.message)

		    end try


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








    End Class


	Public Class legacyCodeAndSandbox

		Function getPropertyList() As IEnumerable (Of (propertyName As String, attachedList As IEnumerable (Of String)))

			Dim tupleToAdd As (propertyName As String, attachedList As IEnumerable (Of String))
			Dim propertyList As IList (Of (propertyName As String, attachedList As IEnumerable (Of String)))

			propertyList = new List (Of (propertyName As String, attachedList As IEnumerable (Of String)))

			Dim propertyName As String
			Dim attachingList As IList(Of String)
			attachingList = new List(Of String)

			'' first let's have the name category

			' this will contain all the names and identifiers
			' of the chemcial
			
			' units and functions found here: https://github.com/DanWBR/dwsim/blob/windows/DWSIM.Thermodynamics/BaseClasses/ThermodynamicsBase.vb
			' line 1419
			' more units found in this file
			' https://github.com/DanWBR/dwsim/blob/windows/DWSIM.Interfaces/ICompoundConstantProperties.vb


			propertyName = "Name"

			attachingList.Add("Name")
			attachingList.Add("CAS_Number")
			attachingList.Add("ID")
			attachingList.Add("COSMODBName")

			tupleToAdd = (propertyName, attachingList)
			propertyList.Add(tupleToAdd)
			attachingList.Clear()

			' critical properties

			propertyName = "criticalProperties"
			attachingList.Add("Critical_Temperature")
			attachingList.Add("Critical_Pressure")
			attachingList.Add("Critical_Volume")
			attachingList.Add("Critical_Compressibility")

			tupleToAdd = (propertyName, attachingList)
			propertyList.Add(tupleToAdd)
			attachingList.Clear()
			'    <Formula>CH4</Formula>
			'    <Molar_Weight>16.043</Molar_Weight>
			'    <Acentric_Factor>0.01155</Acentric_Factor>
			'    <Z_Rackett>2.89E-01</Z_Rackett>
			'    <PR_Volume_Translation_Coefficient>-0.1595</PR_Volume_Translation_Coefficient>
			'    <SRK_Volume_Translation_Coefficient>0.0234</SRK_Volume_Translation_Coefficient>

			' chao seader propperties
			propertyName = "chaoSeaderProperties"
			attachingList.Add("CS_Acentric_Factor")
			attachingList.Add("CS_Solubility_Parameter")
			attachingList.Add("CS_Liquid_Molar_Volume")

			tupleToAdd = (propertyName, attachingList)
			propertyList.Add(tupleToAdd)

			attachingList.Clear()

			' this is enthalpy entropy and Gibbs free energy of formation

			propertyName = "formationProperties"
			attachingList.Add("IG_Entropy_of_Formation_25C")
			attachingList.Add("IG_Enthalpy_of_Formation_25C")
			attachingList.Add("IG_Gibbs_Energy_of_Formation_25C")

			tupleToAdd = (propertyName, attachingList)
			propertyList.Add(tupleToAdd)
			attachingList.Clear()
			'<Dipole_Moment>0</Dipole_Moment>

			' vapour pressure

			propertyName = "vaporPressure"

			attachingList.Add("DIPPR_Vapor_Pressure_Constant_A")
			attachingList.Add("DIPPR_Vapor_Pressure_Constant_B")
			attachingList.Add("DIPPR_Vapor_Pressure_Constant_C")
			attachingList.Add("DIPPR_Vapor_Pressure_Constant_D")
			attachingList.Add("DIPPR_Vapor_Pressure_Constant_E")
			attachingList.Add("DIPPR_Vapor_Pressure_TMIN")
			attachingList.Add("DIPPR_Vapor_Pressure_TMAX")

			tupleToAdd = (propertyName, attachingList)
			propertyList.Add(tupleToAdd)
			attachingList.Clear()

			' heatCapacity ideal gas J/mol/K
			propertyName = "heatCapacity"
			attachingList.Add("Ideal_Gas_Heat_Capacity_Const_A")
			attachingList.Add("Ideal_Gas_Heat_Capacity_Const_B")
			attachingList.Add("Ideal_Gas_Heat_Capacity_Const_C")
			attachingList.Add("Ideal_Gas_Heat_Capacity_Const_D")
			attachingList.Add("Ideal_Gas_Heat_Capacity_Const_E")

			tupleToAdd = (propertyName, attachingList)
			propertyList.Add(tupleToAdd)
			attachingList.Clear()

			' liquid viscosity
			propertyname = "liquidviscosity"
			attachingList.Add("liquid_viscosity_const_a")
			attachingList.Add("liquid_viscosity_const_b")
			attachingList.Add("liquid_viscosity_const_c")
			attachingList.Add("liquid_viscosity_const_d")
			attachingList.Add("liquid_viscosity_const_e")

			tupleToAdd = (propertyName, attachingList)
			propertyList.Add(tupleToAdd)
			attachingList.Clear()

			'' now for boiling point

			propertyname = "boilingpoint"
			attachingList.Add("normal_boiling_point")

			tupleToAdd = (propertyName, attachingList)
			propertyList.Add(tupleToAdd)
			attachingList.Clear()
			'    <ispf>0</ispf>
			'    <ishyp>0</ishyp>
			'' enthalpy of vaporisation properties
			propertyname = "hvap"
			attachingList.Add("hvapa")
			attachingList.Add("hvapb")
			attachingList.Add("hvapc")
			attachingList.Add("hvapd")
			attachingList.Add("hvaptmin")
			attachingList.Add("hvaptmax")

			Me.printEnumerableString(attachingList)

			tupleToAdd = (propertyName, attachingList)

			Me.printEnumerableString(tupleToAdd.attachedList)

			Dim x As IEnumerable (Of String)
			x = tupleToAdd.attachedList

			Console.WriteLine("checking if typecasting method is the cause of a bug")
			Console.WriteLine()
			Me.printEnumerableString(x)

			propertyList.Add(tupleToAdd)
			attachingList.Clear()

			'' uniquac properties

			propertyname = "uniquac"
			'    <uniquac_r>1.1239</uniquac_r>
			'    <uniquac_q>1.152</uniquac_q>
			'    <unifac>
			'      <group name="ch4">1</group>
			'    </unifac>
			'    <elements>
			'      <element name="c">1</element>
			'      <element name="h">4</element>
			'    </elements>



			For Each tuple in propertyList
				Console.WriteLine(tuple.propertyName)
				Console.WriteLine(tuple.attachedList)
				Console.WriteLine()
				Dim y as IEnumerable (Of String)
				y = tuple.AttachedList
				Me.printEnumerableString(y)
			Next

			'' was stuck here, i think the list of tuple of (string,list)
			' doesn't quite work well yeah...


			' so list of tuple (Of String, IEnumerable(Of String))
			' doesn't quite work well
			' here are a number of solutions
			' 1) replace IEnumerable of String with some other object class
				' a) it has worked before
				' b) i just need to make a new class
			' 2) use the IEngineeringConversionEnumerable class
				' a) i use the existing IEngineeringConversionEnumerable interface
				' to put the data in and then just make a new implementation
				' b) cons: doesn't seem to match the function of what the class
				' is meant to do
			' 3) use IXmlPropertyList interface, which should inherit IList or IEnumerable
				' the sublists of which should be also typed as IXmlPropertyList
				' which means i'll need to have several constructors
				' so if the user just does dependency injection and gives the right
				' IXmlLibrary, the whole list will be returned
				' otherwise, if a property is also given
				' then filtered sublists of items will be returned
				' which means the human readable list 
				' may as well be a property within the IXmlPropertyList
				' however, if i merge this altogether, i will violate
				' SRP (Single Responsibility principle)
			' 4) use IXmlHumanReadableList
			' 5) use IXmlPropertyList interface, but implement it with hard coded lists
			' of IEnumerable<string>
				' a) it would make sense that IXmlPropertyList would be implemented
				' by some sublists, like heat capacity and etc
				'
				' b) however, it won't be tightly coupled to the human readable list
				' i would like it to be such that when i make the list here in one place
				' I would also make the same lists in other places
				'
				' c) the simpler approach may be to make a super object which is tightly 
				' coupled but implements several interfaces at one go,
				' because those operations are tightly coupled
				' this may violate single responsibility principle
				' but i guess a heuristic is what the responsibility should be
				' I suppose if operations become so tightly coupled, they can indeed
				' be lumped together in a superclass
				' that does many functions, but has one singular responsibility
				' that's a good rule of thumb
				' this will obey the interface segregation principle
				' but also single responsibility
				'
				' key question is: am I giving myself extra work by
				' decoupling the class?
				'
				' if so, make the single responsibility bigger
				'
				' the responsibility of the eventual class will be to return lists
				' of properties, full lists, subfiltered lists
				' and human readable property lists
				'
				' in doing so, using the object becomes really simple because
				' there are predefined ways of interfacing with an object
				'
				' and by tightly coupling the operations within a single class
				' I can make sure one change in one part of the class is
				' reflected in other areas as well
				' so two interfaces i will make, 
				' IXmlPropertyList and IXmlHumanReadablePropertyList
				' 
			

		End Function


		Function printEnumerableString(ByVal stringEnum As IEnumerable (Of String)) 


			Console.WriteLine("printing Type")
			Dim objtype as Type
			objtype = stringEnum.GetType()
			Console.WriteLine(objtype.Name)

			Console.WriteLine("how many items there are in this object:")
			Console.WriteLine(Enumerable.Count(stringEnum))
			
			For Each item in stringEnum
				Console.WriteLine(item)
			Next

		End Function
	End Class

End Namespace


