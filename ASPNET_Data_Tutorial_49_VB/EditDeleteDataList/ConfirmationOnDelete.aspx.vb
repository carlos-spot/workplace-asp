
Partial Class EditDeleteDataList_ConfirmationOnDelete
    Inherits System.Web.UI.Page

    Protected Sub Products_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Products.DeleteCommand
        ' Read in the ProductID from the DataKeys collection
        Dim productID As Integer = Convert.ToInt32(Products.DataKeys(e.Item.ItemIndex))

        ' Delete the data
        Dim productsAPI As New ProductsBLL()
        productsAPI.DeleteProduct(productID)

        ' Rebind the data to the DataList
        Products.DataBind()
    End Sub

    ' OPTIONAL: You could instead use the declarative approach (see ConfirmationOnDelete.aspx)
    Protected Sub Products_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles Products.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            ' Reference the data bound to the DataListItem
            Dim product As Northwind.ProductsRow = CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, Northwind.ProductsRow)

            ' Reference the Delete button
            Dim db As Button = CType(e.Item.FindControl("DeleteButton"), Button)

            ' Assign the Delete button's OnClientClick property
            db.OnClientClick = String.Format("return confirm('Are you sure that you want to delete the product {0}?');", product.ProductName.Replace("'", "\'"))
        End If
    End Sub
End Class
