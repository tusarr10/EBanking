Public Class EmpServices

    Private uidaiid As String
    Private ippbid As String
    Private pliid As String
    Private cscid As String
    Private employeeid As String
    Public Property memployeeid() As String
        Get
            Return employeeid
        End Get
        Set(ByVal value As String)
            employeeid = value
        End Set
    End Property
    Public Property mcscid() As String
        Get
            Return cscid
        End Get
        Set(ByVal value As String)
            cscid = value
        End Set
    End Property
    Public Property mpli() As String
        Get
            Return pliid
        End Get
        Set(ByVal value As String)
            pliid = value
        End Set
    End Property
    Public Property mippbid() As String
        Get
            Return ippbid
        End Get
        Set(ByVal value As String)
            ippbid = value
        End Set
    End Property
    Public Property muidaiid() As String
        Get
            Return uidaiid
        End Get
        Set(ByVal value As String)
            uidaiid = value
        End Set
    End Property

End Class
