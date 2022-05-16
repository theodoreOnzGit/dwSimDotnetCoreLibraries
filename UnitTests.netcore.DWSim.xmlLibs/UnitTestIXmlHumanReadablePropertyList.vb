Imports System
Imports Xunit
Imports theoOng.netcore.DWSim.xmlLibs

Imports System.Xml
Imports System.Xml.Linq

Imports Xunit.Abstractions


Namespace UnitTests.netcore.DWSim.xmlLibs

    Public Class UnitTestIXmlHumanReadablePropertyList
	' ==== this part helps to inject the output helper so that one can write output ==='
	' only for windows usage of dotnet build
	Inherits testOutputHelper

		Public Sub New(outputHelper As ITestOutputHelper)
			MyBase.New(outputHelper)
		End Sub


        <Fact>
        Sub TestSub()
		End Sub

		<Theory>
		<InlineData("LiquidViscosity")>
		<InlineData("boilingPoint")>
		<InlineData("enthalpyOfVaporisation")>
		<InlineData("criticalProperties")>
		Sub TestIXmlHumanReadablePropertyList_ShouldReturnLists(desiredQuantity As String)

			''Setup
			Dim refEnumerable As IEnumerable (Of String)
			Dim resultEnumerable As IEnumerable (Of String)
			refEnumerable = Me.returnRefEnumerable(desiredQuantity)
			'' Act
			resultEnumerable = Me.retrieveDesiredQuantity(desiredQuantity)
			'' Assert
			Dim areEnumerablesEqual As Boolean
			areEnumerablesEqual = Enumerable.SequenceEqual(refEnumerable,resultEnumerable)
			Assert.True(areEnumerablesEqual)
		End Sub


		'' here is a case structure to return my ref enumerables
		'

		Public Function returnRefEnumerable(ByVal desiredQuantity As String) As IEnumerable (Of String)
			Dim refEnumerable As IEnumerable (Of String)
			Dim refList As IList (Of String)
			refList = new List (Of String)

			Select desiredQuantity.ToLower()
				Case "LiquidViscosity".ToLower()
					refList.Add("Liquid_Viscosity_Const_A")
					refList.Add("Liquid_Viscosity_Const_B")
					refList.Add("Liquid_Viscosity_Const_C")
					refList.Add("Liquid_Viscosity_Const_D")
					refList.Add("Liquid_Viscosity_Const_E")
				Case "boilingPoint".ToLower()
					refList.Add("Normal_Boiling_Point")
				Case "enthalpyOfVaporisation".ToLower()
					refList.Add("HVapA")
					refList.Add("HVapB")
					refList.Add("HvapC")
					refList.Add("HVapD")
					refList.Add("HvapTmin")
					refList.Add("HvapTMAX")
				Case "criticalProperties".ToLower()
					refList.Add("Critical_Temperature")
					refList.Add("Critical_Pressure")
					refList.Add("Critical_Volume")
					refList.Add("Critical_Compressibility")
			End Select
			refEnumerable = refList
			return refEnumerable
		End Function



		<Fact>
		Sub TestIXmlHumanReadablePropertyList_ShouldReturnHeatCapacityList()
			''Setup
			Dim refList As IList (Of String)
			Dim refEnumerable As IEnumerable (Of String)

			refList = new List (Of String)
			refList.Add("Ideal_Gas_Heat_Capacity_Const_A")
			refList.Add("Ideal_Gas_Heat_Capacity_Const_B")
			refList.Add("Ideal_Gas_Heat_Capacity_Const_C")
			refList.Add("Ideal_Gas_Heat_Capacity_Const_D")
			refList.Add("Ideal_Gas_Heat_Capacity_Const_E")
			refEnumerable = refList

			'' Act
			Dim resultEnumerable As IEnumerable (Of String)
			resultEnumerable = Me.retrieveDesiredQuantity("heatcapacity")
			'
			'' Assert
			
			Dim areEnumerablesEqual As Boolean
			areEnumerablesEqual = Enumerable.SequenceEqual(refEnumerable,resultEnumerable)
			Assert.True(areEnumerablesEqual)
		End Sub

		Function retrieveDesiredQuantity(ByVal desiredQuantity As String) As IEnumerable (Of String)
			Dim xmlLibLoader as IXmlLibLoader
			'' please declare new object later
			xmlLibLoader = new dwSimXmlLibBruteForce
			Dim dwSimPropertyList As IXmlHumanReadablePropertyList

			dwSimPropertyList = new dwSimXmlHumanReadablePropertyList_May2022
			dwSimPropertyList.injectLibrary(xmlLibLoader)

			Dim testEnumerable As IEnumerable (Of String)

			testEnumerable = dwSimPropertyList.returnList(desiredQuantity)

			return testEnumerable

		End Function


        '<Theory>
		<InlineData("heatcapacity")>
		<InlineData("Ideal_Gas_Heat_Capacity_Const_A")>
		<InlineData("liquidviscosity")>
		<InlineData("liquid_viscosity_const_e")>
		<InlineData("liquid_viscosity_const_b")>
		<InlineData("boilingPoint")>
		<InlineData("normal_boiling_point")>
		<InlineData("hvap")>
		<InlineData("hvapA")>
		<InlineData("nonsense")>
		<InlineData("miscList")>
		<InlineData("vaporPressure")>
		<InlineData("criticalProperties")>
		<InlineData("critical_volume")>
		<InlineData("compoundname")>
		<InlineData("ID")>
		<InlineData("DIPPR_Vapor_pressure_constant_A")>
		<InlineData("chaoseader")>
		<InlineData("molecularproperties")>
		<InlineData("Z_Rackett")>
		<InlineData("UNIQUAC")>
		<InlineData("UNIFAC")>
		<InlineData("IsPf")>
		<InlineData("")>
        Sub sandbox(desiredQuantity As String)

			Me.cout(VbCrLf)
			Me.cout("Test for:" & desiredQuantity & VbCrLf)


			Dim xmlLibLoader as IXmlLibLoader
			'' please declare new object later
			xmlLibLoader = new dwSimXmlLibBruteForce
			Dim dwSimPropertyList As IXmlHumanReadablePropertyList

			dwSimPropertyList = new dwSimXmlHumanReadablePropertyList_May2022
			dwSimPropertyList.injectLibrary(xmlLibLoader)

			Dim testEnumerable As IEnumerable (Of String)

			Try
				testEnumerable = dwSimPropertyList.returnList(desiredQuantity)
				For Each compoundProperty in testEnumerable
					Me.cout(compoundProperty)
				Next
				Catch ex As InvalidOperationException
					Me.cout(ex.Message)
				Assert.True(True)
			End Try


		End Sub

		<Fact>
		Sub TestIXmlPropertyList_ShouldProduceList()
			'' Setup
			Dim xmlLibLoader as IXmlLibLoader
			'' please declare new object later
			xmlLibLoader = new dwSimXmlLibBruteForce

			Dim xmlData As XDocument
			xmlData = xmlLibLoader.getXDoc()

			Dim xElementList as IEnumerable(Of XElement)

			xElementList = xmlData.Elements().Elements()


			Dim waterComponentXElement As IEnumerable(Of XElement)

			waterComponentXElement = From el In xElementList
									Where el.Element("Name") = "Water"
									Select el



			'' after i have the Xelement for water
			'i can then extract the child elements from them
			'and put their names into a List of string


			Dim refList as List(Of String)
			refList = new List(Of String)

			For Each element As XElement in waterComponentXElement.Elements()
				refList.Add(element.Name.ToString())
			Next

			Dim refEnumerable As IEnumerable(Of String)

			refEnumerable = refList


			' now i will setup the IXmlPropertyList
			Dim resultEnumerable As IEnumerable(Of String)
			Dim dwSimPropertyList As IXmlPropertyList

			dwSimPropertyList = new dwSimXmlPropertyList_May2022
			dwSimPropertyList.injectLibrary(xmlLibLoader)
			'' Act
			'

			resultEnumerable = dwSimPropertyList.returnList()
			'' Assert
			Dim areEnumerablesEqual As Boolean
			areEnumerablesEqual = Enumerable.SequenceEqual(refEnumerable,resultEnumerable)
			Assert.True(areEnumerablesEqual)
		End Sub

		'<Theory>
		<InlineData()>
		Sub sandboxDWSim() 
			'' first i want to get 
			' a list of all properties 
			' so i will load the water XElement first
			' for the dwsim database
			'
			Dim xmlLibLoader as IXmlLibLoader
			'' please declare new object later
			xmlLibLoader = new dwSimXmlLibBruteForce

			Dim xmlData As XDocument
			xmlData = xmlLibLoader.getXDoc()

			Dim xElementList as IEnumerable(Of XElement)

			xElementList = xmlData.Elements().Elements()


			Dim waterComponentXElement As IEnumerable(Of XElement)

			waterComponentXElement = From el In xElementList
									Where el.Element("Name") = "Water"
									Select el



			'' after i have the Xelement for water
			'i can then extract the child elements from them
			'and put their names into a List of string


			Dim nameList as List(Of String)
			nameList = new List(Of String)

			For Each element As XElement in waterComponentXElement.Elements()
				nameList.Add(element.Name.ToString())
			Next

			For Each propertyName As String in nameList
				Console.WriteLine(propertyName)
			Next

		End Sub



    End Class

End Namespace

