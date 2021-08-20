Public Class liveAccountClass

    Private m_accountnumber As String

    Public Property accountnumber() As String
        Get
            Return m_accountnumber
        End Get
        Set(ByVal value As String)
            m_accountnumber = value
        End Set
    End Property

    Private m_cif As String

    Public Property cif() As String
        Get
            Return m_cif
        End Get
        Set(ByVal value As String)
            m_cif = value
        End Set
    End Property

    Private m_name As String

    Public Property n_ame() As String
        Get
            Return m_name
        End Get
        Set(ByVal value As String)
            m_name = value
        End Set
    End Property

    Private m_producttype As String

    Public Property producttype() As String
        Get
            Return m_producttype
        End Get
        Set(ByVal value As String)
            m_producttype = value
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

    Private m_acctype As String

    Public Property acctype() As String
        Get
            Return m_acctype
        End Get
        Set(ByVal value As String)
            m_acctype = value
        End Set
    End Property

    Private m_jointname As String

    Public Property jointname() As String
        Get
            Return m_jointname
        End Get
        Set(ByVal value As String)
            m_jointname = value
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

    Private m_balance As String

    Public Property balance() As String
        Get
            Return m_balance
        End Get
        Set(ByVal value As String)
            m_balance = value
        End Set
    End Property

    Private m_status As String

    Public Property status() As String
        Get
            Return m_status
        End Get
        Set(ByVal value As String)
            m_status = value
        End Set
    End Property

End Class