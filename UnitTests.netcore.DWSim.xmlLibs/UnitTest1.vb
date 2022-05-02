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



        <Fact>
        Sub TestIXmlLibLoader_loadWaterString()

			Dim refString As String
			refString = "Water"

			'' then we do our code here
			Dim resultString As String

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

			' second we setup the interfaces for IXmlLibLoader
			Dim xmlLibLoaderObj As IXmlLibLoader
			Dim xDoc As XDocument
			Dim xmlDoc As xmlDocument
			
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

