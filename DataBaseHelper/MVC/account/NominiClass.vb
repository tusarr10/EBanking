Public Class NominiClass
    Private m_accountnumber As String

    Public Property accountnumber() As String
        Get
            Return m_accountnumber
        End Get
        Set(ByVal value As String)
            m_accountnumber = value
        End Set
    End Property

    Private m_nominireg As String

    Public Property nominireg() As String
        Get
            Return m_nominireg
        End Get
        Set(ByVal value As String)
            m_nominireg = value
        End Set
    End Property

    Private m_nomininame As String

    Public Property nomininame() As String
        Get
            Return m_nomininame
        End Get
        Set(ByVal value As String)
            m_nomininame = value
        End Set
    End Property

    Private m_nominiage As String

    Public Property nominiage() As String
        Get
            Return m_nominiage
        End Get
        Set(ByVal value As String)
            m_nominiage = value
        End Set
    End Property

    Private m_nominiaddress As String

    Public Property nominiaddress() As String
        Get
            Return m_nominiaddress
        End Get
        Set(ByVal value As String)
            m_nominiaddress = value
        End Set
    End Property

    Private m_nominirelation As String

    Public Property nominirelation() As String
        Get
            Return m_nominirelation
        End Get
        Set(ByVal value As String)
            m_nominirelation = value
        End Set
    End Property

End Class