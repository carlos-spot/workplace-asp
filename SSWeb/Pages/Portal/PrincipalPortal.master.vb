Imports SSLogica
Partial Class Pages_Portal_PrincipalPortal
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("Primera") Is Nothing Then
                Session("Primera") = "True"
                Dim objGestor As New Gestor
                objGestor.comprobarBDSurveySystem()
            End If
        Catch ex As Exception
            Response.Write("<script language='javascript' type='text/javascript'> alert('" & ex.Message & "');</Script>")
        End Try
    End Sub
End Class

