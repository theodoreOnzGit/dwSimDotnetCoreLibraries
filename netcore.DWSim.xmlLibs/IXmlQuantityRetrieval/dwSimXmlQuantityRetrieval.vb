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
		
		Me._desiredQuantity = desiredQuantity
		Dim resultEnumerable As IEngineeringConversionEnumerable
		resultEnumerable = Me.loadQuantityList(Me._xmlLibLoader)
		return resultEnumerable
		
	End Function


    Function returnEngineeringEnumerable(ByVal desiredQuantity As String) As IEngineeringConversionEnumerable Implements IXmlQuantityRetrieval.returnEngineeringEnumerable

		Me._desiredQuantity = desiredQuantity
		Dim resultEnumerable As IEngineeringConversionEnumerable
		resultEnumerable = Me.loadQuantityList(Me._xmlLibLoader)
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
	


	Private Function loadConversionDelegates(ByVal dwSimLib As dwSimXmlLibBruteForce)
	End Function
	
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

