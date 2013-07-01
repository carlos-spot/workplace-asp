Imports SSLogica
Partial Class Pages_Rol_3___Asistente_ClonarContactosEncuesta
    Inherits System.Web.UI.Page
    Private encuestaActual As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        encuestaActual = Session("seleccion")
        gvContactoEncuesta.Width = "352"
        cargarEncuestas()
        cargarContactosParticipantesAnteriormente()
        cargarContactosInvitados()
        gvContactoEncuesta.Width = "352"
        gContactosInvitados.Width = "352"
        lblException.Visible = False

    End Sub

    Private Sub cargarEncuestas()
        'Limpiamos el gried view y hacemos desaparecer el label de error por si existe
        gvEncuestas.Columns.Clear()
        gvEncuestas.Width = "360"


        Try
            'Listamos los contactos
            Dim objGestor As New Gestor

            Dim lista As List(Of Array) = objGestor.encuestaListar("Finalizada")
            If Not lista Is Nothing Then
                cargarInformacionEncuestas(lista)
            Else
                Dim datosN() As String = {"", "", "", "", "", "", ""}
                lista.Add(datosN)
                cargarInformacionEncuestas(lista)
            End If


        Catch ex As Exception
            'lblError.Visible = True
            'lblError.Text = ex.Message

        End Try

    End Sub
    Private Sub cargarInformacionEncuestas(ByVal p_lista As List(Of Array))
        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow
        Dim listTemporal() As String

        'Creamos las columnas
        dt.Columns.Add(New Data.DataColumn("Id"))
        dt.Columns.Add(New Data.DataColumn("Nombre"))

        'dt.Columns.Add(New Data.DataColumn("2do Apellido"))
        'Recorremos la lista de contactos
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

                'gContactos.Columns(i).Width = 30

            Next
            gvEncuestas.DataSource = dt
            gvEncuestas.DataBind()
            modificarTamannosDeCeldaEncuesta()

        Else
            'Si no existen datos no muestra el grid
            gvEncuestas.Visible = False

        End If

    End Sub

    Private Sub cargarContactosInvitados()
        'Limpiamos el gried view y hacemos desaparecer el label de error por si existe
        gContactosInvitados.Columns.Clear()
        gContactosInvitados.Width = "352"
        Try
            'Listamos los contactos
            Dim objGestor As New Gestor

            Dim lista As List(Of Array) = objGestor.listarContactosInvitadosPorEncuesta(encuestaActual)
            If Not lista Is Nothing And Not lista.Count = 0 Then
                cargarInformacionContactosInvitados(lista)
            Else
                Dim datosN() As String = {"", "", "", "", "", "", ""}
                lista.Add(datosN)
                cargarInformacionContactosInvitados(lista)
                btnBorrar.Visible = False
            End If


        Catch ex As Exception
            'lblError.Visible = True
            'lblError.Text = ex.Message

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



        Else
            'Si no existen datos no muestra el grid
            gContactosInvitados.Visible = True
            btnBorrar.Visible = False

        End If


    End Sub



    '''''cargar contactos participantes anteriormente

    Private Sub cargarContactosParticipantesAnteriormente()
        'Limpiamos el gried view y hacemos desaparecer el label de error por si existe
        gvContactoEncuesta.Columns.Clear()
        gvContactoEncuesta.Width = "352"
        Dim listaE As ArrayList
        Dim hash As New Hashtable
        Dim listaIds As New List(Of Integer)
        Dim lista As List(Of Array)


        'Listamos los contactos
        Try
            If Not gvEncuestas.Rows.Count = 0 And Not gvEncuestas Is Nothing Then

               
                listaE = gvEncuestas.SelectedRecords
                If Not listaE Is Nothing And Not listaE.Count = 0 Then


                    hash = listaE.Item(0)

                    'lblPrueba.Text = hash.Item("Id")
                    Dim objGestor As New Gestor
                    lista = objGestor.listarContactosQueParticiparonEnEncuesta(hash.Item("Id"))
                    If Not lista Is Nothing And Not lista.Count = 0 Then
                        cargarInformacionContactosParticipantesAnteriormente(lista)
                        gvContactoEncuesta.Width = "352"
                    Else
                        Dim datosN() As String = {"", "", "", "", "", "", ""}
                        lista.Add(datosN)
                        cargarInformacionContactosParticipantesAnteriormente(lista)
                        gvContactoEncuesta.Width = "352"
                    End If
                Else

                End If

            Else
                'gvContactoEncuesta.Visible = False
            End If
        Catch ex As Exception
            'lblError.Visible = True
            'lblError.Text = ex.Message
            Dim plista As New List(Of Array)
            Dim datosN() As String = {"", "", "", "", "", "", ""}
            plista.Add(datosN)
            cargarInformacionContactosParticipantesAnteriormente(plista)


        End Try

    End Sub


    Private Sub cargarInformacionContactosParticipantesAnteriormente(ByVal p_lista As List(Of Array))
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
            gvContactoEncuesta.Visible = True
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
            gvContactoEncuesta.DataSource = dt
            gvContactoEncuesta.DataBind()
            modificarTamannosDeCeldaContactosEncuesta()
            ' btnBorrar.Visible = True



        Else
            'Si no existen datos no muestra el grid
            gvContactoEncuesta.Visible = True
            btnBorrar.Visible = False

        End If


    End Sub
    Private Sub modificarTamannosDeCeldaContactosInvitados()

        'Cambiamos el tamaño para la columna "Codigo"
        gContactosInvitados.Columns.Item("Id").Width = "52"
        'No mostramos los códigos reales para los temas
        gContactosInvitados.Columns.Item("Nombre").Width = "200"
        'gContactosInvitados.Columns.Item("1er Apellido").Width = "120"
        'gContactosInvitados.Columns.Item("2do Apellido").Width = "120"
        gContactosInvitados.Columns.Item("Empresa").Width = "100"

        gContactosInvitados.Columns.Item("Id").Visible = False
        gContactosInvitados.Width = "352"
        gContactosInvitados.DataBind()


    End Sub
    Private Sub modificarTamannosDeCeldaContactosEncuesta()
        'Cambiamos el tamaño para la columna "Codigo"
        gvContactoEncuesta.Columns.Item("Id").Width = "52"
        'No mostramos los códigos reales para los temas
        gvContactoEncuesta.Columns.Item("Nombre").Width = "200"
        'gContactosInvitados.Columns.Item("1er Apellido").Width = "120"
        'gContactosInvitados.Columns.Item("2do Apellido").Width = "120"
        gvContactoEncuesta.Columns.Item("Empresa").Width = "100"

        gvContactoEncuesta.Columns.Item("Id").Visible = False
        gvContactoEncuesta.Width = "352"
        gvContactoEncuesta.DataBind()

    End Sub

    Private Sub modificarTamannosDeCeldaEncuesta()

        'Cambiamos el tamaño para la columna "Codigo"
        gvEncuestas.Columns.Item("Id").Width = "52"
        'No mostramos los códigos reales para los temas
        gvEncuestas.Columns.Item("Nombre").Width = "300"

        gvEncuestas.Width = "360"

        gvEncuestas.DataBind()


    End Sub



    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cargarDatos.Click

    'End Sub

    Protected Sub btnInvitarContacto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInvitarContacto.Click
        Dim listaC As ArrayList
        Dim hash As New Hashtable
        Dim listaIds As New List(Of Integer)

        If Not gvEncuestas.Rows.Count = 0 And Not gvContactoEncuesta.Rows.Count = 0 Then

            Try
                listaC = gvContactoEncuesta.SelectedRecords()

                If Not listaC Is Nothing And Not listaC.Count = 0 Then

                    Dim i As Integer
                    For i = 0 To listaC.Count - 1
                        hash = listaC.Item(i)
                        'lblPrueba.Text = hash.Item("Id")
                        listaIds.Add(CInt(hash.Item("Id")))

                    Next

                    Dim objGestor As New Gestor

                    objGestor.invitacionRegistrar(encuestaActual, listaIds)
                    cargarContactosInvitados()
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub btnAtras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Try
            'Session("seleccion") = gvEncuestas.SelectedRow.Cells(1).Text()
            ' lblError.Text = Session("seleccion")
            Me.Response.Redirect("AgregarContactos.aspx")

        Catch ex As Exception
            'lblInformacion.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnCargarContactos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargarContactos.Click
        cargarContactosParticipantesAnteriormente()
    End Sub

    Protected Sub btnBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim listaC As ArrayList
        Dim hash As New Hashtable
        Dim listaIds As New List(Of Integer)
        If Not gContactosInvitados.SelectedRecords Is Nothing And gContactosInvitados.Columns.Count > 0 Then

            Dim contactos As Integer = gContactosInvitados.Rows.Count


            If Not gvEncuestas.Rows.Count = 0 Then

                Try

                    listaC = gContactosInvitados.SelectedRecords()

                    If Not listaC Is Nothing And Not listaC.Count = 0 Then

                        Dim i As Integer
                        For i = 0 To listaC.Count - 1
                            hash = listaC.Item(i)
                            'lblPrueba.Text = hash.Item("Id")
                            listaIds.Add(CInt(hash.Item("Id")))

                        Next

                        Dim objGestor As New Gestor
                        objGestor.invitacionEliminarContactos(encuestaActual, listaIds)
                        ''Gestor.invitacionEliminarConta(gvEncuestas.SelectedRow.Cells(0).Text(), listaIds)
                        cargarContactosInvitados()

                    End If
                Catch ex As Exception

                End Try

            End If
        End If
    End Sub



End Class
