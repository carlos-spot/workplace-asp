
Partial Class DataListRepeaterFiltering_ProductsForCategoryDetails
    Inherits System.Web.UI.Page

    Protected Sub ProductsInCategory_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductsInCategory.DataBinding
        'Show the Label
        NoProductsMessage.Visible = True
    End Sub

    Protected Sub ProductsInCategory_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles ProductsInCategory.ItemDataBound
        'If we have a data item, hide the Label
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            NoProductsMessage.Visible = False
        End If
    End Sub
End Class
