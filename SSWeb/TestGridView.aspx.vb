Imports ClsCastCadenaUsuario
Imports System.Data
Imports SSLogica

Partial Class TestGridView
    Inherits System.Web.UI.Page
    Private _gestor As New Gestor

    Private Sub cargarDatosPrueba()
        Try
            Dim _listTemp As New List(Of ClsCastCadenaUsuario) 'declarar una variable tipo lista genérica tipo clsCastCadena (Wrapper)
            Dim _tempCast() As String 'declarar una variable tipo arreglo de String
            Dim _listaCliente As List(Of Array) = New List(Of Array)() 'declarar una variable tipo lista genérica de Array
            'declarar una variable tipo Array
            Dim _tempArray As Array

            _listaCliente = _gestor.buscarUsuarios("") 'asignar el resultado de la búsqueda devuelto por un método del Gestor

            For i As Integer = 0 To _listaCliente.Count - 1 'estructura iterativa tipo matriz para recorrer y envolver por el tipo adecuado

                _tempArray = _listaCliente(i) 'clonar a un Array temporal la FILA (ROW) de la consulta
                ReDim _tempCast(_tempArray.Length() - 1) 'redimensionar el arreglo a un tamaño indicado

                For j As Integer = 0 To _tempArray.Length - 1 'recorrer la parte interna de la matriz, columna (COLUMN)
                    _tempCast(j) = _tempArray.GetValue(j).ToString() 'asignar el valor de cada celda 
                Next

                '{objUsuario.Id, objUsuario.Cedula, objUsuario.Nombre, objUsuario.PrimerApellido, objUsuario.SegundoApellido, objUsuario.NombreUsuario, objUsuario.Rol.Descripcion}
                _listTemp.Add(New ClsCastCadenaUsuario(_tempCast(0).ToString(), _tempCast(1).ToString(), _tempCast(2).ToString(), _tempCast(3).ToString(), _tempCast(4).ToString(), _tempCast(5).ToString(), _tempCast(6).ToString())) 'agregar a la lista genérica una colección de la clase wrapper
            Next

            Me.dgCliente.DataSource = getDataTable(_listTemp) 'asignar el fuente de dato para un control tipo datagridview la lista genérica wrappeada
            Me.dgCliente.DataBind()

            GridOrigen.DataSource = getDataTable(_listTemp)
            GridOrigen.DataBind()
        Catch ex As Exception
            MsgBox("Error en la operación ... " & ex.Message, MsgBoxStyle.Information, "Buscar cliente")
        End Try
    End Sub

    'Funcion que crea un DataTable con los datos que le pasemos por parametro.
    Function getDataTable(ByVal pdatos As List(Of ClsCastCadenaUsuario)) As DataTable

        'Creamos el DataTable.
        Dim dt As New DataTable()

        'Dim _id As String
        'Dim _nombre As String
        'Dim _telefono As String
        'Dim _correo As String
        'Dim _contacto As String
        'Dim _direccion As String
        'Definimos el nombre de las columnas.
        dt.Columns.Add(New DataColumn("Id", GetType(String)))
        dt.Columns.Add(New DataColumn("Cedula", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("PrimerApellido", GetType(String)))
        dt.Columns.Add(New DataColumn("SegundoApellido", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreUsuario", GetType(String)))
        dt.Columns.Add(New DataColumn("Rol", GetType(String)))
        ' Create the four records
        For Each usuario As ClsCastCadenaUsuario In pdatos
            Dim dr As DataRow = dt.NewRow()
            dr("Id") = usuario.Id
            'dr("Cedula") = usuario.Cedula
            dr("Nombre") = usuario.Nombre
            'dr("PrimerApellido") = usuario.PrimerApellido
            'dr("SegundoApellido") = usuario.SegundoApellido
            'dr("NombreUsuario") = usuario.NombreUsuario
            'dr("Rol") = usuario.Rol
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargarDatosPrueba()
    End Sub
End Class
