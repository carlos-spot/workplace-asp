
Partial Class DataListRepeaterBasics_Formatting
    Inherits System.Web.UI.Page

    Protected Sub ItemDataBoundFormattingExample_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles ItemDataBoundFormattingExample.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            ' Programmatically reference the ProductsRow instance bound to this DataListItem
            Dim product As Northwind.ProductsRow = CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, Northwind.ProductsRow)

            ' See if the UnitPrice is not NULL and less than $20.00
            If Not product.IsUnitPriceNull() AndAlso product.UnitPrice < 20 Then
                ' Highlight the product name and unit price Labels
                ' First, get a reference to the two Label Web controls
                Dim ProductNameLabel As Label = CType(e.Item.FindControl("ProductNameLabel"), Label)
                Dim UnitPriceLabel As Label = CType(e.Item.FindControl("UnitPriceLabel"), Label)

                ' Next, set their CssClass properties
                If ProductNameLabel IsNot Nothing Then
                    ProductNameLabel.CssClass = "AffordablePriceEmphasis"
                End If

                If UnitPriceLabel IsNot Nothing Then
                    UnitPriceLabel.CssClass = "AffordablePriceEmphasis"
                End If
            End If
        End If
    End Sub

    Protected Function DisplayProductNameAndDiscontinuedStatus(ByVal productName As String, ByVal discontinued As Boolean) As String
        ' Return just the productName if discontinued is false
        If Not discontinued Then
            Return productName
        Else
            ' otherwise, return the productName appended with the text "[DISCONTINUED]"
            Return String.Concat(productName, " [DISCONTINUED]")
        End If
    End Function

    Protected Function DisplayPrice(ByVal product As Northwind.ProductsRow) As String
        ' If price is less than $20.00, return the price, highlighted
        If Not product.IsUnitPriceNull() AndAlso product.UnitPrice < 20 Then
            Return String.Concat("<span class=""AffordablePriceEmphasis"">", product.UnitPrice.ToString("C"), "</span>")
        Else
            ' Otherwise return the text, "Please call for a price quote"
            Return "<span>Please call for a price quote</span>"
        End If
    End Function

    'ALTERATIVE OPTION: You can also allow the UnitPrice to be passed in as a scalar value...
    'Protected Function DisplayPrice(ByVal unitPrice As Object) As String
    '    ' If price is less than $20.00, return the price, highlighted
    '    If Not Convert.IsDBNull(unitPrice) AndAlso CType(unitPrice, Decimal) < 20 Then
    '        Return String.Concat("<span class=""AffordablePriceEmphasis"">", CType(unitPrice, Decimal).ToString("C"), "</span>")
    '    Else
    '        ' Otherwise return the text, "Please call for a price quote"
    '        Return "<span>Please call for a price quote</span>"
    '    End If
    'End Function


End Class
