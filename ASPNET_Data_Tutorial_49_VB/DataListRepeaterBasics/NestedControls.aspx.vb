
Partial Class DataListRepeaterBasics_NestedControls
    Inherits System.Web.UI.Page

    'OPTIONAL: Use this ItemDataBound event handler if you want to use the ObjectDataSource approach
    '          to bind the data to the inner Repeater... this event handler references that ObjectDataSource
    '          and sets its CategoryID parameter accordingly...
    'Protected Sub CategoryList_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs) Handles CategoryList.ItemDataBound
    '    If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
    '        ' Reference the CategoriesRow object being bound to this RepeaterItem
    '        Dim category As Northwind.CategoriesRow = CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, Northwind.CategoriesRow)

    '        ' Reference the ProductsByCategoryDataSource ObjectDataSource
    '        Dim ProductsByCategoryDataSource As ObjectDataSource = CType(e.Item.FindControl("ProductsByCategoryDataSource"), ObjectDataSource)

    '        ' Set the CategoryID Parameter value
    '        ProductsByCategoryDataSource.SelectParameters("CategoryID").DefaultValue = category.CategoryID.ToString()
    '    End If
    'End Sub


    'OPTIONAL: You can use this implementation of the GetProductsInCategory method if you want; it simply returns
    'Protected Function GetProductsInCategory(ByVal categoryID As Integer) As Northwind.ProductsDataTable
    '    ' Create an instance of the ProductsBLL class
    '    Dim productAPI As ProductsBLL = New ProductsBLL()

    '    ' Return the products in the category
    '    Return productAPI.GetProductsByCategoryID(categoryID)
    'End Function


    ' This implementation of the GetProductsInCategory method intelligently accesses ALL of the
    ' products from the database first, and then returns the filtered view of those results based
    ' on the passed-in categoryID parameter...
    Private allProducts As Northwind.ProductsDataTable = Nothing

    Protected Function GetProductsInCategory(ByVal categoryID As Integer) As Northwind.ProductsDataTable
        ' First, see if we've yet to have accessed all of the product information
        If allProducts Is Nothing Then
            Dim productAPI As ProductsBLL = New ProductsBLL()
            allProducts = productAPI.GetProducts()
        End If

        ' Return the filtered view
        allProducts.DefaultView.RowFilter = "CategoryID = " & categoryID
        Return allProducts
    End Function
End Class
