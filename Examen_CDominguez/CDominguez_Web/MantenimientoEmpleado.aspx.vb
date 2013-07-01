
Partial Class MantenimientoEmpleado
    Inherits System.Web.UI.Page
    Private gestor As New CDominguez_Logica.Gestor

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim listaEmpleados As List(Of Array) = gestor.buscarEmpleadosPorCriterio("")
        cargarEmpleados(listaEmpleados)
        'Cargamos los Departamentos en el DropDownList "ddlDepartamentos"
        cargarListaDeDepartamentos()

        'Capturamos el parametro __EVENTTARGET
        'Si coincide con el valor pasado desde JS pues realiza una accion
        If My.Request.Params("__EVENTTARGET") = "eliminar" Then
            eliminarProducto()

        ElseIf My.Request.Params("__EVENTTARGET") = "modificar" Then
            modificarEmpleado()

        End If
    End Sub

    Public Sub cargarListaDeDepartamentos()
        If ddlDepartamentos.Items.Count <= 0 Then
            Dim listaTemas As List(Of Array) = gestor.cargarDepartamentos()
            ddlDepartamentos.Items.Add("--Seleccionar--")
            lbDepartamentos.Items.Add("--Seleccionar--")
            For Each objArray In listaTemas

                'En la posicion 1 del Array biene el nombre del tema
                'En la posición 2 del Array bien el codigo del tema
                ddlDepartamentos.Items.Add(objArray(1).ToString)
                lbDepartamentos.Items.Add(objArray(0).ToString)
            Next
        End If
    End Sub
    Private Sub cargarEmpleados(ByVal plista As List(Of Array))
        'Creamos la tabla con los dato de los productos que vamos a mostrar
        Dim tablaDatos As Data.DataTable = crearTabla(plista)
        actualizarTabla(tablaDatos)
        modificarTamannosDeCelda()
    End Sub

    'Actualiza la tabla con los nuevos datos
    Private Sub actualizarTabla(ByVal ptabla As Data.DataTable)
        tablaGrind.DataSource = ptabla
        tablaGrind.DataBind()
    End Sub

    'Modifica el tamaño de las celdas de la tabla
    Private Sub modificarTamannosDeCelda()

        'Cambiamos el tamaño para la columna "Codigo"
        tablaGrind.Columns.Item("Identificacion").Width = "120"
        'Cambiamos el tamaño para la columna "Nombre del tema"
        tablaGrind.Columns.Item("Nombre del empleado").Width = "256"

        'No mostramos los códigos reales para los productos
        tablaGrind.Columns.Item("idEmpleado").Visible = False
        tablaGrind.DataBind()
    End Sub

    'Genera la tabla que se mostrara en el Grind
    Private Function crearTabla(ByVal plista As List(Of Array)) As Data.DataTable
        Dim tablaDatos As New Data.DataTable
        Dim listTemporal() As String
        Dim filaDatos As Data.DataRow

        'Creamos las columnas
        tablaDatos.Columns.Add(New Data.DataColumn("Identificacion"))
        tablaDatos.Columns.Add(New Data.DataColumn("Nombre del empleado"))
        tablaDatos.Columns.Add(New Data.DataColumn("idEmpleado"))

        'Recorremos la lista de Empleados
        If plista.Count > 0 Then

            Dim n As Integer
            For n = 0 To plista.Count - 1
                filaDatos = tablaDatos.NewRow()

                listTemporal = plista(n)
                'lista(0) = Id
                'lista(1) = Identificacion
                'lista(2) = Nombre
                'lista(3) = Apellidos
                'lista(4) = Telefono
                'lista(5) = Departamento
                'lista(6) = Direccion
                'lista(7) = Puesto
                filaDatos(0) = listTemporal(1)
                filaDatos(1) = listTemporal(2) & " " & listTemporal(3)
                filaDatos(2) = listTemporal(0)

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

    Protected Sub btnGuardarReg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarReg.Click
        If validarDatos() Then
            Dim codDepartamentoSelected As Integer = CInt(lbDepartamentos.Items(ddlDepartamentos.SelectedIndex).ToString)
            Try
                gestor.registrarEmpleado(txtIdentificacion.Text, txtNombre.Text, txtApellidos.Text, txtTelefono.Text, _
                                         codDepartamentoSelected, txtDireccion.Text, txtPuesto.Text)
                cargarEmpleados(gestor.buscarEmpleadosPorCriterio(""))
                limpiarCampos()
                lblMensajeRegistrar.Text = "El empleado se ha registrado satisfactoriamente"
                lblMensajeRegistrar.ForeColor = Drawing.Color.Blue
                lblMensajeRegistrar.Visible = True
            Catch ex As Exception
                lblMensajeRegistrar.Text = ex.Message
                lblMensajeRegistrar.ForeColor = Drawing.Color.Red
                lblMensajeRegistrar.Visible = True
            End Try
        End If
    End Sub

    Private Function validarDatos() As Boolean
        If txtNombre.Text.Equals("") Then
            lblMensajeRegistrar.Text = "Ingrese el nombre del empleado"
            lblMensajeRegistrar.ForeColor = Drawing.Color.Red
            lblMensajeRegistrar.Visible = True
            txtNombre.Focus()
            Return False
        ElseIf txtApellidos.Text.Equals("") Then
            lblMensajeRegistrar.Text = "Ingrese los apellidos del empleado"
            lblMensajeRegistrar.ForeColor = Drawing.Color.Red
            lblMensajeRegistrar.Visible = True
            txtApellidos.Focus()
            Return False
        ElseIf txtDireccion.Text.Equals("") Then
            lblMensajeRegistrar.Text = "Ingrese la dirección del empleado"
            lblMensajeRegistrar.ForeColor = Drawing.Color.Red
            lblMensajeRegistrar.Visible = True
            txtDireccion.Focus()
            Return False
        ElseIf txtIdentificacion.Text.Equals("") Then
            lblMensajeRegistrar.Text = "Ingrese la identificación del empleado"
            lblMensajeRegistrar.ForeColor = Drawing.Color.Red
            lblMensajeRegistrar.Visible = True
            txtIdentificacion.Focus()
            Return False
        ElseIf ddlDepartamentos.SelectedIndex = 0 Then
            lblMensajeRegistrar.Text = "Seleccione el departamento al que pertenece el empleado"
            lblMensajeRegistrar.ForeColor = Drawing.Color.Red
            lblMensajeRegistrar.Visible = True
            ddlDepartamentos.Focus()
            Return False
        ElseIf txtPuesto.Text.Equals("") Then
            lblMensajeRegistrar.Text = "Ingrese el puesto del empleado"
            lblMensajeRegistrar.ForeColor = Drawing.Color.Red
            lblMensajeRegistrar.Visible = True
            txtPuesto.Focus()
            Return False
        ElseIf txtTelefono.Text.Equals("") Then
            lblMensajeRegistrar.Text = "Ingrese el teléfono del empleado"
            lblMensajeRegistrar.ForeColor = Drawing.Color.Red
            lblMensajeRegistrar.Visible = True
            txtTelefono.Focus()
            Return False
        End If

        lblMensajeRegistrar.Visible = False
        Return True
    End Function

    Private Sub limpiarCampos()
        txtNombre.Text = ""
        txtApellidos.Text = ""
        txtCriterio.Text = ""
        txtDireccion.Text = ""
        txtIdentificacion.Text = ""
        txtPuesto.Text = ""
        txtTelefono.Text = ""
        ddlDepartamentos.SelectedIndex = 0
        lblMensajeRegistrar.Visible = False
        lblMensajeBuscar.Visible = False
    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Try
            limpiarCampos()
            Dim objHasht As Hashtable = tablaGrind.SelectedRecords.Item(0)
            Dim datosEmpleado As Array = gestor.obtenerDatosEmpleado(objHasht.Item("idEmpleado"))
            'lista(0) = Id
            'lista(1) = Identificacion
            'lista(2) = Nombre
            'lista(3) = Apellidos
            'lista(4) = Telefono
            'lista(5) = Departamento
            'lista(6) = Direccion
            'lista(7) = Puesto

            lblMantenimiento.Text = "Modificar el empleado seleccionado"
            txtNombre.Text = datosEmpleado(2)
            txtApellidos.Text = datosEmpleado(3)
            txtDireccion.Text = datosEmpleado(6)
            txtIdentificacion.Text = datosEmpleado(1)
            txtPuesto.Text = datosEmpleado(7)
            txtTelefono.Text = datosEmpleado(4)
            ddlDepartamentos.SelectedValue = datosEmpleado(5)
            btnGuardarReg.Visible = False
            btnGuardarMod.Visible = True
            lblMensajeBuscar.Visible = False
        Catch ex As Exception
            lblMensajeBuscar.Text = "Seleccione el empleado que desea modificar"
            lblMensajeBuscar.ForeColor = Drawing.Color.Red
            lblMensajeBuscar.Visible = True
        End Try
    End Sub

    Private Sub eliminarProducto()
        Dim objHasht As Hashtable = tablaGrind.SelectedRecords.Item(0)
        btnGuardarReg.Visible = True
        btnGuardarMod.Visible = False
        Try
            gestor.eliminarEmpleado(CInt(objHasht.Item("idEmpleado")))
            cargarEmpleados(gestor.buscarEmpleadosPorCriterio(""))
            limpiarCampos()
            lblMensajeBuscar.Text = "El empleado '" & objHasht.Item("Nombre del empleado") & "' se elimino satisfactoriamente."
            lblMensajeBuscar.ForeColor = Drawing.Color.Blue
            lblMensajeBuscar.Visible = True
        Catch ex As Exception
            lblMensajeBuscar.Text = ex.Message
            lblMensajeBuscar.ForeColor = Drawing.Color.Red
            lblMensajeBuscar.Visible = True
        End Try
    End Sub

    Private Sub modificarEmpleado()
        If validarDatos() Then
            Try
                Dim objHasht As Hashtable = tablaGrind.SelectedRecords.Item(0)
                Dim codigoDepartamento, idEmpleado As Integer
                idEmpleado = CInt(objHasht.Item("idEmpleado"))
                codigoDepartamento = CInt(lbDepartamentos.Items(ddlDepartamentos.SelectedIndex).ToString)
                gestor.modificarEmpleado(idEmpleado, txtIdentificacion.Text, txtNombre.Text, txtApellidos.Text, _
                                         txtTelefono.Text, codigoDepartamento, txtDireccion.Text, txtPuesto.Text)
                limpiarCampos()
                lblMensajeRegistrar.Text = "El empleado se ha modificado satisfactoriamente."
                lblMensajeRegistrar.ForeColor = Drawing.Color.Blue
                lblMensajeRegistrar.Visible = True
                cargarEmpleados(gestor.buscarEmpleadosPorCriterio(""))
            Catch ex As Exception
                lblMensajeRegistrar.Text = ex.Message
                lblMensajeRegistrar.ForeColor = Drawing.Color.Red
                lblMensajeRegistrar.Visible = True
            End Try
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            Dim listaEmpleados As List(Of Array)
            Dim criterioBusqueda As String = txtCriterio.Text
            If criterioBusqueda.Equals("") Then
                listaEmpleados = gestor.buscarEmpleadosPorCriterio("")
            Else
                listaEmpleados = gestor.buscarEmpleadosPorCriterio(criterioBusqueda)
            End If
            cargarEmpleados(listaEmpleados)
            limpiarCampos()
            txtCriterio.Text = criterioBusqueda
            txtCriterio.Focus()
        Catch ex As Exception
            lblMensajeBuscar.Text = ex.Message
            lblMensajeBuscar.ForeColor = Drawing.Color.Red
            lblMensajeBuscar.Visible = True
        End Try
    End Sub
End Class
