Imports NorthwindTableAdapters

<System.ComponentModel.DataObject()> _
Public Class CategoriesBLL
    Private _categoriesAdapter As CategoriesTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As CategoriesTableAdapter
        Get
            If _categoriesAdapter Is Nothing Then
                _categoriesAdapter = New CategoriesTableAdapter()
            End If

            Return _categoriesAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetCategories() As Northwind.CategoriesDataTable
        Return Adapter.GetCategories()
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetCategoryByCategoryID(ByVal categoryID As Integer) As Northwind.CategoriesDataTable
        Return Adapter.GetCategoryByCategoryID(categoryID)
    End Function
End Class
