Imports System.Xml
Imports System.Xml.Linq
Imports System

Imports System.Collections.Generic



Public Class dwSimXmlPropertyList_May2022

Inherits List (Of String)

Implements IXmlPropertyList

	Property _xmlLibrary As IXmlLibLoader Implements IXmlPropertyList._xmlLibrary

	
	Public Sub New()
	End Sub

	Function injectLibrary(ByVal xmlLibrary As IXmlLibLoader) Implements IXmlPropertyList.injectLibrary
		Me._xmlLibrary = xmlLibrary
	End Function



	Function returnList() As IEnumerable (Of String) Implements IXmlPropertyList.returnList

		If  _xmlLibrary Is Nothing
			throw new InvalidOperationException("please use injectLibrary to inject xmlLibLoader first")
		End If

		'' first i clear the list
		Me.Clear()
		Dim xmlData As XDocument
		xmlData = _xmlLibrary.getXDoc()

		Dim xElementList as IEnumerable(Of XElement)

		xElementList = xmlData.Elements().Elements()


		Dim waterComponentXElement As IEnumerable(Of XElement)

		waterComponentXElement = From el In xElementList
		Where el.Element("Name") = "Water"
		Select el



		'' after i have the Xelement for water
		'i can then extract the child elements from them
		'and put their names into a List of string
		For Each element As XElement in waterComponentXElement.Elements()
			Me.Add(element.Name.ToString())
		Next

		return Me

	End Function



End Class

