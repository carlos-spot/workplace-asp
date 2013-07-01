Imports SSLogica
Partial Class Pages_Rol_3___Asistente_Seguimiento
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' invalidarEncuestasMorosas()
        cargarEncuestasPorAsistente()
        lblError.Visible = False


    End Sub
    Private Sub invalidarEncuestasMorosas()
        Try
            Dim objGestor As New Gestor
            objGestor.invalidarEncuestasMorosas()
        Catch ex As Exception


        End Try

    End Sub

    Private Sub cargarInformacion(ByVal p_lista As List(Of Array))
        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow
        Dim listTemporal() As String

        'Creamos las columnas
        dt.Columns.Add(New Data.DataColumn("Id"))
        dt.Columns.Add(New Data.DataColumn("Nombre"))
        dt.Columns.Add(New Data.DataColumn("Fecha Inicio"))
        dt.Columns.Add(New Data.DataColumn("Fecha Fin"))
        dt.Columns.Add(New Data.DataColumn("Población"))
        dt.Columns.Add(New Data.DataColumn("Muestra"))
        dt.Columns.Add(New Data.DataColumn("Margen de error"))
        dt.Columns.Add(New Data.DataColumn("Proposito"))
        dt.Columns.Add(New Data.DataColumn("Tema"))

        'Recorremos la lista de Empleados
        If Not p_lista.Count = 0 Then
            gvEncuestas.Visible = True
            Dim i As Integer
            Dim n As Integer
            For n = 0 To p_lista.Count - 1
                dr = dt.NewRow()
                listTemporal = p_lista(n)
                For i = 0 To dt.Columns.Count - 1
                    dr(i) = listTemporal(i)
                Next
                dt.Rows.Add(dr)
            Next
            gvEncuestas.DataSource = dt
            gvEncuestas.DataBind()
            modificarTamannosDeCelda()
            '' lblError.Visible = False
            '' desBloquearMantenimiento()
        Else
            'Si no existen datos muestra el error
            gvEncuestas.Visible = True
            ''bloquearMantenimiento()

        End If
    End Sub
    Private Sub cargarEncuestasPorAsistente()
        'Limpiamos el gried view y hacemos desaparecer el label de error por si existe
        gvEncuestas.Columns.Clear()
        gvEncuestas.Width = "885"
        Try
            'Listamos los Empleados
            Dim objGestor As New Gestor
            Dim lista As List(Of Array) = objGestor.encuestaListarPorAsistente(Session("datosUsuarioLogin")(0))
            If Not lista Is Nothing And Not lista.Count = 0 Then
                cargarInformacion(lista)
                gvEncuestas.AllowRecordSelection = True

            Else
                Dim datosN() As String = {"", "", "", "", "", "", "", "", ""}
                lista.Add(datosN)
                cargarInformacion(lista)
                gvEncuestas.Width = "885"
                gvEncuestas.AllowRecordSelection = False

            End If


        Catch ex As Exception
            'lblError.Visible = True
            'lblError.Text = ex.Message
            'bloquearMantenimiento()
        End Try


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInvitarContactos.Click
        'If gvEncuestas.SelectedRow.Cells(1).Text() Is Nothing = "" Then
        '    ' 

        Dim listaE As ArrayList
        Dim hash As New Hashtable
        Try


            listaE = gvEncuestas.SelectedRecords()
            If Not listaE Is Nothing And Not listaE.Count = 0 Then

                hash = listaE.Item(0)
                Session("seleccion") = hash.Item("Id")
                'lblError.Text = Session("seleccion")
                Me.Response.Redirect("AgregarContactos.aspx?id=" & hash.Item("Id"))
                'End If
            End If
        Catch ex As Exception
            lblError.Text = "Debes seleccionar una encuesta"
            lblError.Visible = True

        End Try

    End Sub

    Protected Sub btnModificarEncuesta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificarEncuesta.Click
        Dim listaE As ArrayList
        Dim hash As New Hashtable
        Try


            listaE = gvEncuestas.SelectedRecords()
            If Not listaE Is Nothing And Not listaE.Count = 0 Then

                hash = listaE.Item(0)
                Session("seleccion") = hash.Item("Id")
                'lblError.Text = Session("seleccion")
                Me.Response.Redirect("ModificarEncuesta.aspx?id=" & hash.Item("Id"))
                'End If
            End If
        Catch ex As Exception
            lblError.Text = "Debes seleccionar una encuesta"
            lblError.Visible = True

        End Try

    End Sub
    Private Sub modificarTamannosDeCelda()

        'Cambiamos el tamaño para la columna "Codigo"
        gvEncuestas.Columns.Item("Id").Width = "52"
        'No mostramos los códigos reales para los temas
        gvEncuestas.Columns.Item("Nombre").Width = "225"
        gvEncuestas.Columns.Item("Fecha Inicio").Width = "104"
        gvEncuestas.Columns.Item("Fecha Fin").Width = "104"
        gvEncuestas.Columns.Item("Población").Width = "90"
        gvEncuestas.Columns.Item("Muestra").Width = "82"
        gvEncuestas.Columns.Item("Margen de error").Width = "78"
        gvEncuestas.Columns.Item("Proposito").Width = "0"
        gvEncuestas.Columns.Item("Tema").Width = "150"
        gvEncuestas.Columns.Item("Id").Visible = False


        'gvEncuestas.Width = "885"

        gvEncuestas.DataBind()


        'dt.Columns.Add(New Data.DataColumn("Id"))
        'dt.Columns.Add(New Data.DataColumn("Nombre"))
        'dt.Columns.Add(New Data.DataColumn("Fecha Inicio"))
        'dt.Columns.Add(New Data.DataColumn("Fecha Fin"))
        'dt.Columns.Add(New Data.DataColumn("Población"))
        'dt.Columns.Add(New Data.DataColumn("Muestra"))
        'dt.Columns.Add(New Data.DataColumn("Margen de error"))
        'dt.Columns.Add(New Data.DataColumn("Proposito"))
        'dt.Columns.Add(New Data.DataColumn("Tema"))


    End Sub

    Protected Sub Volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Volver.Click
        Try
            ''borrar variables de sesion
            Me.Response.Redirect("PrincipalAsistente.aspx")

        Catch ex As Exception


        End Try
    End Sub
End Class
