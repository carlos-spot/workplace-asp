Imports SSLogica
Partial Class Pages_Rol_3___Asistente_ModificarEncuesta
    Inherits System.Web.UI.Page
    Private encuestaActual As String
    Private poblacionEn As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblInformacion.ForeColor = Drawing.Color.Blue
        lblInformacion.Visible = False
        encuestaActual = Session("seleccion")
        cargarPantalla()
        cargarEncuesta()
        lblInformacion.Text = ""
        lblInformacion.Visible = False
        lblInformacion.ForeColor = Drawing.Color.Blue


    End Sub
    Public Sub cargarPantalla()
        pModificarMuestra.Visible = False
        lblError.Visible = False
        pprorroga.Visible = False

        ''pProrroga.Visible = False

    End Sub
    'Private Sub cargarInformacion(ByVal p_lista As List(Of Array))
    '    Dim dt As New Data.DataTable
    '    Dim dr As Data.DataRow
    '    Dim listTemporal() As String

    '    'Creamos las columnas
    '    dt.Columns.Add(New Data.DataColumn("Id"))
    '    dt.Columns.Add(New Data.DataColumn("Nombre"))
    '    dt.Columns.Add(New Data.DataColumn("Inicio"))
    '    dt.Columns.Add(New Data.DataColumn("Fin"))
    '    dt.Columns.Add(New Data.DataColumn("Población"))
    '    dt.Columns.Add(New Data.DataColumn("Muestra"))
    '    dt.Columns.Add(New Data.DataColumn("Margen/error"))
    '    dt.Columns.Add(New Data.DataColumn("Propósito"))
    '    dt.Columns.Add(New Data.DataColumn("Tema"))

    '    'Recorremos la lista de Empleados
    '    If Not p_lista.Count = 0 Then
    '        gvEncuestas.Visible = True
    '        Dim i As Integer
    '        Dim n As Integer
    '        For n = 0 To p_lista.Count - 1
    '            dr = dt.NewRow()
    '            listTemporal = p_lista(n)
    '            For i = 0 To dt.Columns.Count - 1
    '                dr(i) = listTemporal(i)
    '            Next
    '            dt.Rows.Add(dr)
    '        Next
    '        gvEncuestas.DataSource = dt
    '        gvEncuestas.DataBind()
    '        modificarTamannosDeCelda()
    '        '' lblError.Visible = False
    '        '' desBloquearMantenimiento()
    '    Else
    '        'Si no existen datos muestra el error
    '        gvEncuestas.Visible = True
    '        ''bloquearMantenimiento()
    '        ''lblError.Text = "No se encontraron encuestas."
    '        ''lblError.Visible = True
    '    End If
    'End Sub
    Private Sub cargarEncuesta()
        'Limpiamos el gried view y hacemos desaparecer el label de error por si existe
        '  gvEncuestas.Columns.Clear()
        Try
            'Listamos los Empleados
            Dim objGestor As New Gestor
            Dim lista As List(Of Array) = objGestor.encuestaBuscarPorId(encuestaActual)
            If Not lista Is Nothing And Not lista.Count = 0 Then
                'cargarInformacion(lista)
                ' gvEncuestas.SelectedDim listTemporal() As Strin
                Dim listTemporal() As String = lista.Item(0)

                lblIdEncuesta.Text = listTemporal(0)
                lblNombreEncuesta.Text = listTemporal(1)
                lblInicio.Text = listTemporal(2)
                lblFin.Text = listTemporal(3)
                lblPoblacion.Text = listTemporal(4)
                lblMuestra.Text = listTemporal(5)
                lblMargen.Text = listTemporal(6)
                lblTema.Text = listTemporal(8)
                'lblTema.Text = listTemporal(8)

                'gvEncuestas.
            Else
                Dim datosN() As String = {"", "", "", "", "", "", "", "", ""}
                lista.Add(datosN)
                'cargarInformacion(lista)
            End If


        Catch ex As Exception
            'lblError.Visible = True
            'lblError.Text = ex.Message
            'bloquearMantenimiento()
        End Try

    End Sub

    Protected Sub btnModificarMuestra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificarMuestra.Click

        Try

            pModificarMuestra.Visible = True


            ''guardamos la id de la encuesta k se va a modificar
            Session("idModEncuesta") = lblIdEncuesta.Text
            txtMuestra.Text = lblMuestra.Text
            Session("poblacion") = lblPoblacion.Text
            ''lblError.Text = Session("seleccion")



        Catch ex As Exception
            lblError.Text = "Debes seleccionar una encuesta"
            lblError.Visible = True

        End Try

        Try




            '' Me.Response.Redirect("ModificarEncuesta.aspx?id=" & gvEncuestas.SelectedRow.Cells(1).Text)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        txtMuestra.Text = ""
        pModificarMuestra.Visible = False


    End Sub

    Protected Sub btnGuardarCambios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarCambios.Click
        Try
            If IsNumeric(txtMuestra.Text) Then


                Dim muestra As Integer = CInt(txtMuestra.Text)
                Dim poblacion As Integer = CInt(Session("poblacion"))
                If muestra > 0 Then


                    If muestra < poblacion And muestra > 0 Then



                        Dim objGestor As New Gestor
                        objGestor.modificarMuestra(muestra, Session("idModEncuesta"))
                        cargarEncuesta()
                        pModificarMuestra.Visible = False
                        cargarPantalla()
                        cargarEncuesta()
                        lblInformacion.Text = "La muestra se ha modificado correctamente"
                        lblInformacion.Visible = True
                    Else
                        lblError.Text = "La muestra no puede ser mayor a la población"
                        lblError.Visible = True
                        pModificarMuestra.Visible = True


                    End If
                Else
                    lblError.Text = "La muestra no puede ser menor a 0"
                    lblError.Visible = True
                    pModificarMuestra.Visible = True

                End If
            Else
                lblError.Text = "Debes ingresar solo numeros"
                lblError.Visible = True
                pModificarMuestra.Visible = True
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
            pModificarMuestra.Visible = True

        End Try


    End Sub

    Protected Sub btnRealizarProrroga_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRealizarProrroga.Click
        lblErrorProrroga.Visible = False
        pprorroga.Visible = True


        Dim hash As New Hashtable
        Try



            ''guardamos la id de la encuesta k se va a modificar
            Session("idModEncuesta") = lblIdEncuesta.Text

            Session("fechaFin") = lblFin.Text

        Catch ex As Exception
            lblError.Text = "Debes seleccionar una encuesta"
            lblError.Visible = True

        End Try






    End Sub


    Protected Sub btnGuardarProrroga_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarProrroga.Click
        Try

            If calendario.SelectedDate > Session("fechaFin") And calendario.SelectedDate > Date.Now.Date Then
                Dim objGestor As New Gestor
                objGestor.realizarProrroga(calendario.SelectedDate, CInt(Session("idModEncuesta")))
                cargarPantalla()
                cargarEncuesta()
                lblInformacion.Text = "Se ha asignado una nueva fecha a la encuesta"
                lblInformacion.Visible = True
            Else
                lblErrorProrroga.Text = "Debes ingresar una fecha válida"
                lblErrorProrroga.Visible = True
                pprorroga.Visible = True

            End If

        Catch ex As Exception
            lblInformacion.Text = "La fecha se ha modificado correctamente. " & ex.Message
            lblInformacion.Visible = True

        End Try
    End Sub


    Protected Sub btnAtras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Try
            'Session("seleccion") = gvEncuestas.SelectedRow.Cells(1).Text()
            ' lblError.Text = Session("seleccion")
            Me.Response.Redirect("Seguimiento.aspx")

        Catch ex As Exception
            'lblInformacion.Text = ex.Message
        End Try
    End Sub

    Private Sub modificarTamannosDeCelda()




    End Sub

End Class

