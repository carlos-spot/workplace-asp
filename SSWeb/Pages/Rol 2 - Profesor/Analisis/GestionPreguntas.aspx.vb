Imports SSLogica

Partial Class pages_Rol_2___Profesor_RegistrarPregunta
    Inherits System.Web.UI.Page

    Dim gestor As New Gestor

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        lblError.Visible = True
        If cbxTipoPregunta.SelectedValue.Equals("--Seleccione--") Then
            lblError.Text = "Debe seleccionar un tipo de pregunta"
        ElseIf cbxTemas.SelectedValue.Equals("--Seleccione--") Then
            lblError.Text = "Debe seleccionar un tema"
        ElseIf txtTexto.Text = "" Then
            lblError.Text = "Debe digitar el texto de la pregunta"
        Else
            Try
                If lblMod.Text.Equals("Crear pregunta") Then
                    Dim codTipo As Integer = gestor.devolverCodigoTipoPregunta(cbxTipoPregunta.SelectedValue)
                    Dim codTema As Integer = gestor.cargarIdTemaPorNombre(cbxTemas.SelectedValue)
                    Dim pregunta As Pregunta = gestor.registrarPregunta(txtTexto.Text, codTipo, codTema)
                    txtTexto.Enabled = False
                    cbxTipoPregunta.Enabled = False
                    lblError.Text = "La pregunta fue agregada al pool de preguntas satisfactoriamente."
                    lblError.ForeColor = Drawing.Color.Blue
                Else
                    Dim codTipo As Integer = gestor.devolverCodigoTipoPregunta(cbxTipoPregunta.SelectedValue)
                    Dim codTema As Integer = gestor.cargarIdTemaPorNombre(cbxTemas.SelectedValue)
                    gestor.modificarPregunta(Session("codPregunta"), txtTexto.Text, codTipo, codTema)
                    txtTexto.Enabled = False
                    cbxTipoPregunta.Enabled = False
                    lblError.Text = "La pregunta fue ha sido modificada satisfactoriamente."
                    lblError.ForeColor = Drawing.Color.Blue
                End If
                limpiarForm()
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End If
    End Sub


    Private Sub limpiarForm()
        cbxTipoPregunta.SelectedValue = "--Seleccione--"
        cbxTipoPregunta.enabled = True
        cbxTemas.SelectedValue = "--Seleccione--"
        cbxTemas.enabled = True
        txtTexto.Text = ""
        txtTexto.enabled = True
    End Sub


    Private Sub llenarListaTipos()
        Dim lista As List(Of Array)
        lista = Gestor.listarTiposPregunta()
        If cbxTipoPregunta.Items.Count <= 1 Then
            cbxTipoPregunta.Items.Add("--Seleccione--")
            For i = 0 To lista.Count - 1
                Dim valores As Array = lista(i)
                cbxTipoPregunta.Items.Add(valores(1))
            Next
        End If
    End Sub


    Private Sub llenarListaTemas()
        Dim lista As New List(Of Array)
        lista = gestor.cargarTemas()
        If cbxTemas.Items.Count <= 1 Then
            cbxTemas.Items.Add("--Seleccione--")
            For i = 0 To lista.Count - 1
                Dim valores As Array = lista(i)
                cbxTemas.Items.Add(valores(1))
            Next
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblError.ForeColor = Drawing.Color.Red
        If Not Page.IsPostBack Then
            If (Request.QueryString("id") = 1) Then
                llenarListaTemas()
                llenarListaTipos()
                modRegistro()
            ElseIf (Request.QueryString("id") = 2) Then
                llenarListaTemas()
                llenarListaTipos()
                modModificar(Session("codPregunta"))
            Else
                llenarListaTemas()
                llenarListaTipos()
                modRegistro()
            End If
        End If
    End Sub

    Private Sub modRegistro()
        lblMod.Text = "Crear pregunta"
        btnRegistrar.Text = "Registrar"
    End Sub

    Private Sub modModificar(ByVal pcodPregunta As Integer)
        Dim pregunta = gestor.buscarPregunta(pcodPregunta)
        cbxTemas.SelectedValue = pregunta.Tema.Nombre
        cbxTipoPregunta.SelectedValue = pregunta.TipoPregunta.NombreTipo
        txtTexto.Text = pregunta.Descripcion
        lblMod.Text = "Modificar pregunta"
        btnRegistrar.Text = "Modificar"
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If lblMod.Text.Equals("Crear pregunta") Then
            limpiarForm()
            lblError.Visible = False
        ElseIf lblMod.Text.Equals("Modificar pregunta") Then
            Response.Redirect("PilaPreguntas.aspx?")
        Else
            limpiarForm()
            lblError.Visible = False
        End If
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Response.Redirect("PilaPreguntas.aspx")
    End Sub
End Class
