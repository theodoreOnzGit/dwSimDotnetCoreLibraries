Imports System
Imports Xunit
Imports theoOng.netcore.DWSim.xmlLibs

Namespace UnitTests.netcore.DWSim.xmlLibs

    Public Class UnitTestIXmlLibrarySelector

		<Theory>
		<InlineData(373.15,"Water","dwSIM")>
		<InlineData(77.344,"Nitrogen","dwsim")>
		<InlineData(353.3,"Benzene","DWSIM")>
		Sub TestIXmlLibrarySelector_loadBoilingPoints(ByVal refTemperature As Double,
			ByVal componentName As String, ByVal libraryName As String)

			
			'This test takes in a reference temperature (boiling Point)
			'of a said component as a double
			'and the component name 
			' And then performs a comparison test (Assert)
			' I'm doing the same test as the unit test, for IXmlLibLoader
			' but changing the way that the xmlLibLoader is loaded using
			' getXmlLibLoader

			Dim resultTemperature As Double
			Dim xmlLibLoader as IXmlLibLoader
			Dim xmlLibrarySelector As IXmlLibrarySelector

			xmlLibrarySelector = new XmlLibSelector_may2022
			xmlLibLoader = xmlLibrarySelector.getXmlLibLoader("dwsIm")

			Dim xmlData As XDocument
			xmlData = xmlLibLoader.getXDoc()


			Dim xElementList as IEnumerable(Of XElement)

			xElementList = xmlData.Elements().Elements()


			Dim ComponentXElement As IEnumerable(Of XElement)

			ComponentXElement = From el In xElementList
									Where el.Element("Name") = componentName 
									Select el


			Dim boilingPoint As String

			boilingPoint = "0"


			'' Act test, use the function to return the value
			For Each el in ComponentXElement.Elements()
				If el.Name = "Normal_Boiling_Point"
					boilingPoint = el.Value
				End If
			Next



			resultTemperature = Convert.ToDouble(boilingPoint)


			'' Assert test


			Assert.Equal(refTemperature,resultTemperature)

		End Sub
	    <Fact>
		Sub IXmlLibrarySelector_executeMoreThanOnceTest()

			
			Dim resultLib As IXmlLibLoader


			Dim xmlLibrarySelector As IXmlLibrarySelector
			xmlLibrarySelector = new XmlLibSelector_may2022

			resultLib = xmlLibrarySelector.getXmlLibLoader("dwsIm")
			resultLib = xmlLibrarySelector.getXmlLibLoader("dwsIm")
			resultLib = xmlLibrarySelector.getXmlLibLoader("dwsIm")

			xmlLibrarySelector = Nothing

		End Sub







	    <Fact> 
		Sub IXmlLibrarySelector_ExceptionTest()
		
			'' Setup

			Dim xmlLibrarySelector As IXmlLibrarySelector
			xmlLibrarySelector = new XmlLibSelector_may2022

			'' Act
			'' Assert
			' credit to: https://groups.google.com/g/nunit-discuss/c/STiMNTVxoPE
			Assert.Throws(Of IndexOutOfRangeException)(Sub() xmlLibrarySelector.getXmlLibLoader("gibberish"))

	    End Sub

        <Fact>
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

