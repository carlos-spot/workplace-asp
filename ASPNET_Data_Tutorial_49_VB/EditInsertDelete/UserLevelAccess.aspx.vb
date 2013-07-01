
Partial Class EditInsertDelete_UserLevelAccess
    Inherits System.Web.UI.Page

    Protected Sub Suppliers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Suppliers.SelectedIndexChanged
        If Suppliers.SelectedValue = "-1" Then
            ' The "Show/Edit ALL" option has been selected
            SupplierDetails.DataSourceID = "AllSuppliersDataSource"

            ' Reset the page index to show the first record
            SupplierDetails.PageIndex = 0
        Else
            ' The user picked a particular supplier
            SupplierDetails.DataSourceID = "SingleSupplierDataSource"
        End If

        ' Ensure that the DetailsView and GridView are in read-only mode
        SupplierDetails.ChangeMode(DetailsViewMode.ReadOnly)
        ProductsBySupplier.EditIndex = -1

        ' Need to "refresh" the DetailsView
        SupplierDetails.DataBind()
    End Sub

    Protected Sub ProductsBySupplier_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles ProductsBySupplier.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Is this a supplier-specific user?
            If Suppliers.SelectedValue <> "-1" Then
                ' Get a reference to the ProductRow
                Dim product As Northwind.ProductsRow = CType(CType(e.Row.DataItem, System.Data.DataRowView).Row, Northwind.ProductsRow)

                ' Is this product discontinued?
                If product.Discontinued Then
                    ' Get a reference to the Edit LinkButton
                    Dim editButton As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)

                    ' Hide the Edit button
                    editButton.Visible = False
                End If
            End If
        End If
    End Sub
End Class
