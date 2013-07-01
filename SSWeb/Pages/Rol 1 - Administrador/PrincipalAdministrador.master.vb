
Partial Class Pages_Rol_1___Administrador_PrincipalAdministrador
    Inherits System.Web.UI.MasterPage

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Write("<script language='javascript' type='text/javascript'> alert('Prueba');</Script>")
        validarUsuario()
    End Sub
    Private Sub validarUsuario()
        If Not Session.Item("datosUsuarioLogin") Is Nothing Then
            Dim datos As Array = CType(Session.Item("datosUsuarioLogin"), Array)
            'datos(2) = Nombre 
            'datos(3) = Primer apellido
            'datos(4) = Segundo apellido
            lblSaludo.Text = "Sesión iniciada para:  " & datos(2) & " " & datos(3) & " " & datos(4)
        Else
            Me.Response.Redirect("~/index.aspx")
        End If
    End Sub

    Private Sub btnCerrarSesion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrarSesion.Click
        Session.Remove("datosUsuarioLogin")
        Session.Abandon()
        Session.Clear()
        Me.Response.Redirect("~/Pages/IniciarSesion/IniciarSesion.aspx")
    End Sub
End Class

