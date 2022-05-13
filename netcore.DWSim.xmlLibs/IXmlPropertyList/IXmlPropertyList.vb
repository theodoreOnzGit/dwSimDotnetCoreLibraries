Imports System.Xml
Imports System.Xml.Linq
Imports System

Imports System.Collections.Generic

Public Interface IXmlPropertyList

Inherits IList (Of String)


	Property _xmlLibrary As IXmlLibLoader

	Function injectLibrary(ByVal xmlLibrary As IXmlLibLoader)

    Function returnList() As IEnumerable(Of String)

End Interface

