Imports System
Imports Xunit
Imports netcore.DWSim.xmlLibs


Imports System.Xml
Imports System.Xml.Linq

Namespace UnitTests.netcore.DWSim.xmlLibs
    Public Class UnitTest1

        <Fact>
        Sub TestSub()

		Dim xmlLibLoader As IXmlLibLoader
		
		xmlLibLoader = new dwSimXmlLibLoader
		
		Dim xmlDoc As XmlDocument

		xmlDoc = xmlLibLoader.getXmlDoc()

		Console.WriteLine(xmlDoc)


        End Sub


    End Class
End Namespace

