Imports SSLogica
Imports System.Collections.Generic
''' <remarks>
''' Autor: Jose Eduardo Fallas
''' Versión: 1.0
''' fecha de Creacion: 29-11-2010
''' Última modificacion: 29-11-2010
''' </remarks>
Partial Class Pages_Rol_2___Profesor_AgrearOpcionCuestionario
    Inherits System.Web.UI.Page

    '''<summary>Carga el cuestionario, le asigna valor a las variables de sesión</summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("crear") = Nothing Then
            Session("crear") = Request.QueryString("crear")
        End If

        If Session("codPregunta") = Nothing Then
            Session("codPregunta") = Request.QueryString("codPregunta")
        End If
        If Session("codEncuesta") = Nothing Then
            Session("codEncuesta") = Request.QueryString("codEncuesta")
        End If

    End Sub

    '''<summary>Lista los productos </summary>
    Private Sub llenarListaPoductos()
        Dim objGestor As New Gestor
        Dim lista As List(Of Array)
        Dim enc As Encuesta = objGestor.encuestaBuscarPorCodigo(Session("codEncuesta"))
        lista = objGestor.listarProductosPorTema(enc.tema.Codigo)

        cbxProducto.Items.Clear()
        cbxProducto.Items.Add("--Seleccione--")

        For i = 0 To lista.Count - 1
            Dim valores As Array = lista(i)
            cbxProducto.Items.Add(valores(1))
        Next
    End Sub
    '''<summary>Agrega la opción y se la asigna a la pregunta. Regresa a la pregunta.</summary>
    Protected Sub btnIrPregunta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIrPregunta.Click
        Dim objGestor As New Gestor
        If txtTextoOpcion.Text = "" And cbxProducto.SelectedItem.Value = "--Seleccione--" Then
            lblError.Text = "Debe ingresar el dato requerido"
        Else
            Try
                If cbxProducto.SelectedItem.Value = "--Seleccione--" Then
                    Dim opc As Opcion = objGestor.registrarOpcion(txtTextoOpcion.Text, -1)
                    objGestor.asociarOpcionConPregunta(Session("codPregunta"), objGestor.devolverCodOpcionPorTexto(opc.TextoOpcion))
                Else
                    Dim codigoProducto As Integer = objGestor.devolverCodigoProducto(cbxProducto.SelectedItem.Value)
                    Dim opc As Opcion = objGestor.registrarOpcion(cbxProducto.SelectedItem.Value, codigoProducto)
                    opc = objGestor.devolverCodigoOpcionProducto()
                    objGestor.asociarOpcionConPregunta(Session("codPregunta"), opc.Codigo)
                End If
                Dim enc As Encuesta = objGestor.encuestaBuscarPorCodigo(Session("codEncuesta"))
                If Session("crear") = "" Then
                    Response.Redirect("ModificarPregunta.aspx?tema=" & enc.tema.Codigo & "&codEncuesta=" & Session("codEncuesta") & "&codPregunta=" & Session("codPregunta"))
                Else
                    Response.Redirect("AgregarPreguntaCuestionario.aspx?tema=" & enc.tema.Codigo & "&codEncuesta=" & Session("codEncuesta"))
                End If

            Catch ex As Exception
                lblError.Visible = True
                lblError.Text = ex.Message
            End Try
        End If
    End Sub

    '''<summary>Habilita la lista de productos si se requiere un producto, o el campo de texto si se quiere el ingresar el texto</summary>
    Protected Sub btnSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        rblSeleccionar.Visible = False
        rblSeleccionar.Enabled = False

        If rblSeleccionar.SelectedValue.Equals("ingresarTexto") Then
            txtTextoOpcion.Visible = True
            LblTexto.Visible = True
        Else
            cbxProducto.Visible = True
            LblProducto.Visible = True
        End If
        btnSiguiente.Visible = False
        btnIrPregunta.Visible = True
        btnAtras.Visible = True

        llenarListaPoductos()
    End Sub
    '''<summary>Ir a la página anterior</summary>
    Protected Sub btnAtras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Dim objGestor As New Gestor
        Dim enc As Encuesta = objGestor.encuestaBuscarPorCodigo(Session("codEncuesta"))
        If Session("crear") = "" Then
            Response.Redirect("ModificarPregunta.aspx?tema=" & enc.tema.Codigo & "&codEncuesta=" & Session("codEncuesta") & "&codPregunta=" & Session("codPregunta"))
        Else
            Response.Redirect("AgregarPreguntaCuestionario.aspx?tema=" & enc.tema.Codigo & "&codEncuesta=" & Session("codEncuesta"))
        End If
    End Sub
End Class
