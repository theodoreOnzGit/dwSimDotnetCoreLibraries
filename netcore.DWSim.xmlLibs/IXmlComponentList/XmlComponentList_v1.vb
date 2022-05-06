Public Class XmlComponentList_v1

Implements IXmlComponentList


    Private Property _xmlLibrarySelector As IXmlLibrarySelector

    ' Constructor for dependency Injection 
	' not quite dependency injection
	' but it should be easy to switch with this
	' structure
    Public Sub New(xmlLibrarySelector As IXmlLibrarySelector)

		Me._xmlLibrarySelector = xmlLibrarySelector
		
	End Sub



    Public Function getComponentList(ByVal desiredLibrary As String) As IEnumerable (Of String) Implements IXmlComponentList.getComponentList


		'' if we run the function more than once, 
		'i want to be able to dipose and delete _xmlLibLoader


		' first we return an instance of the entire xmlLibrary xDocument
		' by first returning the instance of the _xmlLibLoader
		Dim xmlLibLoader As IXmlLibLoader

		' exception management step 1, try to catch the invalid library name exception
		'
		Try
		    xmlLibLoader = Me._xmlLibrarySelector.getXmlLibLoader(desiredLibrary)
		Catch ex As IndexOutOfRangeException
		    Dim errorMessage As String
			errorMessage = "IXmlComponentList:XmlComponentList_v1 :"+ex.Message
			throw new IndexOutOfRangeException(errorMessage)			
	    End Try

		Dim xDoc As XDocument
		xDoc = xmlLibLoader.getXDoc()

		' memory management 1, dispose of xmlLibLoader and delete it
		''  after we are done with xmlLibLoader, we dispose of it and clear it
		' immediately
		xmlLibLoader.Dispose()
		xmlLibLoader = Nothing


		'' second, with this new xDoc, we then build a new list of String

		Dim componentList As List (Of String)
		componentList = new List (Of String)


		'' thirdly, we build a new list

		For Each element As XElement in xDoc.Elements().Elements().Elements("Name")
			componentList.Add(element.Value)
		Next

		'' memory management 2 - delete xDoc

		xDoc = Nothing

		'' next we return this list
		' bear in mind, the return type is IEnumerable, not List
		' however, List types implement IEnumerable

		return componentList
		
		'' next thing to think about is exception behaviour then memory management
		' so firstly, let's dispose of the libLoader Object
		' and then delete the xDoc (it's kind of manual, and not really needed
		' but if we wanna be judicious, we can do so)
		' these come under memory management steps 1 and 2
		' (see above steps 1 and 2)
		'
		' then let's do exception management

	End Function

	' destructor or finaliser
	' this frees up memory in event the object is destroyed
	' or the garbage collector is called to finalize
	' this is for memory management

	Protected Overrides Sub Finalize()

		Me._xmlLibrarySelector = Nothing

	End Sub

End Class
