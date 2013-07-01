
Imports SSLogica
Imports System.Collections.Generic
Imports System.Data

''' <remarks>
''' Autor: Jose Eduardo Fallas
''' Versión: 1.0
''' fecha de Creacion: 29-11-2010
''' Última modificacion: 29-11-2010
''' </remarks>
''' 
Partial Class Pages_Rol_2___Profesor_ClonarEncuesta
    Inherits System.Web.UI.Page

    '''<summary>Realiza la clonación con respecto a la encuesta seleccionada</summary>
    Protected Sub btnClonar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClonar.Click
        Dim objGestor As New Gestor
        Dim listaRecords As New ArrayList
        Dim hashId As New Hashtable
        Dim idEncuesta As String
        listaRecords = gvEncuestas.SelectedRecords()
        If Not listaRecords Is Nothing Then
            If Not listaRecords.Count > 1 Then
                hashId = listaRecords.Item(0)
                idEncuesta = hashId.Item("Nombre")
                Dim encuesta As Encuesta = objGestor.encuestaBuscar(idEncuesta)
                objGestor.clonarCuestionario(encuesta.codigo, Session("codEncuesta"))
                Response.Redirect("ConfeccionEncuesta.aspx?codEncuesta=" & Session("codEncuesta"))

            Else
                lblError.Text = "Debe seleccionar solamente una encuesta."
            End If
        Else
            lblError.Visible = True
            lblError.Text = "Debe seleccionar una encuesta."
        End If

        lblTitulo.Text = objGestor.encuestaBuscarPorCodigo(Session("codEncuesta")).nombre

    End Sub
    Private Sub cargarEncuestas(ByVal plista As List(Of Array))
        'Creción la tabla con los datos que se van a mostrar
        Dim tablaDatos As Data.DataTable = crearTabla(plista)
        actualizarTabla(tablaDatos)
        modificarTamannosDeCelda()
    End Sub

    'Genera la tabla que se mostrara en el Grid
    Private Function crearTabla(ByVal plista As List(Of Array)) As Data.DataTable
        Dim tablaDatos As New Data.DataTable
        Dim listTemporal() As String
        Dim filaDatos As Data.DataRow

        'Creamos las columnas
        tablaDatos.Columns.Add(New Data.DataColumn("Nombre"))
        tablaDatos.Columns.Add(New Data.DataColumn("Tema"))
        tablaDatos.Columns.Add(New Data.DataColumn("Fecha de inicio"))

        'Recorremos la lista de Empleados
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

    'Actualiza la tabla con los nuevos datos
    Private Sub actualizarTabla(ByVal ptabla As Data.DataTable)
        gvEncuestas.DataSource = ptabla
        gvEncuestas.DataBind()
    End Sub

    'Modifica el tamaño de las celdas de la tabla
    Private Sub modificarTamannosDeCelda()

        gvEncuestas.Columns.Item("Nombre").Width = "350"
        gvEncuestas.Columns.Item("Tema").Width = "250"
        gvEncuestas.Columns.Item("Fecha de inicio").Width = "150"

        gvEncuestas.DataBind()
    End Sub
    '''<summary>Reemplazo de caracteres Sql</summary>
    Private Function SafeSqlLiteral(ByVal inputSQL As String) As String
        Return inputSQL.Replace("'", "''")
    End Function
    '''<summary>Ejecuta el método que busca y devuelve las encuestas según el criterio proporcionado</summary>

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim objGestor As New Gestor
        If txtCriterio.Text = "" Then
            lblError.Visible = True
            lblError.Text = "Debe ingresar el criterio de búsqueda"
            txtCriterio.Focus()
        Else
            Try
                Dim encuesta As Encuesta = objGestor.encuestaBuscarPorCodigo(Session("codEncuesta"))
                Dim lista As New List(Of Array)
                lista = objGestor.encuestasBuscarParaClonar(SafeSqlLiteral(txtCriterio.Text), encuesta.tema.Codigo)
                If lista.Count = 0 Then
                    txtCriterio.Focus()
                End If
                cargarEncuestas(lista)
            Catch ex As Exception
                lblError.Visible = True
                lblError.Text = ex.Message
            End Try
        End If


    End Sub
    '''<summary>Carga de la página</summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objGestor As New Gestor
        Session("codEncuesta") = Request.QueryString("codEncuesta")
        Dim encuesta As Encuesta = objGestor.encuestaBuscarPorCodigo(Session("codEncuesta"))
        lblTitulo.Text = encuesta.nombre
        Try
            lblError.Visible = False
            Dim lista As List(Of Array) = objGestor.encuestasBuscarParaClonar(Nothing, encuesta.idTema)
            cargarEncuestas(lista)
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnAtras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Response.Redirect("ConfeccionEncuesta.aspx?codEncuesta=" & Session("codEncuesta"))
    End Sub
End Class
