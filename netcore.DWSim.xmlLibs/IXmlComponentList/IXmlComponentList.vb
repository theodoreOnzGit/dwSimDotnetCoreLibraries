Imports System.Collections.Generic


Public Interface IXmlComponentList

    Function getComponentList(ByVal desiredLibrary As String) As IEnumerable (Of String)

End Interface
