Imports SSLogica
Partial Class Pages_Rol_3___Asistente_RegistrarContacto
    Inherits System.Web.UI.Page
    Private emailExpression As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargarListaDeEmpresas()
        lblException.Visible = False
        lblException.ForeColor = Drawing.Color.Red
        txtNombre.Focus()
    End Sub

    Public Sub cargarListaDeEmpresas()
        Dim objGestor As New Gestor
        If cmbxEmpresa.Items.Count <= 0 Then
            Dim listaTemas As List(Of Array) = objGestor.empresasCargar()
            cmbxEmpresa.Items.Add("--Seleccionar--")
            'lbCodigosTemas.Items.Add("--Seleccionar--")
            For Each objArray In listaTemas

                'En la posicion 1 del Array viene el nombre del tema
                'En la posición 2 del Array viene el codigo del tema
                cmbxEmpresa.Items.Add(objArray(0).ToString)
                ' lbCodigosTemas.Items.Add(objArray(0).ToString)
            Next
        End If
    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim hash As New Hashtable
        Dim listaIds As New List(Of Integer)

        Dim codEmpresa As Integer
        If validarDatosVacios() Then
            If validarDatos() Then
           
                
                Try

                    codEmpresa = CInt(cmbxEmpresa.SelectedIndex.ToString)

                    Dim objGestor As New Gestor
                    objGestor.contactoRegistrar(txtNombre.Text, txtPrimerAp.Text, txtSegundoAp.Text, txtEmail.Text, txtTelefono.Text, codEmpresa)
                    lblException.ForeColor = Drawing.Color.Blue
                    lblException.Text = "El contacto se registró correctamente"
                    lblException.Visible = True

                    limpiarDatos()


                Catch ex As Exception

                    lblException.Text = ex.Message
                End Try

            End If
        Else

        End If
        
    End Sub

    Public Function validarDatosVacios() As Boolean
        Dim val As Boolean
        If Not txtNombre.Text = "" Then

            If Not txtPrimerAp.Text = "" Then

                If Not txtSegundoAp.Text = "" Then

                    If Not txtEmail.Text = "" Then

                        If Not txtTelefono.Text = "" Then
                            Dim int As Integer = CInt(cmbxEmpresa.SelectedIndex.ToString)
                            If Not CInt(cmbxEmpresa.SelectedIndex.ToString) = 0 Then


                                val = True
                            Else
                                lblException.Text = "Debes seleccionar una empresa"
                                lblException.Visible = True
                                val = False
                            End If

                        Else
                            lblException.Text = "Debes ingresar el teléfono."
                            lblException.Visible = True
                            val = False
                            txtTelefono.Focus()

                        End If



                    Else
                        lblException.Text = "Debes ingresar el e-mail."
                        lblException.Visible = True
                        val = False
                        txtEmail.Focus()

                    End If
                Else
                    lblException.Text = "Debes ingresar el segundo apellido"
                    val = False
                    lblException.Visible = True
                    txtSegundoAp.Focus()
                End If


            Else
                lblException.Text = "Debes ingresar el primer apellido"
                val = False
                lblException.Visible = True
                txtPrimerAp.Focus()
            End If
        Else
            lblException.Text = "Debes ingresar el nombre"
            val = False
            lblException.Visible = True
            txtNombre.Focus()
        End If

        Return val
    End Function

    Private Function validarDatos() As Boolean
        Dim val As Boolean

        If emailExpression.IsMatch(txtEmail.Text) Then


            val = True

        Else
            lblException.Text = "El formato del correo electrónico es incorrecto."
            lblException.Visible = True
            val = False

        End If
        Return val
    End Function

    Protected Sub Cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancelar.Click
        Try
            'Session("seleccion") = gvEncuestas.SelectedRow.Cells(1).Text()
            ' lblError.Text = Session("seleccion")


            Me.Response.Redirect("AgregarContactos.aspx")

        Catch ex As Exception
            'lblInformacion.Text = ex.Message
            lblException.Text = ex.Message
        End Try
    End Sub
    Private Sub limpiarDatos()
        txtNombre.Text = ""
        txtPrimerAp.Text = ""
        txtSegundoAp.Text = ""
        txtEmail.Text = ""
        txtTelefono.Text = ""
        cargarListaDeEmpresas()
    End Sub


End Class
