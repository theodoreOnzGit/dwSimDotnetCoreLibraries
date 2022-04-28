Imports System
Imports System.Reflections

Public Class assemblyFilePathLoader

Implements IXmlFilePathString


    Public Function getXmlFilePath() As String Implements IXmlFilePathString.getXmlFilePath

		throw new NotImplementedException()

	End Function

	Public Function getCurrentFilePath() As String Implements IXmlFilePathString.getCurrentFilePath


		' first i instantiate a type variable
		' to store the type of the current class
		Console.WriteLine("this class (assmeblyFilePathLoader)  is under construction")
		Console.WriteLine("don't use it yet")

		Dim typeMe as Type
		typeMe = Me.GetType

		Dim assem As System.Reflection.Assembly


		assem = System.Reflection.Assembly.GetAssembly(typeMe)

		return assem.GetExecutingAssembly().Location

		


	End Function


End Class
