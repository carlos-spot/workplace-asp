
Partial Class DataListRepeaterFiltering_CategoriesAndProducts
    Inherits System.Web.UI.Page

    ' OPTIONAL: Use the ItemDataBound event handler approach to retrieve information about
    '           how many products there are for the category without having to modify the DAL
    Protected Sub Categories_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs)
        ' Make sure we're working with a data item...
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            ' Reference the CategoriesRow instance bound to this RepeaterItem
            Dim category As Northwind.CategoriesRow = CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, Northwind.CategoriesRow)

            ' Determine how many products are in this category
            Dim productsAPI As New NorthwindTableAdapters.ProductsTableAdapter
            Dim productCount As Integer = productsAPI.GetProductsByCategoryID(category.CategoryID).Count

            ' Reference the ViewCategory LinkButton and set its Text property
            Dim ViewCategory As LinkButton = CType(e.Item.FindControl("ViewCategory"), LinkButton)
            ViewCategory.Text = String.Format("{0} ({1:N0})", category.CategoryName, productCount)
        End If
    End Sub

    Protected Sub Categories_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles Categories.ItemCommand
        ' If it's the "ListProducts" command that has been issued...
        If String.Compare(e.CommandName, "ListProducts", True) = 0 Then
            ' Set the CategoryProductsDataSource ObjectDataSource's CategoryID parameter
            ' to the CategoryID of the category that was just clicked (e.CommandArgument)...
            CategoryProductsDataSource.SelectParameters("CategoryID").DefaultValue = e.CommandArgument.ToString()
        End If
    End Sub
End Class
