''' <summary>
''' Clase Empleado
''' </summary>
''' <remarks>
''' Creado por: Carlos Domínguez Lara
''' Fecha: 25/11/2010 8:56 a.m
''' Modificado: 25/11/2010 8:56 a.m
''' </remarks> 
Public Class Empleado

#Region "Atributos privados"
    'Atributos de la clase Empleado
    Private _id As Integer
    Private _identificacion As String
    Private _nombre As String
    Private _apellidos As String
    Private _telefono As String
    Private _departamento As Departamento
    Private _direccion As String
    Private _puesto As String
#End Region

#Region "Constructor"
    ''' <summary>
    ''' Constructor de la clase Empleado
    ''' </summary>
    ''' <param name="pid">Id que se asigna al empleado en la base de datos</param>
    ''' <param name="pidentificacion">Cédula del Empleado</param>
    ''' <param name="pnombre">Nombre del Empleado</param>
    ''' <param name="papellidos">Apellidos del Empleado</param>
    ''' <param name="ptelefono">Teléfono del Empleado</param>
    ''' <param name="pdireccion">Dirección del Empleado</param>
    ''' <param name="ppuesto">Puesto que se le asignara al empleado</param>
    Sub New(ByVal pid As Integer, ByVal pidentificacion As String, ByVal pnombre As String, ByVal papellidos As String, _
            ByVal ptelefono As String, ByVal pdireccion As String, ByVal ppuesto As String)
        Id = pid
        Identificacion = pidentificacion
        Nombre = pnombre
        Apellidos = papellidos
        Telefono = ptelefono
        Direccion = pdireccion
        Puesto = ppuesto
        Departamento = Nothing
    End Sub
#End Region

#Region "Propiedades"

    ''' <summary>
    ''' Propiedad del Id
    ''' </summary>
    ''' <value>Id</value>
    ''' <returns>id del Empleado: Integer</returns>
    Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal pid As Integer)
            _id = pid
        End Set
    End Property

    ''' <summary>
    ''' Propiedad para la identificación
    ''' </summary>
    ''' <value>identificación</value>
    ''' <returns>identificación del Empleado: String</returns>
    Property Identificacion() As String
        Get
            Return _identificacion
        End Get
        Set(ByVal pidentificacion As String)
            _identificacion = pidentificacion
        End Set
    End Property

    ''' <summary>
    ''' Propiedad del nombre
    ''' </summary>
    ''' <value>Nombre</value>
    ''' <returns>Nombre del Empleado: String</returns>
    Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal pnombre As String)
            _nombre = pnombre
        End Set
    End Property

    ''' <summary>
    ''' Propiedad para los apellidos
    ''' </summary>
    ''' <value>apellidos</value>
    ''' <returns>Apellidos del Empleado: String</returns>
    Property Apellidos() As String
        Get
            Return _apellidos

        End Get
        Set(ByVal papellidos As String)
            _apellidos = papellidos
        End Set
    End Property

    ''' <summary>
    ''' Propiedad para el teléfono
    ''' </summary>
    ''' <value>Teléfono</value>
    ''' <returns>Teléfono del Empleado: String</returns>
    Property Telefono() As String
        Get
            Return _telefono

        End Get
        Set(ByVal ptelefono As String)
            _telefono = ptelefono
        End Set
    End Property

    ''' <summary>
    ''' Propiedad para el departamento al que pertenece el Empleado
    ''' </summary>
    ''' <value>Departamento</value>
    ''' <returns>Departamento del Empleado: Departamento</returns>
    Property Departamento() As Departamento
        Get
            If _departamento Is Nothing Then
                _departamento = PersistenciaDepartamento.buscarPorIdEmpleado(Id)
            End If
            Return _departamento
        End Get
        Set(ByVal value As Departamento)
            _departamento = value
        End Set
    End Property

    ''' <summary>
    ''' Propiedad para la dirección
    ''' </summary>
    ''' <value>Dirección</value>
    ''' <returns>Dirección del Empleado: String</returns>
    Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal pdireccion As String)
            _direccion = pdireccion
        End Set
    End Property

    ''' <summary>
    ''' Propiedad para el puesto
    ''' </summary>
    ''' <value>Puesto</value>
    ''' <returns>Puesto del Empleado: String</returns>
    Property Puesto() As String
        Get
            Return _puesto
        End Get
        Set(ByVal ppuesto As String)
            _puesto = ppuesto
        End Set
    End Property
#End Region
End Class
