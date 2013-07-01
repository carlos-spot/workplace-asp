Imports SSLogica
Imports System.IO

Partial Class Pages_Rol_1___Administrador_VerInfoEstadistica
    Inherits System.Web.UI.Page
    Dim gestorDE As New SSLogica.Gestor

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargarEncuestas()
        lblError.Text = ""
        lblError.ForeColor = Drawing.Color.Red
    End Sub

    Private Sub cargarEncuestas()
        gvEncuesta.Columns.Clear()
        gvEncuesta.Columns.Clear()
        Try
            Dim lista As List(Of Array) = gestorDE.encuestaListarWeb("Finalizada")
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

    Protected Sub bTabular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bTabular.Click
        Dim listaRecords As New ArrayList
        Dim hashId As New Hashtable
        Dim idEncuesta As Integer
        listaRecords = gvEncuesta.SelectedRecords()
        Dim totalPreguntas As New Hashtable
        Dim tablaHTML As String = ""

        If Not listaRecords Is Nothing Then
            If Not listaRecords.Count > 1 Then
                Try
                    hashId = listaRecords.Item(0)
                    idEncuesta = (CInt(hashId.Item("CodEncuesta")))
                    totalPreguntas = gestorDE.tabularMasivo(idEncuesta)
                    Dim enc As Encuesta = gestorDE.encuestaBuscarPorCodigo(idEncuesta)
                    tablaHTML += "<html><head><tittle>Survey System</tittle><link href=""../../css/EstiloTabulacion.css"" rel=""stylesheet"" type=""text/css"" /></head><body><h1>Encuesta: " & enc.nombre & "</h1>" + _
                    "<h2>Tema: " & enc.tema.Nombre & "</h2><h2>Resultados de la encuesta:</h2><br/><table border=""0""><tr><td>"
                    For i As Integer = 0 To totalPreguntas.Count - 1
                        tablaHTML += "<table border=""0"" class=""resultadoPregunta"">"
                        Dim totalOpcionesPreguntaActual As Hashtable = totalPreguntas.Item(totalPreguntas.Keys(i))
                        tablaHTML += "<tr><td rowspan=" & Chr(34) & totalOpcionesPreguntaActual.Count & Chr(34) & "class=""textoPregunta"">" & totalPreguntas.Keys(i).ToString & "</td>"
                        tablaHTML += "<td class=""textoOpcion"" >" & totalOpcionesPreguntaActual.Keys(0).ToString & "</td>"
                        tablaHTML += "<td class=""valorOpcion"" >" & FormatNumber(totalOpcionesPreguntaActual.Item(totalOpcionesPreguntaActual.Keys(0)), 2) & " %</td></tr>"
                        For j As Integer = 1 To totalOpcionesPreguntaActual.Count - 1
                            If (Not CStr(totalOpcionesPreguntaActual.Keys(j)).Equals("Respuesta abierta")) Then
                                tablaHTML += "<tr><td class=""textoOpcion"" >" & totalOpcionesPreguntaActual.Keys(j).ToString & "</td>"
                                tablaHTML += "<td class=""valorOpcion"" >" & FormatNumber(totalOpcionesPreguntaActual.Item(totalOpcionesPreguntaActual.Keys(j)), 2) & " %</td></tr>"
                            End If
                        Next
                        tablaHTML += "</table>"
                    Next
                    tablaHTML += "</td></tr></table></body></html>"
                    If bTabular.Attributes.Count > 0 Then
                        bTabular.Attributes.Clear()
                    End If
                    ClientScript.RegisterStartupScript(Me.GetType(), "GenerarTabla", "<script> mostrarTabla('" & tablaHTML & "'); </script>")

                Catch ex As Exception
                    lblError.Text = ex.Message
                End Try
            Else
                lblError.Text = "Debe ser seleccionar solamente una encuesta."
            End If
        Else
            lblError.Text = "Debe seleccionar la encuesta que desea tabular."
        End If
    End Sub

    Public Function DOC_Bytes(ByVal Path As String) As Byte()
        Dim sPath As String
        sPath = Path
        Dim Ruta As New FileStream(sPath, FileMode.Open, FileAccess.Read)
        Dim Binario(CInt(Ruta.Length)) As Byte
        Ruta.Read(Binario, 0, CInt(Ruta.Length))
        Ruta.Close()
        Return Binario
    End Function

End Class

