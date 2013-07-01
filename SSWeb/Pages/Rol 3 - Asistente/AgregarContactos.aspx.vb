Imports SSLogica
Imports System.Collections.ArrayList
Partial Class Pages_Rol_3___Asistente_AgregarContactos
    Inherits System.Web.UI.Page
    Private encuestaActual As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblInformacin.Text = ""
        lblInformacin.ForeColor = Drawing.Color.Blue
        lblInformacin.Visible = False
        encuestaActual = Session("seleccion")
        cargarEncuestasPorAsistente()
        cargarContactos()
        cargarContactosInvitados()
        lblException.Visible = False
        If IsPostBack Then


        End If

    End Sub

    Private Sub cargarContactos()
        Try
            gContactos.Columns.Clear()
            gContactos.Width = "352"
        Catch ex As Exception
            lblException.Text = ex.Message
        End Try
        'Limpiamos el gried view y hacemos desaparecer el label de error por si existe

        'For x As Integer = 0 To gContactos.Columns.Count - 1
        '    gContactos.Columns(x).ItemStyle.Width = 30
        'Next
        Try
            'Listamos los contactos
            Dim lista As List(Of Array) = (New Gestor).listarContactos()
            If Not lista Is Nothing And Not lista.Count = 0 Then
                cargarInformacionContactos(lista)
               
            Else
                Dim datosN() As String = {"", "", "", "", "", "", ""}
                lista.Add(datosN)
                cargarInformacionContactos(lista)
            End If


        Catch ex As Exception
            'lblError.Visible = True
            'lblError.Text = ex.Message

        End Try

    End Sub
    'Private Sub cargarInformacion(ByVal p_lista As List(Of Array))
    '    Dim dt As New Data.DataTable
    '    Dim dr As Data.DataRow
    '    Dim listTemporal() As String

    '    'Creamos las columnas
    '    dt.Columns.Add(New Data.DataColumn("Id"))
    '    dt.Columns.Add(New Data.DataColumn("Nombre"))
    '    dt.Columns.Add(New Data.DataColumn("Inicio"))
    '    dt.Columns.Add(New Data.DataColumn("Fin"))
    '    dt.Columns.Add(New Data.DataColumn("Población"))
    '    dt.Columns.Add(New Data.DataColumn("Muestra"))
    '    dt.Columns.Add(New Data.DataColumn("Margen/error"))
    '    dt.Columns.Add(New Data.DataColumn("Propósito"))
    '    dt.Columns.Add(New Data.DataColumn("Tema"))

    '    'Recorremos la lista de Empleados
    '    If Not p_lista.Count = 0 Then
    '        gvEncuestas.Visible = True
    '        Dim i As Integer
    '        Dim n As Integer
    '        For n = 0 To p_lista.Count - 1
    '            dr = dt.NewRow()
    '            listTemporal = p_lista(n)
    '            For i = 0 To dt.Columns.Count - 1
    '                dr(i) = listTemporal(i)
    '            Next
    '            dt.Rows.Add(dr)
    '        Next
    '        gvEncuestas.DataSource = dt
    '        gvEncuestas.DataBind()
    '        '' lblError.Visible = False
    '        '' desBloquearMantenimiento()
    '    Else
    '        'Si no existen datos muestra el error
    '        gvEncuestas.Visible = True
    '        ''bloquearMantenimiento()
    '        ''lblError.Text = "No se encontraron encuestas."
    '        ''lblError.Visible = True
    '    End If
    'End Sub
    Private Sub cargarEncuestasPorAsistente()
        'Limpiamos el gried view y hacemos desaparecer el label de error por si existe
        Try
            'gvEncuestas.Columns.Clear()
        Catch ex As Exception
            lblException.Text = ex.Message
        End Try


        Try
            'Listamos la Encuesta
            Dim lista As List(Of Array) = (New Gestor).encuestaBuscarPorId(encuestaActual)
            'cargarInformacion(lista)
            Dim listTemporal() As String = lista.Item(0)

            lblIdEncuesta.Text = listTemporal(0)
            lblNombreEncuesta.Text = listTemporal(1)
            lblInicio.Text = listTemporal(2)
            lblFin.Text = listTemporal(3)
            lblPoblacion.Text = listTemporal(4)
            lblMuestra.Text = listTemporal(5)
            lblMargen.Text = listTemporal(6)
            lblTema.Text = listTemporal(8)

        Catch ex As Exception
            'lblError.Visible = True
            'lblError.Text = ex.Message
            'bloquearMantenimiento()
            lblException.Text = ex.Message
        End Try

    End Sub


    Private Sub cargarInformacionContactos(ByVal p_lista As List(Of Array))
        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow
        Dim listTemporal() As String

        'Creamos las columnas
        dt.Columns.Add(New Data.DataColumn("Id"))
        dt.Columns.Add(New Data.DataColumn("Nombre"))
        'dt.Columns.Add(New Data.DataColumn("1er Apellido"))
        'dt.Columns.Add(New Data.DataColumn("2do Apellido"))
        dt.Columns.Add(New Data.DataColumn("Empresa"))

        'For x As Integer = 0 To gContactos.Columns.Count - 1
        '    gContactos.Columns(x).ItemStyle.Width = 10
        'Next
        'dt.Columns.Add(New Data.DataColumn("E-mail"))
        'dt.Columns.Add(New Data.DataColumn("Telefono"))


        'Recorremos la lista de contactos
        If Not p_lista.Count = 0 Then
            gContactosInvitados.Visible = True
            Dim n As Integer
            For n = 0 To p_lista.Count - 1
                dr = dt.NewRow()
                listTemporal = p_lista(n)
                dr(0) = listTemporal(0)
                dr(1) = listTemporal(1) & " " & listTemporal(2) & " " & listTemporal(3)
                dr(2) = listTemporal(4)
                'For i = 0 To dt.Columns.Count - 1
                '    dr(i) = listTemporal(i)

                'Next
                dt.Rows.Add(dr)

            Next
            gContactos.DataSource = dt

            gContactos.DataBind()
            modificarTamannosDeCeldaContactos()

        Else
            'Si no existen datos no muestra el grid
            ' gContactos.Visible = False

        End If

    End Sub


    Protected Sub btnInvitarContacto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInvitarContacto.Click
        
        Dim listaC As ArrayList
        Dim hash As New Hashtable
        Dim listaIds As New List(Of Integer)

        If Not lblIdEncuesta.Text = "" And Not gContactos.Rows.Count = 0 Then

            Try
                listaC = gContactos.SelectedRecords()

                If Not listaC Is Nothing Then

                    Dim i As Integer
                    For i = 0 To listaC.Count - 1
                        hash = listaC.Item(i)
                        'lblPrueba.Text = hash.Item("Id")
                        listaIds.Add(CInt(hash.Item("Id")))

                    Next

                    Dim objGestor As New Gestor
                    objGestor.invitacionRegistrar(lblIdEncuesta.Text, listaIds)
                    cargarContactosInvitados()
                End If
            Catch ex As Exception
                lblException.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub cargarContactosInvitados()
        'Limpiamos el gried view y hacemos desaparecer el label de error por si existe
        gContactosInvitados.Columns.Clear()
        gContactosInvitados.Width = "352"
        Try
            'Listamos los contactos
            Dim lista As List(Of Array) = (New Gestor).listarContactosInvitadosPorEncuesta(encuestaActual)
            If Not lista Is Nothing And Not lista.Count = 0 Then
                cargarInformacionContactosInvitados(lista)
            Else
                Dim datosN() As String = {"", "", "", "", "", "", ""}
                lista.Add(datosN)
                cargarInformacionContactosInvitados(lista)
                btnBorrar.Visible = False
                btnEnviarEnlace.Visible = False
                btnInvitar.Visible = False
            End If


        Catch ex As Exception
            'lblError.Visible = True
            'lblError.Text = ex.Message
            lblException.Text = ex.Message
        End Try

    End Sub


    Private Sub cargarInformacionContactosInvitados(ByVal p_lista As List(Of Array))
        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow
        Dim listTemporal() As String

        'Creamos las columnas
        dt.Columns.Add(New Data.DataColumn("Id"))
        dt.Columns.Add(New Data.DataColumn("Nombre"))
        'dt.Columns.Add(New Data.DataColumn("1er Apellido"))
        'dt.Columns.Add(New Data.DataColumn("2do Apellido"))
        dt.Columns.Add(New Data.DataColumn("Empresa"))

        'For x As Integer = 0 To gContactos.Columns.Count - 1
        '    gContactos.Columns(x).ItemStyle.Width = 10
        'Next
        'dt.Columns.Add(New Data.DataColumn("E-mail"))
        'dt.Columns.Add(New Data.DataColumn("Telefono"))


        'Recorremos la lista de contactos
        If Not p_lista.Count = 0 Then
            gContactosInvitados.Visible = True
            Dim n As Integer
            For n = 0 To p_lista.Count - 1
                dr = dt.NewRow()
                listTemporal = p_lista(n)
                dr(0) = listTemporal(0)
                dr(1) = listTemporal(1) & " " & listTemporal(2) & " " & listTemporal(3)
                dr(2) = listTemporal(4)
                'For i = 0 To dt.Columns.Count - 1
                '    dr(i) = listTemporal(i)

                'Next
                dt.Rows.Add(dr)

            Next
            gContactosInvitados.DataSource = dt
            gContactosInvitados.DataBind()
            modificarTamannosDeCeldaContactosInvitados()
            btnBorrar.Visible = True
            btnEnviarEnlace.Visible = True
            btnInvitar.Visible = True




        Else
            'Si no existen datos no muestra el grid
            gContactosInvitados.Visible = True
            ' btnBorrar.Visible = False

        End If

    End Sub


    Protected Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim listaC As ArrayList
        Dim hash As New Hashtable
        Dim listaIds As New List(Of Integer)
        If Not gContactosInvitados.SelectedRecords Is Nothing And gContactosInvitados.Columns.Count > 0 Then

            Dim contactos As Integer = gContactosInvitados.Rows.Count


            If Not lblIdEncuesta.Text = "" Then

                Try



                    listaC = gContactosInvitados.SelectedRecords()

                    If Not listaC Is Nothing Then

                        Dim i As Integer
                        For i = 0 To listaC.Count - 1
                            hash = listaC.Item(i)
                            'lblPrueba.Text = hash.Item("Id")
                            listaIds.Add(CInt(hash.Item("Id")))

                        Next
                        Dim objGestor As New Gestor
                        objGestor.invitacionEliminarContactos(lblIdEncuesta.Text, listaIds)
                        ''Gestor.invitacionEliminarConta(gvEncuestas.SelectedRow.Cells(0).Text(), listaIds)
                        cargarContactosInvitados()

                    End If
                Catch ex As Exception
                    lblException.Text = ex.Message
                End Try

            End If
        End If
    End Sub

    Protected Sub btnClonacionContactos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClonacionContactos.Click
        Try
            'Session("seleccion") = gvEncuestas.SelectedRow.Cells(1).Text()
            ' lblError.Text = Session("seleccion")
            Me.Response.Redirect("ClonarContactosEncuesta.aspx")

        Catch ex As Exception
            'lblInformacion.Text = ex.
            lblException.Text = ex.Message
        End Try
    End Sub

    Private Sub modificarTamannosDeCeldaContactosInvitados()

        'Cambiamos el tamaño para la columna "Codigo"
        gContactosInvitados.Columns.Item("Id").Width = "52"
        'No mostramos los códigos reales para los temas
        gContactosInvitados.Columns.Item("Nombre").Width = "200"
        'gContactosInvitados.Columns.Item("1er Apellido").Width = "120"
        'gContactosInvitados.Columns.Item("2do Apellido").Width = "120"
        gContactosInvitados.Columns.Item("Empresa").Width = "100"
        gContactosInvitados.Width = "352"
        gContactosInvitados.Columns.Item("Id").Visible = False
        gContactosInvitados.DataBind()


    End Sub
    Private Sub modificarTamannosDeCeldaContactos()
        'Cambiamos el tamaño para la columna "Codigo"
        gContactos.Columns.Item("Id").Width = "52"
        'No mostramos los códigos reales para los temas
        gContactos.Columns.Item("Nombre").Width = "200"
        'gContactos.Columns.Item("1er Apellido").Width = "120"
        'gContactos.Columns.Item("2do Apellido").Width = "120"
        gContactos.Columns.Item("Empresa").Width = "100"
        gContactos.Width = "352"
        gContactos.Columns.Item("Id").Visible = False
        gContactos.DataBind()


    End Sub

    Protected Sub btnAtras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Try
            'Session("seleccion") = gvEncuestas.SelectedRow.Cells(1).Text()
            ' lblError.Text = Session("seleccion")


            Me.Response.Redirect("Seguimiento.aspx")

        Catch ex As Exception
            'lblInformacion.Text = ex.Message
            lblException.Text = ex.Message
        End Try
    End Sub


    Protected Sub btnEnviarEnlace_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviarEnlace.Click
        ''''''''''''''''''''''''''''''''''''''''nviar enlace
        
        btnEnviarEnlace.Enabled = False
        btnInvitar.Enabled = False
        btnBorrar.Enabled = False
        Dim listaC As ArrayList
        Dim hash As New Hashtable
        Dim listaIds As New List(Of Integer)


            If Not gContactosInvitados.SelectedRecords Is Nothing And gContactosInvitados.Columns.Count > 0 Then

                Dim contactos As Integer = gContactosInvitados.Rows.Count

            Dim msj As String = Nothing

            If Not lblIdEncuesta.Text = "" Then

                Try

                    listaC = gContactosInvitados.SelectedRecords()

                    If Not listaC Is Nothing Then

                        Dim i As Integer
                        For i = 0 To listaC.Count - 1
                            hash = listaC.Item(i)
                            'lblPrueba.Text = hash.Item("Id")
                            listaIds.Add(CInt(hash.Item("Id")))

                        Next
                        Dim objGestor As New Gestor

                        Dim msg As String = objGestor.enviarEnlace(lblIdEncuesta.Text, listaIds)

                        lblInformacin.ForeColor = Drawing.Color.Blue
                        lblInformacin.Visible = True

                        lblInformacin.Text = "Se ha enviado el enlace y la contraseña"
                        Response.Write("<script language='javascript' type='text/javascript'> alert('" & msg & "');</Script>")
                    End If
                Catch ex As Exception
                    Response.Write("<script language='javascript' type='text/javascript'> alert('" & ex.Message & "');</Script>")
                End Try
            End If
            End If

        ''Gestor.invitacionEliminarConta(gvEncuestas.SelectedRow.Cells(0).Text(), listaIds)
        cargarContactosInvitados()
        btnEnviarEnlace.Enabled = True
        btnInvitar.Enabled = True
        btnBorrar.Enabled = True
    End Sub


    Protected Sub btnRegContacto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegContacto.Click
        Try
            'Session("seleccion") = gvEncuestas.SelectedRow.Cells(1).Text()
            ' lblError.Text = Session("seleccion")


            Me.Response.Redirect("RegistrarContacto.aspx")

        Catch ex As Exception
            'lblInformacion.Text = ex.Message
            lblException.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnInvitar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInvitar.Click
       
        'btnInvitar.Visible = False
        'btnEnviarEnlace.Visible = False
        'btnBorrar.Visible = False

        Dim listaC As ArrayList
        Dim hash As New Hashtable
        Dim listaIds As New List(Of Integer)
        If Not gContactosInvitados.SelectedRecords Is Nothing And gContactosInvitados.Columns.Count > 0 Then

            Dim contactos As Integer = gContactosInvitados.Rows.Count


            If Not lblIdEncuesta.Text = "" Then

                Try

                    listaC = gContactosInvitados.SelectedRecords()

                    If Not listaC Is Nothing Then

                        Dim i As Integer
                        For i = 0 To listaC.Count - 1
                            hash = listaC.Item(i)
                            'lblPrueba.Text = hash.Item("Id")
                            listaIds.Add(CInt(hash.Item("Id")))

                        Next

                        Dim objGestor As New Gestor
                        objGestor.enviarInvitacionEncuesta(lblIdEncuesta.Text, listaIds)
                        cargarContactosInvitados()
                        lblInformacin.ForeColor = Drawing.Color.Blue
                        lblInformacin.Visible = True

                        lblInformacin.Text = "Se ha enviado la invitación correctamente"
                    End If
                Catch ex As Exception
                    lblInformacin.Text = ex.Message
                    lblInformacin.ForeColor = Drawing.Color.Red
                    lblInformacin.Visible = True
                End Try

            End If
        End If
        btnInvitar.Visible = True
        btnEnviarEnlace.Visible = True
        btnBorrar.Visible = True
    End Sub
End Class
