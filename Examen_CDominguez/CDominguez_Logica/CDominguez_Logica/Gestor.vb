
''' <summary>
''' Clase Gestor
''' </summary>
''' <remarks>
''' Creado por: Carlos Domínguez Lara
''' Fecha: 25/11/2010 8:56 a.m
''' Modificado: 25/11/2010 8:56 a.m
''' </remarks>  
Public Class Gestor

#Region "EMPLEADOS"

    ''' <summary>
    ''' Registra un nuevo empleado al sistema.
    ''' </summary>
    ''' <param name="pidentificacion">Cédula del Empleado</param>
    ''' <param name="pnombre">Nombre del Empleado</param>
    ''' <param name="papellidos">Apellidos del Empleado</param>
    ''' <param name="ptelefono">Teléfono del Empleado</param>
    ''' <param name="pdireccion">Dirección del Empleado</param>
    ''' <param name="ppuesto">Puesto que se le asignara al empleado</param>
    Public Sub registrarEmpleado(ByVal pidentificacion As String, ByVal pnombre As String, ByVal papellidos As String, ByVal ptelefono As String, _
                                ByVal pcodigoDep As Integer, ByVal pdireccion As String, ByVal ppuesto As String)
        Try
            PersistenciaEmpleado.registrar(pidentificacion, pnombre, papellidos, ptelefono, pcodigoDep, pdireccion, ppuesto)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Modifica los datos de un empleado.
    ''' </summary>
    ''' <param name="pid">Id del empleado</param>
    ''' <param name="pidentificacion">Nueva Cédula del Empleado</param>
    ''' <param name="pnombre">Nueva Nombre del Empleado</param>
    ''' <param name="papellidos">Nueva Apellidos del Empleado</param>
    ''' <param name="ptelefono">Nueva Teléfono del Empleado</param>
    ''' <param name="pdireccion">Nueva Dirección del Empleado</param>
    ''' <param name="ppuesto">Nueva Puesto que se le asignara al empleado</param>
    Public Sub modificarEmpleado(ByVal pid As Integer, ByVal pidentificacion As String, ByVal pnombre As String, ByVal papellidos As String, ByVal ptelefono As String, _
                                ByVal pcodigoDep As Integer, ByVal pdireccion As String, ByVal ppuesto As String)
        Dim objEmpleado As Empleado = PersistenciaEmpleado.buscarPorId(pid)
        Dim objDepartamento As Departamento = PersistenciaDepartamento.buscarPorCodigo(pcodigoDep)
        objEmpleado.Identificacion = pidentificacion
        objEmpleado.Nombre = pnombre
        objEmpleado.Apellidos = papellidos
        objEmpleado.Telefono = ptelefono
        objEmpleado.Departamento = objDepartamento
        objEmpleado.Direccion = pdireccion
        objEmpleado.Puesto = ppuesto
        Try
            PersistenciaEmpleado.modificar(objEmpleado)
        Catch ex As Exception
            Throw New Exception
        End Try

    End Sub

    ''' <summary>
    ''' Elimina un usuario del sistema.
    ''' </summary>
    ''' <param name="pid">
    ''' Es la identificación que se le pone al usuario en la base de datos..
    ''' </param>
    Public Sub eliminarEmpleado(ByVal pid As Integer)
        Dim objEmpleado As Empleado = PersistenciaEmpleado.buscarPorId(pid)
        Try
            PersistenciaEmpleado.eliminar(objEmpleado)
        Catch ex As Exception
            Throw New Exception
        End Try

    End Sub

    ''' <summary>
    ''' Obtiene los datos que se mostraran en la interfaz de un empleado
    ''' </summary>
    ''' <param name="pidEmpleado">
    ''' Es el id que se le pone al empleado en la base de datos.
    ''' </param>
    ''' <returns>Un Array de String</returns>
    Public Function obtenerDatosEmpleado(ByVal pidEmpleado As Integer) As Array
        Dim objEmpleado As Empleado = PersistenciaEmpleado.buscarPorId(pidEmpleado)
        Dim datosEmpleado(8) As String

        datosEmpleado(0) = objEmpleado.Id
        datosEmpleado(1) = objEmpleado.Identificacion
        datosEmpleado(2) = objEmpleado.Nombre
        datosEmpleado(3) = objEmpleado.Apellidos
        datosEmpleado(4) = objEmpleado.Telefono
        datosEmpleado(5) = objEmpleado.Departamento.Nombre
        datosEmpleado(6) = objEmpleado.Direccion
        datosEmpleado(7) = objEmpleado.Puesto

        Return datosEmpleado
    End Function

    ''' <summary>
    ''' Busca usuarios por aproximacion de: Nombre, Identificacion 
    ''' </summary>
    ''' <param name="pcriterio">
    ''' Es el criterio de busqueda que va utilizar el metodo para encotrar los Empleados, 
    ''' puede ser por: Nombre o Identificación.
    ''' </param>
    ''' <returns>List(Of Array) con los empleados encontrados</returns>
    Public Function buscarEmpleadosPorCriterio(ByVal pcriterio As String) As List(Of Array)

        Dim listaEmpleados As New List(Of Empleado)
        Dim i As Integer
        Dim objEmpleado As Empleado
        Dim datosEmpleado As New List(Of Array)
        listaEmpleados = PersistenciaEmpleado.buscarPorCriterio(pcriterio)

        For i = 0 To listaEmpleados.Count - 1
            objEmpleado = listaEmpleados(i)
            Dim datosN() As String = {objEmpleado.Id, objEmpleado.Identificacion, objEmpleado.Nombre, _
                                      objEmpleado.Apellidos, objEmpleado.Telefono, objEmpleado.Departamento.Codigo, _
                                      objEmpleado.Direccion, objEmpleado.Puesto}
            datosEmpleado.Add(datosN)
        Next
        Return datosEmpleado
    End Function

#End Region

#Region "DEPARTAMENTOS"
    ''' <summary>
    ''' Carga los departamentos
    ''' </summary>
    ''' <returns name = "datosDepartamento">datosDepartamento</returns>
    ''' <remarks>Creado por: Carlos Domínguez, Creado: 25/11/2010 8:56 a.m, Modificado:  </remarks>
    Public Function cargarDepartamentos() As List(Of Array)

        Dim listDepartamento As List(Of Departamento) = Nothing
        listDepartamento = PersistenciaDepartamento.listarDepartamentos()

        Dim datosDepartamento As New List(Of Array)
        Dim objDepartamento As Departamento

        For Each objDepartamento In listDepartamento
            With objDepartamento
                Dim datosN() As String = {.Codigo, .Nombre}
                datosDepartamento.Add(datosN)
            End With
        Next
        Return datosDepartamento
    End Function

#End Region

End Class
