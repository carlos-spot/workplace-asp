
Partial Class PagingSortingDataListRepeater_Sorting
    Inherits System.Web.UI.Page

    Protected Sub ProductsDataSource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ProductsDataSource.Selecting
        'Have the ObjectDataSource sort the results by the selected sort expression
        e.Arguments.SortExpression = SortBy.SelectedValue
    End Sub
End Class
