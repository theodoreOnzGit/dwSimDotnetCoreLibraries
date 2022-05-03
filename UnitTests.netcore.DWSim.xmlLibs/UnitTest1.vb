Imports System
Imports Xunit
Imports netcore.DWSim.xmlLibs

Imports System.Xml
Imports System.Xml.Linq
Imports System.Collections.Generic


Namespace UnitTests.netcore.DWSim.xmlLibs

    Public Class UnitTest1

        '<Fact>
        Sub TestSub()

		End Sub


		<Theory>
		<InlineData(373.15,"Water")>
		<InlineData(77.344,"Nitrogen")>
		<InlineData(353.3,"Benzene")>
		Sub TestIXmlLibLoader_loadBoilingPoints(ByVal refTemperature As Double,
			ByVal componentName As String)

			
			'This test takes in a reference temperature (boiling Point)
			'of a said component as a double
			'and the component name 
			' And then performs a comparison test (Assert)

			Dim resultTemperature As Double

			Dim xmlLibLoader as IXmlLibLoader
			'' please declare new object later
			xmlLibLoader = new dwSimXmlLibBruteForce

			Dim xmlData As XDocument
			xmlData = xmlLibLoader.getXDoc()


			Dim xElementList as IEnumerable(Of XElement)

			xElementList = xmlData.Elements().Elements()


			Dim waterComponentXElement As IEnumerable(Of XElement)

			waterComponentXElement = From el In xElementList
									Where el.Element("Name") = componentName 
									Select el


			Dim boilingPoint As String

			boilingPoint = "0"


			'' Act test, use the function to return the value
			For Each el in waterComponentXElement.Elements()
				If el.Name = "Normal_Boiling_Point"
					boilingPoint = el.Value
				End If
			Next



			resultTemperature = Convert.ToDouble(boilingPoint)


			'' Assert test


			Assert.Equal(refTemperature,resultTemperature)

		End Sub


        <Fact>
        Sub TestIXmlLibLoader_loadWaterBoilingPoint()

			'' Arrange Test, ie perform setup, declare objects etc
			Dim refTemperature As Double

			' boiling point of water is in kelvin
			' 100C + 273.15K = 373.15K, as we can see from database
			refTemperature = 373.15

			Dim resultTemperature As Double

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


			Dim boilingPoint As String

			boilingPoint = "0"

			' here 

			'' Act test, use the function to return the value
			For Each el in waterComponentXElement.Elements()
				'' i used Console Writeline to debug and see
				' if the code was selecting the right element
				'Console.WriteLine(el.Name)
				If el.Name = "Normal_Boiling_Point"
					'Dim boilingPoint As String
					'boilingPoint = el.Value
					'Console.WriteLine(el.Name)
					'Console.WriteLine(el.Value)
					boilingPoint = el.Value
				End If
			Next



			resultTemperature = Convert.ToDouble(boilingPoint)



			'' Assert test


			Assert.Equal(refTemperature,resultTemperature)

		End Sub

        '<Fact>
        Sub TestIXmlLibLoader_loadWaterXElement()

			'' Arrange Test, ie perform setup, declare objects etc
			Dim refTemperature As Double

			' boiling point of water is in kelvin
			' 100C + 273.15K = 373.15K, as we can see from database
			refTemperature = 373.15


			Dim xmlLibLoader as IXmlLibLoader
			'' please declare new object later
			xmlLibLoader = new dwSimXmlLibBruteForce

			Dim xmlData As XDocument
			xmlData = xmlLibLoader.getXDoc()


			'https://docs.microsoft.com/en-us/dotnet/standard/linq/find-element-specific-child-element
			'copied from ms documentation

			Dim xElementList as IEnumerable(Of XElement)

			xElementList = xmlData.Elements().Elements()


			Dim waterComponentXElement As IEnumerable(Of XElement)

			waterComponentXElement = From el In xElementList
									Where el.Element("Name") = "Water"
									Select el


			For Each element As XElement in waterComponentXElement

				Console.WriteLine(element)
			Next


		End Sub

        <Fact>
        Sub TestIXmlLibLoader_loadWaterString()

			Dim refString As String
			refString = "Water"

			'' then we do our code here
			Dim resultString As String
			resultString = "0"

			' first we get our XDocument

			Dim xmlData as XDocument

			Dim xmlLibLoader as IXmlLibLoader
			'' please declare new object later
			xmlLibLoader = new dwSimXmlLibBruteForce

			xmlData = xmlLibLoader.getXDoc()

			Dim XelementList as IEnumerable(Of XElement)

			xElementList = xmlData.Elements().Elements().Elements("Name")


			For Each xEl As XElement in xElementList

				'Console.WriteLine(xEl.Name)
				'Console.WriteLine(xEl.Value)


				If xEl.Value="Water"

					resultString = xEl.Value
				ElseIf xEl.Value="water"
					
					resultString = xEl.Value

				End If
				
			Next


			'' test if equal

			Assert.Equal(refString,resultString)

		End Sub

        '<Fact>
        Sub TestXElementMethods()

			' first we setup the reference
			Dim refString As String
			Dim resultString As String

			refString = "Water"

			resultString = "0"
			' second we setup the interfaces for IXmlLibLoader
			Dim xmlLibLoaderObj As IXmlLibLoader
			Dim xDoc As XDocument
			
			xmlLibLoaderObj = new dwSimXmlLibBruteForce

			xDoc = xmlLibLoaderObj.getXDoc()
			'Console.WriteLine(xDoc)



			For Each element As XElement in xDoc.Elements()
				Console.WriteLine(element)
			Next

			For Each element As XElement in xDoc.Elements().Elements().Elements("Name")
				Console.WriteLine(element.Name)
				Console.WriteLine(element.Value)
			Next

			' lastly we assert equal to test

			For Each element As XElement in xDoc.Elements().Elements().Elements("Name")
				If element.Value="Water"

					resultString = element.Value
				ElseIf element.Value="water"
					
					resultString = element.Value

				End If
			Next


			Assert.Equal(refString,resultString)

        End Sub


		'<Fact>
		Sub TestXmlFileString()

			'' the first part tries the fileSystemFilePath Implementation
			' there should be a 
			Dim filePathStringObj As IXmlFilePathString
			filePathStringObj = new fileSystemFilePathLoader

			Dim resultString As String

			Try
			    resultString = filePathStringObj.getCurrentFilePath()
			Catch ex As Exception
			    Console.WriteLine(ex.Message)
			End Try


			filePathStringObj = Nothing

			'' now for the second implementation

			filePathStringObj = new systemIODirectoryFilePathLoader

			resultString = filePathStringObj.getCurrentFilePath()

			Console.WriteLine(resultString)


			'' now for the third implementation
			
			filePathStringObj = new assemblyFilePathLoader
			resultString = filePathStringObj.getCurrentFilePath()
			Console.WriteLine(resultString)




		End Sub

		'<Fact>
		Sub IXmlDataMethodsTest

			Dim xmlDataObj As IXmlData

			'dwSimComponentXmlData implementation test

			xmlDataObj = new dwSimComponentXmlData
			xmlDataObj.loadXDoc()
			Console.WriteLine(xmlDataObj.xDoc)
			xmlDataObj.Dispose()
			

		End Sub

		'<Fact>
		Sub IXmlLibLoaderMethodsTest
			' just want to check if the methods are working 
			' properly
			'

			Dim xmlLibLoaderObj As IXmlLibLoader
			Dim xDoc As XDocument
			Dim xmlDoc As xmlDocument
			
			xmlLibLoaderObj = new dwSimXmlLibBruteForce

			xDoc = xmlLibLoaderObj.getXDoc()
			Console.WriteLine(xDoc)

			xmlDoc = xmlLibLoaderObj.getXmlDoc()
			Console.WriteLine(xmlDoc)

			xmlLibLoaderObj.Dispose()

		End Sub

		'<Fact>
		Sub IXmlFilePathStringTest

			Dim typeMe As Type
			typeMe = Me.GetType

			Dim assem As System.Reflection.Assembly
			assem = System.Reflection.Assembly.GetAssembly(typeMe)

			Console.WriteLine(assem.Location)

		End Sub




    End Class

End Namespace

