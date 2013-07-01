Imports SSLogica
Imports System.Collections.Generic

''' <remarks>
''' Autor: Jose Eduardo Fallas
''' Versión: 1.0
''' fecha de Creacion: 29-11-2010
''' Última modificacion: 29-11-2010
''' </remarks>
''' 
Partial Class Pages_Rol_2___Profesor_ConfeccionEncuesta
    Inherits System.Web.UI.Page
    Private gestor As New Gestor

    '''<summary>Cargar página</summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblError.Text = ""
        lblError.Visible = False
        If Session("codEncuesta") = Nothing Then
            Session("codEncuesta") = Request.QueryString("codEncuesta")
        End If
        Dim lista As List(Of Array)
        Try
            lista = gestor.listarPreguntasDeEncuesta(Request.QueryString("codEncuesta"))
            cargarDatos(lista)
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try

        Dim titulo As String = gestor.encuestaBuscarPorCodigo(Request.QueryString("codEncuesta")).nombre
        lblTitulo.Visible = True
        lblTitulo.Text = titulo
        lblError.Visible = False


    End Sub

    '''<summary>Carga los datos en el grid</summary>
    Private Sub cargarDatos(ByVal plista As List(Of Array))
        'Creamos la tabla con los dato de los productos que vamos a mostrar
        Dim tablaDatos As Data.DataTable = crearTabla(plista)
        actualizarTabla(tablaDatos)
        modificarTamannosDeCelda()
    End Sub

    'Genera la tabla que se mostrara en el Grind
    Private Function crearTabla(ByVal plista As List(Of Array)) As Data.DataTable
        Dim tablaDatos As New Data.DataTable
        Dim listTemporal() As String
        Dim filaDatos As Data.DataRow

        'Creamos las columnas
        tablaDatos.Columns.Add(New Data.DataColumn("Codigo"))
        tablaDatos.Columns.Add(New Data.DataColumn("Pregunta"))

        'Recorremos la lista de Empleados
        If plista.Count > 0 Then

            Dim n As Integer
            For n = 0 To plista.Count - 1
                filaDatos = tablaDatos.NewRow()

                'listTemporal(0) = Codigo
                'listTemporal(1) = Pregunta
                listTemporal = plista(n)

                filaDatos(0) = listTemporal(0)
                filaDatos(1) = listTemporal(1)

                tablaDatos.Rows.Add(filaDatos)
            Next

        Else
            filaDatos = tablaDatos.NewRow()
            filaDatos(0) = ""
            filaDatos(1) = ""
        End If
        Return tablaDatos
    End Function

    'Actualiza la tabla con los nuevos datos
    Private Sub actualizarTabla(ByVal ptabla As Data.DataTable)
        gvPreguntas.DataSource = ptabla
        gvPreguntas.DataBind()
    End Sub

    'Modifica el tamaño de las celdas de la tabla
    Private Sub modificarTamannosDeCelda()

        'Cambiamos el tamaño para la columna "Codigo"
        gvPreguntas.Columns.Item("Codigo").Visible = False

        'Cambiamos el tamaño para la columna "Nombre del tema"
        gvPreguntas.Columns.Item("Pregunta").Width = "550"

        gvPreguntas.DataBind()
    End Sub
    '''<summary>Agregar una nueva pregunta</summary>
    Protected Sub btnAgregarPregunta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarPregunta.Click
        Dim encuesta As Encuesta = gestor.encuestaBuscarPorCodigo(Session("codEncuesta"))
        Response.Redirect("AgregarPreguntaCuestionario.aspx?tema=" & encuesta.tema.Codigo & "&codEncuesta=" & encuesta.codigo)

    End Sub

    '''<summary>Agregar una pregunta previamente registrada</summary>
    Protected Sub btnAgregarPreguntaPila_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarPreguntaPila.Click
        Dim encuesta As Encuesta = gestor.encuestaBuscarPorCodigo(Session("codEncuesta"))
        Response.Redirect("SeleccionarPreguntaDePila.aspx?id=" & encuesta.tema.Nombre & "&encuesta=" & encuesta.codigo)
    End Sub

    '''<summary>Modificar una pregunta</summary>
    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim listaRecords As New ArrayList
        Dim hashId As New Hashtable
        Dim idPregunta As String
        listaRecords = gvPreguntas.SelectedRecords()

        If Not listaRecords Is Nothing Then
            If Not listaRecords.Count > 1 Then
                Try
                    hashId = listaRecords.Item(0)
                    idPregunta = hashId.Item("Codigo")
                    Dim codPregunta As Integer = CInt(idPregunta)

                    If gestor.permiteModificar(codPregunta) Then
                        gvPreguntas.SelectedRecords = Nothing
                        Response.Redirect("ModificarPregunta.aspx?codPregunta=" & codPregunta & "&codEncuesta=" & Session("codEncuesta") & "&crear=" & 1)
                    Else
                        lblError.Visible = True
                        lblError.Text = "No se puede modificar está pregunta, existen registros asociados"
                    End If

                    Dim lista = gestor.listarPreguntasDeEncuesta(Session("codEncuesta"))
                    cargarDatos(lista)

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
    '''<summary>Clonar las preguntas de una encuesta ya finalizada del mismo tema</summary>
    Protected Sub btnClonarEncuesta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClonarEncuesta.Click
        Dim encuesta As Encuesta = gestor.encuestaBuscarPorCodigo(Session("codEncuesta"))
        Response.Redirect("ClonarEncuesta.aspx?codEncuesta=" & encuesta.codigo)
    End Sub

    '''<summary>Envia la notificación al encargado de seguimiento y pone la encuesta en estado de seguimiento</summary>
    Protected Sub btnNotificacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNotificacion.Click
        Try
            Try
                gestor.cambiarEstadoEncuestaASeguimiento(Session("codEncuesta"))
            Catch ex As Exception
                lblError.Text = ex.Message
                lblError.Visible = True
            End Try
            Dim encuesta As Encuesta = gestor.encuestaBuscarPorCodigo(Session("codEncuesta"))
            gestor.enviarCorreoConHTML("EncargadoSeguimiento", "Tiene una encuesta pendiente para dar seguimiento", gestor.usuarioBuscar(encuesta.idEncargadoSeguimiento), encuesta.codigo)
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "No se envió notificación por problemas de conexión"
        End Try
        Session.Remove("codEncuesta")
        Session.Remove("codPregunta")
        Session.Remove("temaPregunta")
        Session.Remove("txt")
        Session.Remove("slt")
        Session.Remove("TipoPregunta")
        Session.Remove("cont")
        Session.Remove("codigoPregunta")
        Response.Redirect("~/Pages/Rol 2 - Profesor/PrincipalProfesor.aspx")
    End Sub
    '''<summary>Elimina una pregunta del cuestionario</summary>
    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim listaRecords As New ArrayList
        Dim hashId As New Hashtable
        Dim idPregunta As String
        listaRecords = gvPreguntas.SelectedRecords()

        If Not listaRecords Is Nothing Then
            If Not listaRecords.Count > 1 Then
                Try
                    hashId = listaRecords.Item(0)
                    idPregunta = hashId.Item("Codigo")

                    Dim codPregunta As Integer = CInt(idPregunta)
                    gestor.eliminarPreguntaDeCuestionario(codPregunta, Session("codEncuesta"))
                    lblError.Text = "La pregunta se eliminó satisfactoriamente"
                    Dim lista = gestor.listarPreguntasDeEncuesta(Session("codEncuesta"))
                    cargarDatos(lista)

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

        gvPreguntas.SelectedRecords = Nothing
    End Sub
    '''<summary>Dirige a la página de inicio de profesor</summary>
    Protected Sub btnGuardarCuestionario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarCuestionario.Click
        Session.Remove("codEncuesta")
        Session.Remove("codPregunta")
        Session.Remove("temaPregunta")
        Session.Remove("txt")
        Session.Remove("slt")
        Session.Remove("TipoPregunta")
        Session.Remove("cont")
        Session.Remove("codigoPregunta")
        Response.Redirect("~/Pages/Rol 2 - Profesor/PrincipalProfesor.aspx")
    End Sub

    Protected Sub btnVistaPrevia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVistaPrevia.Click
        Dim encuesta As Encuesta = gestor.encuestaBuscarPorCodigo(Session("codEncuesta"))
        Response.Redirect("VistaPrevia.aspx?codEncuesta=" & encuesta.codigo)
    End Sub
End Class
