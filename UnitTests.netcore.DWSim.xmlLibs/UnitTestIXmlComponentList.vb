Imports System
Imports Xunit
Imports theoOng.netcore.DWSim.xmlLibs

Imports System.Xml.Linq
Imports System.Linq

Namespace UnitTests.netcore.DWSim.xmlLibs

    Public Class UnitTestIXmlComponentList

	    <Fact>
		Sub TestIXmlComponentList_exceptionTest()

			' this is to test if the xmlLibSelector class
			' throws the correct exception
			' if i give it a random gibberish library

			Dim xmlComponentListObj As IXmlComponentList
			
			' now we initiate the xmlComponentListObj with dependency injection
			Dim xmlLibSelector As IXmlLibrarySelector
			xmlLibSelector = new XmlLibSelector_may2022

			xmlComponentListObj = new XmlComponentList_v1(xmlLibSelector)


			Assert.Throws(Of IndexOutOfRangeException)(Sub() xmlComponentListObj.getComponentList("asbubskdufn"))


		End Sub



		'<Theory>
		<InlineData()>
		Sub TestIXmlComponentList_exceptionMessageManual()

			'' this test is to check what the exception message is manually
			'
			Dim xmlComponentListObj As IXmlComponentList
			
			' now we initiate the xmlComponentListObj with dependency injection
			Dim xmlLibSelector As IXmlLibrarySelector
			xmlLibSelector = new XmlLibSelector_may2022

			xmlComponentListObj = new XmlComponentList_v1(xmlLibSelector)


			'' Act
			xmlComponentListObj.getComponentList("asbubskdufn")
			'' manually i see it throws the correct exception
			' with the correct message

		End Sub

	    <Theory>
		<InlineData()>
		Sub TestIXmlComponentList_returnAllComponentsDWSIMxml()


			'' Setup
			Dim xmlLibLoaderObj As IXmlLibLoader
			Dim xDoc As XDocument
			xmlLibLoaderObj = new dwSimXmlLibBruteForce
			xDoc = xmlLibLoaderObj.getXDoc()

			Dim refComponentList As List (Of String)
			refComponentList = new List (Of String)
			' this first part returns a list of all the 
			' components by filtering out the elements by name

			For Each element As XElement in xDoc.Elements().Elements().Elements("Name")
				refComponentList.Add(element.Value)
			Next
			' to compare for equality, i need to change this list to an enumerable

			Dim refComponentEnumerable As IEnumerable (Of String)
			refComponentEnumerable = refComponentList
			
			' now i have build up my reference component list, i need a list
			' returned by IXmlComponentList getComponentList

			Dim testComponentEnumerable As IEnumerable (Of String)
			Dim xmlComponentListObj As IXmlComponentList
			
			' now we initiate the xmlComponentListObj with dependency injection
			Dim xmlLibSelector As IXmlLibrarySelector
			xmlLibSelector = new XmlLibSelector_may2022

			xmlComponentListObj = new XmlComponentList_v1(xmlLibSelector)

			'' Act
			testComponentEnumerable = xmlComponentListObj.getComponentList("dwsim")

			Dim AreListsEqual As Boolean

			'' Assert
			'
			'' the DeepEquals function or method
			'comes from System.Xml.Linq and is a method under XNode
			' it cannot be used for lists, only XNodes
			' but Enumerable.SequenceEqual under System.Linq is ok
			AreListsEqual = Enumerable.SequenceEqual(refComponentList,testComponentEnumerable)
			Assert.True(AreListsEqual)

		End Sub

        '<Fact>
        Sub TestIXmlComponentList_ReturnComponentsManually()

			'' Setup

			Dim xmlLibLoaderObj As IXmlLibLoader
			Dim xDoc As XDocument
			xmlLibLoaderObj = new dwSimXmlLibBruteForce
			xDoc = xmlLibLoaderObj.getXDoc()
			'' Act

			Dim componentList As List (Of String)
			componentList = new List (Of String)
			' this first part returns a list of all the 
			' components by filtering out the elements by name

			For Each element As XElement in xDoc.Elements().Elements().Elements("Name")
				'Console.WriteLine(element.Name)
				Console.WriteLine(element.Value)
				componentList.Add(element.Value)
			Next

			' this next part prints out the content of the list
			For Each component In componentList

				Console.WriteLine(component)

			Next
			'' Assert (NA for manual test)
			'
		End Sub


    End Class

End Namespace

