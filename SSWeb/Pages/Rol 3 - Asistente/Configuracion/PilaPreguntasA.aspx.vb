Imports SSLogica
Partial Class Pages_Rol_3___Asistente_Configuracion_PilaPreguntasA
    Inherits System.Web.UI.Page

    Dim gestor As New Gestor

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargarPreguntas()
        lblError.ForeColor = Drawing.Color.Red
        If My.Request.Params("__EVENTTARGET") = "eliminar" Then
            eliminar()
        ElseIf My.Request.Params("__EVENTTARGET") = "modificar" Then
            modificar()
        End If
    End Sub


    Private Sub cargarPreguntas()
        poolpreguntas.Columns.Clear()
        Try
            Dim lista As List(Of Array) = gestor.listarPreguntas()
            cargarInformacion(lista)

        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub


    Private Function crearTabla(ByVal plista As List(Of Array)) As Data.DataTable
        Dim tablaDatos As New Data.DataTable
        Dim listTemporal() As String
        Dim filaDatos As Data.DataRow
        tablaDatos.Columns.Add(New Data.DataColumn("Código"))
        tablaDatos.Columns.Add(New Data.DataColumn("Descripción"))
        tablaDatos.Columns.Add(New Data.DataColumn("Tema"))
        If plista.Count > 0 Then

            Dim n As Integer
            For n = 0 To plista.Count - 1
                filaDatos = tablaDatos.NewRow()
                listTemporal = plista(n)

                filaDatos(0) = listTemporal(0)
                filaDatos(1) = listTemporal(1)
                filaDatos(2) = listTemporal(2)

                tablaDatos.Rows.Add(filaDatos)
            Next

        Else
            filaDatos = tablaDatos.NewRow()
            filaDatos(0) = ""
            filaDatos(1) = ""
            filaDatos(2) = ""
        End If
        Return tablaDatos
    End Function

    Private Sub actualizarTabla(ByVal ptabla As Data.DataTable)
        poolpreguntas.DataSource = ptabla
        poolpreguntas.DataBind()
    End Sub


    Private Sub cargarInformacion(ByVal p_lista As List(Of Array))
        'Creamos la tabla con los dato de los productos que vamos a mostrar
        Dim tablaDatos As Data.DataTable = crearTabla(p_lista)
        actualizarTabla(tablaDatos)
        modificarTamannosDeCelda()
    End Sub


    Private Sub modificarTamannosDeCelda()
        'Cambiamos el tamaño para la columna "Nombre del tema"
        poolpreguntas.Columns.Item("Código").Width = "80"
        'Cambiamos el tamaño para la columna "Marca"
        poolpreguntas.Columns.Item("Descripción").Width = "490"
        poolpreguntas.Columns.Item("Tema").Width = "250"

        'No mostramos los códigos reales para los productos
        poolpreguntas.Columns.Item("Código").Visible = False
        poolpreguntas.DataBind()
    End Sub


    Private Sub eliminar()
        Dim listaRecords As New ArrayList
        Dim hashId As New Hashtable
        Dim idPregunta As Integer
        listaRecords = poolpreguntas.SelectedRecords()
        lblError.Text = ""
        If Not listaRecords Is Nothing Then
            If Not listaRecords.Count > 1 Then
                Try
                    hashId = listaRecords.Item(0)
                    idPregunta = (CInt(hashId.Item("Código")))
                    gestor.eliminarPregunta(idPregunta)
                    lblError.Text = "La pregunta fue eliminada satisfactoriamente."
                    lblError.ForeColor = Drawing.Color.Blue
                    cargarPreguntas()
                    poolpreguntas.SelectedRecords = Nothing
                Catch ex As Exception
                    lblError.Text = ex.Message
                End Try
            Else
                lblError.Text = "Debe ser seleccionar solamente una pregunta."
            End If
        Else
            lblError.Text = "Debe seleccionar la pregunta que desea eliminar."
        End If
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        eliminar()
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Response.Redirect("GestionPreguntaA.aspx?id=" & 1)
    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        modificar()
    End Sub

    Private Sub modificar()
        Dim esModificable As Boolean
        Dim listaRecords As New ArrayList
        Dim hashId As New Hashtable
        Dim idPregunta As Integer
        listaRecords = poolpreguntas.SelectedRecords()
        lblError.Text = ""
        If Not listaRecords Is Nothing Then
            If Not listaRecords.Count > 1 Then
                Try
                    hashId = listaRecords.Item(0)
                    idPregunta = (CInt(hashId.Item("Código")))
                    esModificable = gestor.esModificable(idPregunta)
                    If (esModificable = True) Then
                        Session("codPregunta") = idPregunta
                        Response.Redirect("GestionPreguntaA.aspx?id=" & 2)
                    Else
                        lblError.Text = "La pregunta no puede ser modificada porque ya existe en otro cuestionario"
                    End If
                Catch ex As Exception
                    lblError.Text = ex.Message
                End Try
            Else
                lblError.Text = "Debe ser seleccionar solamente una pregunta."
            End If
        Else
            lblError.Text = "Debe seleccionar la pregunta que desea modificar."
        End If
    End Sub

End Class

