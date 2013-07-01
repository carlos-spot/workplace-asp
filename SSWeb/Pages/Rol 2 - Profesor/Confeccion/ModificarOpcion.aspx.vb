Imports SSLogica
Imports System.Collections.Generic
''' <remarks>
''' Autor: Jose Eduardo Fallas
''' Versión: 1.0 
''' fecha de Creacion: 29-11-2010
''' Última modificacion: 29-11-2010
''' </remarks>
Partial Class Pages_Rol_2___Profesor_ModificarOpcion
    Inherits System.Web.UI.Page

    '''<summary>Carga del cuestionario</summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objGestor As New Gestor
        Try
            If Session("crear") = Nothing Then
                Session("crear") = Request.QueryString("crear")
            End If

            If Session("ct") > 1 Then
                Session("ct") = 0
            End If

            Session("ct") = Session("ct") + 1
            Session("codOpc") = Request.QueryString("codOpc")

            If Session("codEncuesta") = Nothing Then
                Session("codEncuesta") = Request.QueryString("codEncuesta")
            End If

            Session("codPregunta") = Request.QueryString("codPregunta")

            If Session("ct") <= 1 Then
                llenarListaPoductos()
                Dim opc As Opcion = objGestor.opcionBuscar(Session("codOpc"))
                If Not opc.CodigoProducto = -1 Then
                    txtTextoOpcion.Visible = False
                    Label2.Visible = False
                    cbxProducto.SelectedValue = opc.Producto.Nombre
                Else
                    lblProducto.Visible = False
                    cbxProducto.Visible = False
                    txtTextoOpcion.Text = opc.TextoOpcion
                End If
            Else

            End If
        Catch ex As Exception
            lblError.Text = "Problemas de conexión"
        End Try

        lblPregunta.Text = objGestor.preguntaBuscar(Session("codPregunta")).Descripcion

    End Sub

    '''<summary>Llena la lista de productos</summary>
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
    '''<summary>Modifica la opción y realiza los cambios, redirecciona a la página donde fue invocado</summary>
    Protected Sub btnIrPregunta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIrPregunta.Click
        Dim objGestor As New Gestor
        Try
            If cbxProducto.SelectedItem.Value = "--Seleccione--" Then
                Dim opc As Opcion = New Opcion(Session("codOpc"), txtTextoOpcion.Text, -1)
                objGestor.modificarOpcionDePregunta(opc)
            Else
                Dim codigoProducto As Integer = objGestor.devolverCodigoProducto(cbxProducto.SelectedItem.Value)
                Dim opc As Opcion = New Opcion(Session("codOpc"), cbxProducto.SelectedItem.Value, codigoProducto)
                objGestor.modificarOpcionDePregunta(opc)
            End If
            Session("codigoEncuesta") = Session("codEncuesta")
            Session("codEncuesta") = Nothing
            Session("ct") = Nothing
            If Session("crear") = "" Then
                Response.Redirect("ModificarPregunta.aspx?codPregunta=" & Session("codPregunta") & "&codEncuesta=" & Session("codigoEncuesta"))
            Else
                Response.Redirect("AgregarPreguntaCuestionario.aspx?codPregunta=" & Session("codPregunta") & "&codEncuesta=" & Session("codigoEncuesta"))
            End If

        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub
    '''<summary>Regresa a la modificación o confección de encuesta</summary>
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
