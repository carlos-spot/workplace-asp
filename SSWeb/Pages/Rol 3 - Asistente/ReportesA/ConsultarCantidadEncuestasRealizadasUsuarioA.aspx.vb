Imports SSLogica
Partial Class Reporte_ConsultarCantidadEncuestasRealizadasUsuario
    Inherits System.Web.UI.Page

    Private gestor As New Gestor

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargarListaDeUsuarios()
        End If
        lblError.Visible = False
    End Sub
    Public Sub cargarListaDeUsuarios()
        Try

            ddlUsuarios.Items.Clear()
            lbCodigosUsuarios.Items.Clear()
            If ddlUsuarios.Items.Count <= 0 Then
                Dim listaUsuarios As List(Of Array) = gestor.cargarUsuarios("Profesor")
                'Dim tam = obtenerTamannoMayor(listaTemas)
                'ddlTemas.Style. = (tam + 10)
                ddlUsuarios.Items.Add("  --  --  --Seleccionar--  --  -- ")
                lbCodigosUsuarios.Items.Add("--Seleccionar--")


                For Each objArray In listaUsuarios


                    'En la posicion 1 del Array viene el nombre del tema
                    'En la posición 2 del Array viene el codigo del tema
                    ddlUsuarios.Items.Add(objArray(1).ToString + " " + objArray(2).ToString + " " + objArray(3).ToString)
                    lbCodigosUsuarios.Items.Add(objArray(0).ToString)

                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If Not ddlUsuarios.SelectedIndex = 0 Then


            Session("idUsuarioAnalisis") = CInt(lbCodigosUsuarios.Items(ddlUsuarios.SelectedIndex).ToString)

            Dim val As Integer = Session("idUsuarioAnalisis")

            ' Session("idPeriodoRep") = CInt(lbCodigosPeriodos(Me.ddlPeriodos.SelectedIndex).ToString)
            Try
                Dim cant As Integer = gestor.cantidadEncuestasPorProfesor(Session("idUsuarioAnalisis"))
                If cant > 0 Then
                    Try
                        Me.Response.Redirect("CantidadEncuestasRealizadasUsuarioA.aspx")
                    Catch ex As Exception

                    End Try
                    '
                Else
                    lblError.Text = "No se encontraron encuestas analizadas por este usuario."

                    lblError.Visible = True
                End If

            Catch ex As Exception
                'lblError.Text = "No se encontraron encuestas analizadas por este usuario."
                lblError.Text = ex.Message
                lblError.Visible = True
            End Try



        Else
            lblError.Text = "Debe seleccionar un usuario."

            lblError.Visible = True

        End If
    End Sub
End Class
