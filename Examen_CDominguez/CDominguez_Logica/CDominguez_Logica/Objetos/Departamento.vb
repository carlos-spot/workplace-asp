''' <summary>
''' Clase Departamento
''' </summary>
''' <remarks>
''' Creado por: Carlos Domínguez Lara
''' Fecha: 25/11/2010 8:56 a.m
''' Modificado: 25/11/2010 8:56 a.m
''' </remarks> 
Public Class Departamento

#Region "Atributos privados"
    'Atributos de la clase Departamento
    Private _codigo As Integer
    Private _nombre As String
    Private _encargado As Empleado
#End Region

#Region "Constructor"
    ''' <summary>
    ''' Constructor de la clase Departamento
    ''' </summary>
    Sub New(ByVal pcodigo As Integer, ByVal pnombre As String)
        Codigo = pcodigo
        Nombre = pnombre
        Encargado = Nothing
    End Sub
#End Region

    ''' <summary>
    ''' Propiedad del Codigo
    ''' </summary>
    ''' <value>Codigo</value>
    ''' <returns>Codigo del Departamento: Integer</returns>
    Property Codigo() As Integer
        Get
            Return _codigo
        End Get
        Set(ByVal pcodigo As Integer)
            _codigo = pcodigo
        End Set
    End Property

    ''' <summary>
    ''' Propiedad del nombre
    ''' </summary>
    ''' <value>Nombre</value>
    ''' <returns>Nombre del departamento: String</returns>
    Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal pnombre As String)
            _nombre = pnombre
        End Set
    End Property

    ''' <summary>
    ''' Propiedad para el Encargado
    ''' </summary>
    ''' <value>Encargado</value>
    ''' <returns>Encargado para el Departamento: Empleado</returns>
    Property Encargado() As Empleado
        Get
            If _encargado Is Nothing Then
                _encargado = PersistenciaEmpleado.buscarPorCodDep(Codigo)
            End If
            Return _encargado
        End Get
        Set(ByVal pencargado As Empleado)
            _encargado = pencargado
        End Set
    End Property

End Class
