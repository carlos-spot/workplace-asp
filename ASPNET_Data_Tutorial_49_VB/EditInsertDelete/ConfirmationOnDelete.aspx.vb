
Partial Class EditInsertDelete_ConfirmationOnDelete
    Inherits System.Web.UI.Page

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' reference the Delete LinkButton
            Dim db As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)

            ' Get information about the product bound to the row
            Dim product As Northwind.ProductsRow = CType(CType(e.Row.DataItem, System.Data.DataRowView).Row, Northwind.ProductsRow)

            db.OnClientClick = String.Format("return confirm('Are you certain you want to delete the {0} product?');", product.ProductName.Replace("'", "\'"))
        End If
    End Sub
End Class
