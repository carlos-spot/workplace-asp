Imports SSLogica
Partial Class Pages_Rol_2___Profesor_Confeccion_GraficoReportePocentual
    Inherits System.Web.UI.Page
    Private gestor As New Gestor
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Session("codEncuesta") = Request.QueryString("codEncuesta")
            crs1.Report.Parameters(0).DefaultValue = "'" & gestor.encuestaBuscarPorCodigo(Session("codEncuesta")).codigo & "'"
            Dim titulo As String = gestor.encuestaBuscarPorCodigo(Session("codEncuesta")).nombre
            lblTitulo.Text = titulo
            'crv1.RefreshReport()
            'crv1.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnAtras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Response.Redirect("ReportePorcentualRespTabuladasA.aspx")
    End Sub
End Class
