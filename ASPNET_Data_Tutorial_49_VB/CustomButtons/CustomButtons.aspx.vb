
Partial Class CustomButtons_CustomButtons
    Inherits System.Web.UI.Page

    Protected Sub Suppliers_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles Suppliers.ItemCommand
        If e.CommandName.CompareTo("DiscontinueProducts") = 0 Then
            ' The "Discontinue All Products" Button was clicked.
            ' Invoke the ProductsBLL.DiscontinueAllProductsForSupplier(supplierID) method

            ' First, get the SupplierID selected in the FormView
            Dim supplierID As Integer = CType(Suppliers.SelectedValue, Integer)

            ' Next, create an instance of the ProductsBLL class
            Dim productInfo As New ProductsBLL()

            ' Finally, invoke the DiscontinueAllProductsForSupplier(supplierID) method
            productInfo.DiscontinueAllProductsForSupplier(supplierID)
        End If
    End Sub

    Protected Sub SuppliersProducts_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles SuppliersProducts.RowCommand
        If e.CommandName.CompareTo("IncreasePrice") = 0 OrElse e.CommandName.CompareTo("DecreasePrice") = 0 Then
            ' The Increase Price or Decrease Price Button has been clicked

            ' Determine the ID of the product whose price was adjusted
            Dim productID As Integer = Convert.ToInt32(SuppliersProducts.DataKeys(Convert.ToInt32(e.CommandArgument)).Value)

            ' Determine how much to adjust the price
            Dim percentageAdjust As Decimal
            If e.CommandName.CompareTo("IncreasePrice") = 0 Then
                percentageAdjust = 1.1
            Else
                percentageAdjust = 0.9
            End If

            ' Adjust the price
            Dim productInfo As New ProductsBLL()
            productInfo.UpdateProduct(percentageAdjust, productID)
        End If
    End Sub
End Class
