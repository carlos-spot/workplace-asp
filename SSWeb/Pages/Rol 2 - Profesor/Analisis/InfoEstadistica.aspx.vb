Imports Obout.Grid
Imports System.Web.UI.WebControls.ListView



Partial Class pages_Rol_2___Profesor_InfoEstadistica
    Inherits System.Web.UI.Page

    Dim gestor As New SSLogica.Gestor

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargarEncuestas()
    End Sub


    Private Sub cargarEncuestas()
        grnetEncuestas.Columns.Clear()
        grnetEncuestas.Columns.Clear()
        Try
            Dim lista As List(Of Array) = gestor.encuestasBuscarPorEstadoUsuario("Análisis", Session("datosUsuarioLogin")(0))
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

    Private Sub cargarInformacion(ByVal pidEncuesta As Integer)
        Dim gestor As New SSLogica.Gestor
        Dim datosHash As Hashtable = gestor.obtenerInfoEstadistica(pidEncuesta)
        Dim enc As SSLogica.Encuesta = gestor.encuestaBuscarPorCodigo(pidEncuesta)


        For Each objP As DictionaryEntry In datosHash
            'Titulo de la pregunta
            Dim datosInfo As String() = objP.Value
            Dim objLabel As New Label
            objLabel.Font.Size = 14
            objLabel.Text = objP.Key.ToString & "<br />"

            PanelDatos.Controls.Add(objLabel)


            'Titulo de la Moda
            Dim lblModa As New Label
            lblModa.CssClass = "Label"
            lblModa.Font.Size = 12
            lblModa.Text = "Moda: "


            PanelDatos.Controls.Add(lblModa)

            'Dato para la moda
            Dim lblDatoModa As New Label
            lblDatoModa.CssClass = "Label"
            lblDatoModa.Font.Size = 11
            lblDatoModa.Text = datosInfo(0) & "<br />"

            PanelDatos.Controls.Add(lblDatoModa)

            'Titulo de la Media
            Dim lblMedia As New Label
            lblMedia.CssClass = "Label"
            lblMedia.Font.Size = 12
            lblMedia.Text = "Media: "

            PanelDatos.Controls.Add(lblMedia)

            'Dato para la Media
            Dim lblDatoMedia As New Label
            lblDatoMedia.CssClass = "Label"
            lblDatoMedia.Font.Size = 11
            lblDatoMedia.Text = datosInfo(1) & "<br />"

            PanelDatos.Controls.Add(lblDatoMedia)

            'Titulo de la Mediana
            Dim lblMediana As New Label
            lblMediana.CssClass = "Label"
            lblMediana.Font.Size = 12
            lblMediana.Text = "Mediana: "

            PanelDatos.Controls.Add(lblMediana)

            'Datos para la mediana
            Dim lblDatoMediana As New Label
            lblDatoMediana.CssClass = "Label"
            lblDatoMediana.Font.Size = 11
            lblDatoMediana.Text = datosInfo(2) & "<br />"

            PanelDatos.Controls.Add(lblDatoMediana)

            'Titulo del persentil 25
            Dim lblPersentil25 As New Label
            lblPersentil25.CssClass = "Label"
            lblPersentil25.Font.Size = 12
            lblPersentil25.Text = "Persentil 25: "

            PanelDatos.Controls.Add(lblPersentil25)

            'Dato para el persentil 25
            Dim lblDatoPersentil25 As New Label
            lblDatoPersentil25.CssClass = "Label"
            lblDatoPersentil25.Font.Size = 11
            lblDatoPersentil25.Text = datosInfo(3) & "<br />"

            PanelDatos.Controls.Add(lblDatoPersentil25)

            'Titulo del persentil 50
            Dim lblPersentil50 As New Label
            lblPersentil50.CssClass = "Label"
            lblPersentil50.Font.Size = 11
            lblPersentil50.Text = "Persentil 50: "

            PanelDatos.Controls.Add(lblPersentil50)

            'Dato para el persentil 50
            Dim lblDatoPersentil50 As New Label
            lblDatoPersentil50.CssClass = "Label"
            lblDatoPersentil50.Font.Size = 11
            lblDatoPersentil50.Text = datosInfo(4) & "<br /> <br /><br />"

            PanelDatos.Controls.Add(lblDatoPersentil50)
        Next

    End Sub

    Protected Sub btnVerInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerInfo.Click
        Dim listaRecords As New ArrayList
        Dim hashId As New Hashtable
        Dim idEncuesta As Integer
        listaRecords = grnetEncuestas.SelectedRecords()
        Dim totalPreguntas As New Hashtable
        Dim tablaHTML As String = ""

        If Not listaRecords Is Nothing Then
            If Not listaRecords.Count > 1 Then
                Try
                    hashId = listaRecords.Item(0)
                    idEncuesta = (CInt(hashId.Item("Código")))
                    cargarInformacion(idEncuesta)
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
