''' <summary>
''' Here data come from office Info
'''                 EmployeeInfo
'''                 and present Employee status in Deportment 
'''                 date of join ret and licences
''' </summary>
Public Class clsEmpDetails
    Private officeId As String
    Private empId As String
    Private DateOfPosting As String ' in current Postt
    Private DateOfJoin As String   ' in India Post
    Private DateOfRet As String
    Private EmpStatus As String   ' Acctive or terminate
    Private Postt As String
    Private trcalvl As String
    Private orgPost As String
    Private currentPlace As String
    Private currentPost As String
    Private Remarks As String

    Private IsUIDAI As String
    Private IsIPPB As String
    Private IsCSC As String
    Private IsPLI As String  '16


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
            Return Postt
        End Get
        Set(ByVal value As String)
            Postt = value
        End Set
    End Property
    Public Property Mofficeid1 As String
        Get
            Return officeId
        End Get
        Set(value As String)
            officeId = value
        End Set
    End Property

    Public Property MemployeeId1 As String
        Get
            Return empId
        End Get
        Set(value As String)
            empId = value
        End Set
    End Property

    Public Property MDateofJoin1 As String
        Get
            Return DateOfJoin
        End Get
        Set(value As String)
            DateOfJoin = value
        End Set
    End Property

    Public Property MDateofRet1 As String
        Get
            Return DateOfRet
        End Get
        Set(value As String)
            DateOfRet = value
        End Set
    End Property

    Public Property MEmployeeStatus1 As String
        Get
            Return EmpStatus
        End Get
        Set(value As String)
            EmpStatus = value
        End Set
    End Property

    Public Property MIsUidai1 As String
        Get
            Return IsUIDAI
        End Get
        Set(value As String)
            IsUIDAI = value
        End Set
    End Property

    Public Property MIsIPPB1 As String
        Get
            Return IsIPPB
        End Get
        Set(value As String)
            IsIPPB = value
        End Set
    End Property

    Public Property MIsCSC1 As String
        Get
            Return IsCSC
        End Get
        Set(value As String)
            IsCSC = value
        End Set
    End Property

    Public Property MIsPLI1 As String
        Get
            Return IsPLI
        End Get
        Set(value As String)
            IsPLI = value
        End Set
    End Property

    Public Property MDateOfPosting1 As String
        Get
            Return DateOfPosting
        End Get
        Set(value As String)
            DateOfPosting = value
        End Set
    End Property
End Class
