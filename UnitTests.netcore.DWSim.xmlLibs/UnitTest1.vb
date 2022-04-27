Imports System
Imports Xunit
Imports netcore.DWSim.xmlLibs


Imports System.Xml
Imports System.Xml.Linq


'' for Assmebly references
Imports System.Reflection


'' for FileSystem
Imports Microsoft.VisualBasic.FileIO


'' for Directory class
Imports System.IO

Namespace UnitTests.netcore.DWSim.xmlLibs
    Public Class UnitTest1

        <Fact>
        Sub TestSub()

		Dim xmlLibLoader As IXmlLibLoader
		
		xmlLibLoader = new dwSimXmlLibLoader
		
		Dim xmlDoc As XmlDocument
		

		Dim typeXmlLib As Type

		typeXmlLib = xmlLibLoader.GetType

		Dim assem As Assembly 

		assem = Assembly.GetAssembly(typeXmlLib)

		Console.WriteLine(assem)
		Console.WriteLine(assem.GetManiFestResourceStream("DWSIM.Thermodynamics.dwsim.xml"))
		Console.WriteLine("assembly location")
		Console.WriteLine(assem.GetExecutingAssembly().Location)

		Dim fileSysObj As FileSystem
		fileSysObj = new FileSystem

		Console.WriteLine(FileSysObj.CurrentDirectory)

		Console.WriteLine(" ")
		Console.WriteLine("AppDomain method")

		Dim path as String = AppDomain.CurrentDomain.BaseDirectory
		Console.WriteLine(path)




		'xmlDoc = xmlLibLoader.getXmlDoc()

		'Console.WriteLine(xmlDoc)


        End Sub


    End Class
End Namespace

