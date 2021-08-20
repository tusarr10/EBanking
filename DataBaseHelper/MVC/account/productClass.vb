Public Class productClass
    Private m_accountnumber As String

    Public Property accountnumber() As String
        Get
            Return m_accountnumber
        End Get
        Set(ByVal value As String)
            m_accountnumber = value
        End Set
    End Property

    Private m_type As String

    Public Property type() As String
        Get
            Return m_type
        End Get
        Set(ByVal value As String)
            m_type = value
        End Set
    End Property

    Private m_term As String

    Public Property term() As String
        Get
            Return m_term
        End Get
        Set(ByVal value As String)
            m_term = value
        End Set
    End Property

    Private m_vlaue As String

    Public Property v_alue() As String
        Get
            Return m_vlaue
        End Get
        Set(ByVal value As String)
            m_vlaue = value
        End Set
    End Property

End Class