Imports SSLogica
Imports System.Collections.Generic

''' <remarks>
''' Autor: Jose Eduardo Fallas
''' Versión: 1.0
''' fecha de Creacion: 29-11-2010
''' Última modificacion: 29-11-2010
''' </remarks>
''' 
Partial Class Pages_Rol_2___Profesor_SeleccionarPreguntaDePila
    Inherits System.Web.UI.Page
    '''<summary>Carga de página</summary>
    ''' 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objGestor As New Gestor
        Session("nombreTema") = Request.QueryString("id") 'Nombre del tema de la encuesta
        Session("encuesta") = Request.QueryString("encuesta") 'Id de la encuesta en gestión
        Try
            Dim lista As List(Of Array)
            lista = objGestor.listarPreguntasSegunTema(Session("nombreTema"), "")
            If lista.Count = 0 Then
                lblError.Visible = True
                lblError.Text = "No se encontraron resultados"
            Else
                cargarDatos(lista)
            End If
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
        lblTitulo.Text = objGestor.encuestaBuscarPorCodigo(Session("encuesta")).nombre
    End Sub
    '''<summary>Ejecuta el método de buscar las preguntas según un criterio dado</summary>
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim objGestor As New Gestor
        If txtCriterio.Text = "" Then
            lblError.Visible = True
            lblError.Text = "Debe ingresar el criterio de búsqueda"
        Else
            Try
                Dim lista As List(Of Array)
                lista = objGestor.listarPreguntasSegunTema(Session("nombreTema"), txtCriterio.Text)
                If lista.Count = 0 Then

                Else
                    cargarDatos(lista)
                End If
            Catch ex As Exception
                lblError.Visible = True
                lblError.Text = ex.Message
            End Try
        End If
    End Sub
    '''<summary>Carga los datos</summary>
    Private Sub cargarDatos(ByVal p_lista As List(Of Array))
        Try
            Dim dt As New Data.DataTable
            Dim dr As Data.DataRow
            Dim listTemporal() As String

            dt.Columns.Add(New Data.DataColumn("Código"))
            dt.Columns.Add(New Data.DataColumn("Pregunta"))

            If Not p_lista.Count = 0 Then

                Dim i As Integer
                Dim n As Integer
                For n = 0 To p_lista.Count - 1
                    dr = dt.NewRow()
                    listTemporal = p_lista(n)
                    For i = 0 To dt.Columns.Count - 1
                        dr(i) = listTemporal(i)
                    Next
                    dt.Rows.Add(dr)
                Next
                gvPreguntas.DataSource = dt
                gvPreguntas.DataBind()

                'Cambiamos el tamaño para la columna "Codigo"
                gvPreguntas.Columns.Item("Código").Visible = False
                gvPreguntas.Columns.Item("Pregunta").Width = "500"
                gvPreguntas.DataBind()
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try

    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim objGestor As New Gestor
        Dim listaRecords As New ArrayList
        Dim hashId As New Hashtable
        Dim idPregunta As String
        listaRecords = gvPreguntas.SelectedRecords()


        If Not listaRecords Is Nothing Then
            If Not listaRecords.Count > 1 Then
                Try
                    hashId = listaRecords.Item(0)
                    idPregunta = hashId.Item("Código")

                    Dim codPregunta As Integer = CInt(idPregunta)
                    Try
                        objGestor.asociarPreguntaACuestionario(Session("encuesta"), idPregunta)
                        Response.Redirect("ConfeccionEncuesta.aspx?codEncuesta=" & Session("encuesta"))
                    Catch ex As Exception
                        lblError.Visible = True
                        lblError.Text = ex.Message
                    End Try
                Catch ex As Exception
                    lblError.Text = ex.Message
                End Try
            Else
                lblError.Text = "Debe seleccionar solamente una pregunta."
            End If
        Else
            lblError.Visible = True
            lblError.Text = "Debe seleccionar una pregunta."
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIraCuestionario.Click
        Response.Redirect("ConfeccionEncuesta.aspx?codEncuesta=" & Session("encuesta"))
    End Sub
End Class
