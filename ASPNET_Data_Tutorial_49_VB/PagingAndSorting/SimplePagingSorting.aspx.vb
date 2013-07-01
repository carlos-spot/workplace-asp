
Partial Class PagingAndSorting_SimplePagingSorting
    Inherits System.Web.UI.Page

    Protected Sub Products_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles Products.DataBound
        PagingInformation.Text = String.Format("You are viewing page {0} of {1}...", Products.PageIndex + 1, Products.PageCount)

        ' Clear out all of the items in the DropDownList
        PageList.Items.Clear()

        ' Add a ListItem for each page
        For i As Integer = 0 To Products.PageCount - 1
            ' Add the new ListItem
            Dim pageListItem As New ListItem(String.Concat("Page ", i + 1), i.ToString())
            PageList.Items.Add(pageListItem)

            ' select the current item, if needed
            If i = Products.PageIndex Then
                pageListItem.Selected = True
            End If
        Next
    End Sub

    Protected Sub PageList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageList.SelectedIndexChanged
        ' Jump to the specified page
        Products.PageIndex = Convert.ToInt32(PageList.SelectedValue)
    End Sub

    Protected Sub SortPriceDescending_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortPriceDescending.Click
        'Sort by UnitPrice in descending order
        Products.Sort("UnitPrice", SortDirection.Descending)
    End Sub
End Class
