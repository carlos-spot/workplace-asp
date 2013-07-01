Imports SSLogica

Partial Class Pages_Portal_ResponderEncuesta
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Capturamos el parametro __EVENTTARGET
        'Si coincide con el valor pasado desde JS pues realiza una accion
        If My.Request.Params("__EVENTTARGET") = "salir" Then
            salir()
        End If

        'datosAcceso(0) = Codigo del ejemplar
        'datosAcceso(1) = Codigo encuesta
        'datosAcceso(2) = Nombre de la encuesta
        'datosAcceso(3) = Proposito de la encuesta
        Dim datosAcceso As Array = Session("datosAcceso")

        'Agregamos el nombre de la encuesta y el proposito de la encuesta.
        lblNombre.Text = datosAcceso(2)
        lblProposito.Text = datosAcceso(3)

        'Convertimos el codigo de la encuesta a entero para poder mandarlo al metodo
        cargarPreguntas(CInt(datosAcceso(1)))
    End Sub

    ''' <summary>
    ''' Carga las preguntas de una encuesta en el contenedor
    ''' </summary>
    ''' <remarks>Autor: Carlos Domínguez Lara</remarks>
    ''' <param name="pcodigoEncuesta">Código de la encuesta</param>
    Private Sub cargarPreguntas(ByVal pcodigoEncuesta As Integer)
        Dim gestor As New Gestor
        Dim datosPregunta As List(Of Array)(,) = gestor.buscarPreguntas(pcodigoEncuesta)

        'Dividimos entre dos ya que es una matriz bidimencional
        Dim numPreguntas As Integer = (datosPregunta.Length / 2) - 1
        For i As Integer = 0 To numPreguntas
            'datosP(0) = Codigo de la pregunta
            'datosP(1) = Descripción de la pregunta
            'datosP(2) = Id del tipo de pregunta
            Dim datosP() As String = datosPregunta(i, 0)(0)
            Dim objTab As New AjaxControlToolkit.TabPanel
            objTab.HeaderText = "Pregunta " & (i + 1)
            objTab.ToolTip = "Pregunta " & (i + 1)
            objTab.ID = datosP(0)

            Dim objLabel As New Label
            objLabel.ID = datosP(2) & "-" & datosP(0)
            objLabel.Text = datosP(1) & "  <br /><br />"
            objLabel.ForeColor = Drawing.Color.FromName("#003300")
            objLabel.Font.Size = 13
            objLabel.Font.Name = "Arial"
            objTab.Controls.Add(objLabel)
            generarOpciones(CInt(datosP(0)), CInt(datosP(2)), datosPregunta(i, 1), objTab)
            ContenedorPreguntas.Tabs.Add(objTab)
        Next
    End Sub

    ''' <summary>
    ''' Se encarga de generar las opciones de una pregunta
    ''' </summary>
    ''' <remarks>Autor: Carlos Domínguez Lara</remarks>
    ''' <param name="pcodPregunta">Código de la pregunta a la que se quiere generar las opciones</param>
    ''' <param name="pobjTab">Objeto AjaxControlToolkit.TabPanel al que se agregaran las preguntas(Se pasa por referencia)</param>
    ''' <param name="popcionesPregunta">Una List(Of Array) con los datos de las opciones</param>
    ''' <param name="ptipoPregunta">Número que indica el tipo de pregunta: 1.Seleccion Unica, 2.Multiple, 3.Abierta</param>
    Private Sub generarOpciones(ByVal pcodPregunta As Integer, ByVal ptipoPregunta As Integer, ByVal popcionesPregunta As List(Of Array), ByRef pobjTab As AjaxControlToolkit.TabPanel)
        'Para preguntas de selección unica
        If ptipoPregunta = 1 Then
            For i As Integer = 0 To popcionesPregunta.Count - 1
                Dim datosOpcion As String() = popcionesPregunta(i)
                Dim rdButton As New RadioButton
                rdButton.ID = datosOpcion(0)
                rdButton.Text = datosOpcion(1) & "  <br />"
                rdButton.ForeColor = Drawing.Color.FromName("#003300")
                rdButton.Font.Size = 11
                rdButton.Font.Name = "Arial"
                rdButton.GroupName = pcodPregunta
                pobjTab.Controls.Add(rdButton)
            Next
        End If


        'Para preguntas de selección multiple
        If ptipoPregunta = 2 Then
            For i As Integer = 0 To popcionesPregunta.Count - 1
                Dim datosOpcion As String() = popcionesPregunta(i)
                Dim chxBox As New CheckBox
                chxBox.ID = datosOpcion(0)
                chxBox.Text = datosOpcion(1) & "  <br />"
                chxBox.ForeColor = Drawing.Color.FromName("#003300")
                chxBox.Font.Size = 11
                chxBox.Font.Name = "Arial"
                pobjTab.Controls.Add(chxBox)
            Next
        End If

        'Para preguntas abiertas
        If ptipoPregunta = 3 Then
            Dim datosOpcion As String() = popcionesPregunta(0)
            Dim objTextBox As New TextBox
            objTextBox.ID = datosOpcion(0)
            objTextBox.Height = 110
            objTextBox.Width = 400
            objTextBox.TextMode = TextBoxMode.MultiLine
            objTextBox.Font.Size = 11
            objTextBox.Font.Name = "Arial"
            pobjTab.Controls.Add(objTextBox)
        End If
    End Sub

    Protected Sub btnFinalizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        Dim datosRespuesta As List(Of Array) = validarPreguntas()
        If Not datosRespuesta Is Nothing Then
            Dim objGestor As New Gestor
            Try
                objGestor.registrarRespuestas(datosRespuesta)
                objGestor.bloquearClave(CInt(Session("datosAcceso")(0)))
            Catch ex As Exception

            End Try
            Session.Remove("datosAcceso")
            Response.Redirect("~/Pages/Portal/ValidarClaveAcceso.aspx?respondido=" & 1)
        End If
    End Sub

    'Metodo que valida las preguntas y devuelve las respuestas.
    Private Function validarPreguntas() As List(Of Array)
        Dim datosRespuestas As New List(Of Array)
        Dim numPreguntas As Integer = ContenedorPreguntas.Tabs.Count - 1

        For i As Integer = 0 To numPreguntas
            Dim objTab As AjaxControlToolkit.TabPanel
            objTab = ContenedorPreguntas.Tabs.Item(i)
            Dim numOpciones As Integer = objTab.Controls.Count - 1
            Try
                'Conseguimos el Id del Label que es el que tiene el codigo del tipo de pregunta
                Dim pidLabel As String = CType(objTab.Controls.Item(0), Label).ID

                'Convertimos la primera posicion del String en entero, ya que ahi se encuentra el codigo del tipo
                Dim ptipoPregunta As Integer = CInt(pidLabel.Substring(0, 1))

                Select Case ptipoPregunta
                    Case 1
                        Dim objR As RadioButton
                        Dim contadorRespuesta As Integer = 0
                        For j As Integer = 1 To numOpciones
                            objR = CType(objTab.Controls.Item(j), RadioButton)
                            If objR.Checked Then
                                'Para registrar una pregunta se guardan los siguientes datos:
                                'Codigo del ejemplar: Session("datosAcceso")(0)
                                'Texto de la respuesta: objR.Text
                                'Codigo de la pregunta: objTad.ID
                                'Codigo de la opcion: objR.ID
                                Dim textoRespuesta As String = objR.Text
                                textoRespuesta = textoRespuesta.Replace("  <br />", "")
                                Dim datosR As String() = {Session("datosAcceso")(0), textoRespuesta, objTab.ID, objR.ID}
                                'CAMBIAR CUADO HAGA EL DE VALIDAR --->>> Dim datosR As String() = {1, objR.Text, objTab.ID, objR.ID}
                                datosRespuestas.Add(datosR)
                                contadorRespuesta += 1
                            End If
                        Next
                        If contadorRespuesta = 0 Then
                            lblMensajeError.Text = "La pregunta número '" & CInt(objTab.HeaderText.Substring(9)) & "' no se ha respondido."
                            lblMensajeError.Visible = True
                            ContenedorPreguntas.ActiveTab = objTab
                            datosRespuestas = Nothing
                            Return datosRespuestas
                        End If
                    Case 2
                        Dim contadorRespuesta As Integer = 0
                        For j As Integer = 1 To numOpciones
                            Dim objCbx As CheckBox
                            objCbx = CType(objTab.Controls.Item(j), CheckBox)
                            If objCbx.Checked Then
                                'Para registrar una pregunta se guardan los siguientes datos:
                                'Codigo del ejemplar: Session("datosAcceso")(0)
                                'Texto de la respuesta: objR.Text
                                'Codigo de la pregunta: objTad.ID
                                'Codigo de la opcion: objR.ID
                                Dim textoRespuesta As String = objCbx.Text
                                textoRespuesta = textoRespuesta.Replace("  <br />", "")
                                Dim datosR As String() = {Session("datosAcceso")(0), textoRespuesta, objTab.ID, objCbx.ID}
                                'CAMBIAR CUADO HAGA EL DE VALIDAR --->>> Dim datosR As String() = {1, objCbx.Text, objTab.ID, objCbx.ID}
                                datosRespuestas.Add(datosR)
                                contadorRespuesta += 1
                            End If
                        Next
                        If contadorRespuesta = 0 Then
                            lblMensajeError.Text = "La pregunta número '" & CInt(objTab.HeaderText.Substring(9)) & "' no se ha respondido."
                            lblMensajeError.Visible = True
                            ContenedorPreguntas.ActiveTab = objTab
                            datosRespuestas = Nothing
                            Return datosRespuestas
                        End If
                    Case 3
                        Dim objTextBox As TextBox = CType(objTab.Controls.Item(1), TextBox)

                        If Not objTextBox.Text.Equals("") Then
                            'Para registrar una pregunta se guardan los siguientes datos:
                            'Codigo del ejemplar: Session("datosAcceso")(0)
                            'Texto de la respuesta: objR.Text
                            'Codigo de la pregunta: objTad.ID
                            'Codigo de la opcion: objR.ID
                            Dim datosR As String() = {Session("datosAcceso")(0), objTextBox.Text, objTab.ID, objTextBox.ID}
                            'CAMBIAR CUADO HAGA EL DE VALIDAR --->>> Dim datosR As String() = {1, objTextBox.Text, objTab.ID, objTextBox.ID}
                            datosRespuestas.Add(datosR)
                        Else
                            lblMensajeError.Text = "La pregunta número '" & CInt(objTab.HeaderText.Substring(9)) & "' no se ha respondido."
                            lblMensajeError.Visible = True
                            ContenedorPreguntas.ActiveTab = objTab
                            datosRespuestas = Nothing
                            Return datosRespuestas
                        End If
                End Select
            Catch ex As Exception
                Throw New Exception
            End Try
        Next
        Return datosRespuestas
    End Function

    Private Sub salir()
        Session.Remove("CodigoEjemplar")
        Me.Response.Redirect("~/index.aspx")
    End Sub
End Class
