Imports System.Collections.Generic
Imports SSLogica

Partial Class Pages_Rol_2___Profesor_Confeccion_VistaPrevia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objGestor As New Gestor
        'Agregamos el nombre de la encuesta y el proposito de la encuesta.
        Dim encuesta As Encuesta = objGestor.encuestaBuscarPorCodigo(Session("codEncuesta"))
        lblNombre.Text = encuesta.nombre
        lblProposito.Text = encuesta.proposito

        'Convertimos el codigo de la encuesta a entero para poder mandarlo al metodo
        cargarPreguntas(Session("codEncuesta"))
    End Sub

    ''' <summary>
    ''' Carga las preguntas de una encuesta en el contenedor
    ''' </summary>
    ''' <remarks>Autor: Carlos Domínguez Lara</remarks>
    ''' <param name="pcodigoEncuesta">Código de la encuesta</param>
    Private Sub cargarPreguntas(ByVal pcodigoEncuesta As Integer)
        Dim objGestor As New Gestor
        Dim datosPregunta As List(Of Array)(,) = objGestor.buscarPreguntas(pcodigoEncuesta)

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

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Response.Redirect("ConfeccionEncuesta.aspx?codEncuesta=" & Session("codEncuesta"))
    End Sub
End Class
