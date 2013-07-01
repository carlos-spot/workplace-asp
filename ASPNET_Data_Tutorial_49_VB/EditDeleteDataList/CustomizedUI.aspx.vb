
Partial Class EditDeleteDataList_CustomizedUI
    Inherits System.Web.UI.Page

    Protected Sub Products_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Products.EditCommand
        ' Set the DataList's EditItemIndex property to the
        ' index of the DataListItem that was clicked
        Products.EditItemIndex = e.Item.ItemIndex

        ' Rebind the data to the DataList
        Products.DataBind()
    End Sub

    Protected Sub Products_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Products.CancelCommand
        ' Set the DataList's EditItemIndex property to -1
        Products.EditItemIndex = -1

        ' Rebind the data to the DataList
        Products.DataBind()
    End Sub

    Protected Sub Products_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Products.UpdateCommand
        If Not Page.IsValid Then
            Exit Sub
        End If

        ' Read in the ProductID from the DataKeys collection
        Dim productID As Integer = Convert.ToInt32(Products.DataKeys(e.Item.ItemIndex))

        ' Read in the product name and price values
        Dim productName As TextBox = CType(e.Item.FindControl("ProductName"), TextBox)
        Dim categories As DropDownList = CType(e.Item.FindControl("Categories"), DropDownList)
        Dim suppliers As DropDownList = CType(e.Item.FindControl("Suppliers"), DropDownList)
        Dim discontinued As CheckBox = CType(e.Item.FindControl("Discontinued"), CheckBox)

        Dim productNameValue As String = Nothing
        If productName.Text.Trim().Length > 0 Then
            productNameValue = productName.Text.Trim()
        End If

        Dim categoryIDValue As Nullable(Of Integer) = Nothing
        If Not String.IsNullOrEmpty(categories.SelectedValue) Then
            categoryIDValue = Convert.ToInt32(categories.SelectedValue)
        End If

        Dim supplierIDValue As Nullable(Of Integer) = Nothing
        If Not String.IsNullOrEmpty(suppliers.SelectedValue) Then
            supplierIDValue = Convert.ToInt32(suppliers.SelectedValue)
        End If

        Dim discontinuedValue As Boolean = discontinued.Checked

        ' Call the ProductsBLL's UpdateProduct method...
        Dim productsAPI As New ProductsBLL()
        productsAPI.UpdateProduct(productNameValue, categoryIDValue, supplierIDValue, discontinuedValue, productID)

        ' Revert the DataList back to its pre-editing state
        Products.EditItemIndex = -1
        Products.DataBind()
    End Sub
End Class
