
Partial Class CustomButtonsDataListRepeater_CustomButtons
    Inherits System.Web.UI.Page

    Protected Sub Categories_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles Categories.ItemCommand
        If e.CommandName = "ShowProducts" Then
            ' Determine the CategoryID
            Dim categoryID As Integer = Convert.ToInt32(e.CommandArgument)

            ' Get the associated products from the ProudctsBLL and bind them to the BulletedList
            Dim products As BulletedList = CType(e.Item.FindControl("ProductsInCategory"), BulletedList)
            Dim productsAPI As New ProductsBLL()
            products.DataSource = productsAPI.GetProductsByCategoryID(categoryID)
            products.DataBind()
        End If
    End Sub
End Class
