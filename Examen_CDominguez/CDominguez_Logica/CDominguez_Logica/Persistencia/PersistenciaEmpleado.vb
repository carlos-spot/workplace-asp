Imports CDominguez_AccesoDatos

''' <summary>
''' Clase PersistenciaEmpleado
''' </summary>
''' <remarks>
''' Creado por: Carlos Domínguez Lara
''' Fecha: 25/11/2010 8:56 a.m
''' Modificado: 25/11/2010 8:56 a.m
''' </remarks> 
Public Class PersistenciaEmpleado

    ''' <summary>
    ''' Registra un nuevo empleado a la base de datos.
    ''' </summary>
    ''' <param name="pidentificacion">Cédula del Empleado</param>
    ''' <param name="pnombre">Nombre del Empleado</param>
    ''' <param name="papellidos">Apellidos del Empleado</param>
    ''' <param name="ptelefono">Teléfono del Empleado</param>
    ''' <param name="pdireccion">Dirección del Empleado</param>
    ''' <param name="ppuesto">Puesto que se le asignara al empleado</param>
    ''' <exception cref="SqlClient.SqlException">Error con la base de datos</exception>
    Public Shared Sub registrar(ByVal pidentificacion As String, ByVal pnombre As String, ByVal papellidos As String, ByVal ptelefono As String, _
                                ByVal pcodigoDep As Integer, ByVal pdireccion As String, ByVal ppuesto As String)
        Dim sql As String
        Dim pars(0 To 6) As Parameters
        Dim dr As IDataReader = Nothing

        Try
            sql = "INSERT INTO t_empleado values(pidentificacion, pnombre, papellidos, ptelefono, pcodigoDep, pdireccion, ppuesto)"

            'Estos nombres son los mismos que deben ir en los values del insert.
            pars(0) = New Parameters("pidentificacion", pidentificacion)
            pars(1) = New Parameters("pnombre", pnombre)
            pars(2) = New Parameters("papellidos", papellidos)
            pars(3) = New Parameters("ptelefono", ptelefono)
            pars(4) = New Parameters("pcodigoDep", pcodigoDep)
            pars(5) = New Parameters("pdireccion", pdireccion)
            pars(6) = New Parameters("ppuesto", ppuesto)

            GLOBAL_ACCESS.executeSQL(sql, pars)

        Catch ex As SqlClient.SqlException
            If (ex.Message.Contains("IX_t_empleado_identificacion")) Then
                Throw New Exception("El número de identificación ya está registrado en el sistema," & vbCrLf & "no puede ser duplicado.")

            ElseIf (ex.Number = -1) Then
                Throw New Exception("No se encontro el servidor de base de datos.")

            Else
                Throw New Exception("Error al tratar de conectar con la base de datos.")

            End If
        End Try
    End Sub

    ''' <summary>
    ''' Modificar un empleado de la base de datos.
    ''' </summary>
    ''' <param name="pobjEmpleado">El objeto Empleado que se desea modificar</param>
    ''' <exception cref="SqlClient.SqlException">Error con la base de datos</exception>
    Public Shared Sub modificar(ByVal pobjEmpleado As Empleado)
        Dim sql As String
        Dim pars(0 To 7) As Parameters

        Try
            sql = "UPDATE t_empleado SET identificacion = p_ident, nombre = pnombre, apellidos = papellidos, "
            sql &= " telefono = ptelefono, codigo_departamento = pcodigoDep, direccion = pdireccion, puesto = ppuesto"
            sql &= " WHERE id = pid"
            'Estos nombres son los mismos que deben ir en los values del Update.
            pars(0) = New Parameters("p_ident", pobjEmpleado.Identificacion)
            pars(1) = New Parameters("pnombre", pobjEmpleado.Nombre)
            pars(2) = New Parameters("papellidos", pobjEmpleado.Apellidos)
            pars(3) = New Parameters("ptelefono", pobjEmpleado.Telefono)
            pars(4) = New Parameters("pcodigoDep", pobjEmpleado.Departamento.Codigo)
            pars(5) = New Parameters("pdireccion", pobjEmpleado.Direccion)
            pars(6) = New Parameters("ppuesto", pobjEmpleado.Puesto)
            pars(7) = New Parameters("pid", pobjEmpleado.Id)

            GLOBAL_ACCESS.executeSQL(sql, pars)

        Catch ex As SqlClient.SqlException
            If (ex.Message.Contains("IX_t_empleado_identificacion")) Then
                Throw New Exception("El número de identificación ya está registrado en el sistema," & vbCrLf & "no puede ser duplicado.")
            Else
                Throw New Exception("Error al tratar de conectar con la base de datos.")

            End If
        End Try
    End Sub

    ''' <summary>
    ''' Elimina un empleado de la base de datos
    ''' </summary>
    ''' <param name="pempleado">departamento</param>
    ''' <remarks>Creado por: Carlos Dominguez </remarks>
    Public Shared Sub eliminar(ByVal pempleado As Empleado)
        Dim sql As String
        Dim par As Parameters

        sql = "delete from t_empleado where id = pid "
        par = New Parameters("pid", pempleado.Id)

        Try
            GLOBAL_ACCESS.executeSQL(sql, par)

        Catch ex As SqlClient.SqlException
            Throw New Exception("Error al tratar de conectar con la base de datos.")
        End Try
    End Sub

    ''' <summary>
    ''' Busca un empleado por su id.
    ''' </summary>
    ''' <param name="pid">Identificacion que se le asigna al empleado en la base de datos</param>
    ''' <returns>El objeto Empleado que se encontro</returns>
    ''' <exception cref="SqlClient.SqlException">Error con la base de datos</exception>
    Public Shared Function buscarPorId(ByVal pid As String) As Empleado
        Dim sql As String
        Dim dr As IDataReader = Nothing
        Dim cnx As IDbConnection
        Dim pars(0) As Parameters
        Dim objEmpleado As Empleado = Nothing

        sql = "SELECT * "
        sql &= " FROM t_empleado "
        sql &= " WHERE id = pid "

        Try
            pars(0) = New Parameters("pid", pid)
            cnx = GLOBAL_ACCESS.getConnection
            dr = GLOBAL_ACCESS.executeSQL(sql, cnx, pars)

            While dr.Read
                With dr
                    objEmpleado = cargarEmpleado(dr)
                End With
            End While
            cnx.Close()

        Catch ex As SqlClient.SqlException
            Throw New Exception("No se pudo realizar la busqueda.")
        End Try

        Return objEmpleado
    End Function

    ''' <summary>
    ''' Busca un Empleado por el Codigo de un Departamento.
    ''' </summary>
    ''' <param name="pcodDepartamento">Codigo que se le asigna al Departamento en la base de datos</param>
    ''' <returns>El objeto Empleado</returns>
    ''' <exception cref="Exception">Error con la base de datos</exception>
    Public Shared Function buscarPorCodDep(ByVal pcodDepartamento As Integer) As Empleado
        Dim cnx As IDbConnection
        Dim dr As IDataReader
        Dim sql As String
        Dim objEmpleado As Empleado = Nothing
        Dim pars(0) As Parameters

        pars(0) = New Parameters("pcodDepartamento", pcodDepartamento)
        sql = "  SELECT E.id, E.identificacion, E.nombre, E.apellidos, E.telefono, E.direccion, E.puesto "
        sql &= " FROM t_departamento as D INNER JOIN t_empleado as E ON D.codigo = E.codigo_departamento "
        sql &= " WHERE D.codigo = pcodDepartamento"

        Try
            cnx = GLOBAL_ACCESS.getConnection()
            dr = GLOBAL_ACCESS.executeSQL(sql, cnx, pars)

            While dr.Read
                With dr
                    objEmpleado = cargarEmpleado(dr)
                End With
            End While
            cnx.Close()
        Catch ex As Exception
            Throw New Exception("Error al tratar de conectar con la base de datos.")
        End Try
        Return objEmpleado
    End Function

    ''' <summary>
    ''' Lista los Empleados segun el criterio de busqueda que se le envie.
    ''' </summary>
    ''' <param name="pcriterio">Criterio de busqueda que se utilizara</param>
    ''' <returns>Un List(Of Empleado) Con todos los Empleados encontrados</returns>
    Public Shared Function buscarPorCriterio(ByVal pcriterio As String) As List(Of Empleado)
        Dim cnx As IDbConnection
        Dim dr As IDataReader
        Dim listaEmpleados As New List(Of Empleado)
        Dim sql As String
        Try
            If (pcriterio.Equals("")) Or (pcriterio Is Nothing) Then
                listaEmpleados = listarEmpleados()
            Else
                sql = "SELECT * "
                sql &= " FROM t_empleado"
                sql &= " WHERE nombre LIKE '" & pcriterio & "%' OR identificacion LIKE '" & pcriterio & "%' "
                sql &= " ORDER BY nombre"

                cnx = GLOBAL_ACCESS.getConnection()
                dr = GLOBAL_ACCESS.executeSQL(sql, cnx)
                With dr
                    While .Read
                        listaEmpleados.Add(cargarEmpleado(dr))
                    End While
                End With
                cnx.Close()
            End If
        Catch ex As Exception
            Throw New Exception("Error al tratar de conectar con la base de datos.")
        End Try

        Return listaEmpleados
    End Function

    ''' <summary>
    ''' Lista todos los Empleados registrados registrados en la base de datos.
    ''' </summary>
    ''' <returns>Un List(Of Empleado)</returns>
    ''' <exception cref="SqlClient.SqlException">Error con la base de datos</exception>
    Public Shared Function listarEmpleados() As List(Of Empleado)
        Dim cnx As IDbConnection
        Dim dr As IDataReader
        Dim listaEmpleados As New List(Of Empleado)
        Dim sql As String

        sql = "SELECT * FROM t_empleado ORDER BY nombre"

        Try
            cnx = GLOBAL_ACCESS.getConnection()
            dr = GLOBAL_ACCESS.executeSQL(sql, cnx)
            With dr
                While .Read
                    listaEmpleados.Add(cargarEmpleado(dr))
                End While
            End With
            cnx.Close()

        Catch ex As SqlClient.SqlException
            Throw New Exception("Error al tratar de conectar con la base de datos.")
        End Try
        Return listaEmpleados
    End Function


    ''' <summary>
    ''' Ayuda a la persistencia a cargar los empleados.
    ''' </summary>
    ''' <param name="dr">Resultado de la sentencia Sql</param>
    ''' <returns>Un objeto Empleado</returns>
    Private Shared Function cargarEmpleado(ByVal dr As IDataReader) As Empleado
        Dim objEmpleado As Empleado = Nothing
        With dr
            objEmpleado = New Empleado(CInt(dr.Item("id")), CType((dr.Item("identificacion")), String), CType((dr.Item("nombre")), String), _
                                       CType((dr.Item("apellidos")), String), CType((dr.Item("telefono")), String), CType((dr.Item("direccion")), String), _
                                       CType((dr.Item("puesto")), String))
        End With
        Return objEmpleado
    End Function
End Class
