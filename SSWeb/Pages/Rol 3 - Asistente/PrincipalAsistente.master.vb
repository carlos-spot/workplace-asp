
Partial Class Pages_Rol_3___Asistente_PrincipalAsistente
    Inherits System.Web.UI.MasterPage
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        validarUsuario()
    End Sub
    Private Sub validarUsuario()
        Try
            Dim datos As Array = CType(Session.Item("datosUsuarioLogin"), Array)
            'datos(2) = Nombre 
            'datos(3) = Primer apellido
            'datos(4) = Segundo apellido
            lblSaludo.Text = "Sesión iniciada para:  " & datos(2) & " " & datos(3) & " " & datos(4)
        Catch ex As Exception
            Me.Response.Redirect("~/index.aspx")
        End Try
    End Sub

    Protected Sub btnCerrarSesion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrarSesion.Click
        Session.Remove("datosUsuarioLogin")
        Me.Response.Redirect("~/Pages/IniciarSesion/IniciarSesion.aspx")
    End Sub
End Class

