Imports System
Imports Xunit
Imports Xunit.Abstractions


'' this file contains classes which help with dotnet output for xunit in windows
' the main issue is that Console.WriteLine for debugging in dotnet test
' does not work in windows in that no print output is given
'https://lifesaver.codes/answer/net-core-tests-produce-no-output-1141 

' the answer was given in the above website
' one needs to use the ITestOutputHelper via depdendency injection

' to help with this issue, the idea is to make an abstract class
' otherwise known as "MustInherit"
' for convenience run the following when doing Xunit
' dotnet watch test --logger "console;verbosity=detailed"

' after that the _output property can be used to print output in Xunit Tests



Namespace UnitTests.netcore.DWSim.xmlLibs

	Public MustInherit Class testOutputHelper

	Public Property _output As ITestOutputHelper

		Public Sub New(outputHelper As ITestOutputHelper)

			Me._output = outputHelper

		End Sub

		Public Sub cout(ByVal text As String)
			Console.WriteLine(text)
			Me._output.WriteLine(text)
		End Sub

	End Class


End Namespace

