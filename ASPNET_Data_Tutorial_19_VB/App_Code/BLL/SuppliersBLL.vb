Imports NorthwindTableAdapters

<System.ComponentModel.DataObject()> _
Public Class SuppliersBLL
    Private _suppliersAdapter As SuppliersTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As SuppliersTableAdapter
        Get
            If _suppliersAdapter Is Nothing Then
                _suppliersAdapter = New SuppliersTableAdapter()
            End If

            Return _suppliersAdapter
        End Get
    End Property


    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSuppliers() As Northwind.SuppliersDataTable
        Return Adapter.GetSuppliers()
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetSupplierBySupplierID(ByVal supplierID As Integer) As Northwind.SuppliersDataTable
        Return Adapter.GetSupplierBySupplierID(supplierID)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetSuppliersByCountry(ByVal country As String) As Northwind.SuppliersDataTable
        If String.IsNullOrEmpty(country) Then
            Return GetSuppliers()
        Else
            Return Adapter.GetSuppliersByCountry(country)
        End If
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateSupplierAddress(ByVal supplierID As Integer, ByVal address As String, ByVal city As String, ByVal country As String) As Boolean
        Dim suppliers As Northwind.SuppliersDataTable = Adapter.GetSupplierBySupplierID(supplierID)

        If suppliers.Count = 0 Then
            ' no matching record found, return false
            Return False
        Else
            Dim supplier As Northwind.SuppliersRow = suppliers(0)

            If address Is Nothing Then supplier.SetAddressNull() Else supplier.Address = address
            If city Is Nothing Then supplier.SetCityNull() Else supplier.City = city
            If country Is Nothing Then supplier.SetCountryNull() Else supplier.Country = country

            ' Update the supplier Address-related information
            Dim rowsAffected As Integer = Adapter.Update(supplier)

            ' Return true if precisely one row was updated, otherwise false
            Return rowsAffected = 1
        End If
    End Function

End Class
