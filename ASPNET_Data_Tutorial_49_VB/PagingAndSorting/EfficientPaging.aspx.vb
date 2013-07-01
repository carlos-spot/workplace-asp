
Partial Class PagingAndSorting_EfficientPaging
    Inherits System.Web.UI.Page

    ' The following two event handlers illustrate two different techniques you can use to
    ' correctly handle deleting when using custom paging with an ObjectDataSource. Currently,
    ' these event handlers aren't wired up to any event, so they have no effect. But if you
    ' configure the GridView to support deleing, you'll want to use either one of these two
    ' approaches so that when a user deletes the last record from a page, the GridView's PageIndex
    ' is updated accordingly.

    Protected Sub ObjectDataSource1_Deleted(ByVal sender As Object, ByVal e As ObjectDataSourceStatusEventArgs)
        ' If we get back a Boolean value from the DeleteProduct method and it's true, then
        ' we successfully deleted the product. Set AffectedRows to 1
        If TypeOf e.ReturnValue Is Boolean AndAlso CType(e.ReturnValue, Boolean) = True Then
            e.AffectedRows = 1
        End If
    End Sub

    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As GridViewDeletedEventArgs)
        ' If we just deleted the last row in the GridView, decrement the PageIndex
        If e.Exception Is Nothing AndAlso GridView1.Rows.Count = 1 Then
            ' we just deleted the last row
            GridView1.PageIndex = Math.Max(0, GridView1.PageIndex - 1)
        End If
    End Sub
End Class
