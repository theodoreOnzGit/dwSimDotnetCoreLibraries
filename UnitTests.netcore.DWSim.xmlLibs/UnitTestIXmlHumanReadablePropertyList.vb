Imports System
Imports Xunit
Imports theoOng.netcore.DWSim.xmlLibs

Imports System.Xml
Imports System.Xml.Linq

Imports Xunit.Abstractions


Namespace UnitTests.netcore.DWSim.xmlLibs

    Public Class UnitTestIXmlHumanReadablePropertyList
	' ==== this part helps to inject the output helper so that one can write output ==='
	' only for windows usage of dotnet build
	Inherits testOutputHelper

		Public Sub New(outputHelper As ITestOutputHelper)
			MyBase.New(outputHelper)
		End Sub


        <Fact>
        Sub TestSub()
		End Sub

		<Fact>
		Sub TestIXmlHumanReadablePropertyList_ShouldGetPropertyMenu
			'' Setup

			Dim xmlLibLoader as IXmlLibLoader
			'' please declare new object later
			xmlLibLoader = new dwSimXmlLibBruteForce
			Dim dwSimPropertyList As IXmlHumanReadablePropertyList

			dwSimPropertyList = new dwSimXmlHumanReadablePropertyList_May2022
			dwSimPropertyList.injectLibrary(xmlLibLoader)


			Dim resultEnumerable As IEnumerable (Of String)
			Dim refEnumerable As IEnumerable(Of String)
			Dim desiredQuantity As String
			desiredQuantity = "propertyMenu"

			refEnumerable = Me.returnRefEnumerable(desiredQuantity)
			'' this part checks if refEnumerable is null
			If refEnumerable Is Nothing
				throw new InvalidOperationException()
			End If
			If Enumerable.Count(refEnumerable) = 0
				throw new InvalidOperationException()
			End If
			'' Act
			resultEnumerable = dwSimPropertyList.getMenu()
			'' Assert
			Dim areEnumerablesEqual As Boolean
			areEnumerablesEqual = Enumerable.SequenceEqual(refEnumerable,resultEnumerable)
			Assert.True(areEnumerablesEqual)


		End Sub

		<Theory>
		<InlineData("LiquidViscosity")>
		<InlineData("boilingPoint")>
		<InlineData("enthalpyOfVaporisation")>
		<InlineData("criticalProperties")>
		<InlineData("compoundName")>
		<InlineData("vaporPressure")>
		<InlineData("formationProperties")>
		<InlineData("chaoSeader")>
		<InlineData("molecularProperties")>
		<InlineData("rackettCompressibility")>
		<InlineData("UNIQUAC")>
		<InlineData("UNIFAC")>
		<InlineData("IsPetroleumFraction")>
		Sub TestIXmlHumanReadablePropertyList_ShouldReturnLists(desiredQuantity As String)

			''Setup
			Dim refEnumerable As IEnumerable (Of String)
			Dim resultEnumerable As IEnumerable (Of String)
			refEnumerable = Me.returnRefEnumerable(desiredQuantity)
			'' this part checks if refEnumerable is null
			If refEnumerable Is Nothing
				throw new InvalidOperationException()
			End If
			If Enumerable.Count(refEnumerable) = 0
				throw new InvalidOperationException()
			End If
			'' Act
			resultEnumerable = Me.retrieveDesiredQuantity(desiredQuantity)
			'' Assert
			Dim areEnumerablesEqual As Boolean
			areEnumerablesEqual = Enumerable.SequenceEqual(refEnumerable,resultEnumerable)
			Assert.True(areEnumerablesEqual)
		End Sub


		'' here is a case structure to return my ref enumerables
		'

		Public Function returnRefEnumerable(ByVal desiredQuantity As String) As IEnumerable (Of String)
			Dim refEnumerable As IEnumerable (Of String)
			Dim refList As IList (Of String)
			refList = new List (Of String)

			Select desiredQuantity.ToLower()
				Case "LiquidViscosity".ToLower()
					refList.Add("Liquid_Viscosity_Const_A")
					refList.Add("Liquid_Viscosity_Const_B")
					refList.Add("Liquid_Viscosity_Const_C")
					refList.Add("Liquid_Viscosity_Const_D")
					refList.Add("Liquid_Viscosity_Const_E")
				Case "boilingPoint".ToLower()
					refList.Add("Normal_Boiling_Point")
				Case "enthalpyOfVaporisation".ToLower()
					refList.Add("HVapA")
					refList.Add("HVapB")
					refList.Add("HvapC")
					refList.Add("HVapD")
					refList.Add("HvapTmin")
					refList.Add("HvapTMAX")
				Case "criticalProperties".ToLower()
					refList.Add("Critical_Temperature")
					refList.Add("Critical_Pressure")
					refList.Add("Critical_Volume")
					refList.Add("Critical_Compressibility")
				Case "compoundName".ToLower()
					Dim checkList As List (Of String) = new List (Of String)
					checkList.Add("Name")
					checkList.Add("CAS_Number")
					checkList.Add("Formula")
					checkList.Add("COSMODBName")
					checkList.Add("ID")
					refList=checkList
				Case "vaporPressure".ToLower()
					Dim constA As String = "DIPPR_Vapor_Pressure_Constant_A"
					Dim constB As String = "DIPPR_Vapor_Pressure_Constant_B"
					Dim constC As String = "DIPPR_Vapor_Pressure_Constant_C"
					Dim constD As String = "DIPPR_Vapor_Pressure_Constant_D"
					Dim constE As String = "DIPPR_Vapor_Pressure_Constant_E"
					Dim tmin As String = "DIPPR_Vapor_Pressure_TMIN"
					Dim tmax As String = "DIPPR_Vapor_Pressure_TMAX"

					Dim checkList As List (Of String) = new List (Of String)
					checkList.Add(constA)
					checkList.Add(constB)
					checkList.Add(constC)
					checkList.Add(constD)
					checkList.Add(constE)
					checkList.Add(tmin)
					checkList.Add(tmax)
					refList=checkList
				Case "formationProperties".ToLower()
					Dim checkList As List (Of String) = new List (Of String)
					checkList.Add("IG_Entropy_of_Formation_25C")
					checkList.Add("IG_Enthalpy_of_Formation_25C")
					checkList.Add("IG_Gibbs_Energy_of_Formation_25C")
					refList = checkList
				Case "chaoSeader".ToLower()
					Dim checkList As List (Of String) = new List (Of String)
					checkList.Add("CS_Acentric_Factor")
					checkList.Add("CS_Solubility_Parameter")
					checkList.Add("CS_Liquid_Molar_Volume")
					refList = checkList
				Case "molecularProperties".ToLower()
					Dim checkList As List (Of String) = new List (Of String)
					checkList.Add("Molar_Weight")
					checkList.Add("elements")
					checkList.Add("Acentric_Factor")
					checkList.Add("Dipole_Moment")
					checkList.Add("ID")
					refList = checkList
				Case "rackettCompressibility".ToLower()
					Dim checkList As List (Of String) = new List (Of String)
					checkList.Add("Z_Rackett")
					refList = checkList
				Case "IsPetroleumFraction".ToLower()
					Dim checkList As List (Of String) = new List (Of String)
					checkList.Add("isPf")
					refList = checkList
				Case "UNIQUAC".ToLower()
					Dim checkList As List (Of String) = new List (Of String)
					checkList.Add("UNIQUAC_r")
					checkList.Add("UNIQUAC_q")
					refList = checkList
				Case "UNIFAC".ToLower()
					Dim checkList As List (Of String) = new List (Of String)
					checkList.Add("UNIFAC")
					refList = checkList
				Case "propertyMenu".ToLower()
					Dim checkList As List (Of String) = new List (Of String)
					checkList.Add("miscList")
					checkList.Add("heatCapacity")
					checkList.Add("liquidViscosity")
					checkList.Add("boilingPoint")
					checkList.Add("enthalpyOfVaporisation")
					checkList.Add("criticalProperties")
					checkList.Add("vaporPressure")
					checkList.Add("compoundName")
					checkList.Add("formationProperties")
					checkList.Add("chaoSeader")
					checkList.Add("molecularProperties")
					checkList.Add("rackettCompressibility")
					checkList.Add("UNIQUAC")
					checkList.Add("UNIFAC")
					checkList.Add("IsPetroleumFraction")

					refList = checkList
			End Select
			refEnumerable = refList
			return refEnumerable
		End Function



		<Fact>
		Sub TestIXmlHumanReadablePropertyList_ShouldReturnHeatCapacityList()
			''Setup
			Dim refList As IList (Of String)
			Dim refEnumerable As IEnumerable (Of String)

			refList = new List (Of String)
			refList.Add("Ideal_Gas_Heat_Capacity_Const_A")
			refList.Add("Ideal_Gas_Heat_Capacity_Const_B")
			refList.Add("Ideal_Gas_Heat_Capacity_Const_C")
			refList.Add("Ideal_Gas_Heat_Capacity_Const_D")
			refList.Add("Ideal_Gas_Heat_Capacity_Const_E")
			refEnumerable = refList

			'' Act
			Dim resultEnumerable As IEnumerable (Of String)
			resultEnumerable = Me.retrieveDesiredQuantity("heatcapacity")
			'
			'' Assert
			
			Dim areEnumerablesEqual As Boolean
			areEnumerablesEqual = Enumerable.SequenceEqual(refEnumerable,resultEnumerable)
			Assert.True(areEnumerablesEqual)
		End Sub

		Function retrieveDesiredQuantity(ByVal desiredQuantity As String) As IEnumerable (Of String)
			Dim xmlLibLoader as IXmlLibLoader
			'' please declare new object later
			xmlLibLoader = new dwSimXmlLibBruteForce
			Dim dwSimPropertyList As IXmlHumanReadablePropertyList

			dwSimPropertyList = new dwSimXmlHumanReadablePropertyList_May2022
			dwSimPropertyList.injectLibrary(xmlLibLoader)

			Dim testEnumerable As IEnumerable (Of String)

			testEnumerable = dwSimPropertyList.returnList(desiredQuantity)

			return testEnumerable

		End Function


        '<Theory>
		<InlineData("heatcapacity")>
		<InlineData("Ideal_Gas_Heat_Capacity_Const_A")>
		<InlineData("liquidviscosity")>
		<InlineData("liquid_viscosity_const_e")>
		<InlineData("liquid_viscosity_const_b")>
		<InlineData("boilingPoint")>
		<InlineData("normal_boiling_point")>
		<InlineData("hvap")>
		<InlineData("hvapA")>
		<InlineData("nonsense")>
		<InlineData("miscList")>
		<InlineData("vaporPressure")>
		<InlineData("criticalProperties")>
		<InlineData("critical_volume")>
		<InlineData("compoundname")>
		<InlineData("ID")>
		<InlineData("DIPPR_Vapor_pressure_constant_A")>
		<InlineData("chaoseader")>
		<InlineData("molecularproperties")>
		<InlineData("Z_Rackett")>
		<InlineData("UNIQUAC")>
		<InlineData("UNIFAC")>
		<InlineData("IsPf")>
		<InlineData("")>
        Sub sandbox(desiredQuantity As String)

			Me.cout(VbCrLf)
			Me.cout("Test for:" & desiredQuantity & VbCrLf)


			Dim xmlLibLoader as IXmlLibLoader
			'' please declare new object later
			xmlLibLoader = new dwSimXmlLibBruteForce
			Dim dwSimPropertyList As IXmlHumanReadablePropertyList

			dwSimPropertyList = new dwSimXmlHumanReadablePropertyList_May2022
			dwSimPropertyList.injectLibrary(xmlLibLoader)

			Dim testEnumerable As IEnumerable (Of String)

			Try
				testEnumerable = dwSimPropertyList.returnList(desiredQuantity)
				For Each compoundProperty in testEnumerable
					Me.cout(compoundProperty)
				Next
				Catch ex As InvalidOperationException
					Me.cout(ex.Message)
				Assert.True(True)
			End Try


		End Sub

		<Fact>
		Sub TestIXmlPropertyList_ShouldProduceList()
			'' Setup
			Dim xmlLibLoader as IXmlLibLoader
			'' please declare new object later
			xmlLibLoader = new dwSimXmlLibBruteForce

			Dim xmlData As XDocument
			xmlData = xmlLibLoader.getXDoc()

			Dim xElementList as IEnumerable(Of XElement)

			xElementList = xmlData.Elements().Elements()


			Dim waterComponentXElement As IEnumerable(Of XElement)

			waterComponentXElement = From el In xElementList
									Where el.Element("Name") = "Water"
									Select el



			'' after i have the Xelement for water
			'i can then extract the child elements from them
			'and put their names into a List of string


			Dim refList as List(Of String)
			refList = new List(Of String)

			For Each element As XElement in waterComponentXElement.Elements()
				refList.Add(element.Name.ToString())
			Next

			Dim refEnumerable As IEnumerable(Of String)

			refEnumerable = refList


			' now i will setup the IXmlPropertyList
			Dim resultEnumerable As IEnumerable(Of String)
			Dim dwSimPropertyList As IXmlPropertyList

			dwSimPropertyList = new dwSimXmlPropertyList_May2022
			dwSimPropertyList.injectLibrary(xmlLibLoader)
			'' Act
			'

			resultEnumerable = dwSimPropertyList.returnList()
			'' Assert
			Dim areEnumerablesEqual As Boolean
			areEnumerablesEqual = Enumerable.SequenceEqual(refEnumerable,resultEnumerable)
			Assert.True(areEnumerablesEqual)
		End Sub

		'<Theory>
		<InlineData()>
		Sub sandboxDWSim() 
			'' first i want to get 
			' a list of all properties 
			' so i will load the water XElement first
			' for the dwsim database
			'
			Dim xmlLibLoader as IXmlLibLoader
			'' please declare new object later
			xmlLibLoader = new dwSimXmlLibBruteForce

			Dim xmlData As XDocument
			xmlData = xmlLibLoader.getXDoc()

			Dim xElementList as IEnumerable(Of XElement)

			xElementList = xmlData.Elements().Elements()


			Dim waterComponentXElement As IEnumerable(Of XElement)

			waterComponentXElement = From el In xElementList
									Where el.Element("Name") = "Water"
									Select el



			'' after i have the Xelement for water
			'i can then extract the child elements from them
			'and put their names into a List of string


			Dim nameList as List(Of String)
			nameList = new List(Of String)

			For Each element As XElement in waterComponentXElement.Elements()
				nameList.Add(element.Name.ToString())
			Next

			For Each propertyName As String in nameList
				Console.WriteLine(propertyName)
			Next

		End Sub



    End Class

End Namespace

