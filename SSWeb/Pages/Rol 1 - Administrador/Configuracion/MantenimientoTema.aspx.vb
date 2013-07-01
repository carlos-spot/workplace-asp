Imports SSLogica
Imports Obout.Grid

Partial Class Pages_Rol_1___Administrador_MantenimientoTema
    Inherits System.Web.UI.Page
    Private gestor As Gestor = New Gestor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim listaTemas As List(Of Array) = Nothing

        'Capturamos el parametro __EVENTTARGET
        'Si coincide con el valor pasado desde JS pues realiza una accion
        If My.Request.Params("__EVENTTARGET") = "eliminar" Then
            eliminarTema()

        ElseIf My.Request.Params("__EVENTTARGET") = "modificar" Then
            modificarDatosTema()

        End If

        txtNombre.Attributes.Add("onfocus", "this.select();")

        Try
            listaTemas = gestor.cargarTemas
            cargarTemas(listaTemas)
        Catch ex As Exception
            lblMensajeBuscar.Text = ex.Message
            lblMensajeBuscar.ForeColor = Drawing.Color.Red
            lblMensajeBuscar.Visible = True
        End Try

    End Sub

    Private Sub cargarTemas(ByVal plista As List(Of Array))
        Dim tablaDatos As Data.DataTable = crearTabla(plista)
        actualizarTabla(tablaDatos)
        modificarTamannosDeCelda()
    End Sub

    'Genera la tabla que se mostrara en el Grind
    Private Function crearTabla(ByVal plista As List(Of Array)) As Data.DataTable
        Dim tablaDatos As New Data.DataTable
        Dim listTemporal() As String
        Dim filaDatos As Data.DataRow

        'Creamos las columnas
        tablaDatos.Columns.Add(New Data.DataColumn("Nombre del tema"))
        tablaDatos.Columns.Add(New Data.DataColumn("codTema"))

        'Recorremos la lista de Empleados
        If plista.Count > 0 Then

            Dim n As Integer
            For n = 0 To plista.Count - 1
                filaDatos = tablaDatos.NewRow()

                'listTemporal(0) = Codigo del tema
                'listTemporal(1) = Nombre del tema
                listTemporal = plista(n)

                filaDatos(0) = listTemporal(1)
                filaDatos(1) = listTemporal(0)

                tablaDatos.Rows.Add(filaDatos)
            Next

        Else
            filaDatos = tablaDatos.NewRow()
            filaDatos(0) = ""
            filaDatos(1) = ""
        End If
        Return tablaDatos
    End Function

    'Actualiza la tabla con los nuevos datos
    Private Sub actualizarTabla(ByVal ptabla As Data.DataTable)
        tablaGrind.DataSource = ptabla
        tablaGrind.DataBind()
    End Sub

    Private Sub modificarTamannosDeCelda()
        'Cambiamos el tamaño para la columna "Nombre del tema"
        tablaGrind.Columns.Item("Nombre del tema").Width = "400"
        'No mostramos los códigos reales para los temas
        tablaGrind.Columns.Item("codTema").Visible = False
        tablaGrind.DataBind()
    End Sub

    Private Sub modificarDatosTema()
        If Not txtNombre.Text.Equals("") Then
            Try
                Dim objHasht As Hashtable = tablaGrind.SelectedRecords.Item(0)
                Dim codigoTema As Integer
                codigoTema = objHasht.Item("codTema")
                gestor.modificarTema(codigoTema, txtNombre.Text)
                limpiarCampos()
                lblMensajeRegistrar.Text = "El tema se ha modificado satisfactoriamente."
                lblMensajeRegistrar.ForeColor = Drawing.Color.Blue
                lblMensajeRegistrar.Visible = True
                cargarTemas(gestor.cargarTemas())
            Catch ex As Exception
                lblMensajeRegistrar.Text = ex.Message
                lblMensajeRegistrar.ForeColor = Drawing.Color.Red
                lblMensajeRegistrar.Visible = True
                If lblMensajeRegistrar.Text = "El nombre del tema ya está registrado en el sistema." Then
                    txtNombre.Focus()
                End If
            End Try
        Else
            txtNombre.Focus()
            lblMensajeRegistrar.Text = "Debe ingresar el nombre del tema"
            lblMensajeRegistrar.ForeColor = Drawing.Color.Red
            lblMensajeRegistrar.Visible = True
        End If
    End Sub

    Private Sub eliminarTema()
        btnGuardarReg.Visible = True
        btnGuardarMod.Visible = False
        Try
            Dim objHasht As Hashtable = tablaGrind.SelectedRecords.Item(0)
        Catch ex As Exception
            limpiarCampos()
            lblMensajeBuscar.Text = "Selecciona un tema que desee eliminar"
            lblMensajeBuscar.ForeColor = Drawing.Color.Red
            lblMensajeBuscar.Visible = True
            Return
        End Try
        Try
            Dim objHasht As Hashtable = tablaGrind.SelectedRecords.Item(0)
            gestor.eliminarTema(CInt(objHasht.Item("codTema")))
            cargarTemas(gestor.cargarTemas())
            limpiarCampos()
            lblMensajeBuscar.Text = "El tema '" & objHasht.Item("Nombre del tema") & "' se elimino satisfactoriamente."
            lblMensajeBuscar.ForeColor = Drawing.Color.Blue
            lblMensajeBuscar.Visible = True
        Catch ex As Exception
            limpiarCampos()
            lblMensajeBuscar.Text = ex.Message
            lblMensajeBuscar.ForeColor = Drawing.Color.Red
            lblMensajeBuscar.Visible = True
        End Try
    End Sub

    Protected Sub btnGuardarReg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarReg.Click
        If txtNombre.Text.Equals("") Then
            lblMensajeRegistrar.Text = "Ingrese el nombre del tema."
            lblMensajeRegistrar.Visible = True
        Else
            Try
                gestor.registrarTema(txtNombre.Text)
                cargarTemas(gestor.cargarTemas())
                limpiarCampos()
                lblMensajeRegistrar.Text = "El tema se ha registrado satisfactoriamente"
                lblMensajeRegistrar.ForeColor = Drawing.Color.Blue
                lblMensajeRegistrar.Visible = True
            Catch ex As Exception
                lblMensajeRegistrar.Text = ex.Message
                lblMensajeRegistrar.ForeColor = Drawing.Color.Red
                lblMensajeRegistrar.Visible = True
                If lblMensajeRegistrar.Text = "El nombre del tema ya está registrado en el sistema." Then
                    txtNombre.Focus()
                End If
            End Try
        End If
    End Sub

    Private Sub limpiarCampos()
        txtCriterio.Text = ""
        txtNombre.Text = ""
        lblNombre.Text = "Nombre del nuevo tema:"
        lblMantenimiento.Text = "Registrar un tema"
        lblMensajeRegistrar.Visible = False
        lblMensajeBuscar.Visible = False
        btnGuardarMod.Visible = False
        btnGuardarReg.Visible = True

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        buscarTemas()
    End Sub

    Private Sub buscarTemas()
        Dim criterio As String = txtCriterio.Text
        Dim listaTemas As List(Of Array)
        If criterio.Length <= 0 Then
            listaTemas = gestor.cargarTemasPorCriterio("")
        Else
            listaTemas = gestor.cargarTemasPorCriterio(txtCriterio.Text)
        End If
        cargarTemas(listaTemas)
        limpiarCampos()
        txtCriterio.Focus()
    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Try
            limpiarCampos()
            Dim objHasht As Hashtable = tablaGrind.SelectedRecords.Item(0)
            lblMantenimiento.Text = "Modificar el tema seleccionado"
            lblNombre.Text = "Nombre para el tema"
            txtNombre.Text = objHasht.Item("Nombre del tema")
            btnGuardarReg.Visible = False
            btnGuardarMod.Visible = True
            lblMensajeBuscar.Visible = False
        Catch ex As Exception
            lblMensajeBuscar.Text = "Seleccione el tema que desea modificar"
            lblMensajeBuscar.ForeColor = Drawing.Color.Red
            lblMensajeBuscar.Visible = True
        End Try
    End Sub

    Protected Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpiarCampos()
    End Sub

    Private Sub txtCriterio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCriterio.TextChanged
        buscarTemas()
    End Sub
End Class
