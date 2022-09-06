Public Class ClassStaff
    Private _mofficeId As String
    Private _mBoname As String
    Private _mBPM As String
    Private _mMD As String
    Private _mMC As String
    Private _mABPM As String
    Private _mABPM1 As String
    Private _mABPM2 As String
    Private _mRemarks As String

    Public Property MofficeId As String
        Get
            Return _mofficeId
        End Get
        Set(value As String)
            _mofficeId = value
        End Set
    End Property

    Public Property MBoname As String
        Get
            Return _mBoname
        End Get
        Set(value As String)
            _mBoname = value
        End Set
    End Property

    Public Property MBPM As String
        Get
            Return _mBPM
        End Get
        Set(value As String)
            _mBPM = value
        End Set
    End Property

    Public Property MMD As String
        Get
            Return _mMD
        End Get
        Set(value As String)
            _mMD = value
        End Set
    End Property

    Public Property MMC As String
        Get
            Return _mMC
        End Get
        Set(value As String)
            _mMC = value
        End Set
    End Property

    Public Property MABPM As String
        Get
            Return _mABPM
        End Get
        Set(value As String)
            _mABPM = value
        End Set
    End Property

    Public Property MABPM1 As String
        Get
            Return _mABPM1
        End Get
        Set(value As String)
            _mABPM1 = value
        End Set
    End Property

    Public Property MABPM2 As String
        Get
            Return _mABPM2
        End Get
        Set(value As String)
            _mABPM2 = value
        End Set
    End Property

    Public Property MRemarks As String
        Get
            Return _mRemarks
        End Get
        Set(value As String)
            _mRemarks = value
        End Set
    End Property
End Class
