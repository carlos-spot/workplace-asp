
Partial Class pages_Rol_2___Profesor_Analisis_TabulacionAbiertas
    Inherits System.Web.UI.Page

    Dim gestorDE As New SSLogica.Gestor


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim enc As SSLogica.Encuesta = gestorDE.encuestaBuscarPorCodigo((Request.QueryString("id")))
        lblNombre.Text = enc.nombre
        Dim listaEjemplares = enc.cuestionario.ejemplares
        Session("encuestaActual") = (Request.QueryString("id"))
        Dim codigosejemplares As New ListBox
        For i As Integer = 0 To listaEjemplares.Count - 1
            codigosejemplares.Items.Add(listaEjemplares(i).Codigo)
        Next

        If Not Page.IsPostBack Then
            Session("totalEjemplares") = codigosejemplares.Items.Count
            Session("totalEjemplaresTemporal") = Session("totalEjemplares")
            Session("totalEjemplaresTemporal") = 1
            lblCont.Text = "Ejemplar " & Session("totalEjemplaresTemporal") & " de " & Session("totalEjemplares")
            Session.Add("codigosEjemplares", codigosejemplares)
            btnFinalizar.Enabled = True
            cargarPreguntas()
            cargarRespuestas()
            cargarOpciones()
        End If
    End Sub

    Private Sub cargarPreguntas()
        Dim contPreguntas As Integer
        Dim preg As SSLogica.Pregunta
        Dim listaPreguntas = gestorDE.obtenerAbiertasPorEncuesta((Request.QueryString("id")))
        If (listaPreguntas.Count = 0) Then
            Response.Redirect("Analisis.aspx?respondido=" & 1)
        Else
            For Each preg In listaPreguntas
                Me.ddlPreguntas.Items.Add(preg.Descripcion)
                Me.codPreguntas.Items.Add(preg.Codigo)
                Me.ddlPreguntas.Items.Item(contPreguntas).Value = preg.Codigo
                contPreguntas = contPreguntas + 1
            Next
        End If
    End Sub



    Private Sub cargarRespuestas()
        Dim idPregunta As Integer = CInt(Me.codPreguntas.Items(ddlPreguntas.SelectedIndex).ToString)
        codPreguntas.SelectedIndex = ddlPreguntas.SelectedIndex

        Dim codigosEjemplares As ListBox
        codigosEjemplares = Session("codigosEjemplares")
        Dim idEjemplar = codigosEjemplares.Items.Item(0).Value
        Dim listaRespuestas As List(Of SSLogica.Respuesta) = gestorDE.respuestaPorPreguntaEjemplar(idEjemplar, idPregunta)
        txtRespuesta.Text = listaRespuestas(0).TextoRespuesta
        txtRespuesta.Enabled = False
        ddlPreguntas.Items.Clear()
        cargarPreguntas()
        Me.ddlPreguntas.SelectedIndex = codPreguntas.SelectedIndex
    End Sub


    Private Sub cargarOpciones()
        ddlOpciones.Items.Clear()
        Dim contOpciones As Integer
        Dim idPregunta As Integer = CInt(Me.codPreguntas.Items(ddlPreguntas.SelectedIndex).ToString)
        Dim opciones As List(Of Array) = gestorDE.listarOpcionesPorPregunta(idPregunta)
        For i As Integer = 0 To opciones.Count - 1
            Dim datosO As String() = opciones.Item(i)
            If Not datosO(1).Equals("Respuesta abierta") Then
                Me.ddlOpciones.Items.Add(datosO(1))
                Me.ddlOpciones.Items.Item(contOpciones).Value = datosO(0)
                contOpciones = contOpciones + 1
            End If
        Next
    End Sub

    Protected Sub btnFinalizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        registrarOpcionTabulada()
        Session("totalEjemplaresTemporal") = Session("totalEjemplaresTemporal") + 1
        lblCont.Text = "Ejemplar " & Session("totalEjemplaresTemporal") & " de " & Session("totalEjemplares")
        If (Session("totalEjemplaresTemporal") = Session("totalEjemplares")) Then
            Session("totalEjemplaresTemporal") = 0
        End If
    End Sub


    Private Sub registrarOpcionTabulada()
        Dim codigosEjemplares As ListBox
        codigosEjemplares = Session("codigosEjemplares")
        Dim idEjemplar As Integer = codigosEjemplares.Items.Item(0).Value
        Dim idPregunta = Me.ddlPreguntas.SelectedItem.Value
        Dim idOpcion = Me.ddlOpciones.SelectedItem.Value
        Dim textoOpcion As String = Me.ddlOpciones.SelectedItem.Text
        Try
            gestorDE.respuestaRegistrar(idEjemplar, textoOpcion, idPregunta, idOpcion)
            codigosEjemplares.Items.RemoveAt(0)
            Session("codigosEjemplares") = codigosEjemplares
            If codigosEjemplares.Items.Count = 0 Then
                gestorDE.preguntaMarcarComoTabulada(idPregunta)
                ddlPreguntas.Items.Clear()
                codPreguntas.Items.Clear()
                Dim enc As SSLogica.Encuesta = gestorDE.encuestaBuscarPorCodigo((Request.QueryString("id")))
                Dim listaEjemplares = enc.cuestionario.ejemplares
                Session("encuestaActual") = (Request.QueryString("id"))
                For i As Integer = 0 To listaEjemplares.Count - 1
                    codigosejemplares.Items.Add(listaEjemplares(i).Codigo)
                Next
                cargarPreguntas()
                cargarRespuestas()
                cargarOpciones()
            Else
                cargarRespuestas()
                cargarOpciones()
            End If
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
        End Try
    End Sub

    Protected Sub ddlPreguntas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPreguntas.SelectedIndexChanged
        btnFinalizar.Enabled = True
        cargarRespuestas()
        cargarOpciones()
        Dim enc As SSLogica.Encuesta = gestorDE.encuestaBuscarPorCodigo(Request.QueryString("id"))
        Dim listaEjemplares = enc.cuestionario.ejemplares
        Dim codigosEjemplares As New ListBox

        For i As Integer = 0 To listaEjemplares.Count - 1
            codigosEjemplares.Items.Add(listaEjemplares(i).Codigo)
        Next
        Session.Remove("codigosEjemplares")
        Session.Add("codigosEjemplares", codigosEjemplares)
    End Sub


End Class
