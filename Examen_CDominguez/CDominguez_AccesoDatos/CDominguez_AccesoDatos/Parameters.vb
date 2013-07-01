Public Class Parameters

#Region "Atributos privados"
    'Atributos de la clase Parameters
    Private _name As String
    Private _data As Object
#End Region

#Region "class constructors"
    ''' <summary>
    ''' Constructor sin parametros
    ''' </summary>
    Sub New()

    End Sub

    ''' <summary>
    ''' Constructor con parametros
    ''' </summary>
    ''' <param name="pName">Nombre del parametro</param>
    ''' <param name="pData">Valor del parametro</param>
    Sub New(ByVal pName As String, ByVal pData As Object)
        Name = pName
        Data = pData
    End Sub


#End Region

#Region "class properties"

    ''' <summary>
    ''' Propiedad para el nombre del parametro
    ''' </summary>
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    ''' <summary>
    ''' Valor del parametro
    ''' </summary>
    Public Property Data() As Object
        Get
            Return _data
        End Get
        Set(ByVal value As Object)
            _data = value
        End Set
    End Property

#End Region

End Class
