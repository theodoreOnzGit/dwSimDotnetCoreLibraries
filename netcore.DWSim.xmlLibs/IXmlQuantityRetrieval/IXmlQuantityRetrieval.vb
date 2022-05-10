Imports System.Xml
Imports System.Xml.Linq
Imports System

Imports EngineeringUnits
Imports EngineeringUnits.Units

Public Interface IXmlQuantityRetrieval

Inherits IDisposable

    Property _xmlLibLoader As IXmlLibLoader

    Function returnQuantityList(ByVal desiredQuantity As String) As IEnumerable (Of Double)

    Function returnDimensionedQuantityList(ByVal desiredQuantity As String) As IEnumerable (Of BaseUnit)

    Sub injectLib(xmlLibLoaderObj As IXmlLibLoader)

    '' to be included: an input to load xml properties 

End Interface

