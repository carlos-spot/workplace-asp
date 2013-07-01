Imports SSLogica
Partial Class Pages_Rol_2___Profesor_MantenimientoProductoP
    Inherits System.Web.UI.Page
    Private gestor As New Gestor

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Cargamos los temas en el DropDownList "ddlTemas"
        cargarListaDeTemas()

        'Agregamos el evento "Select" a las cajas de texto
        agregarEventoSelect()

        'Si no mando nada en el criterio me carga automaticamente todos los temas
        Dim listaProductos As List(Of Array) = gestor.cargarProductosPorCriterio("")
        cargarProductos(listaProductos)

        'Capturamos el parametro __EVENTTARGET
        'Si coincide con el valor pasado desde JS pues realiza una accion
        If My.Request.Params("__EVENTTARGET") = "eliminar" Then
            eliminarProducto()

        ElseIf My.Request.Params("__EVENTTARGET") = "modificar" Then
            modificarDatosProducto()

        End If
    End Sub

    Public Sub agregarEventoSelect()
        txtNombre.Attributes.Add("onfocus", "this.select();")
        txtCriterio.Attributes.Add("onfocus", "this.select();")
    End Sub

    Public Sub cargarListaDeTemas()
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

    Private Sub cargarProductos(ByVal plista As List(Of Array))
        'Creamos la tabla con los dato de los productos que vamos a mostrar
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
        tablaDatos.Columns.Add(New Data.DataColumn("Nombre del producto"))
        tablaDatos.Columns.Add(New Data.DataColumn("Marca"))
        tablaDatos.Columns.Add(New Data.DataColumn("Fabricante"))
        tablaDatos.Columns.Add(New Data.DataColumn("Tema"))
        tablaDatos.Columns.Add(New Data.DataColumn("codProducto"))

        'Recorremos la lista de Empleados
        If plista.Count > 0 Then

            Dim n As Integer
            For n = 0 To plista.Count - 1
                filaDatos = tablaDatos.NewRow()

                'listTemporal(0) = Nombre del producto
                'listTemporal(1) = Marca 
                'listTemporal(2) = Fabricante
                'listTemporal(3) = Nombre del tema
                'listTemporal(4) = Código del producto
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
    Private Sub actualizarTabla(ByVal ptabla As Data.DataTable)
        tablaGrind.DataSource = ptabla
        tablaGrind.DataBind()
    End Sub

    'Modifica el tamaño de las celdas de la tabla
    Private Sub modificarTamannosDeCelda()

        'Cambiamos el tamaño para la columna "Nombre del tema"
        tablaGrind.Columns.Item("Nombre del producto").Width = "156"
        'Cambiamos el tamaño para la columna "Marca"
        tablaGrind.Columns.Item("Marca").Width = "150"
        'Cambiamos el tamaño para la columna "Fabricante"
        tablaGrind.Columns.Item("Fabricante").Width = "150"
        'Cambiamos el tamaño para la columna "Tema"
        tablaGrind.Columns.Item("Tema").Width = "220"

        'No mostramos los códigos reales para los productos
        tablaGrind.Columns.Item("codProducto").Visible = False
        tablaGrind.DataBind()
    End Sub

    Protected Sub btnGuardarReg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarReg.Click
        If validarDatos() Then
            Dim codTemaSelected As Integer = CInt(lbCodigosTemas.Items(ddlTemas.SelectedIndex).ToString)
            Try
                gestor.registrarProducto(txtNombre.Text, txtMarca.Text, txtFabricante.Text, codTemaSelected)
                cargarProductos(gestor.cargarProductosPorCriterio(""))
                limpiarCampos()
                lblMensajeRegistrar.Text = "El producto se ha registrado satisfactoriamente"
                lblMensajeRegistrar.ForeColor = Drawing.Color.Blue
                lblMensajeRegistrar.Visible = True
            Catch ex As Exception
                lblMensajeRegistrar.Text = ex.Message
                lblMensajeRegistrar.ForeColor = Drawing.Color.Red
                lblMensajeRegistrar.Visible = True
                If lblMensajeRegistrar.Text = "El nombre de este producto ya esta registrado en el sistema." Then
                    txtNombre.Focus()
                End If
            End Try
        End If
    End Sub
    Private Function validarDatos() As Boolean
        If txtNombre.Text.Equals("") Then
            lblMensajeRegistrar.Text = "Ingrese el nombre del producto"
            lblMensajeRegistrar.ForeColor = Drawing.Color.Red
            lblMensajeRegistrar.Visible = True
            txtNombre.Focus()
            Return False
        ElseIf txtMarca.Text.Equals("") Then
            lblMensajeRegistrar.Text = "Ingrese la marca del producto"
            lblMensajeRegistrar.ForeColor = Drawing.Color.Red
            lblMensajeRegistrar.Visible = True
            txtMarca.Focus()
            Return False
        ElseIf txtFabricante.Text.Equals("") Then
            lblMensajeRegistrar.Text = "Ingrese el fabricante producto"
            lblMensajeRegistrar.ForeColor = Drawing.Color.Red
            lblMensajeRegistrar.Visible = True
            txtFabricante.Focus()
            Return False
        ElseIf ddlTemas.SelectedIndex = 0 Then
            lblMensajeRegistrar.Text = "Seleccione el tema para el producto"
            lblMensajeRegistrar.ForeColor = Drawing.Color.Red
            lblMensajeRegistrar.Visible = True
            ddlTemas.Focus()
            Return False
        End If
        lblMensajeRegistrar.Visible = False
        Return True
    End Function

    Protected Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpiarCampos()
    End Sub

    Private Sub limpiarCampos()
        txtCriterio.Text = ""
        txtFabricante.Text = ""
        txtNombre.Text = ""
        txtMarca.Text = ""
        lblMantenimiento.Text = "Registrar producto"
        ddlTemas.SelectedIndex = 0
        lblMensajeRegistrar.Visible = False
        lblMensajeBuscar.Visible = False
        btnGuardarMod.Visible = False
        btnGuardarReg.Visible = True

    End Sub

    Private Sub eliminarProducto()
        Dim objHasht As Hashtable = tablaGrind.SelectedRecords.Item(0)
        lblNombre.Text = "Nombre para el nuevo producto:"
        btnGuardarReg.Visible = True
        btnGuardarMod.Visible = False
        Try
            gestor.eliminarProducto(CInt(objHasht.Item("codProducto")))
            cargarProductos(gestor.cargarProductosPorCriterio(""))
            limpiarCampos()
            lblMensajeBuscar.Text = "El producto '" & objHasht.Item("Nombre del producto") & "' se elimino satisfactoriamente."
            lblMensajeBuscar.ForeColor = Drawing.Color.Blue
            lblMensajeBuscar.Visible = True
        Catch ex As Exception
            lblMensajeBuscar.Text = ex.Message
            lblMensajeBuscar.ForeColor = Drawing.Color.Red
            lblMensajeBuscar.Visible = True
        End Try
    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Try
            limpiarCampos()
            Dim objHasht As Hashtable = tablaGrind.SelectedRecords.Item(0)
            lblMantenimiento.Text = "Modificar el producto seleccionado"
            lblNombre.Text = "Nombre para el producto"
            txtNombre.Text = objHasht.Item("Nombre del producto")
            txtFabricante.Text = objHasht.Item("Fabricante")
            txtMarca.Text = objHasht.Item("Marca")
            ddlTemas.SelectedValue = objHasht.Item("Tema")
            btnGuardarReg.Visible = False
            btnGuardarMod.Visible = True
            lblMensajeBuscar.Visible = False
        Catch ex As Exception
            lblMensajeBuscar.Text = "Seleccione el producto que desea modificar"
            lblMensajeBuscar.ForeColor = Drawing.Color.Red
            lblMensajeBuscar.Visible = True
        End Try
    End Sub

    Private Sub modificarDatosProducto()
        If validarDatos() Then
            Try
                Dim objHasht As Hashtable = tablaGrind.SelectedRecords.Item(0)
                Dim codigoProducto, codigoTema As Integer
                codigoProducto = objHasht.Item("codProducto")
                codigoTema = CInt(lbCodigosTemas.Items(ddlTemas.SelectedIndex).ToString)
                gestor.modificarProducto(codigoProducto, txtNombre.Text, txtMarca.Text, txtFabricante.Text, codigoTema)
                limpiarCampos()
                lblMensajeRegistrar.Text = "El producto se ha modificado satisfactoriamente."
                lblMensajeRegistrar.ForeColor = Drawing.Color.Blue
                lblMensajeRegistrar.Visible = True
                cargarProductos(gestor.cargarProductosPorCriterio(""))
            Catch ex As Exception
                lblMensajeRegistrar.Text = ex.Message
                lblMensajeRegistrar.ForeColor = Drawing.Color.Red
                lblMensajeRegistrar.Visible = True
                If lblMensajeRegistrar.Text = "El nombre de este producto ya esta registrado en el sistema." Then
                    txtNombre.Focus()
                End If
            End Try
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        buscarProductos()
        limpiarCampos()
        txtCriterio.Focus()
    End Sub

    Private Sub buscarProductos()
        Try
            Dim listaProductos As List(Of Array)
            Dim criterioBusqueda As String = txtCriterio.Text
            If criterioBusqueda.Equals("") Then
                listaProductos = gestor.cargarProductosPorCriterio("")
            Else
                listaProductos = gestor.cargarProductosPorCriterio(criterioBusqueda)
            End If
            cargarProductos(listaProductos)
            limpiarCampos()
            txtCriterio.Text = criterioBusqueda
            txtCriterio.Focus()
        Catch ex As Exception
            lblMensajeBuscar.Text = ex.Message
            lblMensajeBuscar.ForeColor = Drawing.Color.Red
            lblMensajeBuscar.Visible = True
        End Try
    End Sub

    Protected Sub txtCriterio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCriterio.TextChanged
        buscarProductos()
    End Sub

End Class
