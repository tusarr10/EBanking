Public Class sbJournalClass

    Private m_accountnumber As String

    Public Property accountnumber() As String
        Get
            Return m_accountnumber
        End Get
        Set(ByVal value As String)
            m_accountnumber = value
        End Set
    End Property

    Private m_depositername As String

    Public Property depositername() As String
        Get
            Return m_depositername
        End Get
        Set(ByVal value As String)
            m_depositername = value
        End Set
    End Property

    Private m_date As String

    Public Property da_te() As String
        Get
            Return m_date
        End Get
        Set(ByVal value As String)
            m_date = value
        End Set
    End Property

    Private m_bbt As String

    Public Property bbt() As String
        Get
            Return m_bbt
        End Get
        Set(ByVal value As String)
            m_bbt = value
        End Set
    End Property

    Private m_transctiontype As String

    Public Property transctiontype() As String
        Get
            Return m_transctiontype
        End Get
        Set(ByVal value As String)
            m_transctiontype = value
        End Set
    End Property

    Private m_amount As String

    Public Property amount() As String
        Get
            Return m_amount
        End Get
        Set(ByVal value As String)
            m_amount = value
        End Set
    End Property

    Private m_bat As String

    Public Property bat() As String
        Get
            Return m_bat
        End Get
        Set(ByVal value As String)
            m_bat = value
        End Set
    End Property

    Private m_trid As String

    Public Property trid() As String
        Get
            Return m_trid
        End Get
        Set(ByVal value As String)
            m_trid = value
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

    Private moffice As String

    Public Property office() As String
        Get
            Return moffice
        End Get
        Set(ByVal value As String)
            moffice = value
        End Set
    End Property

    Private m_user As String

    Public Property u_ser() As String
        Get
            Return m_user
        End Get
        Set(ByVal value As String)
            m_user = value
        End Set
    End Property

    Private m_details As String

    Public Property Details() As String
        Get
            Return m_details
        End Get
        Set(ByVal value As String)
            m_details = value
        End Set
    End Property

End Class