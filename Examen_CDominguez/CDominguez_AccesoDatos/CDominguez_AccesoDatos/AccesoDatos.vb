
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.IO

''' <summary>
''' Clase AccesoDatos
''' </summary>
''' <remarks>
''' Creado por: Carlos Domínguez Lara
''' Fecha: 25/11/2010 8:56 a.m
''' Modificado: 25/11/2010 8:56 a.m
''' </remarks> 
Public Class AccesoDatos

#Region "class field"
    'Atributos de la clase AccesoDatos
    Private _accesoDatos As String = Nothing
#End Region

#Region "class property"
    ''' <summary>
    ''' Conexion a la base de datos
    ''' </summary>
    ''' <returns>Un String con la conexion de la base de datos</returns>
    Public Property Conexion() As String
        Get
            If IsNothing(CStr(_accesoDatos)) Then
                _accesoDatos = My.Settings.connCDominguez.ToString()
            End If
            Return _accesoDatos
        End Get
        Set(ByVal pconexion As String)
            _accesoDatos = pconexion
        End Set
    End Property

#End Region

#Region "class methods"
    ''' <summary>
    ''' Devuelve la conexion a la base de datos
    ''' </summary>
    ''' <returns>Un String con la conexion de la base de datos</returns>
    Public Function getConnection() As SqlConnection
        Return New SqlConnection(Conexion)
    End Function

    Public Sub executeSQL(ByVal pSQL As String, ByVal ParamArray pParameters() As Parameters)
        Dim _cmd As SqlCommand
        Dim _objParamArray As Parameters
        Dim _name As String

        _cmd = New SqlCommand()
        _cmd.Connection = getConnection()

        For Each _objParamArray In pParameters
            _name = "@" & _objParamArray.Name
            _cmd.Parameters.AddWithValue(_name, _objParamArray.Data)
            pSQL = pSQL.Replace(_objParamArray.Name, _name)
        Next

        _cmd.CommandText = pSQL
        _cmd.Connection.Open()
        _cmd.ExecuteNonQuery()
        _cmd.Connection.Close()
    End Sub

    ''' <summary>
    ''' Ejecuta una sentencia SQL en la base de datos
    ''' </summary>
    ''' <param name="pConexion">Conexion a la base de datos</param>
    ''' <param name="pParameters">Parametros para cambiar en la sentencia</param>
    ''' <param name="pSQL">Scrips SQL que se ejecutara</param>
    Public Function executeSQL(ByVal pSQL As String, ByVal pConexion As IDbConnection, ByVal ParamArray pParameters() As Parameters) As SqlDataReader
        Dim _cmd As SqlCommand
        Dim _objParamArray As Parameters
        Dim _name As String

        _cmd = New SqlCommand
        _cmd.Connection = pConexion

        For Each _objParamArray In pParameters
            _name = "@" & _objParamArray.Name
            _cmd.Parameters.AddWithValue(_name, _objParamArray.Data)
            pSQL = pSQL.Replace(_objParamArray.Name, _name)
        Next

        _cmd.CommandText = pSQL

        If _cmd.Connection.State = ConnectionState.Closed Then
            _cmd.Connection.Open()
        End If
        Return _cmd.ExecuteReader

    End Function

    ''' <summary>
    ''' Ejecuta una sentencia en la base de datos
    ''' </summary>
    Public Function executeSQL(ByVal pSQL As String, ByVal pTable As String) As DataSet
        Dim _adapter As SqlDataAdapter
        Dim _ds As New DataSet()

        _adapter = New SqlDataAdapter(pSQL, CType(getConnection(), SqlConnection))
        _adapter.Fill(_ds, pTable)

        Return _ds
    End Function

#End Region

End Class

