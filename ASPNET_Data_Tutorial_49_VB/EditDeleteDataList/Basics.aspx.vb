
Partial Class EditDeleteDataList_Basics
    Inherits System.Web.UI.Page

#Region "Editing-Related Event Handlers"
    Protected Sub DataList1_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.EditCommand
        ' Set the DataList's EditItemIndex property to the
        ' index of the DataListItem that was clicked
        DataList1.EditItemIndex = e.Item.ItemIndex

        ' Rebind the data to the DataList
        DataList1.DataBind()
    End Sub

    Protected Sub DataList1_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.CancelCommand
        ' Set the DataList's EditItemIndex property to -1
        DataList1.EditItemIndex = -1

        ' Rebind the data to the DataList
        DataList1.DataBind()
    End Sub

    Protected Sub DataList1_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.UpdateCommand
        ' Read in the ProductID from the DataKeys collection
        Dim productID As Integer = Convert.ToInt32(DataList1.DataKeys(e.Item.ItemIndex))

        ' Read in the product name and price values
        Dim productName As TextBox = CType(e.Item.FindControl("ProductName"), TextBox)
        Dim unitPrice As TextBox = CType(e.Item.FindControl("UnitPrice"), TextBox)

        Dim productNameValue As String = Nothing
        If productName.Text.Trim().Length > 0 Then
            productNameValue = productName.Text.Trim()
        End If

        Dim unitPriceValue As Nullable(Of Decimal) = Nothing
        If unitPrice.Text.Trim().Length > 0 Then
            unitPriceValue = Decimal.Parse(unitPrice.Text.Trim(), System.Globalization.NumberStyles.Currency)
        End If

        ' Call the ProductsBLL's UpdateProduct method...
        Dim productsAPI As New ProductsBLL()
        productsAPI.UpdateProduct(productNameValue, unitPriceValue, productID)


        ' Revert the DataList back to its pre-editing state
        DataList1.EditItemIndex = -1
        DataList1.DataBind()
    End Sub
#End Region

    Protected Sub DataList1_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.DeleteCommand
        ' Read in the ProductID from the DataKeys collection
        Dim productID As Integer = Convert.ToInt32(DataList1.DataKeys(e.Item.ItemIndex))

        ' Delete the data
        Dim productsAPI As New ProductsBLL()
        productsAPI.DeleteProduct(productID)

        ' Rebind the data to the DataList
        DataList1.DataBind()
    End Sub
End Class
