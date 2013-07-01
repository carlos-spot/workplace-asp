Imports CDominguez_AccesoDatos

''' <summary>
''' Clase PersistenciaEmpleado
''' </summary>
''' <remarks>
''' Creado por: Carlos Domínguez Lara
''' Fecha: 25/11/2010 8:56 a.m
''' Modificado: 25/11/2010 8:56 a.m
''' </remarks> 
Public Class PersistenciaDepartamento

    ''' <summary>
    ''' Busca un Departamento por el id de un Empleado.
    ''' </summary>
    ''' <param name="pidEmpleado">Id que se le asigna al Empleado en la base de datos</param>
    ''' <returns>El objeto Departamento</returns>
    ''' <exception cref="Exception">Error con la base de datos</exception>
    Public Shared Function buscarPorIdEmpleado(ByVal pidEmpleado As Integer) As Departamento
        Dim cnx As IDbConnection
        Dim dr As IDataReader
        Dim sql As String
        Dim objDepartamento As Departamento = Nothing
        Dim pars(0) As Parameters

        pars(0) = New Parameters("pidEmpleado", pidEmpleado)
        sql = "  SELECT D.codigo, D.nombre, D.id_encargado "
        sql &= " FROM t_departamento as D INNER JOIN t_empleado as E ON D.codigo = E.codigo_departamento "
        sql &= " WHERE E.id = pidEmpleado"

        Try
            cnx = GLOBAL_ACCESS.getConnection()
            dr = GLOBAL_ACCESS.executeSQL(sql, cnx, pars)

            While dr.Read
                With dr
                    objDepartamento = cargarDepartamento(dr)
                End With
            End While
            cnx.Close()
        Catch ex As Exception
            Throw New Exception("Error al tratar de conectar con la base de datos.")
        End Try
        Return objDepartamento
    End Function


    ''' <summary>
    ''' Busca un departamento por su codigo
    ''' </summary>
    ''' <param name="pcodigo">pcodigo</param>
    ''' <returns name = "departamento">Departamento que encontro</returns>
    ''' <remarks>Creado por: Carlos Domínguez  </remarks>
    Public Shared Function buscarPorCodigo(ByVal pcodigo As Integer) As Departamento
        Dim sql As String
        Dim dr As IDataReader = Nothing
        Dim cnx As IDbConnection
        Dim departamento As Departamento = Nothing
        Dim par As Parameters

        sql = "SELECT * FROM t_departamento WHERE codigo = pcodigo"

        par = New Parameters("pcodigo", pcodigo)
        cnx = GLOBAL_ACCESS.getConnection
        Try
            dr = GLOBAL_ACCESS.executeSQL(sql, cnx, par)
            With dr
                While .Read
                    departamento = cargarDepartamento(dr)
                End While
            End With
        Catch ex As Exception
            Throw New Exception("Error al tratar de conectar con la base de datos.")
        End Try
        cnx.Close()
        Return departamento
    End Function

    ''' <summary>
    ''' listarDepartamentos
    ''' </summary>
    ''' <returns name = "listaDepartamentos">lista con los departamentos</returns>
    ''' <remarks>Creado por: Carlos Domínguez, Creado: 25/11/2010 8:56 a.m  </remarks>
    Public Shared Function listarDepartamentos() As List(Of Departamento)
        Dim cnx As IDbConnection
        Dim dr As IDataReader
        Dim listaDepartamentos As New List(Of Departamento)
        Dim sql As String

        sql = "select * from t_departamento"
        cnx = GLOBAL_ACCESS.getConnection

        dr = GLOBAL_ACCESS.executeSQL(sql, cnx)
        With dr
            While .Read
                listaDepartamentos.Add(cargarDepartamento(dr))
            End While
        End With
        cnx.Close()
        Return listaDepartamentos
    End Function

    ''' <summary>
    ''' Ayuda a la persistencia a cargar los departamentos.
    ''' </summary>
    ''' <param name="dr">Resultado de la sentencia Sql</param>
    ''' <returns>Un objeto Departamento</returns>
    Private Shared Function cargarDepartamento(ByVal dr As IDataReader) As Departamento
        Dim objDepartamento As Departamento = Nothing
        With dr
            objDepartamento = New Departamento(CInt(dr.Item("codigo")), CType((dr.Item("nombre")), String))
        End With
        Return objDepartamento
    End Function
End Class
