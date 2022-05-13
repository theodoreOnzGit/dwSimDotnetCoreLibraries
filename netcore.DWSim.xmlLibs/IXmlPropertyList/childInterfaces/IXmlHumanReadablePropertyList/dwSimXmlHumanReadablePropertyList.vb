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

		Me.constructHeatCapacityList(desiredQuantity)

		'' if after all the checks the propertyList
		'isn't populated, then something is wrong,
		'throw an exception
		If Me.propertyList.Count = 0

			'probably change this to out of range later
			Dim errorMsg as String
			errorMsg = desiredQuantity + " does not exist" & VbCrLf
			errorMsg += "please select a valid entry from the following:" & VbCrLf
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
		Me.constructHeatCapacityList()

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

	End Sub

	'' next thing is liquid viscosity
	
	Private Sub constructLiquidViscosity()
		Me.propertyList.Add("liquidViscosity")
	End Sub

	Private Sub constructLiquidViscosity(ByVal desiredQuantity As String)
		Select Case desiredQuantity.ToLower()
			Case "liquidViscosity".ToLower()
				Me.propertyList.Clear()
				Me.propertyList.Add("liquid_viscosity_const_a")
				Me.propertyList.Add("liquid_viscosity_const_b")
				Me.propertyList.Add("liquid_viscosity_const_c")
				Me.propertyList.Add("liquid_viscosity_const_d")
				Me.propertyList.Add("liquid_viscosity_const_e")
			Case "liquid_viscosity_const_a".ToLower()
				Me.propertyList.Add("liquid_viscosity_const_a")
			Case "liquid_viscosity_const_b".ToLower()
				Me.propertyList.Add("liquid_viscosity_const_b")
			Case "liquid_viscosity_const_c".ToLower()
				Me.propertyList.Add("liquid_viscosity_const_c")
			Case "liquid_viscosity_const_d".ToLower()
				Me.propertyList.Add("liquid_viscosity_const_d")
			Case "liquid_viscosity_const_e".ToLower()
				Me.propertyList.Add("liquid_viscosity_const_e")
		End Select
	End Sub

	'' boiling point
	

	Private Sub constructBoilingPoint()
		Me.propertyList.Add("boilingPoint")
	End Sub

	Private Sub constructBoilingPoint(ByVal desiredQuantity As String)
		throw new NotImplementedException()
	End Sub

	'' hvap

	Private Sub constructHVap()
		Me.propertyList.Add("hVap")
	End Sub

	Private Sub constructHVap(ByVal desiredQuantity As String)
		throw new NotImplementedException()
	End Sub

	'' critical Properties

	Private Sub constructCriticalProperties()
		Me.propertyList.Add("criticalProperties")
	End Sub

	Private Sub constructCriticalProperties(ByVal desiredQuantity As String)
		throw new NotImplementedException()
	End Sub


	'' name and identifiers
	
	Private Sub constructCompoundName()
		Me.propertyList.Add("compoundName")
	End Sub

	Private Sub constructCompoundName(ByVal desiredQuantity As String)
		throw new NotImplementedException()
	End Sub

End Class

