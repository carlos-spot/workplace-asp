Public Class MantenimientoEmpleado

    Private codigosDep As New ListBox

    Private Sub MantenimientoEmpleado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cbxDepartamento.Items.Add("-- Seleccionar --")
            cargarContenedor()
            cargarDepartamentos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub cargarDepartamentos()
        cbxDepartamento.Items.Clear()
        cbxDepartamento.Items.Add("-- Seleccionar --")

        codigosDep.Items.Clear()
        codigosDep.Items.Add("-1")
        cbxDepartamento.SelectedIndex = 0

        Dim departamentos As New List(Of Array)

        Try
            departamentos = GLOBAL_GESTOR.cargarDepartamentos()

            For i As Integer = 0 To departamentos.Count - 1
                codigosDep.Items.Add(departamentos(i)(0).ToString)
                cbxDepartamento.Items.Add(departamentos(i)(1).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub cargarContenedor()
        Dim lista As New List(Of Array)
        lista = GLOBAL_GESTOR.buscarEmpleadosPorCriterio("")
        cargarDatos(lista, dgvDatosEmpleado)
    End Sub

    ''' <summary>
    ''' Metodo que carga los datos de una lista en un DataGridView
    ''' </summary>
    ''' <param name="p_lista"></param>
    ''' <param name="p_componente"></param>
    ''' <remarks></remarks>
    Private Sub cargarDatos(ByVal p_lista As List(Of Array), ByVal p_componente As DataGridView)
        Dim ind As Integer = p_lista.Count
        Dim cols As Integer = p_componente.ColumnCount

        p_componente.Rows.Clear()

        For i As Integer = 0 To ind - 1
            p_componente.Rows.Add()

            Dim temp() As String = p_lista.Item(i)
            p_componente.Rows(i).Cells(0).Value = temp(0)
            p_componente.Rows(i).Cells(1).Value = temp(1)
            p_componente.Rows(i).Cells(2).Value = temp(2) & " " & temp(3)

        Next
        p_componente.ClearSelection()

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If gbDatosEmpleado.Text = "Registrar empleado" Then
            registrarEmpleado()
        Else
            modificarEmpleado()
        End If
    End Sub

    Private Sub registrarEmpleado()
        If hayDatosCorrectos() Then
            Try
                Dim codigoDep As Integer = CInt(codigosDep.Items(cbxDepartamento.SelectedIndex))

                GLOBAL_GESTOR.registrarEmpleado(txtIdentificacion.Text, txtNombre.Text, txtApellidos.Text, txtTelefono.Text, codigoDep, txtDireccion.Text, txtPuesto.Text)
                MsgBox("El empleado " & txtNombre.Text & " " & txtApellidos.Text & " se ha registrado satisfactoriamente", MsgBoxStyle.Information, "Registrar empleado")
                limpiarDatos()
                cargarContenedor()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error al registrar")
                lblMensajeError.Text = ex.Message
                lblMensajeError.Visible = True
            End Try

        End If
    End Sub

    Private Sub modificarEmpleado()
        If hayDatosCorrectos() Then
            Dim msj As String = "¿Está seguro que desea modficar el empleado?"
            If (MessageBox.Show(msj, "Modificar empleado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0, False)) = Windows.Forms.DialogResult.OK Then
                Try
                    Dim codigoDep As Integer = CInt(codigosDep.Items(cbxDepartamento.SelectedIndex))

                    GLOBAL_GESTOR.modificarEmpleado(CInt(lblId.Text), txtIdentificacion.Text, txtNombre.Text, txtApellidos.Text, txtTelefono.Text, codigoDep, txtDireccion.Text, txtPuesto.Text)
                    MsgBox("El empleado " & txtNombre.Text & " " & txtApellidos.Text & " se ha modificado satisfactoriamente", MsgBoxStyle.Information, "Modificar empleado")
                    lblMensajeError.Visible = False
                    cargarContenedor()
                    limpiarDatos()
                Catch ex As Exception
                    lblMensajeError.Text = ex.Message
                    lblMensajeError.Visible = True
                End Try
            End If
        End If
    End Sub

    Private Function hayDatosCorrectos() As Boolean

        If txtNombre.Text.Equals("") Then
            txtNombre.Focus()
            lblMensajeError.Text = "Debe ingresar el nombre."
            lblMensajeError.Visible = True
            Return False
        End If

        If txtApellidos.Text.Equals("") Then
            txtApellidos.Focus()
            lblMensajeError.Text = "Debe ingresar sus apellidos."
            lblMensajeError.Visible = True
            Return False
        End If

        If txtDireccion.Text.Equals("") Then
            txtDireccion.Focus()
            lblMensajeError.Text = "Debe ingresar la dirección."
            lblMensajeError.Visible = True
            Return False
        End If

        If txtIdentificacion.Text.Equals("") Then
            txtIdentificacion.Focus()
            lblMensajeError.Text = "Debe ingresar la identificación."
            lblMensajeError.Visible = True
            Return False
        End If

        If cbxDepartamento.SelectedIndex = 0 Then
            lblMensajeError.Text = "Debe seleccionar el departamento."
            lblMensajeError.Visible = True
            Return False
        End If

        If txtPuesto.Text.Equals("") Then
            txtPuesto.Focus()
            lblMensajeError.Text = "Debe ingresar el puesto."
            lblMensajeError.Visible = True
            Return False
        End If

        If txtTelefono.Text.Equals("") Then
            txtTelefono.Focus()
            lblMensajeError.Text = "Debe ingresar el número de teléfono."
            lblMensajeError.Visible = True
            Return False
        End If

        Return True
    End Function

    Private Sub limpiarDatos()

        gbDatosEmpleado.Text = "Registrar empleado"
        cbxDepartamento.SelectedIndex = 0
        lblMensajeError.Visible = False

        txtNombre.Text = ""
        txtNombre.Focus()
        txtApellidos.Text = ""
        txtIdentificacion.Text = ""
        txtDireccion.Text = ""
        txtPuesto.Text = ""
        txtTelefono.Text = ""
    End Sub

    Private Sub pbModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim idEmpleado As String
        Dim lista() As String = Nothing
        lblMensajeError.Visible = False
        Try
            idEmpleado = dgvDatosEmpleado.SelectedCells(0).Value
            lista = GLOBAL_GESTOR.obtenerDatosEmpleado(CInt(idEmpleado))

            'Esto son los datos que tiene lista
            'lista(0) = Id
            'lista(1) = Identificacion
            'lista(2) = Nombre
            'lista(3) = Apellidos
            'lista(4) = Telefono
            'lista(5) = Departamento
            'lista(6) = Direccion
            'lista(7) = Puesto

            lblId.Text = lista(0)
            txtIdentificacion.Text = lista(1)
            txtNombre.Text = lista(2)
            txtApellidos.Text = lista(3)
            txtTelefono.Text = lista(4)
            cbxDepartamento.SelectedItem = lista(5)
            txtDireccion.Text = lista(6)
            txtPuesto.Text = lista(7)

        Catch ex As SqlClient.SqlException
            MsgBox("Error de conexión de base de datos: " & ex.Message, MsgBoxStyle.Exclamation, "Error al modificar")
        Catch ex As Exception
            MsgBox("Seleccione el empleado que desee modificar", MsgBoxStyle.Exclamation, "Error al modificar")
            txtCriterio.Text = ""
        End Try
        gbDatosEmpleado.Text = "Modificar empleado"

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim idEmpleado As Integer
        Try
            idEmpleado = CInt(dgvDatosEmpleado.SelectedCells(0).Value)

            Dim msj As String = "¿Está seguro que desea eliminar este empleado?"
            If (MessageBox.Show(msj, "Eliminar empleado", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, False)) = Windows.Forms.DialogResult.OK Then
                eliminarUsuario(idEmpleado)
            End If
        Catch ex As Exception
            MsgBox("Seleccione el empleado que desee eliminar", MsgBoxStyle.Exclamation, "Error al eliminar")
        End Try
    End Sub

    Private Sub eliminarUsuario(ByVal pidEmpleado As Integer)
        Try
            GLOBAL_GESTOR.eliminarEmpleado(pidEmpleado)
            MsgBox("El empleado " & dgvDatosEmpleado.SelectedCells(2).Value & " se ha eliminado satisfactoriamente", MsgBoxStyle.Information, "Eliminar usuario")
            gbDatosEmpleado.Text = "Registrar empleado"
            cargarContenedor()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error al elimiar")
            cargarContenedor()
        End Try
    End Sub

    Private Sub txtCriterio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCriterio.TextChanged
        'codigo para k buske mientras cambia el criterio
        Try
            cargarDatos(GLOBAL_GESTOR.buscarEmpleadosPorCriterio(txtCriterio.Text), dgvDatosEmpleado)
            If txtCriterio.Text.Equals("") Then
                cargarContenedor()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class