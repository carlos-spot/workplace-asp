
Partial Class Filtering_MasterDetailsDetails
    Inherits System.Web.UI.Page

    Protected Sub ProductsByCategory_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductsByCategory.DataBound
        ProductDetails.DataBind()
    End Sub
End Class
