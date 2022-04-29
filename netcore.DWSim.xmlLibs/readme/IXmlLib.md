# IXmlReader

  - inputs

    - fluid type

    - desired Quantity list

  - outputs

    - IEnumerable of EngineeringUnits quantities

  - dependencies

    - engineeringUnits Nuget Package

  - implementations

    - 

# IXmlLibs

  - inputs

    - fluid type (string or enum)

    - desired property/properties (string or enum)

    - fluid conditions

      - Temperature (double)

      - Pressure (double)

    - Desired Library (should be optional, otherwise default to some value)

  - outputs

    - desired quantity list (IEnumerable of Engineering Units)

      - Ideal Gas Heat Capacity

      - Viscosity

    - List of Components (Ienumerable of string)

    - List of Available Properties (IEnumerable of string)

    - List of Available xml Libraries (IEnumerable of String)

  - dependencies

  - implementations

    - implementation1

      - dependencies

        - IXmlComponentList

        - IXmlReader

  - tests

# IXmlComponentList

  - inputs

    - Desired Library

  - outputs

    - ListOfComponents (IEnumerable of String)

  - dependencies

    - system.collections

    - IXmlLibLoader

  - implementations

    - DWSimXmlComponentList

      - Method: the xmlComponentList using ChildNodes method

        - Description: takes in the XmlDocument Object and returns

# IXmlLibLoader

  - inputs

  - outputs

    - XDocument of xmlLibrary

    - XmlDocument of xmlLibrary

  - dependencies

  - implementations

    - dwSimXmlLibLoader Class

      - Dependencies

        - IXmlFilePathString

    - dwSimXmlLibBruteForce Class

      - description

        - this class uses brute force to bring in the xml file, ie copy and paste the xml file into a visual basic, define the whole thing as a string and return it

      - dependencies

        - IXmlData

  - tests

    - extract the name water using a fact test

    - extract boiling point of Nitrogen, Water and benzene in Kelvin using a theory test

# IXmlFilePathString

  - inputs

  - outputs

    - filePathForXmlLibrary

  - implementations

    - XmlFileRelativeFilePath (Incomplete)

      - description: this is one attempt to return the xmlFilePath based on the directories relative to the dll library, 

      - issues: 

        - Could not find elegant solution file path relative to vbproj folder (27 apr 2022)

  - dependencies

    - inherits: IDisposable

      - why? Always give yourself the option to delete the object if you need to

      - doesn't really do anything in this case, memory is pretty clean here

  - tests

# IXmlData

  - inputs

  - outputs

    - xDoc of xmldata

  - implementations

  - dependencies

    - inherits: IDisposable

      - why? Xmldata is very memory intensive

      - always give a good way of disposing of this

  - tests

