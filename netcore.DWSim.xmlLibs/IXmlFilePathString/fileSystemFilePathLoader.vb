Imports System
' Microsoft.VisualBasic namespace does not exist
'Imports Microsoft.VisualBasic.FileIO

Public Class fileSystemFilePathLoader

Implements IXmlFilePathString


    Public Function getXmlFilePath() As String Implements IXmlFilePathString.getXmlFilePath

		throw new NotImplementedException()

	End Function

	Public Function getCurrentFilePath() As String Implements IXmlFilePathString.getCurrentFilePath


		' first i instantiate a type variable
		' to store the type of the current class
		Console.WriteLine("this class (fileSystemFilePathLoader)  is under construction")
		Console.WriteLine("don't use it yet")
		'' note the microsoft.visualbasic.FileIO namespace
		' is NOT available for netstandard2.0

		'Dim fileSysObj As FileSystem
		'fileSysObj = new FileSystem

		'return FileSysObj.CurrentDirectory

		throw new NotImplementedException()

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
