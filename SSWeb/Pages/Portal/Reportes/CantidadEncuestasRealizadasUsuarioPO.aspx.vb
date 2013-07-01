
Partial Class Reporte_CantidadEncuestasRealizadasUsuario
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportAnalisisSource.Report.Parameters(0).DefaultValue = Session("idUsuarioAnalisis")
        'CrystalReportAnalisisSource.Report.Parameters(1).DefaultValue = Session("idUsuarioAnalisis")
        CrystalReportAnalisisViewer.RefreshReport()

    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Response.Redirect("ConsultarCantidadEncuestasRealizadasUsuarioPO.aspx")

    End Sub
End Class
