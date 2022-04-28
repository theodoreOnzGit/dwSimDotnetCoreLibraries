Imports System
Imports System.Reflection

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
		assem = Assembly.GetAssembly(typeMe)

		return assem.Location


	End Function

	Public Sub Dispose() Implements IDisposable.Dispose

		' this first part disposes the object
		' if there are any objects called in this class that need disposing
		' this second part tells the garbage collector (GC) that the object
		' is disposed

		' this is optional:
		' GC.Collect

	End Sub

End Class
