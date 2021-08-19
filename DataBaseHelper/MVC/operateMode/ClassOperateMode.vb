Public Class ClassOperateMode
    Private accountnumber As String
    Private accountoperatemode As String
    Private guardianname As String
    Private relation As String

    Property Accountnumber1 As String
        Get
            Return Me.accountnumber
        End Get
        Set(ByVal value As String)
            Me.accountnumber = value
        End Set
    End Property

    Property Accountoperatemode1 As String
        Get
            Return Me.accountoperatemode
        End Get
        Set(ByVal value As String)
            Me.accountoperatemode = value
        End Set
    End Property

    Property Guardianname1 As String
        Get
            Return Me.guardianname
        End Get
        Set(ByVal value As String)
            Me.guardianname = value
        End Set
    End Property

    Property Relation1 As String
        Get
            Return Me.relation
        End Get
        Set(ByVal value As String)
            Me.relation = value
        End Set
    End Property

End Class
