
Partial Class pages_Rol_2___Profesor_Analisis_ReportesPantallas_RepReavsEspe
    Inherits System.Web.UI.Page

    Dim gestor As New SSLogica.Gestor

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargarEncuestas()
    End Sub


    Private Sub cargarEncuestas()
        grnetEncuestas.Columns.Clear()
        grnetEncuestas.Columns.Clear()
        Try
            Dim lista As List(Of Array) = gestor.encuestaListarWeb("Finalizada")
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
        tablaDatos.Columns.Add(New Data.DataColumn("Nombre"))
        tablaDatos.Columns.Add(New Data.DataColumn("Población"))
        tablaDatos.Columns.Add(New Data.DataColumn("Muestra"))
        tablaDatos.Columns.Add(New Data.DataColumn("Tema"))

        If plista.Count > 0 Then

            Dim n As Integer
            For n = 0 To plista.Count - 1
                filaDatos = tablaDatos.NewRow()
                listTemporal = plista(n)
                filaDatos(0) = listTemporal(0)
                filaDatos(1) = listTemporal(1)
                filaDatos(2) = listTemporal(2)
                filaDatos(3) = listTemporal(3)
                filaDatos(4) = listTemporal(4)

                tablaDatos.Rows.Add(filaDatos)
            Next
        Else
            filaDatos = tablaDatos.NewRow()
            filaDatos(0) = ""
            filaDatos(1) = ""
            filaDatos(2) = ""
            filaDatos(3) = ""
            filaDatos(4) = ""
        End If
        Return tablaDatos
    End Function



    'Actualiza la tabla con los nuevos datos
    Private Sub actualizarTabla(ByVal ptabla As Data.DataTable)
        grnetEncuestas.DataSource = ptabla
        grnetEncuestas.DataBind()
    End Sub


    Private Sub cargarInformacion(ByVal p_lista As List(Of Array))
        Dim tablaDatos As Data.DataTable = crearTabla(p_lista)
        actualizarTabla(tablaDatos)
        modificarTamannosDeCelda()
    End Sub



    Private Sub modificarTamannosDeCelda()

        'Cambiamos el tamaño para la columna "Nombre del tema"
        grnetEncuestas.Columns.Item("Código").Width = "80"
        'Cambiamos el tamaño para la columna "Marca"
        grnetEncuestas.Columns.Item("Nombre").Width = "300"
        'Cambiamos el tamaño para la columna "Fabricante"
        grnetEncuestas.Columns.Item("Población").Width = "90"
        'Cambiamos el tamaño para la columna "Muestra"
        grnetEncuestas.Columns.Item("Muestra").Width = "90"
        'Cambiamos el tamaño para la columna "Tema"
        grnetEncuestas.Columns.Item("Tema").Width = "200"

        'No mostramos los códigos reales para los productos
        grnetEncuestas.Columns.Item("Código").Visible = False
        grnetEncuestas.DataBind()
    End Sub

    Private Sub insertarParam(ByVal pparam As Integer)
        crs01.Report.Parameters(0).DefaultValue = "'" + CStr(pparam) + "'"
        crv01.RefreshReport()
        crv01.DataBind()

    End Sub



    Protected Sub btnVer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVer.Click
        Dim listaRecords As New ArrayList
        Dim hashId As New Hashtable
        Dim idEncuesta As Integer
        listaRecords = grnetEncuestas.SelectedRecords()
        Dim totalPreguntas As New Hashtable

        If Not listaRecords Is Nothing Then
            If Not listaRecords.Count > 1 Then
                Try
                    hashId = listaRecords.Item(0)
                    idEncuesta = (CInt(hashId.Item("Código")))
                    insertarParam(idEncuesta)
                Catch ex As Exception
                    lblError.Text = ex.Message
                End Try
            Else
                lblError.Text = "Debe ser seleccionar solamente una encuesta."
            End If
        Else
            lblError.Text = "Debe seleccionar la encuesta que desea ver."
        End If
    End Sub

End Class