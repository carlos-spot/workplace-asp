Imports SSLogica
Partial Class IniciarSesion
    Inherits System.Web.UI.MasterPage

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Session.Item("datosUsuarioLogin") Is Nothing Then
            Dim datos As Array = Me.Session.Item("datosUsuarioLogin")
            dirigirAPagina(Me.Session.Item("datosUsuarioLogin")(7), datos)
        End If
    End Sub

    Protected Sub dirigirAPagina(ByVal prol As String, ByVal pdatos As Array)
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
End Class

