
Partial Class EditDeleteDataList_OptimisticConcurrency
    Inherits System.Web.UI.Page

    Protected Sub Products_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Products.EditCommand
        Products.EditItemIndex = e.Item.ItemIndex
        Products.DataBind()
    End Sub

    Protected Sub Products_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Products.CancelCommand
        Products.EditItemIndex = -1
        Products.DataBind()
    End Sub

    Protected Sub Products_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Products.UpdateCommand
        ' Make sure the validators on the page are valid
        If Not Page.IsValid Then Exit Sub

        ' Read in the ProductID
        Dim productID As Integer = Convert.ToInt32(Products.DataKeys(e.Item.ItemIndex))


        ' Read in the original values
        Dim original_productName As String = Nothing
        Dim original_unitPrice As Nullable(Of Decimal) = Nothing

        If Not String.IsNullOrEmpty(CType(ViewState("original_productName"), String)) Then
            original_productName = CType(ViewState("original_productName"), String)
        End If
        If Not String.IsNullOrEmpty(CType(ViewState("original_unitPrice"), String)) Then
            original_unitPrice = Decimal.Parse(CType(ViewState("original_unitPrice"), String), System.Globalization.NumberStyles.Currency)
        End If

        ' Read in the new values
        Dim new_productName As String = Nothing
        Dim new_unitPrice As Nullable(Of Decimal) = Nothing

        Dim ProductName As TextBox = CType(e.Item.FindControl("ProductName"), TextBox)
        Dim UnitPrice As TextBox = CType(e.Item.FindControl("UnitPrice"), TextBox)

        If ProductName.Text.Trim().Length > 0 Then
            new_productName = ProductName.Text.Trim()
        End If
        If UnitPrice.Text.Trim().Length > 0 Then
            new_unitPrice = Decimal.Parse(UnitPrice.Text.Trim(), System.Globalization.NumberStyles.Currency)
        End If

        Try
            ' Call the UpdateProduct method in ProductsOptimisticConcurrencyBLL
            Dim optimisticProductsAPI As New ProductsOptimisticConcurrencyBLL()
            optimisticProductsAPI.UpdateProduct(new_productName, new_unitPrice, productID, original_productName, original_unitPrice, productID)

            ' Return the DataList to its pre-editing state
            Products.EditItemIndex = -1
            Products.DataBind()
        Catch dbConcurEx As System.Data.DBConcurrencyException
            ' Display the UpdateConcurrencyViolationMessage Label
            UpdateConcurrencyViolationMessage.Visible = True

            ' Re-read the values from the database
            Products.DataBind()
        Catch
            ' Some other kind of exception occurred
            Throw
        End Try
    End Sub

    Protected Sub Products_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Products.DeleteCommand
        ' Read in the ProductID
        Dim productID As Integer = Convert.ToInt32(Products.DataKeys(e.Item.ItemIndex))


        ' Read in the current name and price values for the product being deleted
        Dim ProductNameLabel As Label = CType(e.Item.FindControl("ProductNameLabel"), Label)
        Dim UnitPriceLabel As Label = CType(e.Item.FindControl("UnitPriceLabel"), Label)

        Dim original_productName As String = ProductNameLabel.Text
        Dim original_unitPrice As Nullable(Of Decimal) = Nothing
        If Not String.IsNullOrEmpty(UnitPriceLabel.Text) Then
            original_unitPrice = Decimal.Parse(UnitPriceLabel.Text, System.Globalization.NumberStyles.Currency)
        End If

        ' Delete the product using the ProductsOptimisticConcurrencyBLL class
        Dim optimisticProductsAPI As New ProductsOptimisticConcurrencyBLL()
        Dim deleteSucceeded As Boolean = optimisticProductsAPI.DeleteProduct(productID, original_productName, original_unitPrice)


        ' If the delete failed, display the DeleteConcurrencyViolationMessage Label
        If Not deleteSucceeded Then
            DeleteConcurrencyViolationMessage.Visible = True
        End If

        ' Rebind the data to the DataList
        Products.DataBind()
    End Sub

    Protected Sub Products_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles Products.ItemDataBound
        If e.Item.ItemType = ListItemType.EditItem Then
            ' Read the edited item's original values into the Page's view state
            Dim ProductName As TextBox = CType(e.Item.FindControl("ProductName"), TextBox)
            Dim UnitPrice As TextBox = CType(e.Item.FindControl("UnitPrice"), TextBox)

            ViewState("original_productName") = ProductName.Text
            ViewState("original_unitPrice") = UnitPrice.Text
        End If
    End Sub
End Class
