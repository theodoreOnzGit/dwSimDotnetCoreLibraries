Imports System
Imports Xunit
Imports theoOng.netcore.DWSim.xmlLibs

Namespace UnitTests.netcore.DWSim.xmlLibs

    Public Class UnitTestIXmlLibrarySelector


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

