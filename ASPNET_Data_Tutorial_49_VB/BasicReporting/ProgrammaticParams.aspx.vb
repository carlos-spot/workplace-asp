
Partial Class BasicReporting_ProgrammaticParams
    Inherits System.Web.UI.Page

    Protected Sub ObjectDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource1.Selecting
        e.InputParameters("month") = DateTime.Now.Month
    End Sub
End Class
