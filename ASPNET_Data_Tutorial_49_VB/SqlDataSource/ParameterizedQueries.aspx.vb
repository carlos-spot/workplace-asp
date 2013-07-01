Partial Class SqlDataSource_ParameterizedQueries
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Get the data from the SqlDataSource as a DataView
        Dim randomCategoryView As System.Data.DataView = CType(RandomCategoryDataSource.Select(DataSourceSelectArguments.Empty), System.Data.DataView)

        If randomCategoryView.Count > 0 Then
            ' Assign the CategoryName value to the Label
            CategoryNameLabel.Text = String.Format("Here are Products in the {0} Category...", randomCategoryView(0)("CategoryName").ToString())

            ' Assign the ProductsByCategoryDataSource's CategoryID parameter's DefaultValue property
            ProductsByCategoryDataSource.SelectParameters("CategoryID").DefaultValue = randomCategoryView(0)("CategoryID").ToString()
        End If
    End Sub
End Class
