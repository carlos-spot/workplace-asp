
Partial Class CustomFormatting_CustomColors
    Inherits System.Web.UI.Page

    Protected Sub ExpensiveProductsPriceInBoldItalic_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExpensiveProductsPriceInBoldItalic.DataBound
        ' Get the ProductsRow object from the DataItem property...
        Dim product As Northwind.ProductsRow = CType(CType(ExpensiveProductsPriceInBoldItalic.DataItem, System.Data.DataRowView).Row, Northwind.ProductsRow)
        If Not product.IsUnitPriceNull() AndAlso product.UnitPrice > 75 Then
            ExpensiveProductsPriceInBoldItalic.Rows(4).Cells(1).CssClass = "ExpensivePriceEmphasis"
        End If
    End Sub

    Protected Sub LowStockedProductsInRed_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles LowStockedProductsInRed.DataBound
        'Get the ProductsRow object from the DataItem property...
        Dim product As Northwind.ProductsRow = CType(CType(LowStockedProductsInRed.DataItem, System.Data.DataRowView).Row, Northwind.ProductsRow)
        If Not product.IsUnitsInStockNull() AndAlso product.UnitsInStock <= 10 Then
            Dim unitsInStock As Label = CType(LowStockedProductsInRed.FindControl("UnitsInStockLabel"), Label)

            If unitsInStock IsNot Nothing Then
                unitsInStock.CssClass = "LowUnitsInStockEmphasis"
            End If
        End If
    End Sub

    Protected Sub HighlightCheapProducts_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles HighlightCheapProducts.RowDataBound
        'Make sure we are working with a DataRow
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Get the ProductsRow object from the DataItem property...
            Dim product As Northwind.ProductsRow = CType(CType(e.Row.DataItem, System.Data.DataRowView).Row, Northwind.ProductsRow)
            If Not product.IsUnitPriceNull() AndAlso product.UnitPrice < 10 Then
                e.Row.CssClass = "AffordablePriceEmphasis"
            End If
        End If
    End Sub

End Class
