
Partial Class Pages_Rol_1___Administrador_Reportes_VistaReporteComparacion
    Inherits System.Web.UI.Page

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Response.Redirect("ComparacionEncuestas.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim codEncuesta1 As Integer = Request.QueryString("cod1")
        Dim codEncuesta2 As Integer = Request.QueryString("cod2")

        crsComparacion.Report.Parameters.Item(0).DefaultValue = codEncuesta1
        crsComparacion.Report.Parameters.Item(1).DefaultValue = codEncuesta2
    End Sub
End Class
