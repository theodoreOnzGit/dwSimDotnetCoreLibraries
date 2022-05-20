Imports System.Xml
Imports System.Xml.Linq
Imports System

Imports EngineeringUnits
Imports EngineeringUnits.Units
Imports System.Linq

Public Class dwSimXmlQuantityRetrieval 

Implements IXmlQuantityRetrieval

	'' these are the input data you'd want to put in
	Private _desiredQuantity As String
	Private _fluidType As String
	Public Property fluidType As String Implements IXmlQuantityRetrieval.fluidType
		Get
			Return Me._fluidType
		End Get
		Set(ByVal fluid As String)
			'' i want to have a check here
			'' so that if my fluid does not match a checklist
			' i will throw an invalid operation exception
			'
			Me.checkFluid(Me._xmlLibLoader,fluid)
			Me._fluidType = fluid
		End Set
	End Property


	'' dependency injection
    Private Property _xmlLibLoader As IXmlLibLoader Implements IXmlQuantityRetrieval._xmlLibLoader
    Private Property _humanReadablePropertyList As IXmlHumanReadablePropertyList 

	Public Sub New(ByVal humanReadablePropertyList As IXmlHumanReadablePropertyList,
		ByVal xmlLibLoaderObj As IXmlLibLoader)

		'' here i am injecting an IXmlComponentList, with a default value
		'and you don't have to supply a value here,
		' you can if you want
		Me._humanReadablePropertyList = humanReadablePropertyList
		Me._humanReadablePropertyList.injectLibrary(xmlLibLoaderObj)
		Me.injectLib(xmlLibLoaderObj)
	End Sub

    Sub injectLib(xmlLibLoaderObj As IXmlLibLoader) Implements IXmlQuantityRetrieval.injectLib
		Me._xmlLibLoader = xmlLibLoaderObj
	End Sub

	'' these functions deal with the output
    Function returnQuantityList(ByVal desiredQuantity As String) As IEnumerable (Of Double) Implements IXmlQuantityRetrieval.returnQuantityList
		
		Dim resultEnumerable As IEngineeringConversionEnumerable
		resultEnumerable = Me.returnEngineeringEnumerable(desiredQuantity)
		return resultEnumerable
		
	End Function


    Function returnEngineeringEnumerable(ByVal desiredQuantity As String) As IEngineeringConversionEnumerable Implements IXmlQuantityRetrieval.returnEngineeringEnumerable

		Me._desiredQuantity = desiredQuantity
		Dim resultEnumerable As IEngineeringConversionEnumerable
		resultEnumerable = Me.loadQuantityList(Me._xmlLibLoader)
		resultEnumerable = Me.loadConversionDelegates(Me._xmlLibLoader,resultEnumerable)
		return resultEnumerable
		
	End Function

	'' this helps to deal with the disposal of unused resources
    Public Sub Dispose() Implements IDisposable.Dispose

		Me._desiredQuantity = Nothing
		Me._xmlLibLoader.Dispose()
		Me._xmlLibLoader = Nothing

	End Sub
	

	'' for this implementation
	' i will check what kind of libraryloader is injected into this
	' if the libraryLoader is dwsimXmllib, then i will activate a function
	' this will serve as a template that i will use next time i make new implementations
	' of the library if i get there

	Private Function loadQuantityList(ByVal dwSimLib As dwSimXmlLibBruteForce) As IEngineeringConversionEnumerable
		Dim desiredQuantity As String
		desiredQuantity = Me._desiredQuantity.ToLower()

		Dim checkList As IEnumerable(Of String)
		checkList = Me._humanReadablePropertyList.returnList(Me._desiredQuantity)
		'' so i have a list of things to search for, 
		'' i will need to check the fluid type
		'' and then return the quantities stated in the list
		' also if a wrong desired quantity is supplied, an error message should display

		'(1) return x Document

		Dim xmlData As XDocument
		xmlData = dwSimLib.getXDoc()
		
		'(2) return the XElement where the compound name matches the fluidType

		'(2a) return a full list of XElements for all compounds
		Dim xElementList as IEnumerable(Of XElement)
		xElementList = xmlData.Elements().Elements()

		'(2b) return the XElement which matches the fluidType
		Dim fluidXElement As IEnumerable(Of XElement)

		fluidXElement = From el In xElementList
		Where el.Element("Name") = Me.fluidType 
		Select el

		'(2c) if the no. of elements inside this Enumerable is zero, throw an error
		Me.checkFluidCount(dwSimLib,fluidXElement)
		
		'(3) now that we have the XElement list of the particular fluid we want, we can start
		' filling up the list of desired quantities 
		' so i will take the human readable propertyList enumerable, a.k.a the checkList
		' and then make a new list from this checklist
		'ill make a new EngineeringConversionList First

		Dim resultList As IEngineeringConversionEnumerable
		resultList = new EngineeringConversionList
		Dim resultDouble As Double


		For Each quantityString in checkList
			resultDouble = Me.getXmlPropertyValue(dwSimLib,fluidXElement,quantityString)
			resultList.Add(resultDouble)
		Next


		return resultList



	End Function

	' over here i also have checkFluid functions
	' that are tightly coupled and check if matches a list
	


	Private Function loadConversionDelegates(ByVal dwSimLib As dwSimXmlLibBruteForce,
		ByVal engineeringEnum As IEngineeringConversionEnumerable) As IEngineeringConversionEnumerable

		'' we prepare conversion function to inject
		' by setting the variable
		Dim conversionFunction As EngineeringConversion

		Select Me._desiredQuantity.ToLower()
			Case "heatcapacity"
				conversionFunction = new EngineeringConversion(AddressOf Me.convertCpDWsim)
				engineeringEnum.setDelegate(conversionFunction)
			Case "liquidviscosity"
				conversionFunction = new EngineeringConversion(AddressOf Me.convertLiqViscosityDWsim)
				engineeringEnum.setDelegate(conversionFunction)
		End Select

		return engineeringEnum

	End Function

	'' here is the delegate to convertCp for dwsim library

	Private Function convertCpDWsim(ByVal heatCapacityEnum As IEnumerable (Of Double)) As IEnumerable (Of BaseUnit)
		'' for cp units in DWSim, the units are in J/(mol * K)
		' however, i want it to be output in SI units
		' J/(kg * K)
		' so some extra work must be done
		' i need to extract the molar weight of this first in g/gmol
		' to do this i use the human readable property list
		' and extract the value molar_weight


		' first i set my unit systems
		Dim cpMolarUnit As UnitSystem
		cpMolarUnit = (EnergyUnit.SI/AmountOfSubstanceUnit.SI/TemperatureUnit.SI)
		Dim constantUnit As UnitSystem
		Dim constantQuantity As BaseUnit

		' next thing i do, is to instantiate a list
		Dim heatCapacityConstList As List (Of BaseUnit)
		heatCapacityConstList = new List (Of BaseUnit)

		Dim Molar_Weight As BaseUnit
		Molar_Weight = Me.getMolarWt()


		'	Next I initiate the for loop to return the list

		For i As Integer = 0 To heatCapacityEnum.Count - 1
			constantUnit = cpMolarUnit/TemperatureUnit.SI.pow(i)
			constantQuantity = new BaseUnit(heatCapacityEnum(i),constantUnit)
			constantQuantity = constantQuantity / Molar_Weight / gToKg
							
			heatCapacityConstList.Add(constantQuantity)
			constantUnit = Nothing
			constantQuantity = Nothing
		Next

		'' put the formula here so users know what formula it is

		Console.WriteLine("Cp (J/(kg * K)) = A + B*T + C*T^2 + D*T^3 + E*T^4" & VbCrLf)
		Console.WriteLine("A is the first element of the enum, B is the second," & VbCrLf)
		Console.WriteLine("C is the third and so forth")


		return heatCapacityConstList

	End Function


	'' here is the delegate to get viscosity in right units

	Private Function convertLiqViscosityDWsim(ByVal viscosityEnum As IEnumerable (Of Double)) As IEnumerable (Of BaseUnit)
		' first let's have a list of base units
		Dim liqViscosityConstList As IList (Of BaseUnit)
		liqViscosityConstList = new List (Of BaseUnit)

		Dim constantUnit As UnitSystem
		Dim constantQuantity As BaseUnit

		' most constants in viscosity are dimensionless
		' here is the eqn
		' result = Math.Exp(A + B / T + C * Math.Log(T) + D * T ^ E)
		' hence i want base units but with no units
		' to get that i have a dimensionlessOne
		' and make a onekelvin Temperature object
		' the oneKelvin object is to convert B into 1/K unit
		Dim dimensionlessOne As BaseUnit

		Dim oneKelvin As Temperature = new Temperature(1, TemperatureUnit.SI)

		dimensionlessOne = oneKelvin/onekelvin

		'' what i'm trying to do here is to cycle through all
		' the quantity list of viscosity constants
		' i will assign a dimensionless unit to A,C,D and E which are
		' at index 0,2,3,4 of the viscosityEnum (double)
		' and then i will convert them into a base unit and add it to the liquid viscosity list
		' for B, i will divide it by oneKelvin so that i can get 
		' it in the 1/K temperature units

		For i As Integer = 0 To viscosityEnum.Count - 1
			' A is dimensionless, so we multiply A by a dimensionless 1
			' same thing for C,D and E
			' C, D and E are cases 2,3,4 respectively
			Select i.ToString()
				Case 0,2,4
					'' need to make this extra step to help with typecasting
					' to BaseUnit
					Dim quantity As Decimal
					quantity = viscosityEnum(i)
					constantQuantity = dimensionlessOne * quantity
					liqViscosityConstList.Add(constantQuantity)
					quantity = Nothing
					constantQuantity = Nothing
				Case 1
					'' need to make this extra step to help with typecasting
					' to BaseUnit
					Dim quantity As Decimal
					quantity = viscosityEnum(i)
					constantQuantity = 1/oneKelvin * quantity
					liqViscosityConstList.Add(constantQuantity)
					quantity = Nothing
					constantQuantity = Nothing
				Case 3 '' this is for D
					Dim quantity As Decimal
					quantity = viscosityEnum(i)
					Dim E As Decimal
					E = viscosityEnum(4)
					constantQuantity = 1/oneKelvin.pow(E) * quantity
					liqViscosityConstList.Add(constantQuantity)
					quantity = Nothing
					constantQuantity = Nothing
			End Select 
		Next


		Console.WriteLine("Viscosity (Pa*s) = Math.Exp(A + B/T + C*Math.Log(T) + D*T^E)" & VbCrLf)
		Console.WriteLine("A is the first element of the enum, B is the second," & VbCrLf)
		Console.WriteLine("C is the third and so forth")


		return liqViscosityConstList
	End Function

	' a lot of functions in DWSim libraries are in molar quantities
	' eg heat capacity for dwsim library, this particular function
	' returns molar weight for 
	' a given compound so that we can use it for unit conversion
	Private Function getMolarWt() As BaseUnit

		Dim molarWeightList As IEnumerable(Of Double)
		molarWeightList = Me.returnQuantityList("Molar_Weight")

		Dim molarWeightDouble As Double

		For Each molarWt in molarWeightList
			molarWeightDouble = molarWt
		Next

		Dim molarWtUnit As UnitSystem
		molarWtUnit = (MassUnit.Gram/AmountOfSubstanceUnit.SI)
		Dim Molar_Weight As BaseUnit
		Molar_Weight = new BaseUnit(molarWeightDouble,molarWtUnit)

		return Molar_Weight
	End Function


	'' here are also some useful conversion constants i am going to use

	Private Dim gToKg As BaseUnit = new BaseUnit(1e-3, MassUnit.SI/MassUnit.Gram)

	
	'' this set of function(s) gets the value given the name of the quantity

	Private Function getXmlPropertyValue(ByVal dwSimLib As dwSimXmlLibBruteForce,
		ByVal fluidXElement As IEnumerable(Of XElement),
		ByVal quantityString As String) As Double

		Dim resultString As String
		Dim resultDouble As Double

		quantityString = quantityString.ToLower()
		For Each el in fluidXElement.Elements()
			If el.Name.LocalName.ToLower() = quantityString
				resultString = el.Value
				resultDouble = Convert.ToDouble(resultString)
				return resultDouble
			End If
		Next


		'' if everything else fails, the double is 0
		resultDouble = 0
		resultString = "0"

		Dim errorMsg As String
		errorMsg = "The string given: " & quantityString & VbCrLf
		errorMsg += "does not have an entry in dwSimXml" & VbCrLf

		errorMsg += VbCrLf
		errorMsg += VbCrLf

		throw new InvalidOperationException(errorMsg)



	End Function


	'' count functions for enumerables
	' this is basically for me to check if i loaded my enumerables correctly

	Private Sub checkFluidCount(ByVal dwSimLib As dwSimXmlLibBruteForce,
		ByVal enumerable As IEnumerable (Of Object))
		Dim countNumber As Integer
		countNumber = Me.countEnum(enumerable)

		If countNumber = 0
			Dim errorMsg As String
			errorMsg = "The compound you specified: " & Me.fluidType & VbCrLf
			errorMsg += "does not exist" & VbCrLf

			errorMsg += VbCrLf
			errorMsg += VbCrLf
			errorMsg += "Please select a compound from the following (case sensitive):"
			errorMsg += VbCrLf
			errorMsg += VbCrLf

			' first let's get our XDocument
			Dim xDoc As XDocument
			xDoc = dwSimLib.getXDoc()
			'' then let's make a list of elements
			For Each element As XElement in xDoc.Elements().Elements().Elements("Name")
				errorMsg += element.Value & VbCrLf
			Next

			errorMsg += VbCrLf
			errorMsg += "=== thank you ==="
			errorMsg += VbCrLf

			throw new InvalidOperationException(errorMsg)
		End If
	End Sub

	''  this overload of check fluid checks if a string exists in the in the
	' dwsim xml library

	Private Sub checkFluid(ByVal dwSimLib As dwSimXmlLibBruteForce,
		ByVal fluid As String)

		Dim xDoc As XDocument
		xDoc = dwSimLib.getXDoc()

		Dim checkList As IList(Of String)
		checkList = new List(Of String)
		For Each element As XElement in xDoc.Elements().Elements().Elements("Name")
			checkList.Add(element.Value)
		Next

		Dim countNumber As Integer = 0

		'' so now let's check if the fluid name matches the name in the checklist

		For Each elementName in checkList
			If fluid = elementName
				countNumber += 1
			End If
		Next

		If countNumber = 0
			Dim errorMsg As String
			errorMsg = "The compound you specified: " & fluid & VbCrLf
			errorMsg += "does not exist" & VbCrLf

			errorMsg += VbCrLf
			errorMsg += VbCrLf
			errorMsg += "Please select a compound from the following (case sensitive):"
			errorMsg += VbCrLf
			errorMsg += VbCrLf

			'' then let's make a list of elements
			For Each elementName As String in checkList
				errorMsg += elementName & VbCrLf
			Next

			errorMsg += VbCrLf
			errorMsg += "=== thank you ==="
			errorMsg += VbCrLf

			throw new InvalidOperationException(errorMsg)
		End If
	End Sub

	Private Function countEnum(ByVal enumerable As IEnumerable(Of Object)) As Integer
		Dim counter As Integer
		counter = 0

		For Each item in enumerable
			counter +=1
		Next

		return counter

	End Function
	


End Class

