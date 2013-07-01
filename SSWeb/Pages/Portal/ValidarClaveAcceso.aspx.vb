Imports System.Text.RegularExpressions

Partial Class Pages_Portal_ValidarClaveAcceso
    Inherits System.Web.UI.Page
    Private emailExpression As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")

    Protected Sub btnIngresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        'Valida que los campos del inicio de sesion no se encuentren vacios
        Me.Session.Remove("datosAcceso")
        If validarCampos() Then

            'Llama al metodo de validar Contacto
            Try

                'datosAcceso(0) = Codigo del ejemplar 
                'datosAcceso(1) = Codigo encuesta
                'datosAcceso(2) = Nombre de la encuesta
                'datosAcceso(3) = Proposito de la encuesta
                Dim datosAcceso As Array = validarAcceso()

                'Valida que los datos del acceso existan
                If Not datosAcceso Is Nothing Then
                    Me.Session.Add("datosAcceso", datosAcceso)
                    Me.Response.Redirect("~/Pages/Portal/ResponderEncuesta.aspx")

                Else
                    lblMensaje.Text = "Los datos que ingresó son incorrectos."
                    lblMensaje.ForeColor = Drawing.Color.Red
                    lblMensaje.Visible = True
                End If
            Catch ex As Exception
                lblMensaje.Text = ex.Message
                lblMensaje.ForeColor = Drawing.Color.Red
                lblMensaje.Visible = True
            End Try
        End If
    End Sub

    Private Function validarAcceso() As Array
        Dim gestor As New SSLogica.Gestor
        Dim datos As Array = Nothing
        datos = gestor.validarAccesoAEncuesta(txtContacto.Text, txtClave.Text)
        Return datos
    End Function

    Private Function validarCampos() As Boolean
        Dim validado As Boolean = True
        If txtContacto.Text = "" Then
            txtContacto.Focus()
            lblMensaje.Text = "Debe ingresar el correo electrónico."
            lblMensaje.ForeColor = Drawing.Color.Red
            lblMensaje.Visible = True
            validado = False
        ElseIf txtClave.Text = "" Then
            txtClave.Focus()
            lblMensaje.Text = "Debe ingresar la clave de acceso."
            lblMensaje.ForeColor = Drawing.Color.Red
            lblMensaje.Visible = True
            validado = False
        ElseIf Not emailExpression.IsMatch(txtContacto.Text) Then
            lblMensaje.Text = "El formato del correo electrónico es incorrecto."
            lblMensaje.ForeColor = Drawing.Color.Red
            lblMensaje.Visible = True
            txtContacto.Focus()
            validado = False
        Else
            lblMensaje.Visible = False
        End If
        Return validado
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request.QueryString("respondido") Is Nothing Then
            lblMensaje.Text = "Gracias por haber participado en nuestra encuesta. Los datos han sido guardados correctamente."
            lblMensaje.ForeColor = Drawing.Color.Blue
            lblMensaje.Visible = True
        End If
    End Sub
End Class
