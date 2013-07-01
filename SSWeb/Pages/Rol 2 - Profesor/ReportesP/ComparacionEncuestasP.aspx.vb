
Partial Class Pages_Rol_1___Administrador_Reportes_ComparacionEncuestas
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Cargamos los temas y codigos en el DropDownList "ddlPeriodos y ddlTemas"
            cargarPeriodos()
            cargarTemas()
        End If
    End Sub

    Public Sub cargarTemas()
        Dim gestor As New SSLogica.Gestor
        If ddlTemas.Items.Count <= 0 Then
            Dim listaTemas As List(Of Array) = gestor.cargarTemas()
            ddlTemas.Items.Add("--Seleccionar--")
            lbCodigosTemas.Items.Add("--Seleccionar--")
            For Each objArray In listaTemas
                'En la posicion 1 del Array biene el nombre del tema
                'En la posición 2 del Array bien el codigo del tema
                ddlTemas.Items.Add(objArray(1).ToString)
                lbCodigosTemas.Items.Add(objArray(0).ToString)
            Next
        End If
    End Sub

    Public Sub cargarPeriodos()
        Dim gestor As New SSLogica.Gestor
        If ddlPeriodos.Items.Count <= 0 Then
            Dim listaPeriodos As List(Of Array) = gestor.cargarPeriodos()
            ddlPeriodos.Items.Add("--Seleccionar--")
            lbCodigosPeriodos.Items.Add("--Seleccionar--")
            For Each objArray In listaPeriodos
                'En la posicion 1 del Array biene el nombre del tema
                'En la posición 2 del Array bien el codigo del tema
                ddlPeriodos.Items.Add(objArray(1).ToString)
                lbCodigosPeriodos.Items.Add(objArray(0).ToString)
            Next
        End If
    End Sub

    Private Sub cargarPrimerGridDeEncuestas(ByVal plista As List(Of Array))
        'Creamos la tabla con los dato de los productos que vamos a mostrar
        Dim tablaDatos As Data.DataTable = crearTabla(plista)
        actualizarTabla(gvPrimeraEncuesta, tablaDatos)
        modificarTamannosDeCelda(gvPrimeraEncuesta)
    End Sub

    Private Sub cargarSegundoGridDeEncuestas(ByVal plista As List(Of Array))
        'Creamos la tabla con los dato de los productos que vamos a mostrar
        Dim tablaDatos As Data.DataTable = crearTabla(plista)
        actualizarTabla(gvSegundaEncuesta, tablaDatos)
        modificarTamannosDeCelda(gvSegundaEncuesta)
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
                'listTemporal(2) = Fecha Inicio
                'listTemporal(3) = Fecha Fin
                'listTemporal(4) = Periodo
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

    Protected Sub btnComparar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComparar.Click
        Dim gestor As New SSLogica.Gestor
        Dim codPeriodo As Integer = CInt(lbCodigosPeriodos.Items(ddlPeriodos.SelectedIndex).ToString)
        Dim codTema As Integer = CInt(lbCodigosTemas.Items(ddlTemas.SelectedIndex).ToString)
        Dim objHasht As Hashtable = gvPrimeraEncuesta.SelectedRecords.Item(0)
        Dim codEncuestaExcluir As Integer = objHasht.Item("CodEncuesta")

        Dim lista As List(Of Array) = gestor.encuestaBuscarParaComparar(codPeriodo, codTema, codEncuestaExcluir)
        cargarSegundoGridDeEncuestas(lista)
        Try
            'Bloqueamos y desbloqueamos el boton "btnGenerarReporte"
            If gvSegundaEncuesta.Rows.Count >= 1 Then
                btnGenerarReporte.Enabled = True
            Else
                btnGenerarReporte.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnGenerarReporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerarReporte.Click
        Dim objHasht1 As Hashtable = gvPrimeraEncuesta.SelectedRecords.Item(0)
        Dim codEncuesta1 As Integer = objHasht1.Item("CodEncuesta")

        Dim objHasht2 As Hashtable = gvSegundaEncuesta.SelectedRecords.Item(0)
        Dim codEncuesta2 As Integer = objHasht2.Item("CodEncuesta")

        Response.Redirect("VistaReporteComparacionP.aspx?cod1=" & codEncuesta1 & "&cod2=" & codEncuesta2)
    End Sub

    Protected Sub ddlTemas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTemas.SelectedIndexChanged
        Dim gestor As New SSLogica.Gestor

        If Not (ddlPeriodos.SelectedItem.Value.ToString = "--Seleccionar--") And Not (ddlTemas.SelectedItem.Value.ToString = "--Seleccionar--") Then
            Dim codPeriodo As Integer = CInt(lbCodigosPeriodos.Items(ddlPeriodos.SelectedIndex).ToString)
            Dim codTema As Integer = CInt(lbCodigosTemas.Items(ddlTemas.SelectedIndex).ToString)

            Dim lista As List(Of Array) = gestor.encuestaBuscarParaComparar(codPeriodo, codTema, -1)

            cargarPrimerGridDeEncuestas(lista)
            cargarSegundoGridDeEncuestas(New List(Of Array))
            Try
                'Bloqueamos y desbloqueamos el boton "btnComparar"
                If gvPrimeraEncuesta.Rows.Count >= 2 Then
                    btnComparar.Enabled = True
                Else
                    btnComparar.Enabled = False
                End If

                'Bloqueamos y desbloqueamos el boton "btnGenerarReporte"
                If gvSegundaEncuesta.Rows.Count >= 2 Then
                    btnGenerarReporte.Enabled = True
                Else
                    btnGenerarReporte.Enabled = False
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
