# This is the IXmlLibrary Loader interface and implementation folder

The purpose of the IXmlLibLoader interface is to be able to 

supply an XmlDocument class return type based on an selected 
thermodynamics property library

There are several libraries i want to try using

chemsep1.xml
chemsep2.xml
dwsim.xml

## interface structure

so the user would select one of the above libraries
and the class would return an XmlDocumentObject

the libraries will be selected via an dependency injection

the class would then have the filepath of the xml library hardcoded in
load the appropriate xml library and then return the XmlDocument

the return types are XDocument of xmlLibrary
and XmlDocument of the xmlLibrary

## implementations

dwSimXmlLibLoader

## tests

at the end of the day, i want an xUnit test to deliver the following:

1) a fact test that is able to extract the string for the name water
2) a theory test that is able to extract the boiling points of nitrogen, water
and benzene

from the dwsim library

water boiling point: 313.15 K
benzene boiling point: 409.3 K
nitrogen boiling point: 77.344 K





