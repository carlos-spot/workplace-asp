Partial Class EditDeleteDataList_ErrorHandling
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
        ' Handle any exceptions raised during the editing process
        Try
            ' Read in the ProductID from the DataKeys collection
            Dim productID As Integer = Convert.ToInt32(Products.DataKeys(e.Item.ItemIndex))

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
            Products.EditItemIndex = -1
            Products.DataBind()
        Catch ex As Exception
            DisplayExceptionDetails(ex)
        End Try
    End Sub

    Private Sub DisplayExceptionDetails(ByVal ex As Exception)
        ' Display a user-friendly message
        ExceptionDetails.Text = "There was a problem updating the product. "

        If TypeOf ex Is System.Data.Common.DbException Then
            ExceptionDetails.Text += "Our database is currently experiencing problems. Please try again later."
        ElseIf TypeOf ex Is System.Data.NoNullAllowedException Then
            ExceptionDetails.Text += "There are one or more required fields that are missing."
        ElseIf TypeOf ex Is ArgumentException Then
            Dim paramName As String = CType(ex, ArgumentException).ParamName
            ExceptionDetails.Text += String.Concat("The ", paramName, " value is illegal.")
        ElseIf TypeOf ex Is ApplicationException Then
            ExceptionDetails.Text += ex.Message
        End If
    End Sub
End Class
