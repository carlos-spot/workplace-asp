
Partial Class Reporte_CantidadEncuestasPorTemaDadoPeriodo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportSource1.Report.Parameters(0).DefaultValue = Session("idPeriodoRep")
        CrystalReportSource1.Report.Parameters(1).DefaultValue = Session("idTemaRep")
        CrystalReportViewer1.RefreshReport()

    End Sub
    'Protected Sub CrystalReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Init
    '    CrystalReportSource1.Report.Parameters(0).DefaultValue = Session("idPeriodoRep")
    '    CrystalReportSource1.Report.Parameters(1).DefaultValue = Session("idTemaRep")

    '    CrystalReportViewer1.RefreshReport()

    '    'Session("idTemaRep") 

    '    'Session("idPeriodoRep")
    'End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Response.Redirect("ConsultarCantidadEncuestaPorTemaYPeriodoDadoA.aspx")
    End Sub
End Class
