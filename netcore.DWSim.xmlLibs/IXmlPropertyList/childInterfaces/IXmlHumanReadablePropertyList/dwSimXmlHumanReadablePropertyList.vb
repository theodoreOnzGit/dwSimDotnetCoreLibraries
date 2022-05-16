Imports System.Xml
Imports System.Xml.Linq
Imports System

Imports System.Collections.Generic




Public Class dwSimXmlHumanReadablePropertyList_May2022

Inherits dwSimXmlPropertyList_May2022

Implements IXmlHumanReadablePropertyList

	' the propertyMenu just displays the list of available properties the user can use
	Private Property propertyMenu As IEnumerable (Of String) Implements IXmlHumanReadablePropertyList.propertyMenu

	' it is a private property, needing the getMenu()
	' function to read it from the outside
	Public Function getMenu() As IEnumerable(Of String) Implements IXmlHumanReadablePropertyList.getMenu
		return Me.propertyMenu
	End Function


	'' this is where the user accesses the lists from outside
	Public Overloads Function returnList(ByVal desiredQuantity As String) As IEnumerable (Of String) Implements IXmlHumanReadablePropertyList.returnList
	'' first i clear the property List
		Me.propertyList = new List (Of String) 

		'' next i check if the desiredQuantity is some null value
		If desiredQuantity Is Nothing
			'' remember to put message here later
			throw new InvalidOperationException()
		End If
		If  _xmlLibrary Is Nothing
			throw new InvalidOperationException("please use injectLibrary to inject xmlLibLoader first")
		End If

		
		'' first i return a miscList, this will be a full copy of the
		' propertyList found
		Me.constructUnEditedMiscList()
		Me.constructHeatCapacityList(desiredQuantity)
		Me.constructLiquidViscosity(desiredQuantity)
		Me.constructBoilingPoint(desiredQuantity)
		Me.constructMiscList(desiredQuantity)
		Me.constructHVap(desiredQuantity)
		Me.constructCriticalProperties(desiredQuantity)
		Me.constructVaporPressure(desiredQuantity)
		Me.constructCompoundName(desiredQuantity)
		Me.constructFormationProperties(desiredQuantity)
		Me.constructChaoSeader(desiredQuantity)
		Me.constructMolecularProperties(desiredQuantity)
		Me.constructZRackett(desiredQuantity)
		Me.constructUNIQUAC(desiredQuantity)
		Me.constructUNIFAC(desiredQuantity)
		Me.constructIsPetroleumFraction(desiredQuantity)

		'' if after all the checks the propertyList
		'isn't populated, then something is wrong,
		'throw an exception
		If Me.propertyList.Count = 0

			'probably change this to out of range later
			Dim errorMsg as String
			errorMsg = "The quantity you entered :("+ desiredQuantity + ") does not exist" & VbCrLf
			errorMsg += "please select a valid entry from the following:" & VbCrLf
			errorMsg += VbCrLf
			For Each menuItem in Me.propertyMenu
				errorMsg += menuItem & VbCrLf
			Next
			
			errorMsg += VbCrLf
			errorMsg += "Thank you!" & VbCrLf


			throw new InvalidOperationException(errorMsg)

		End If

		
		return Me.propertyList
	End Function

	' the constructor constructs all the relevant lists needed 
	Public Sub New()
		Me.propertyList = new List(Of String)
		Me.constructMiscList()
		Me.constructHeatCapacityList()
		Me.constructLiquidViscosity()
		Me.constructBoilingPoint()
		Me.constructHVap()
		Me.constructCriticalProperties()
		Me.constructVaporPressure()
		Me.constructCompoundName()
		Me.constructFormationProperties()
		Me.constructChaoSeader()
		Me.constructMolecularProperties()
		Me.constructZRackett()
		Me.constructUNIQUAC()
		Me.constructUNIFAC()
		Me.constructIsPetroleumFraction()


		Me.propertyMenu = propertyList
		Me.propertyList = Nothing
	End Sub

	'' the propertyList list is used 
	' in the constructor to build up the property menu
	' after that it is cleared,
	' the rest of the time
	' the propertyList is an intermediate variable
	' to be returned and then cleared

	Private propertyList As IList (Of String)


	'' how i do my list is as follows:
	' i will just use individual Subs (void functions) to 
	' perform my nested if loop checks,
	' they will be overloads of my constructor
	' so that when i construct the list constructor
	'
	' i will also construct the appropriate
	' if loops inside the "case" structure
	' no need to do a list of tuple (string, List)
	' that's for loose coupling, i have tight coupling here

	'' here is Construct heat capacity list Sub (or void)
	' basically it checks if the desired quantity is equal to
	' any of the accepted keywords
	' then if so, the appropriate strings are added to the property list
	

	Private Sub constructHeatCapacityList()
		Me.propertyList.Add("heatCapacity")
	End Sub

	'' the following just provides nested if loops
	'
	Private Sub constructHeatCapacityList(ByVal desiredQuantity As String)
		'' first convert the string to lowercase
		desiredQuantity = desiredQuantity.ToLower()
		'' now perform checks

		If desiredQuantity = "heatCapacity".ToLower()
			Me.propertyList.Clear()
			Me.propertyList.Add("Ideal_Gas_Heat_Capacity_Const_A")
			Me.propertyList.Add("Ideal_Gas_Heat_Capacity_Const_B")
			Me.propertyList.Add("Ideal_Gas_Heat_Capacity_Const_C")
			Me.propertyList.Add("Ideal_Gas_Heat_Capacity_Const_D")
			Me.propertyList.Add("Ideal_Gas_Heat_Capacity_Const_E")
		End If

		If desiredQuantity = "Ideal_Gas_Heat_Capacity_Const_A".ToLower()
			Me.propertyList.Clear()
			Me.propertyList.Add("Ideal_Gas_Heat_Capacity_Const_A")
		End If

		If desiredQuantity = "Ideal_Gas_Heat_Capacity_Const_B".ToLower()
			Me.propertyList.Clear()
			Me.propertyList.Add("Ideal_Gas_Heat_Capacity_Const_B")
		End If
		If desiredQuantity = "Ideal_Gas_Heat_Capacity_Const_C".ToLower()
			Me.propertyList.Clear()
			Me.propertyList.Add("Ideal_Gas_Heat_Capacity_Const_C")
		End If
		If desiredQuantity = "Ideal_Gas_Heat_Capacity_Const_D".ToLower()
			Me.propertyList.Clear()
			Me.propertyList.Add("Ideal_Gas_Heat_Capacity_Const_D")
		End If
		If desiredQuantity = "Ideal_Gas_Heat_Capacity_Const_E".ToLower()
			Me.propertyList.Clear()
			Me.propertyList.Add("Ideal_Gas_Heat_Capacity_Const_E")
		End If


		'' lastly i'll remove all the entries from the miscList
		Me.MiscList.Remove("Ideal_Gas_Heat_Capacity_Const_A")
		Me.MiscList.Remove("Ideal_Gas_Heat_Capacity_Const_B")
		Me.MiscList.Remove("Ideal_Gas_Heat_Capacity_Const_C")
		Me.MiscList.Remove("Ideal_Gas_Heat_Capacity_Const_D")
		Me.MiscList.Remove("Ideal_Gas_Heat_Capacity_Const_E")

	End Sub

	'' next thing is liquid viscosity
	
	Private Sub constructLiquidViscosity()
		Me.propertyList.Add("liquidViscosity")
	End Sub

	Private Sub constructLiquidViscosity(ByVal desiredQuantity As String)
		Select Case desiredQuantity.ToLower()
			Case "liquidViscosity".ToLower()
				Me.propertyList.Clear()
				Me.propertyList.Add("Liquid_Viscosity_Const_A")
				Me.propertyList.Add("Liquid_Viscosity_Const_B")
				Me.propertyList.Add("Liquid_Viscosity_Const_C")
				Me.propertyList.Add("Liquid_Viscosity_Const_D")
				Me.propertyList.Add("Liquid_Viscosity_Const_E")
			Case "Liquid_Viscosity_Const_A".ToLower()
				Me.propertyList.Clear()
				Me.propertyList.Add("Liquid_Viscosity_Const_A")
			Case "Liquid_Viscosity_Const_B".ToLower()
				Me.propertyList.Clear()
				Me.propertyList.Add("Liquid_Viscosity_Const_B")
			Case "Liquid_Viscosity_Const_C".ToLower()
				Me.propertyList.Clear()
				Me.propertyList.Add("Liquid_Viscosity_Const_C")
			Case "Liquid_Viscosity_Const_D".ToLower()
				Me.propertyList.Clear()
				Me.propertyList.Add("Liquid_Viscosity_Const_D")
			Case "Liquid_Viscosity_Const_E".ToLower()
				Me.propertyList.Clear()
				Me.propertyList.Add("Liquid_Viscosity_Const_E")
		End Select
		Me.MiscList.Remove("Liquid_Viscosity_Const_A")
		Me.MiscList.Remove("Liquid_Viscosity_Const_B")
		Me.MiscList.Remove("Liquid_Viscosity_Const_C")
		Me.MiscList.Remove("Liquid_Viscosity_Const_D")
		Me.MiscList.Remove("Liquid_Viscosity_Const_E")
	End Sub

	'' boiling point
	

	Private Sub constructBoilingPoint()
		Me.propertyList.Add("boilingPoint")
	End Sub

	Private Sub constructBoilingPoint(ByVal desiredQuantity As String)
		Select Case desiredQuantity.ToLower()
			Case "boilingPoint".ToLower() 
				Me.propertyList.Clear()
				Me.propertyList.Add("Normal_Boiling_Point")
			Case "Normal_Boiling_Point".ToLower()
				Me.propertyList.Clear()
				Me.propertyList.Add("Normal_Boiling_Point")
		End Select
		Me.miscList.Remove("Normal_Boiling_Point")
	End Sub

	'' hvap

	Private Sub constructHVap()
		Me.propertyList.Add("enthalpyOfVaporisation")
	End Sub

	Private Sub constructHVap(ByVal desiredQuantity As String)
		Select Case desiredQuantity.ToLower()
			Case "enthalpyOfVaporisation".ToLower()
				Me.propertyList.Clear()
				Me.propertyList.Add("HVapA")
				Me.propertyList.Add("HVapB")
				Me.propertyList.Add("HvapC")
				Me.propertyList.Add("HVapD")
				Me.propertyList.Add("HvapTmin")
				Me.propertyList.Add("HvapTMAX")
			Case "hVap".ToLower()
				Me.propertyList.Clear()
				Me.propertyList.Add("HVapA")
				Me.propertyList.Add("HVapB")
				Me.propertyList.Add("HvapC")
				Me.propertyList.Add("HVapD")
				Me.propertyList.Add("HvapTmin")
				Me.propertyList.Add("HvapTMAX")
			Case "HVapA".ToLower() 
				Me.propertyList.Clear()
				Me.propertyList.Add("HVapA")
			Case "HVapB".ToLower() 
				Me.propertyList.Clear()
				Me.propertyList.Add("HVapB")
			Case "HVapC".ToLower() 
				Me.propertyList.Clear()
				Me.propertyList.Add("HvapC")
			Case "HVapD".ToLower() 
				Me.propertyList.Clear()
				Me.propertyList.Add("HVapD")
			Case "HvapTmin".ToLower() 
				Me.propertyList.Clear()
				Me.propertyList.Add("HvapTmin")
			Case "HvapTMAX".ToLower() 
				Me.propertyList.Clear()
				Me.propertyList.Add("HvapTMAX")
		End Select
		Me.miscList.Remove("HVapA")
		Me.miscList.Remove("HVapB")
		Me.miscList.Remove("HvapC")
		Me.miscList.Remove("HVapD")
		Me.miscList.Remove("HvapTmin")
		Me.miscList.Remove("HvapTMAX")
	End Sub

	'' critical Properties

	Private Sub constructCriticalProperties()
		Me.propertyList.Add("criticalProperties")
	End Sub

	Private Sub constructCriticalProperties(ByVal desiredQuantity As String)
		Dim critT As String = "Critical_Temperature"
		Dim critP As String = "Critical_Pressure"
		Dim critV As String = "Critical_Volume"
		Dim critZ As String = "Critical_Compressibility"
		Select desiredQuantity.ToLower()
			Case "criticalProperties".ToLower()
				Me.propertyList.Clear()
				Me.propertyList.Add(critT)
				Me.propertyList.Add(critP)
				Me.propertyList.Add(critV)
				Me.propertyList.Add(critZ)
		End Select

		Me.Check(desiredQuantity,critT)
		Me.Check(desiredQuantity,critV)
		Me.Check(desiredQuantity,critP)
		Me.Check(desiredQuantity,critZ)
	End Sub



	'' name and identifiers
	
	Private Sub constructCompoundName()
		Me.propertyList.Add("compoundName")
	End Sub

	Private Sub constructCompoundName(ByVal desiredQuantity As String)
		Dim checkList As List (Of String) = new List (Of String)
		checkList.Add("Name")
		checkList.Add("CAS_Number")
		checkList.Add("Formula")
		checkList.Add("COSMODBName")
		checkList.Add("ID")

		'' this part of the code adds the above strings to the
		'propertyList
		Select desiredQuantity.ToLower()
			Case "compoundName".ToLower()
				Me.propertyList.Clear()
				For Each listItem in checkList
					Me.PropertyList.Add(listItem)
				Next
		End Select

		'' this part of the code cleans up the Misc list
		'and also checks if the desired quantity happens to be any
		'of the desired properties in the list

		For Each listItem in checkList
			Me.check(desiredQuantity,listItem)
		Next


	End Sub

	'' vapor pressure
	Private Sub constructVaporPressure()
		Me.propertyList.Add("vaporPressure")
	End Sub

	Private Sub constructVaporPressure(ByVal desiredQuantity As String)

		Dim vaporPressure As String = "vaporPressure"
		Dim vapourPressure As String = "vapourPressure"
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
		'' this part of the code adds the above strings to the
		'propertyList
		Select desiredQuantity.ToLower()
			Case vapourPressure.ToLower()
				Me.propertyList.Clear()
				For Each listItem in checkList
					Me.PropertyList.Add(listItem)
				Next
			Case vaporPressure.ToLower()
				Me.propertyList.Clear()
				For Each listItem in checkList
					Me.PropertyList.Add(listItem)
				Next
		End Select

		'' this part of the code cleans up the Misc list
		'and also checks if the desired quantity happens to be any
		'of the desired properties in the list

		For Each listItem in checkList
			Me.check(desiredQuantity,listItem)
		Next
	End Sub


	'' formation properties
	
	Private Sub constructFormationProperties()
		Me.propertyList.Add("formationProperties")
	End Sub

	Private Sub constructFormationProperties(ByVal desiredQuantity As String)
		Dim checkList As List (Of String) = new List (Of String)
		checkList.Add("IG_Entropy_of_Formation_25C")
		checkList.Add("IG_Enthalpy_of_Formation_25C")
		checkList.Add("IG_Gibbs_Energy_of_Formation_25C")

		'' this part of the code adds the above strings to the
		'propertyList
		Select desiredQuantity.ToLower()
			Case "formationProperties".ToLower()
				Me.propertyList.Clear()
				For Each listItem in checkList
					Me.PropertyList.Add(listItem)
				Next
		End Select

		'' this part of the code cleans up the Misc list
		'and also checks if the desired quantity happens to be any
		'of the desired properties in the list

		For Each listItem in checkList
			Me.check(desiredQuantity,listItem)
		Next
	End Sub
	'
	'' chao seader properties
	Private Sub constructChaoSeader()
		Me.propertyList.Add("chaoSeader")
	End Sub

	Private Sub constructChaoSeader(ByVal desiredQuantity As String)
		Dim checkList As List (Of String) = new List (Of String)
		checkList.Add("CS_Acentric_Factor")
		checkList.Add("CS_Solubility_Parameter")
		checkList.Add("CS_Liquid_Molar_Volume")

		'' this part of the code adds the above strings to the
		'propertyList
		Select desiredQuantity.ToLower()
			Case "chaoSeader".ToLower()
				Me.propertyList.Clear()
				For Each listItem in checkList
					Me.PropertyList.Add(listItem)
				Next
		End Select

		'' this part of the code cleans up the Misc list
		'and also checks if the desired quantity happens to be any
		'of the desired properties in the list

		For Each listItem in checkList
			Me.check(desiredQuantity,listItem)
		Next
	End Sub
	'' molecular properties

	Private Sub constructMolecularProperties()
		Me.propertyList.Add("molecularProperties")
	End Sub

	Private Sub constructMolecularProperties(ByVal desiredQuantity As String)
		Dim checkList As List (Of String) = new List (Of String)
		checkList.Add("Molar_Weight")
		checkList.Add("elements")
		checkList.Add("Acentric_Factor")
		checkList.Add("Dipole_Moment")
		checkList.Add("ID")

		'' this part of the code adds the above strings to the
		'propertyList
		Select desiredQuantity.ToLower()
			Case "molecularProperties".ToLower()
				Me.propertyList.Clear()
				For Each listItem in checkList
					Me.PropertyList.Add(listItem)
				Next
		End Select

		'' this part of the code cleans up the Misc list
		'and also checks if the desired quantity happens to be any
		'of the desired properties in the list

		For Each listItem in checkList
			Me.check(desiredQuantity,listItem)
		Next


	End Sub
	
	'' Z_Rackett
	

	Private Sub constructZRackett()
		'' this is the Z Rackett Compressibility Factor
		Me.propertyList.Add("rackettCompressibility")
	End Sub

	Private Sub constructZRackett(ByVal desiredQuantity As String)
		Dim checkList As List (Of String) = new List (Of String)
		checkList.Add("Z_Rackett")

		'' this part of the code adds the above strings to the
		'propertyList
		Select desiredQuantity.ToLower()
			Case "rackettCompressibility".ToLower()
				Me.propertyList.Clear()
				For Each listItem in checkList
					Me.PropertyList.Add(listItem)
				Next
		End Select

		'' this part of the code cleans up the Misc list
		'and also checks if the desired quantity happens to be any
		'of the desired properties in the list

		For Each listItem in checkList
			Me.check(desiredQuantity,listItem)
		Next


	End Sub

	'' UNIQUAC

	Private Sub constructUNIQUAC()
		'' this is the UNIQUAC r and q parameters
		Me.propertyList.Add("UNIQUAC")
	End Sub

	Private Sub constructUNIQUAC(ByVal desiredQuantity As String)
		Dim checkList As List (Of String) = new List (Of String)
		checkList.Add("UNIQUAC_r")
		checkList.Add("UNIQUAC_q")

		'' this part of the code adds the above strings to the
		'propertyList
		Select desiredQuantity.ToLower()
			Case "UNIQUAC".ToLower()
				Me.propertyList.Clear()
				For Each listItem in checkList
					Me.PropertyList.Add(listItem)
				Next
		End Select

		'' this part of the code cleans up the Misc list
		'and also checks if the desired quantity happens to be any
		'of the desired properties in the list

		For Each listItem in checkList
			Me.check(desiredQuantity,listItem)
		Next


	End Sub

	'' this is the UNIFAC List

	Private Sub constructUNIFAC()
		'' this is the unifac property
		Me.propertyList.Add("UNIFAC")
	End Sub

	Private Sub constructUNIFAC(ByVal desiredQuantity As String)
		Dim checkList As List (Of String) = new List (Of String)
		checkList.Add("UNIFAC")

		'' this part of the code adds the above strings to the
		'propertyList
		Select desiredQuantity.ToLower()
			Case "UNIFAC".ToLower()
				Me.propertyList.Clear()
				For Each listItem in checkList
					Me.PropertyList.Add(listItem)
				Next
		End Select

		'' this part of the code cleans up the Misc list
		'and also checks if the desired quantity happens to be any
		'of the desired properties in the list

		For Each listItem in checkList
			Me.check(desiredQuantity,listItem)
		Next


	End Sub

	'' here is a boolean for indicating if the compound is a petroleum 
	'fraction

	Private Sub constructIsPetroleumFraction()
		Me.propertyList.Add("IsPetroleumFraction")
	End Sub

	Private Sub constructIsPetroleumFraction(ByVal desiredQuantity As String)
		Dim checkList As List (Of String) = new List (Of String)
		checkList.Add("isPf")

		'' this part of the code adds the above strings to the
		'propertyList
		Select desiredQuantity.ToLower()
			Case "IsPetroleumFraction".ToLower()
				Me.propertyList.Clear()
				For Each listItem in checkList
					Me.PropertyList.Add(listItem)
				Next
		End Select

		'' this part of the code cleans up the Misc list
		'and also checks if the desired quantity happens to be any
		'of the desired properties in the list

		For Each listItem in checkList
			Me.check(desiredQuantity,listItem)
		Next


	End Sub

	'' finally i have a misc list here
	' a misc list holds all the properties present,
	' but as the other properties are constructed, the misc list has its properties
	' removed
	Private Sub constructMiscList()
		Me.propertyList.Add("miscList")
	End Sub

	Private Sub constructMiscList(ByVal desiredQuantity As String)
		Select desiredQuantity.ToLower()
			Case "misc".ToLower()
				Me.propertyList.Clear()
				Me.propertyList = Me.miscList
			Case "miscList".ToLower()
				Me.propertyList.Clear()
				Me.propertyList = Me.miscList
		End Select
	
	End Sub

	Private Sub constructUnEditedMiscList()
		Me.miscList = new List(Of String)

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
			Me.miscList.Add(element.Name.ToString())
		Next
	End Sub

	' for convenience, i will have a constructorUpdateList method
	' this adds the string to the propertyList, 
	' and deletes it from the miscList
	Private Sub constructorUpdateList(ByVal x As String)
		Me.propertyList.Add(x)
	End Sub

	Private Property miscList As IList(Of String)


	' another convenience thing
	'
	Private Sub Check(ByVal desiredQuantity As String, ByVal inputString As String)
		desiredQuantity = desiredQuantity.ToLower()
		If desiredQuantity = inputString.ToLower()
			Me.propertyList.Clear()
			Me.propertyList.Add(inputString)
		End If
		Me.miscList.Remove(inputString)
	End Sub

End Class

