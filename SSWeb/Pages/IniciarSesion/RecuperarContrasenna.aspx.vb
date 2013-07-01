Imports System.Text.RegularExpressions
Imports SSLogica

Partial Class Pages_IniciarSesion_RecuperarContrasenna
    Inherits System.Web.UI.Page
    Private emailExpression As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCorreo.Attributes.Add("onfocus", "this.select();")
        txtNombre.Attributes.Add("onfocus", "this.select();")
    End Sub

    Private Sub limpiarDatos()
        txtCorreo.Text = ""
        txtNombre.Text = ""
        lblMensajeRecuperar.Text = ""
        lblMensajeRecuperar.Visible = False
    End Sub
    Protected Sub btnRecuperar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecuperar.Click
        recuperar()
    End Sub

    Private Sub recuperar()
        If validarDatos() Then
            Dim gestor As New Gestor
            Try
                gestor.recuperarContrasenna(txtNombre.Text, txtCorreo.Text)
                limpiarDatos()
                lblMensajeRecuperar.ForeColor = Drawing.Color.Blue
                lblMensajeRecuperar.Text = "La contraseña fue restaurada satisfactoriamente. Por favor revise su correo."
                lblMensajeRecuperar.Visible = True
            Catch ex As Exception
                lblMensajeRecuperar.Text = ex.Message
                lblMensajeRecuperar.Visible = True
            End Try
        End If
    End Sub

    Private Function validarDatos() As Boolean
        If txtNombre.Text.Equals("") Then
            lblMensajeRecuperar.Text = "Debe ingresar el nombre de usuario"
            lblMensajeRecuperar.ForeColor = Drawing.Color.Red
            lblMensajeRecuperar.Visible = True
            txtNombre.Focus()
            Return False
        End If
        If txtCorreo.Text.Equals("") Then
            lblMensajeRecuperar.Text = "Debe ingresar el correo electrónico"
            lblMensajeRecuperar.ForeColor = Drawing.Color.Red
            lblMensajeRecuperar.Visible = True
            txtCorreo.Focus()
            Return False
        End If
        If Not emailExpression.IsMatch(txtCorreo.Text) Then
            lblMensajeRecuperar.Text = "El formato del correo electrónico es incorrecto."
            lblMensajeRecuperar.ForeColor = Drawing.Color.Red
            lblMensajeRecuperar.Visible = True
            txtCorreo.Focus()
            Return False
        End If
        Return True
    End Function

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Response.Redirect("~/Pages/IniciarSesion/IniciarSesion.aspx")
    End Sub
End Class
