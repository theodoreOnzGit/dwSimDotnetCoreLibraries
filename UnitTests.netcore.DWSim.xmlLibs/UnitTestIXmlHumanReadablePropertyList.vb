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
		<InlineData("heatcapacity")>
		<InlineData("Ideal_Gas_Heat_Capacity_Const_A")>
		<InlineData("liquidviscosity")>
		<InlineData("liquid_viscosity_const_e")>
		<InlineData("liquid_viscosity_const_b")>
		<InlineData("nonsense")>
		<InlineData("")>
        Sub sandbox(desiredQuantity As String)


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
					_output.Writeline(compoundProperty)
				Next
				Catch ex As InvalidOperationException
					_output.Writeline(ex.Message)
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

