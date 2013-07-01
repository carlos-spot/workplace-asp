Imports SSLogica
Imports System.Collections.Generic

''' <remarks>
''' Autor: Jose Eduardo Fallas
''' Versión: 1.0
''' fecha de Creacion: 29-11-2010
''' Última modificacion: 29-11-2010
''' </remarks>
''' 
Partial Class Pages_Rol_2___Profesor_AgregarPreguntaCuestionario
    Inherits System.Web.UI.Page

    '''<summary>Cargar la página</summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objGestor As New Gestor
        lblError.Visible = False
        lblError1.Visible = False
        If Session("codEncuesta") = Nothing Then
            Session("codEncuesta") = Request.QueryString("codEncuesta")
        End If

        If Session("codPregunta") = Nothing Then
            Session("temaPregunta") = Request.QueryString("tema")

            cargarPregunta()
        Else
            cargarOpciones()
            Dim lista As List(Of Array) = objGestor.listarOpcionesPorPregunta(Session("codPregunta"))
            cargarOpciones(lista)
        End If

        Session("temaPregunta") = Request.QueryString("tema")
        llenarListaTipos()
        If Not Session("txt") = "" Then
            txtTextoPregunta.Text = Session("txt")
            cbxTipoPregunta.SelectedValue = Session("slt")
        End If
        lblEncuesta.Text = objGestor.encuestaBuscarPorCodigo(Session("codEncuesta")).nombre
    End Sub
    '''<summary>Llena la lista de tipos de pregunta</summary>
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
    '''<summary>Agregar un nueva pregunta</summary>
    Protected Sub btnAgregarPregunta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarPregunta.Click
        Dim objGestor As New Gestor
        If cbxTipoPregunta.SelectedValue.Equals("--Seleccione--") Then
            lblError.Visible = True
            lblError.Text = "Debe seleccionar un tipo de pregunta"
        ElseIf txtTextoPregunta.Text = "" Then
            lblError.Visible = True
            lblError.Text = "Debe digitar el texto de la pregunta"
        Else
            Try
                Dim codTipo As Integer = objGestor.devolverCodigoTipoPregunta(cbxTipoPregunta.SelectedValue)

                Dim codTema As Integer = CInt(Session("temaPregunta"))
                Dim pregunta As Pregunta = objGestor.registrarPregunta(txtTextoPregunta.Text, codTipo, codTema)
                Session("codPregunta") = pregunta.Codigo
                Session("TipoPregunta") = pregunta.TipoPregunta.NombreTipo
                Session("slt") = cbxTipoPregunta.SelectedValue
                Session("txt") = txtTextoPregunta.Text
                cargarOpciones()
                'Asignacion de la pregunta creada al cuestionario 
                objGestor.asociarPreguntaACuestionario(Session("codEncuesta"), Session("codPregunta"))
            Catch ex As Exception
                lblError.Visible = True
                lblError.Text = ex.Message
            End Try
        End If

    End Sub
    '''<summary>Carga las opciones de la pregunta</summary>
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
        dt.Columns.Add(New Data.DataColumn("Opcion"))
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
        gvOpciones.Columns.Item("Opcion").Width = "400px"

        gvOpciones.DataBind()
    End Sub

    '''<summary>Se devuelve a la página de gestión de la encuesta</summary>
    Protected Sub btnIrCuestionario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIrCuestionario.Click
        Session("codPregunta") = Nothing
        Session("slt") = Nothing
        Session("txt") = Nothing
        Response.Redirect("ConfeccionEncuesta.aspx?codEncuesta=" & Session("codEncuesta"))
    End Sub
    '''<summary>Elimina una de las opciones</summary>
    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim objGestor As New Gestor
        Dim listaRecords As New ArrayList
        Dim hashId As New Hashtable
        Dim idOpcion As String
        listaRecords = gvOpciones.SelectedRecords()

        If Not listaRecords Is Nothing Then
            If Not listaRecords.Count > 1 Then
                Try
                    hashId = listaRecords.Item(0)
                    idOpcion = hashId.Item("Código")

                    Dim codOpcion As Integer = CInt(idOpcion)
                    Try
                        objGestor.eliminarOpcionDePregunta(Session("codPregunta"), codOpcion)
                        lblError1.Text = "La opción se eliminó satisfactoriamente"
                        lblError1.ForeColor = Drawing.Color.Blue
                        lblError1.Visible = True
                    Catch ex As Exception
                        lblError1.Text = ex.Message
                        lblError1.Visible = True
                    End Try
                Catch ex As Exception
                    lblError1.Text = ex.Message
                    lblError1.ForeColor = Drawing.Color.Red
                    lblError1.Visible = True
                End Try
            Else
                lblError1.Text = "Debe seleccionar solamente una opción"
                lblError1.ForeColor = Drawing.Color.Red
            End If
        Else
            lblError.Visible = True
            lblError.Text = "Debe seleccionar una opción."
            lblError.ForeColor = Drawing.Color.Red
        End If
        gvOpciones.SelectedRecords = Nothing
        Dim lista As List(Of Array) = objGestor.listarOpcionesPorPregunta(Session("codPregunta"))
        cargarOpciones(lista)
    End Sub
    '''<summary>Modifica una de las opciones</summary>
    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        lblError.Visible = True
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
                    Session("codigoPregunta") = Session("codPregunta")
                    Session("codPregunta") = Nothing  ' bajar en una variable y mandar
                    Response.Redirect("ModificarOpcion.aspx?codEncuesta=" & Session("codEncuesta") & "&codOpc=" & codOpc & "&codPregunta=" & Session("codigoPregunta") & "&crear=" & 1)

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
    '''<summary>Agregar una nueva opción a la pregunta</summary>
    Protected Sub btnAgregarOpcion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarOpcion.Click
        If Session("TipoPregunta").Equals("Abierta") Then
            Response.Redirect("CriterioEvaluacionPreguntaAbiertas.aspx?codPregunta=" & Session("codPregunta"))
        Else
            Response.Redirect("AgrearOpcionCuestionario.aspx?codPregunta=" & Session("codPregunta") & "&codEncuesta=" & Session("codEncuesta") & "&crear=" & 1)
        End If
    End Sub
    '''<summary>Carga el cuadro de registro de una pregunta</summary>
    Private Sub cargarPregunta()
        gvOpciones.Visible = False
        lblError1.Visible = False
        btnAgregarOpcion.Visible = False
        btnEliminar.Visible = False
        btnModificar.Visible = False
        lblError.Visible = False
    End Sub
    '''<summary>Carga de el cuadro de registro y visualización de opciones</summary>
    Private Sub cargarOpciones()
        Dim objGestor As New Gestor
        btnAgregarPregunta.Visible = False
        Dim lista As List(Of Array) = objGestor.listarOpcionesPorPregunta(Session("codPregunta"))
        If lista.Count > 0 Then
            gvOpciones.Visible = True
        Else
            gvOpciones.Visible = False

        End If
        gvOpciones.Visible = True
        btnAgregarOpcion.Visible = True
        btnEliminar.Visible = True
        btnModificar.Visible = True
        cbxTipoPregunta.Enabled = False
        txtTextoPregunta.Enabled = False
        lblError.Visible = False
    End Sub

End Class
