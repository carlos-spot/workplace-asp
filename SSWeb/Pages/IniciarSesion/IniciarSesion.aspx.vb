
Partial Class IniciarSesion
    Inherits System.Web.UI.Page

    Private Sub dirigirAPagina(ByVal prol As String, ByVal pdatos As Array)
        Select Case prol
            Case "Administrador"
                Me.Session.Add("datosUsuarioLogin", pdatos)
                Me.Response.Redirect("~/Pages/Rol 1 - Administrador/PrincipalAdministrador.aspx")

            Case "Profesor"
                Me.Session.Add("datosUsuarioLogin", pdatos)
                Me.Response.Redirect("~/Pages/Rol 2 - Profesor/PrincipalProfesor.aspx")

            Case "Asistente"
                Me.Session.Add("datosUsuarioLogin", pdatos)
                Me.Response.Redirect("~/Pages/Rol 3 - Asistente/PrincipalAsistente.aspx")
            Case Else
                Me.Response.Redirect("~/index.aspx")
        End Select
    End Sub

    Protected Sub btnIngresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        'Valida que los campos del inicio de sesion no se encuentren vacios
        Me.Session.Clear()
        If validarCampos() Then

            'Llama al metodo de validar Usuario
            Try
                Dim datosUsuario As Array = validarUsuario()

                'Valida que el usuario exista
                If datosUsuario.Length > 0 Then
                    'datosUsuario(0) = objUsuario.Id
                    'datosUsuario(1) = objUsuario.Cedula
                    'datosUsuario(2) = objUsuario.Nombre
                    'datosUsuario(3) = objUsuario.PrimerApellido
                    'datosUsuario(4) = objUsuario.SegundoApellido
                    'datosUsuario(5) = objUsuario.Correo
                    'datosUsuario(6) = objUsuario.Departamento.Nombre
                    'datosUsuario(7) = objUsuario.Rol.Descripcion
                    'datosUsuario(8) = objUsuario.NombreUsuario

                    'Dependiendo del tipo de usuario que inicia sesión se redirecciona a la página correspondiente
                    dirigirAPagina(datosUsuario(7), datosUsuario)

                Else
                    lblMensaje.Text = "No coinciden los datos de ingreso"
                    lblMensaje.Visible = True
                End If
            Catch ex As Exception
                lblMensaje.Text = ex.Message
                lblMensaje.Visible = True
            End Try
        End If
    End Sub

    Private Function validarUsuario() As Array
        Dim gestor As New SSLogica.Gestor
        Dim datos As Array = Nothing
        datos = gestor.iniciarSesion(txtUsuario.Text, txtContrasenna.Text)
        Return datos
    End Function

    Private Function validarCampos() As Boolean
        Dim validado As Boolean = True

        If txtUsuario.Text = "" Then
            lblMensaje.Text = "Debe ingresar el nombre de usuario."
            lblMensaje.Visible = True
            validado = False
        ElseIf txtContrasenna.Text = "" Then
            lblMensaje.Text = "Debe ingresar la contraseña."
            lblMensaje.Visible = True
            validado = False
        Else
            lblMensaje.Visible = False
        End If

        Return validado
    End Function

    Protected Sub txtUsuario_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsuario.TextChanged
        validarCampos()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtUsuario.Focus()
        End If
    End Sub
End Class
