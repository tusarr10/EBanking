Public Class clsEmpTrnsf
    Private mEmployeeID As String        '1
    Private mdate As String       '2
    Private mFrom As String     '3  
    Private mTO As String       '4
    Private mRemark As String       '5
    Private officecode As String         '6
    Private officeName As String        '7
    Private name As String            '8
    Private designation As String        '9
    Private post As String          '10
    Private other As String     '11
    Public Property mother() As String
        Get
            Return other
        End Get
        Set(ByVal value As String)
            other = value
        End Set
    End Property
    Public Property mpost() As String
        Get
            Return post
        End Get
        Set(ByVal value As String)
            post = value
        End Set
    End Property
    Public Property mdesignation() As String
        Get
            Return designation
        End Get
        Set(ByVal value As String)
            designation = value
        End Set
    End Property
    Public Property mname() As String
        Get
            Return name
        End Get
        Set(ByVal value As String)
            name = value
        End Set
    End Property
    Public Property mOfficename() As String
        Get
            Return officeName
        End Get
        Set(ByVal value As String)
            officeName = value
        End Set
    End Property
    Public Property mofficecode() As String
        Get
            Return officecode
        End Get
        Set(ByVal value As String)
            officecode = value
        End Set
    End Property

    Public Property MEmployeeID1 As String
        Get
            Return mEmployeeID
        End Get
        Set(value As String)
            mEmployeeID = value
        End Set
    End Property

    Public Property Mdate1 As String
        Get
            Return mdate
        End Get
        Set(value As String)
            mdate = value
        End Set
    End Property

    Public Property MFrom1 As String
        Get
            Return mFrom
        End Get
        Set(value As String)
            mFrom = value
        End Set
    End Property

    Public Property MTO1 As String
        Get
            Return mTO
        End Get
        Set(value As String)
            mTO = value
        End Set
    End Property

    Public Property MRemark1 As String
        Get
            Return mRemark
        End Get
        Set(value As String)
            mRemark = value
        End Set
    End Property
End Class
