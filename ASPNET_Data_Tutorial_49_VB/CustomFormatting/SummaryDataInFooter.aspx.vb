
Partial Class CustomFormatting_SummaryDataInFooter
    Inherits System.Web.UI.Page

    ' Class-scope, running total variables...
    Dim _totalUnitPrice As Decimal = 0
    Dim _totalNonNullUnitPriceCount As Integer = 0
    Dim _totalUnitsInStock As Integer = 0
    Dim _totalUnitsOnOrder As Integer = 0

    Protected Sub ProductsInCategory_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles ProductsInCategory.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Reference the ProductsRow via the e.Row.DataItem property
            Dim product As Northwind.ProductsRow = CType(CType(e.Row.DataItem, System.Data.DataRowView).Row, Northwind.ProductsRow)

            ' Increment the running totals (if they're not NULL!)
            If Not product.IsUnitPriceNull() Then
                _totalUnitPrice += product.UnitPrice
                _totalNonNullUnitPriceCount += 1
            End If

            If Not product.IsUnitsInStockNull() Then
                _totalUnitsInStock += product.UnitsInStock
            End If

            If Not product.IsUnitsOnOrderNull() Then
                _totalUnitsOnOrder += product.UnitsOnOrder
            End If
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            ' Determine the average UnitPrice
            Dim avgUnitPrice As Decimal = _totalUnitPrice / CType(_totalNonNullUnitPriceCount, Decimal)

            ' Display the summary data in the appropriate cells
            e.Row.Cells(1).Text = "Avg.: " & avgUnitPrice.ToString("c")
            e.Row.Cells(2).Text = "Total: " & _totalUnitsInStock.ToString()
            e.Row.Cells(3).Text = "Total: " & _totalUnitsOnOrder.ToString()
        End If
    End Sub
End Class
