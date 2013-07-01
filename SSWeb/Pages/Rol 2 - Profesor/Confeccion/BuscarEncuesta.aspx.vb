
Imports SSLogica
Imports System.Collections.Generic
Imports System.Data

''' <remarks>
''' Autor: Jose Eduardo Fallas
''' Versión: 1.0
''' fecha de Creacion: 29-11-2010
''' Última modificacion: 29-11-2010
''' </remarks>

Partial Class Pages_Rol_2___Profesor_BuscarEncuesta
    Inherits System.Web.UI.Page

    '''<summary>Crea un nuevo cuestionario</summary>
    Protected Sub btnCrearCuestionario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCrearCuestionario.Click
        Dim objGestor As New Gestor
        Dim listaRecords As New ArrayList
        Dim hashId As New Hashtable
        Dim idEncuesta As String
        listaRecords = gvEncuestas.SelectedRecords()
        lblError.Text = ""
        If Not listaRecords Is Nothing Then
            If Not listaRecords.Count > 1 Then
                Try
                    hashId = listaRecords.Item(0)
                    idEncuesta = hashId.Item("Nombre")
                    Dim encuesta As Encuesta = objGestor.encuestaBuscar(idEncuesta)

                    objGestor.crearCuestionario(encuesta.codigo)

                    Response.Redirect("ConfeccionEncuesta.aspx?codEncuesta=" & encuesta.codigo)
                Catch ex As Exception
                    lblError.Text = ex.Message
                End Try
            Else
                lblError.Text = "Debe seleccionar solamente una encuesta."
            End If
        Else
            lblError.Visible = True
            lblError.Text = "Debe seleccionar una encuesta."
        End If

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
    '''<summary>Buscar una encuesta según el criterio dado</summary>
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim objGestor As New Gestor
        Try
            txtCriterio.Focus()
            Dim lista As New List(Of Array)
            lista = objGestor.encuestasBuscarPorNombre(SafeSqlLiteral(txtCriterio.Text), "Confección", Session("datosUsuarioLogin")(0))
            txtCriterio.Text = ""
            cargarEncuestas(lista)

        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub
    '''<summary>Carga la página</summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objGestor As New Gestor
        Try
            lblError.Visible = False
            Dim lista As List(Of Array) = objGestor.encuestasBuscarPorNombre("", "Confección", Session("datosUsuarioLogin")(0))
            cargarEncuestas(lista)
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub
End Class
