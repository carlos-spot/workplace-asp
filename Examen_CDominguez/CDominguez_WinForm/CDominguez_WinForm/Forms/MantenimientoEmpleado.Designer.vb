<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MantenimientoEmpleado
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gbDatosEmpleado = New System.Windows.Forms.GroupBox
        Me.txtIdentificacion = New System.Windows.Forms.TextBox
        Me.lblIdentificacion = New System.Windows.Forms.Label
        Me.lblMensajeError = New System.Windows.Forms.Label
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.lblDireccion = New System.Windows.Forms.Label
        Me.txtPuesto = New System.Windows.Forms.TextBox
        Me.lblPuesto = New System.Windows.Forms.Label
        Me.cbxDepartamento = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.lblTelefono = New System.Windows.Forms.Label
        Me.txtApellidos = New System.Windows.Forms.TextBox
        Me.lblApellidos = New System.Windows.Forms.Label
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.lblNombre = New System.Windows.Forms.Label
        Me.dgvDatosEmpleado = New System.Windows.Forms.DataGridView
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.identificacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblNombrePanel = New System.Windows.Forms.Label
        Me.lblCriterio = New System.Windows.Forms.Label
        Me.txtCriterio = New System.Windows.Forms.TextBox
        Me.btnModificar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.lblId = New System.Windows.Forms.Label
        Me.gbDatosEmpleado.SuspendLayout()
        CType(Me.dgvDatosEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDatosEmpleado
        '
        Me.gbDatosEmpleado.Controls.Add(Me.txtIdentificacion)
        Me.gbDatosEmpleado.Controls.Add(Me.lblIdentificacion)
        Me.gbDatosEmpleado.Controls.Add(Me.lblMensajeError)
        Me.gbDatosEmpleado.Controls.Add(Me.btnLimpiar)
        Me.gbDatosEmpleado.Controls.Add(Me.btnGuardar)
        Me.gbDatosEmpleado.Controls.Add(Me.txtDireccion)
        Me.gbDatosEmpleado.Controls.Add(Me.lblDireccion)
        Me.gbDatosEmpleado.Controls.Add(Me.txtPuesto)
        Me.gbDatosEmpleado.Controls.Add(Me.lblPuesto)
        Me.gbDatosEmpleado.Controls.Add(Me.cbxDepartamento)
        Me.gbDatosEmpleado.Controls.Add(Me.Label10)
        Me.gbDatosEmpleado.Controls.Add(Me.txtTelefono)
        Me.gbDatosEmpleado.Controls.Add(Me.lblTelefono)
        Me.gbDatosEmpleado.Controls.Add(Me.txtApellidos)
        Me.gbDatosEmpleado.Controls.Add(Me.lblApellidos)
        Me.gbDatosEmpleado.Controls.Add(Me.txtNombre)
        Me.gbDatosEmpleado.Controls.Add(Me.lblNombre)
        Me.gbDatosEmpleado.Location = New System.Drawing.Point(60, 74)
        Me.gbDatosEmpleado.Name = "gbDatosEmpleado"
        Me.gbDatosEmpleado.Size = New System.Drawing.Size(630, 227)
        Me.gbDatosEmpleado.TabIndex = 0
        Me.gbDatosEmpleado.TabStop = False
        Me.gbDatosEmpleado.Text = "Registrar empleado"
        '
        'txtIdentificacion
        '
        Me.txtIdentificacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdentificacion.Location = New System.Drawing.Point(420, 18)
        Me.txtIdentificacion.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtIdentificacion.MaxLength = 25
        Me.txtIdentificacion.Name = "txtIdentificacion"
        Me.txtIdentificacion.Size = New System.Drawing.Size(180, 22)
        Me.txtIdentificacion.TabIndex = 4
        '
        'lblIdentificacion
        '
        Me.lblIdentificacion.AutoSize = True
        Me.lblIdentificacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdentificacion.Location = New System.Drawing.Point(315, 21)
        Me.lblIdentificacion.Name = "lblIdentificacion"
        Me.lblIdentificacion.Size = New System.Drawing.Size(83, 16)
        Me.lblIdentificacion.TabIndex = 70
        Me.lblIdentificacion.Text = "Identificación"
        '
        'lblMensajeError
        '
        Me.lblMensajeError.AutoSize = True
        Me.lblMensajeError.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeError.ForeColor = System.Drawing.Color.Red
        Me.lblMensajeError.Location = New System.Drawing.Point(73, 204)
        Me.lblMensajeError.Name = "lblMensajeError"
        Me.lblMensajeError.Size = New System.Drawing.Size(44, 20)
        Me.lblMensajeError.TabIndex = 68
        Me.lblMensajeError.Text = "Error"
        Me.lblMensajeError.Visible = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(467, 154)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(101, 35)
        Me.btnLimpiar.TabIndex = 67
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(329, 154)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(101, 35)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtDireccion
        '
        Me.txtDireccion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = New System.Drawing.Point(77, 91)
        Me.txtDireccion.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtDireccion.MaxLength = 255
        Me.txtDireccion.Multiline = True
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(201, 80)
        Me.txtDireccion.TabIndex = 3
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.Location = New System.Drawing.Point(10, 94)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(62, 16)
        Me.lblDireccion.TabIndex = 65
        Me.lblDireccion.Text = "Dirección"
        '
        'txtPuesto
        '
        Me.txtPuesto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuesto.Location = New System.Drawing.Point(420, 85)
        Me.txtPuesto.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtPuesto.MaxLength = 25
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.Size = New System.Drawing.Size(180, 22)
        Me.txtPuesto.TabIndex = 6
        '
        'lblPuesto
        '
        Me.lblPuesto.AutoSize = True
        Me.lblPuesto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuesto.Location = New System.Drawing.Point(315, 88)
        Me.lblPuesto.Name = "lblPuesto"
        Me.lblPuesto.Size = New System.Drawing.Size(49, 16)
        Me.lblPuesto.TabIndex = 63
        Me.lblPuesto.Text = "Puesto"
        '
        'cbxDepartamento
        '
        Me.cbxDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.cbxDepartamento.FormattingEnabled = True
        Me.cbxDepartamento.Location = New System.Drawing.Point(420, 53)
        Me.cbxDepartamento.Name = "cbxDepartamento"
        Me.cbxDepartamento.Size = New System.Drawing.Size(180, 24)
        Me.cbxDepartamento.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(315, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 16)
        Me.Label10.TabIndex = 61
        Me.Label10.Text = "Departamento"
        '
        'txtTelefono
        '
        Me.txtTelefono.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(420, 117)
        Me.txtTelefono.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtTelefono.MaxLength = 20
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(180, 22)
        Me.txtTelefono.TabIndex = 7
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefono.Location = New System.Drawing.Point(315, 120)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(55, 16)
        Me.lblTelefono.TabIndex = 56
        Me.lblTelefono.Text = "Teléfono"
        '
        'txtApellidos
        '
        Me.txtApellidos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApellidos.Location = New System.Drawing.Point(77, 53)
        Me.txtApellidos.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtApellidos.MaxLength = 25
        Me.txtApellidos.Name = "txtApellidos"
        Me.txtApellidos.Size = New System.Drawing.Size(201, 22)
        Me.txtApellidos.TabIndex = 2
        '
        'lblApellidos
        '
        Me.lblApellidos.AutoSize = True
        Me.lblApellidos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApellidos.Location = New System.Drawing.Point(10, 56)
        Me.lblApellidos.Name = "lblApellidos"
        Me.lblApellidos.Size = New System.Drawing.Size(61, 16)
        Me.lblApellidos.TabIndex = 53
        Me.lblApellidos.Text = "Apellidos"
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.HideSelection = False
        Me.txtNombre.Location = New System.Drawing.Point(77, 21)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtNombre.MaxLength = 25
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(201, 22)
        Me.txtNombre.TabIndex = 1
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(10, 24)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(53, 16)
        Me.lblNombre.TabIndex = 50
        Me.lblNombre.Text = "Nombre"
        '
        'dgvDatosEmpleado
        '
        Me.dgvDatosEmpleado.AllowUserToAddRows = False
        Me.dgvDatosEmpleado.AllowUserToResizeColumns = False
        Me.dgvDatosEmpleado.AllowUserToResizeRows = False
        Me.dgvDatosEmpleado.ColumnHeadersHeight = 47
        Me.dgvDatosEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDatosEmpleado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.identificacion, Me.nombre})
        Me.dgvDatosEmpleado.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvDatosEmpleado.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvDatosEmpleado.Location = New System.Drawing.Point(60, 365)
        Me.dgvDatosEmpleado.Name = "dgvDatosEmpleado"
        Me.dgvDatosEmpleado.ReadOnly = True
        Me.dgvDatosEmpleado.RowHeadersVisible = False
        Me.dgvDatosEmpleado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDatosEmpleado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatosEmpleado.Size = New System.Drawing.Size(492, 214)
        Me.dgvDatosEmpleado.TabIndex = 345
        '
        'id
        '
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.id.DefaultCellStyle = DataGridViewCellStyle10
        Me.id.HeaderText = "idEmpleado"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.id.Visible = False
        Me.id.Width = 30
        '
        'identificacion
        '
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.identificacion.DefaultCellStyle = DataGridViewCellStyle11
        Me.identificacion.HeaderText = "Identificación"
        Me.identificacion.Name = "identificacion"
        Me.identificacion.ReadOnly = True
        Me.identificacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.identificacion.Width = 150
        '
        'nombre
        '
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.nombre.DefaultCellStyle = DataGridViewCellStyle12
        Me.nombre.HeaderText = "Nombre del empleado"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 350
        '
        'lblNombrePanel
        '
        Me.lblNombrePanel.AutoSize = True
        Me.lblNombrePanel.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombrePanel.Location = New System.Drawing.Point(56, 31)
        Me.lblNombrePanel.Name = "lblNombrePanel"
        Me.lblNombrePanel.Size = New System.Drawing.Size(282, 24)
        Me.lblNombrePanel.TabIndex = 346
        Me.lblNombrePanel.Text = "Mantenimiento de empleados"
        '
        'lblCriterio
        '
        Me.lblCriterio.AutoSize = True
        Me.lblCriterio.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCriterio.Location = New System.Drawing.Point(57, 327)
        Me.lblCriterio.Name = "lblCriterio"
        Me.lblCriterio.Size = New System.Drawing.Size(207, 17)
        Me.lblCriterio.TabIndex = 348
        Me.lblCriterio.Text = "Ingrese el criterio de busqueda"
        '
        'txtCriterio
        '
        Me.txtCriterio.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.txtCriterio.Location = New System.Drawing.Point(308, 327)
        Me.txtCriterio.Name = "txtCriterio"
        Me.txtCriterio.Size = New System.Drawing.Size(169, 22)
        Me.txtCriterio.TabIndex = 347
        Me.txtCriterio.Tag = ""
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(571, 393)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(101, 35)
        Me.btnModificar.TabIndex = 349
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(571, 461)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(101, 35)
        Me.btnEliminar.TabIndex = 350
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(527, 13)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(0, 13)
        Me.lblId.TabIndex = 351
        Me.lblId.Visible = False
        '
        'MantenimientoEmpleado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 611)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.lblCriterio)
        Me.Controls.Add(Me.txtCriterio)
        Me.Controls.Add(Me.lblNombrePanel)
        Me.Controls.Add(Me.dgvDatosEmpleado)
        Me.Controls.Add(Me.gbDatosEmpleado)
        Me.Name = "MantenimientoEmpleado"
        Me.Text = "MantenimientoEmpleado"
        Me.gbDatosEmpleado.ResumeLayout(False)
        Me.gbDatosEmpleado.PerformLayout()
        CType(Me.dgvDatosEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDatosEmpleado As System.Windows.Forms.GroupBox
    Private WithEvents dgvDatosEmpleado As System.Windows.Forms.DataGridView
    Friend WithEvents lblNombrePanel As System.Windows.Forms.Label
    Friend WithEvents txtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents lblApellidos As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents cbxDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents txtPuesto As System.Windows.Forms.TextBox
    Friend WithEvents lblPuesto As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCriterio As System.Windows.Forms.Label
    Friend WithEvents txtCriterio As System.Windows.Forms.TextBox
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents identificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblMensajeError As System.Windows.Forms.Label
    Friend WithEvents txtIdentificacion As System.Windows.Forms.TextBox
    Friend WithEvents lblIdentificacion As System.Windows.Forms.Label
    Friend WithEvents lblId As System.Windows.Forms.Label
End Class
