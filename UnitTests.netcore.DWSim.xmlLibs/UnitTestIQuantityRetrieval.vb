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
			attachedList.Clear()


			propertyName = "criticalProperties"
			attachedList.Add("Critical_Temperature")
			attachedList.Add("Critical_Pressure")
			attachedList.Add("Critical_Volume")
			attachedList.Add("Critical_Compressibility")

			tupleToAdd = (propertyName, attachedList)
			propertyList.Add(tupleToAdd)
			attachedList.Clear()
'    <Formula>CH4</Formula>
'    <Molar_Weight>16.043</Molar_Weight>
'    <Acentric_Factor>0.01155</Acentric_Factor>
'    <Z_Rackett>2.89E-01</Z_Rackett>
'    <PR_Volume_Translation_Coefficient>-0.1595</PR_Volume_Translation_Coefficient>
'    <SRK_Volume_Translation_Coefficient>0.0234</SRK_Volume_Translation_Coefficient>
			propertyName = "chaoSeaderProperties"
			attachedList.Add("CS_Acentric_Factor")
			attachedList.Add("CS_Solubility_Parameter")
			attachedList.Add("CS_Liquid_Molar_Volume")

			tupleToAdd = (propertyName, attachedList)
			propertyList.Add(tupleToAdd)

			attachedList.Clear()

			' this is enthalpy entropy and Gibbs free energy of formation

			propertyName = "formationProperties"
			attachedList.Add("IG_Entropy_of_Formation_25C")
			attachedList.Add("IG_Enthalpy_of_Formation_25C")
			attachedList.Add("IG_Gibbs_Energy_of_Formation_25C")

			tupleToAdd = (propertyName, attachedList)
			propertyList.Add(tupleToAdd)
			attachedList.Clear()
'    <Dipole_Moment>0</Dipole_Moment>
			propertyName = "vaporPressure"

			attachedList.Add("DIPPR_Vapor_Pressure_Constant_A")
			attachedList.Add("DIPPR_Vapor_Pressure_Constant_B")
			attachedList.Add("DIPPR_Vapor_Pressure_Constant_C")
			attachedList.Add("DIPPR_Vapor_Pressure_Constant_D")
			attachedList.Add("DIPPR_Vapor_Pressure_Constant_E")
			attachedList.Add("DIPPR_Vapor_Pressure_TMIN")
			attachedList.Add("DIPPR_Vapor_Pressure_TMAX")

			tupleToAdd = (propertyName, attachedList)
			propertyList.Add(tupleToAdd)
			attachedList.Clear()

			propertyName = "heatCapacity"
			attachedList.Add("Ideal_Gas_Heat_Capacity_Const_A")
			attachedList.Add("Ideal_Gas_Heat_Capacity_Const_B")
			attachedList.Add("Ideal_Gas_Heat_Capacity_Const_C")
			attachedList.Add("Ideal_Gas_Heat_Capacity_Const_D")
			attachedList.Add("Ideal_Gas_Heat_Capacity_Const_E")

			tupleToAdd = (propertyName, attachedList)
			propertyList.Add(tupleToAdd)
			attachedList.Clear()

			propertyname = "liquidviscosity"
			attachedList.Add("liquid_viscosity_const_a")
			attachedList.Add("liquid_viscosity_const_b")
			attachedList.Add("liquid_viscosity_const_c")
			attachedList.Add("liquid_viscosity_const_d")
			attachedList.Add("liquid_viscosity_const_e")

			tupleToAdd = (propertyName, attachedList)
			propertyList.Add(tupleToAdd)
			attachedList.Clear()

			propertyname = "boilingpoint"
			attachedList.Add("normal_boiling_point")

			tupleToAdd = (propertyName, attachedList)
			propertyList.Add(tupleToAdd)
			attachedList.Clear()
'    <ispf>0</ispf>
'    <ishyp>0</ishyp>
propertyname = "hvap"
'    <hvapa>10194000</hvapa>
'    <hvapb>0.26087</hvapb>
'    <hvapc>-0.14694</hvapc>
'    <hvapd>0.22154</hvapd>
'    <hvaptmin>90</hvaptmin>
'    <hvaptmax>190</hvaptmax>
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
'




		end function




	    '<theory>
		<inlinedata()>
		sub ixmlreader_ienumerabletest()

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

