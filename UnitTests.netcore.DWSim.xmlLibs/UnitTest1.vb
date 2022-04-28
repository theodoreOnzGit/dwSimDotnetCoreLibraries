Imports System
Imports Xunit
Imports netcore.DWSim.xmlLibs

Imports System.Xml
Imports System.Xml.Linq


Namespace UnitTests.netcore.DWSim.xmlLibs

    Public Class UnitTest1

        <Fact>
        Sub TestSub()


        End Sub


		<Fact>
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

		<Fact>
		Sub IXmlDataMethodsTest

			Dim xmlDataObj As IXmlData

			'dwSimComponentXmlData implementation test

			xmlDataObj = new dwSimComponentXmlData
			xmlDataObj.loadXDoc()
			Console.WriteLine(xmlDataObj.xDoc)
			xmlDataObj.Dispose()
			

		End Sub

		<Fact>
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

		End Sub

    End Class

End Namespace

