Public Class clsvillege
    Private sn As String
    Public Property msn() As String
        Get
            Return sn
        End Get
        Set(ByVal value As String)
            sn = value
        End Set
    End Property
    Private officecode As String
    Public Property mofficecode() As String
        Get
            Return officecode
        End Get
        Set(ByVal value As String)
            officecode = value
        End Set
    End Property
    Private villegename As String
    Public Property nvillegename() As String
        Get
            Return villegename
        End Get
        Set(ByVal value As String)
            villegename = value
        End Set
    End Property
    Private totalpopulation As String
    Public Property mtotalpopulation() As String
        Get
            Return totalpopulation
        End Get
        Set(ByVal value As String)
            totalpopulation = value
        End Set
    End Property
    Private accountOpen As String
    Public Property mAccountOpen() As String
        Get
            Return accountOpen
        End Get
        Set(ByVal value As String)
            accountOpen = value
        End Set
    End Property
    Private fiveStar As String
    Public Property mFiveStar() As String
        Get
            Return fiveStar
        End Get
        Set(ByVal value As String)
            fiveStar = value
        End Set
    End Property
    Private ssg As String
    Public Property mssg() As String
        Get
            Return ssg
        End Get
        Set(ByVal value As String)
            ssg = value
        End Set
    End Property
    Private sbg As String
    Public Property msbg() As String
        Get
            Return sbg
        End Get
        Set(ByVal value As String)
            sbg = value
        End Set
    End Property
End Class
