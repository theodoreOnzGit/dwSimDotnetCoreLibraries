Public Interface IXmlFilePathString
'' it's always good practice to inherit an IDisposable interface
' so that we ensure that we can delete the object if we need to
'
Inherits IDisposable

    Function getXmlFilePath() As String

	Function getCurrentFilePath() As String

End Interface



