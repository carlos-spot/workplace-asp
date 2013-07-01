Imports SSLogica

Partial Class Pages_Rol_2___Profesor_CriterioEvaluacionPreguntaAbiertas
    Inherits System.Web.UI.Page

    Protected Sub btnIrPregunta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIrPregunta.Click
        Dim objGestor As New Gestor
        If txtTextoOpcion.Text = "" Then
            lblError.Visible = True
            lblError.Text = "Debe ingresar el criterio"
        Else
            Dim opc As Opcion = objGestor.registrarOpcion(txtTextoOpcion.Text, -1)
            objGestor.asociarOpcionConPregunta(Session("codPregunta"), objGestor.devolverCodOpcionPorTexto(opc.TextoOpcion))
            Dim encuesta As Encuesta = objGestor.encuestaBuscarPorCodigo(Session("codEncuesta"))
            Response.Redirect("AgregarPreguntaCuestionario.aspx?tema=" & encuesta.tema.Codigo & "&codEncuesta=" & encuesta.codigo)
        End If
    End Sub

    Protected Sub btnAtras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Dim objGestor As New Gestor
        Dim encuesta As Encuesta = objGestor.encuestaBuscarPorCodigo(Session("codEncuesta"))
        Response.Redirect("AgregarPreguntaCuestionario.aspx?tema=" & encuesta.tema.Codigo & "&codEncuesta=" & encuesta.codigo)
    End Sub
End Class
