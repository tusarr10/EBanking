Public Class accOperateClass
    Private m_accountnumber As String

    Public Property accountnumber() As String
        Get
            Return m_accountnumber
        End Get
        Set(ByVal value As String)
            m_accountnumber = value
        End Set
    End Property

    Private m_operatemode As String

    Public Property accountoperatemode() As String
        Get
            Return m_operatemode
        End Get
        Set(ByVal value As String)
            m_operatemode = value
        End Set
    End Property

    Private m_guardianname As String

    Public Property guardianname() As String
        Get
            Return m_guardianname
        End Get
        Set(ByVal value As String)
            m_guardianname = value
        End Set
    End Property

    Private m_relation As String

    Public Property relation() As String
        Get
            Return m_relation
        End Get
        Set(ByVal value As String)
            m_relation = value
        End Set
    End Property

End Class