Imports SSLogica
Imports System.IO


Partial Class Pages_Rol_1___Administrador_Configuracion_GestionArchivosAd
    Inherits System.Web.UI.Page
    Dim gestor As New SSLogica.Gestor


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargarEncuestas()
        lblError.ForeColor = Drawing.Color.Red
        lblError.Text = ""
        lblRetro1.Text = ""
        lblRetro1.ForeColor = Drawing.Color.Red
    End Sub


    Private Sub cargarEncuestas()
        gvEncuesta.Columns.Clear()
        gvEncuesta.Columns.Clear()
        Try
            Dim lista As List(Of Array) = gestor.encuestaListarWeb("Finalizada")
            cargarEncuestas(lista)

        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Private Sub cargarEncuestas(ByVal plista As List(Of Array))
        'Creamos la tabla con los dato de los productos que vamos a mostrar
        Dim tablaDatos As Data.DataTable = crearTabla(plista)
        actualizarTabla(gvEncuesta, tablaDatos)
        modificarTamannosDeCelda(gvEncuesta)
    End Sub

    'Genera la tabla que se mostrara en el Grind
    Private Function crearTabla(ByVal plista As List(Of Array)) As Data.DataTable
        Dim tablaDatos As New Data.DataTable
        Dim listTemporal() As String
        Dim filaDatos As Data.DataRow

        'Datos de la lista
        '{.codigo, .nombre, .fechaInicio, .fechaFin, .periodo.NombrePeriodo}

        'Creamos las columnas
        tablaDatos.Columns.Add(New Data.DataColumn("CodEncuesta"))
        tablaDatos.Columns.Add(New Data.DataColumn("Nombre"))
        tablaDatos.Columns.Add(New Data.DataColumn("FechaInicio"))
        tablaDatos.Columns.Add(New Data.DataColumn("FechaFin"))
        tablaDatos.Columns.Add(New Data.DataColumn("Periodo"))

        'Recorremos la lista de Empleados
        If plista.Count > 0 Then

            Dim n As Integer
            For n = 0 To plista.Count - 1
                filaDatos = tablaDatos.NewRow()

                'listTemporal(0) = Codigo de la encuesta
                'listTemporal(1) = Nombre 
                'listTemporal(5) = Fecha Inicio
                'listTemporal(6) = Fecha Fin
                'listTemporal(7) = Periodo
                listTemporal = plista(n)

                filaDatos(0) = listTemporal(0)
                filaDatos(1) = listTemporal(1)
                filaDatos(2) = listTemporal(5)
                filaDatos(3) = listTemporal(6)
                filaDatos(4) = listTemporal(7)

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
    Private Sub actualizarTabla(ByVal pGgDatos As Obout.Grid.Grid, ByVal ptabla As Data.DataTable)
        pGgDatos.DataSource = ptabla
        pGgDatos.DataBind()
    End Sub

    'Modifica el tamaño de las celdas de la tabla
    Private Sub modificarTamannosDeCelda(ByVal pGgDatos As Obout.Grid.Grid)
        'Cambiamos el tamaño para la columna "Nombre de la encuesta"
        pGgDatos.Columns.Item("Nombre").Width = "420"
        'Cambiamos el tamaño para la columna "Fecha de inicio"
        pGgDatos.Columns.Item("FechaInicio").Width = "110"
        'Cambiamos el tamaño para la columna "Fecha fin"
        pGgDatos.Columns.Item("FechaFin").Width = "110"
        'Cambiamos el tamaño para la columna "Periodo"
        pGgDatos.Columns.Item("Periodo").Width = "110"

        'No mostramos los códigos reales para los productos
        pGgDatos.Columns.Item("CodEncuesta").Visible = False
        pGgDatos.DataBind()
    End Sub


    Protected Sub pdf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pdf.Click
        gestorDescargas(".pdf")
    End Sub

    Protected Sub doc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles doc.Click
        gestorDescargas(".doc")
    End Sub

    Public Sub gestorDescargas(ByVal pext As String)
        Dim listaRecords As New ArrayList
        Dim hashId As New Hashtable
        Dim idEncuesta As Integer
        listaRecords = gvEncuesta.SelectedRecords()
        If Not listaRecords Is Nothing Then
            If Not listaRecords.Count > 1 Then
                Try
                    hashId = listaRecords.Item(0)
                    idEncuesta = (CInt(hashId.Item("CodEncuesta")))
                    ' Obtiene desc del puesto
                    Dim archivoDescargado As New ArrayList
                    archivoDescargado = gestor.bajarArchivo(idEncuesta, pext)
                    ' Revisa si existe
                    If archivoDescargado(0) Is Nothing Then
                        lblRetro1.Text = "El archivo solicitado no existe"
                    Else
                        'Dim destino As String
                        'destino = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & gestor.encuestaBuscarPorCodigo(idEncuesta).nombre & archivoDescargado(1)
                        'If File.Exists(destino) Then File.Delete(destino)
                        '' Crea el Archivo
                        'Dim fs As FileStream = New FileStream(destino, FileMode.CreateNew, FileAccess.ReadWrite)
                        'Dim bw As New BinaryWriter(fs)
                        'bw.Write(archivoDescargado(0))
                        'bw.Close()
                        'fs.Close()
                        downloadBinarios(CType(archivoDescargado(0), Byte()), gestor.encuestaBuscarPorCodigo(idEncuesta).nombre & archivoDescargado(1))

                        lblRetro1.Text = "El archivo ha sido descargado satisfactoriamente."
                        lblRetro1.ForeColor = Drawing.Color.Blue
                        gvEncuesta.SelectedRecords = Nothing
                    End If

                Catch ex As Exception
                    lblRetro1.Text = ex.Message
                End Try
            Else
                lblRetro1.Text = "Debe ser seleccionar solamente una encuesta."
            End If
        Else
            lblRetro1.Text = "Debe seleccionar la encuesta para descargar el archivo."
        End If

    End Sub

    Public Sub downloadBinarios(ByVal pbinarios As Byte(), ByVal filename As String)

        Try
            'fsize = fs.Length
            'Dim Binario(CInt(fs.Length)) As Byte
            'fs.Read(Binario, 0, CInt(fs.Length))
            Response.ClearHeaders()
            Response.ClearContent()
            Response.Clear()
            Response.ContentType = "application/octet-stream"
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename)
            Response.BinaryWrite(pbinarios)
            Response.Flush()
            'Response.End()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
