Imports Microsoft.VisualBasic
Imports SSLogica

Public Class ClsCastCadenaUsuario
    Private _gestor As New Gestor

#Region "Atributos privados"
    'Atributos de la clase Producto
    Private _id As Integer
    Private _cedula As String
    Private _nombre As String
    Private _primerApellido As String
    Private _segundoApellido As String
    Private _nombreUsuario As String
    Private _rol As String
#End Region

#Region "Constructor"
    ''' <summary>
    ''' Constructor de la clase Usuario
    ''' </summary>
    ''' <param name="pcedula">Cédula del usuario</param>
    ''' <param name="pnombre">Nombre del usuario</param>
    ''' <param name="pnombreUsuario">Nombre usuario que se le asignara para ser reconocido en la aplicación</param>
    ''' <param name="pprimerApellido">Primer apellido del usuario</param>
    ''' <param name="psegundoApellido">Segundo apellido del usuario</param>
    Sub New(ByVal pid As Integer, ByVal pcedula As String, ByVal pnombre As String, _
            ByVal pprimerApellido As String, ByVal psegundoApellido As String, _
            ByVal pnombreUsuario As String, ByVal prol As String)
        Id = pid
        Cedula = pcedula
        Nombre = pnombre
        PrimerApellido = pprimerApellido
        SegundoApellido = psegundoApellido
        NombreUsuario = pnombreUsuario
        Rol = prol
    End Sub
#End Region

#Region "Propiedades"

    ''' <summary>
    ''' Propiedad del Id
    ''' </summary>
    ''' <value>Id</value>
    ''' <returns>id del Usuario: Integer</returns>
    Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal pid As Integer)
            _id = pid
        End Set
    End Property

    ''' <summary>
    ''' Propiedad de la cédula
    ''' </summary>
    ''' <value>Cedula</value>
    ''' <returns>Cedula del Usuario: String</returns>
    Property Cedula() As String
        Get
            Return _cedula
        End Get
        Set(ByVal pcedula As String)
            _cedula = pcedula
        End Set
    End Property

    ''' <summary>
    ''' Propiedad del nombre
    ''' </summary>
    ''' <value>Nombre</value>
    ''' <returns>Cedula del Usuario: String</returns>
    Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal pnombre As String)
            _nombre = pnombre
        End Set
    End Property

    ''' <summary>
    ''' Propiedad para el primer apellido
    ''' </summary>
    ''' <value>PrimerApellido</value>
    ''' <returns>Primer apellido del Usuario: String</returns>
    Property PrimerApellido() As String
        Get
            Return _primerApellido

        End Get
        Set(ByVal pprimerApellido As String)
            _primerApellido = pprimerApellido
        End Set
    End Property

    ''' <summary>
    ''' Propiedad para el primer apellido
    ''' </summary>
    ''' <value>PrimerApellido</value>
    ''' <returns>Primer apellido del Usuario: String</returns>
    Property SegundoApellido() As String
        Get
            Return _segundoApellido

        End Get
        Set(ByVal psegundoApellido As String)
            _segundoApellido = psegundoApellido

        End Set
    End Property

    ''' <summary>
    ''' Propiedad para el nommbre de usuario
    ''' </summary>
    ''' <value>NombreUsuario</value>
    ''' <returns>Nombre de usuario: String</returns>
    Property NombreUsuario() As String
        Get
            Return _nombreUsuario

        End Get
        Set(ByVal pnombreUsuario As String)
            _nombreUsuario = pnombreUsuario
        End Set
    End Property

    ''' <summary>
    ''' Propiedad para el rol que se le asigno al usuario
    ''' </summary>
    ''' <value>Rol</value>
    ''' <returns>Rol del usuario: Rol</returns>
    Property Rol() As String
        Get
            Return _rol
        End Get
        Set(ByVal value As String)
            _rol = value

        End Set
    End Property

#End Region
End Class
