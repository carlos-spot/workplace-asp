Imports NorthwindTableAdapters

<System.ComponentModel.DataObject()> _
Public Class EmployeesBLL
    Private _employeesAdapter As EmployeesTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As EmployeesTableAdapter
        Get
            If _employeesAdapter Is Nothing Then
                _employeesAdapter = New EmployeesTableAdapter()
            End If

            Return _employeesAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployees() As Northwind.EmployeesDataTable
        Return Adapter.GetEmployees()
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetEmployeeByEmployeeID(ByVal employeeID As Integer) As Northwind.EmployeesDataTable
        Return Adapter.GetEmployeeByEmployeeID(employeeID)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetEmployeesByManager(ByVal managerID As Integer) As Northwind.EmployeesDataTable
        Return Adapter.GetEmployeesByManager(managerID)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetEmployeesByHiredDateMonth(ByVal month As Integer) As Northwind.EmployeesDataTable
        Return Adapter.GetEmployeesByHiredDateMonth(month)
    End Function

End Class
