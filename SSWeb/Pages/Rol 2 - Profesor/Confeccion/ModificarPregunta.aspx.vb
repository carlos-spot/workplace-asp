Imports SSLogica
Imports System.Collections.Generic

''' <remarks>
''' Autor: Jose Eduardo Fallas
''' Versión: 1.0
''' fecha de Creacion: 29-11-2010
''' Última modificacion: 29-11-2010
''' </remarks>

Partial Class Pages_Rol_2___Profesor_ModificarPregunta
    Inherits System.Web.UI.Page
    '''<summary>Cargar la página</summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objGestor As New Gestor
        Session("cont") = Session("cont") + 1

        cbxTipoPregunta.Enabled = False
        lblError.ForeColor = Drawing.Color.Red
        lblError.Visible = False
        lblError1.Visible = False
        If Session("cont") > 1 Then
            Session("cont") = 0
        End If

        If Not IsPostBack Then
            Session("codPregunta") = Request.QueryString("codPregunta")
            Session("codEncuesta") = Request.QueryString("codEncuesta")
        End If

        Session("TipoPregunta") = objGestor.preguntaBuscar(Session("codPregunta")).TipoPregunta.NombreTipo

        Dim lista = objGestor.listarOpcionesPorPregunta(Session("codPregunta"))
        cargarOpciones(lista)

        If Session("cont") = 1 Then
            Dim pregunta As Pregunta
            pregunta = objGestor.preguntaBuscar(Session("codPregunta"))
            llenarListaTipos()
            cbxTipoPregunta.SelectedValue = pregunta.TipoPregunta.NombreTipo
            txtTextoPregunta.Text = pregunta.Descripcion

            Session("slt") = pregunta.TipoPregunta.NombreTipo
            Session("txt") = pregunta.Descripcion
        End If

        If Not Session("txt") = "" Then
            txtTextoPregunta.Text = Session("txt")
            cbxTipoPregunta.SelectedValue = Session("slt")
        End If
        lblEncuesta.Text = objGestor.encuestaBuscarPorCodigo(Session("codEncuesta")).nombre
    End Sub
    '''<summary>Lista de tipos de pregunta</summary>
    Private Sub llenarListaTipos()
        Dim objGestor As New Gestor
        Dim lista As List(Of Array)
        lista = objGestor.listarTiposPregunta()
        If cbxTipoPregunta.Items.Count <= 1 Then
            cbxTipoPregunta.Items.Add("--Seleccione--")
            For i = 0 To lista.Count - 1
                Dim valores As Array = lista(i)
                cbxTipoPregunta.Items.Add(valores(1))
            Next
        End If

    End Sub
    '''<summary>Agregar una nueva pregunta</summary>
    Protected Sub btnAgregarPregunta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarPregunta.Click
        Dim objGestor As New Gestor
        lblError.Visible = True
        If cbxTipoPregunta.SelectedValue.Equals("--Seleccione--") Then
            lblError.Text = "Debe seleccionar un tipo de pregunta"
        ElseIf txtTextoPregunta.Text = "" Then
            lblError.Text = "Debe digitar el texto de la pregunta"
        Else
            Try
                Try
                    Dim pregunta As Pregunta = objGestor.preguntaBuscar(Session("codPregunta"))
                    Dim nuevaPregunta As New Pregunta(pregunta.Codigo, txtTextoPregunta.Text, pregunta.IdTipoPregunta, pregunta.Tema.Codigo)
                    objGestor.modificarPreguntaDeCuestionario(nuevaPregunta)
                    txtTextoPregunta.Enabled = False
                    cbxTipoPregunta.Enabled = False
                    Dim lista = objGestor.listarOpcionesPorPregunta(Session("codPregunta"))
                    cargarOpciones(lista)
                    lblError.ForeColor = Drawing.Color.Blue
                    lblError.Text = "La modificación se realizó satisfactoriamente"
                    btnAgregarPregunta.Visible = False
                Catch ex As Exception
                    lblError.Text = ex.Message
                End Try
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End If

    End Sub
    Private Sub cargarOpciones(ByVal plista As List(Of Array))
        'Creción la tabla con los datos que se van a mostrar
        Dim tablaDatos As Data.DataTable = crearTabla(plista)
        actualizarTabla(tablaDatos)
        modificarTamannosDeCelda()
    End Sub

    'Genera la tabla que se mostrara en el Grid
    Private Function crearTabla(ByVal plista As List(Of Array)) As Data.DataTable
        Dim dt As New Data.DataTable
        Dim listTemporal() As String
        Dim filaDatos As Data.DataRow

        dt.Columns.Add(New Data.DataColumn("Código"))
        dt.Columns.Add(New Data.DataColumn("Opción"))

        'Recorremos la lista de Empleados
        If plista.Count > 0 Then

            Dim n As Integer
            For n = 0 To plista.Count - 1
                filaDatos = dt.NewRow()
                listTemporal = plista(n)

                If Not listTemporal(0) = 7 Then
                    filaDatos = dt.NewRow()
                    filaDatos(0) = listTemporal(0)
                    filaDatos(1) = listTemporal(1)
                    dt.Rows.Add(filaDatos)
                End If
            Next

        Else
            filaDatos = dt.NewRow()
            filaDatos(0) = ""
            filaDatos(1) = ""
        End If

        Return dt
    End Function

    'Actualiza la tabla con los nuevos datos
    Private Sub actualizarTabla(ByVal ptabla As Data.DataTable)
        gvOpciones.DataSource = ptabla
        gvOpciones.DataBind()
    End Sub

    'Modifica el tamaño de las celdas de la tabla
    Private Sub modificarTamannosDeCelda()

        gvOpciones.Columns.Item("Código").Visible = False
        gvOpciones.Columns.Item("Opción").Width = "350"

        gvOpciones.DataBind()
    End Sub
    '''<summary>Va a la página del cuestionario</summary>
    Protected Sub btnIrCuestionario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIrCuestionario.Click
        Session("codPregunta") = Nothing
        Session("cont") = Nothing
        Response.Redirect("ConfeccionEncuesta.aspx?codEncuesta=" & Session("codEncuesta"))
    End Sub

    '''<summary>Agrega una nueva opción</summary>
    Protected Sub btnAgregarOpcion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarOpcion.Click
        Session("cont") = Nothing
        If Session("TipoPregunta").Equals("Abierta") Then
            Response.Redirect("CriterioEvaluacionPreguntaAbiertas.aspx?codPregunta=" & Session("codPregunta"))
        Else
            Response.Redirect("AgrearOpcionCuestionario.aspx?codPregunta=" & Session("codPregunta") & "&codEncuesta=" & Session("codEncuesta") & "&crear=" & 1)
        End If
    End Sub
    '''<summary>Modifica una pregunta</summary>
    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        lblError1.Visible = True
        Dim listaRecords As New ArrayList
        Dim hashId As New Hashtable
        Dim idOpc As String
        listaRecords = gvOpciones.SelectedRecords()

        If Not listaRecords Is Nothing Then
            If Not listaRecords.Count > 1 Then
                Try
                    hashId = listaRecords.Item(0)
                    idOpc = hashId.Item("Código")

                    Dim codOpc As Integer = CInt(idOpc)
                    Session("cont") = 0
                    Session("cont") = Nothing
                    Response.Redirect("ModificarOpcion.aspx?codEncuesta=" & Session("codEncuesta") & "&codOpc=" & codOpc & "&codPregunta=" & Session("codPregunta"))

                Catch ex As Exception
                    lblError1.Text = ex.Message
                End Try
            Else
                lblError1.Text = "Debe seleccionar solamente una opción."
            End If
        Else
            lblError1.Visible = True
            lblError1.Text = "Debe seleccionar una opción."
        End If

        gvOpciones.SelectedRecords = Nothing
    End Sub
    '''<summary>Elimina una pregunta</summary>
    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim objGestor As New Gestor
        Dim listaRecords As New ArrayList
        Dim hashId As New Hashtable
        Dim idOpc As String
        listaRecords = gvOpciones.SelectedRecords()

        If Not listaRecords Is Nothing Then
            If Not listaRecords.Count > 1 Then
                Try
                    hashId = listaRecords.Item(0)
                    idOpc = hashId.Item("Código")

                    Dim codOpc As Integer = CInt(idOpc)
                    objGestor.eliminarOpcionDePregunta(Session("codPregunta"), codOpc)
                    lblError1.Text = "La opción se eliminó satisfactoriamente"
                    Dim lista = objGestor.listarOpcionesPorPregunta(Session("codPregunta"))
                    cargarOpciones(lista)

                Catch ex As Exception
                    lblError1.Text = ex.Message
                End Try
            Else
                lblError1.Text = "Debe seleccionar solamente una opción."
            End If
        Else
            lblError1.Visible = True
            lblError1.Text = "Debe seleccionar una opción."
        End If

        gvOpciones.SelectedRecords = Nothing

    End Sub

End Class
