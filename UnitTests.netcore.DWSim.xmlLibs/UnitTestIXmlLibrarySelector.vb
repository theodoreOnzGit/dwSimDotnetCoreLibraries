Imports System
Imports Xunit
Imports theoOng.netcore.DWSim.xmlLibs

Namespace UnitTests.netcore.DWSim.xmlLibs

    Public Class UnitTestIXmlLibrarySelector


        <Fact>
        Sub TestSub()

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

