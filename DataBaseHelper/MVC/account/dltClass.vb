Public Class dltClass
    Private m_accountnumber As String

    Public Property accountnumber() As String
        Get
            Return m_accountnumber
        End Get
        Set(ByVal value As String)
            m_accountnumber = value
        End Set
    End Property

    Private m_accountbalance As String

    Public Property accountbalance() As String
        Get
            Return m_accountbalance
        End Get
        Set(ByVal value As String)
            m_accountbalance = value
        End Set
    End Property

    Private m_dlt As String

    Public Property dlt() As String
        Get
            Return m_dlt
        End Get
        Set(ByVal value As String)
            m_dlt = value
        End Set
    End Property

    Private m_dlt2 As String

    Public Property dlt2() As String
        Get
            Return m_dlt2
        End Get
        Set(ByVal value As String)
            m_dlt2 = value
        End Set
    End Property

End Class