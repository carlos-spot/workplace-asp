Imports SSLogica
Partial Class Reporte_ConsultarCantidadEncuestaPorTemaYPeriodoDado
    Inherits System.Web.UI.Page
    Private listaCodTema As New List(Of Integer)
    Private listaCodPeriodos As New List(Of Integer)
    Private gestor As New Gestor

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargarListaDeTemas()
            cargarListaDePeriodos()
        End If
        lblError.Visible = False
    End Sub
    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If Not ddlTemas.SelectedIndex = 0 Then

            If Not ddlPeriodos.SelectedIndex = 0 Then
                Session("idTemaRep") = CInt(lbCodigosTemas.Items(ddlTemas.SelectedIndex).ToString)

                Dim valperiodo As Integer = ddlPeriodos.SelectedIndex()
                Session("idPeriodoRep") = valperiodo
                ' Session("idPeriodoRep") = CInt(lbCodigosPeriodos(Me.ddlPeriodos.SelectedIndex).ToString)
                Try
                    Dim cant As Integer = gestor.cantidadEncuestasPorTemaPeriodo(Session("idTemaRep"), Session("idPeriodoRep"))
                    If cant > 0 Then

                        Me.Response.Redirect("CantidadEncuestasPorTemaDadoPeriodoP.aspx")
                    Else
                        lblError.Text = "No se encontraron encuestas."

                        lblError.Visible = True
                    End If

                Catch ex As Exception
                    lblError.Text = "No se encontraron encuestas."

                    lblError.Visible = True
                End Try

            Else
                lblError.Text = "Debe seleccionar un periódo."

                lblError.Visible = True
            End If

        Else
            lblError.Text = "Debe seleccionar un tema."

            lblError.Visible = True

        End If
    End Sub
    Public Sub cargarListaDeTemas()
        Try

            ddlTemas.Items.Clear()
            lbCodigosTemas.Items.Clear()
            If ddlTemas.Items.Count <= 0 Then
                Dim listaTemas As List(Of Array) = gestor.cargarTemas
                'Dim tam = obtenerTamannoMayor(listaTemas)
                'ddlTemas.Style. = (tam + 10)
                ddlTemas.Items.Add("  --  --  --Seleccionar--  --  -- ")
                lbCodigosTemas.Items.Add("--Seleccionar--")


                For Each objArray In listaTemas


                    'En la posicion 1 del Array viene el nombre del tema
                    'En la posición 2 del Array viene el codigo del tema
                    ddlTemas.Items.Add(objArray(1).ToString)
                    lbCodigosTemas.Items.Add(objArray(0).ToString)

                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function obtenerTamannoMayor(ByVal plistaTemas As List(Of Array)) As Integer
        Dim mayor As Integer = 0
        Dim temp As Integer = 0

        For Each objArray In plistaTemas
            Dim Strins As String = objArray(1).ToString
            If CInt(objArray(1).ToString.Length) > mayor Then
                mayor = CInt(objArray(1).ToString.Length)
            End If

        Next


        Return mayor

    End Function
    Public Sub cargarListaDePeriodos()
        Try

            ddlPeriodos.Items.Clear()
            lbCodigosPeriodos.Items.Clear()
            If ddlPeriodos.Items.Count <= 0 Then
                Dim listaTemas As List(Of Array) = gestor.cargarPeriodos()

                'Dim tam = obtenerTamannoMayor(listaTemas)
                'ddlTemas.Style. = (tam + 10)
                ddlPeriodos.Items.Add("  --  --  --Seleccionar--  --  -- ")
                lbCodigosPeriodos.Items.Add("--Seleccionar--")


                For Each objArray In listaTemas


                    'En la posicion 1 del Array viene el nombre del tema
                    'En la posición 2 del Array viene el codigo del tema
                    ddlPeriodos.Items.Add(objArray(1).ToString)
                    lbCodigosPeriodos.Items.Add(objArray(0).ToString)

                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    
End Class
