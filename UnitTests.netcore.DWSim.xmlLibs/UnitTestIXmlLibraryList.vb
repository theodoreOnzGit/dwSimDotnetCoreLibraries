Imports System
Imports Xunit
Imports netcore.DWSim.xmlLibs

Imports System.Xml
Imports System.Xml.Linq


Namespace UnitTests.netcore.DWSim.xmlLibs

    Public Class UnitTestIXmlLibraryList

        <Fact>
        Sub TestSub()

		End Sub

        '<Fact>
        Sub TestListAndTuple()

			Dim tuple As (a As String, b As Double)

			' this code just shows how to play with tuples and lists
			' in visual basic, not C#,
			' i will not run this as part of standard tests

			tuple.a = "water boiling point"
			tuple.b = 373.15

			Dim list As List(Of (a As String, b As Double))

			list = new List(Of (a As String, b As Double))

			list.Add(tuple)


			tuple.a = "nitrogen boiling point"
			tuple.b = 77.36

			list.Add(tuple)

			For Each item In List

				Console.WriteLine(item)

			Next




		End Sub

    End Class

End Namespace

