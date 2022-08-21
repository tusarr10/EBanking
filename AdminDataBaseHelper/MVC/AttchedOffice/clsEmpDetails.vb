''' <summary>
''' Here data come from office Info
'''                 EmployeeInfo
'''                 and present Employee status in Deportment 
'''                 date of join ret and licences
''' </summary>
Public Class clsEmpDetails
    Private mofficeid As String
    Private memployeeId As String
    Private mDateOfPosting As String ' in current post
    Private mDateofJoin As String   ' in India Post
    Private mDateofRet As String
    Private mEmployeeStatus As String   ' Acctive or terminate
    Private post As String
    Private trcalvl As String
    Private orgPost As String
    Private currentPlace As String
    Private currentPost As String
    Private Remarks As String

    Private mIsUidai As String
    Private mIsIPPB As String
    Private mIsCSC As String
    Private mIsPLI As String  '16


    Public Property remarks1() As String
        Get
            Return Remarks
        End Get
        Set(ByVal value As String)
            Remarks = value
        End Set
    End Property
    Public Property currentPost1() As String
        Get
            Return currentPost
        End Get
        Set(ByVal value As String)
            currentPost = value
        End Set
    End Property
    Public Property CurrentPlace1() As String
        Get
            Return currentPlace
        End Get
        Set(ByVal value As String)
            currentPlace = value
        End Set
    End Property
    Public Property orgPost1() As String
        Get
            Return orgPost
        End Get
        Set(ByVal value As String)
            orgPost = value
        End Set
    End Property
    Public Property trcalvl1() As String
        Get
            Return trcalvl
        End Get
        Set(ByVal value As String)
            trcalvl = value
        End Set
    End Property
    Public Property post1() As String
        Get
            Return post
        End Get
        Set(ByVal value As String)
            post = value
        End Set
    End Property
    Public Property Mofficeid1 As String
        Get
            Return mofficeid
        End Get
        Set(value As String)
            mofficeid = value
        End Set
    End Property

    Public Property MemployeeId1 As String
        Get
            Return memployeeId
        End Get
        Set(value As String)
            memployeeId = value
        End Set
    End Property

    Public Property MDateofJoin1 As String
        Get
            Return mDateofJoin
        End Get
        Set(value As String)
            mDateofJoin = value
        End Set
    End Property

    Public Property MDateofRet1 As String
        Get
            Return mDateofRet
        End Get
        Set(value As String)
            mDateofRet = value
        End Set
    End Property

    Public Property MEmployeeStatus1 As String
        Get
            Return mEmployeeStatus
        End Get
        Set(value As String)
            mEmployeeStatus = value
        End Set
    End Property

    Public Property MIsUidai1 As String
        Get
            Return mIsUidai
        End Get
        Set(value As String)
            mIsUidai = value
        End Set
    End Property

    Public Property MIsIPPB1 As String
        Get
            Return mIsIPPB
        End Get
        Set(value As String)
            mIsIPPB = value
        End Set
    End Property

    Public Property MIsCSC1 As String
        Get
            Return mIsCSC
        End Get
        Set(value As String)
            mIsCSC = value
        End Set
    End Property

    Public Property MIsPLI1 As String
        Get
            Return mIsPLI
        End Get
        Set(value As String)
            mIsPLI = value
        End Set
    End Property

    Public Property MDateOfPosting1 As String
        Get
            Return mDateOfPosting
        End Get
        Set(value As String)
            mDateOfPosting = value
        End Set
    End Property
End Class
