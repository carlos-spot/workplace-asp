
Partial Class EditInsertDelete_ErrorHandling
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ExceptionDetails.Visible = False
    End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        If e.NewValues("UnitPrice") IsNot Nothing Then
            e.NewValues("UnitPrice") = Decimal.Parse(e.NewValues("UnitPrice").ToString(), System.Globalization.NumberStyles.Currency)
        End If
    End Sub

    Protected Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView1.RowUpdated
        If e.Exception IsNot Nothing Then
            ' Display a user-friendly message
            ExceptionDetails.Visible = True
            ExceptionDetails.Text = "There was a problem updating the product. "

            If e.Exception.InnerException IsNot Nothing Then
                Dim inner As Exception = e.Exception.InnerException

                If TypeOf inner Is System.Data.Common.DbException Then
                    ExceptionDetails.Text &= "Our database is currently experiencing problems. Please try again later."
                ElseIf TypeOf inner Is System.Data.NoNullAllowedException Then
                    ExceptionDetails.Text += "There are one or more required fields that are missing."
                ElseIf TypeOf inner Is ArgumentException Then
                    Dim paramName As String = CType(inner, ArgumentException).ParamName
                    ExceptionDetails.Text &= String.Concat("The ", paramName, " value is illegal.")
                ElseIf TypeOf inner Is ApplicationException Then
                    ExceptionDetails.Text += inner.Message
                End If
            End If

            ' Indicate that the exception has been handled
            e.ExceptionHandled = True

            ' Keep the row in edit mode
            e.KeepInEditMode = True
        End If
    End Sub
End Class
