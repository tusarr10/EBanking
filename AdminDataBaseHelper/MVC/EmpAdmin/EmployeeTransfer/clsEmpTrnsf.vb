Public Class clsEmpTrnsf
    Private EmpId As String        '1
    Private mDate As String       '2
    Private mFrom As String     '3  
    Private mTO As String       '4
    Private mRemarks As String       '5
    Private officeCode As String         '6
    Private officeName As String        '7
    Private Name As String            '8
    Private Designation As String        '9
    Private postt As String          '10
    Private other As String     '11
    Private mmemo As String
    Public Property mmemo1() As String
        Get
            Return mmemo
        End Get
        Set(ByVal value As String)
            mmemo = value
        End Set
    End Property
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
            Return postt
        End Get
        Set(ByVal value As String)
            postt = value
        End Set
    End Property
    Public Property mdesignation() As String
        Get
            Return Designation
        End Get
        Set(ByVal value As String)
            Designation = value
        End Set
    End Property
    Public Property mname() As String
        Get
            Return Name
        End Get
        Set(ByVal value As String)
            Name = value
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
            Return officeCode
        End Get
        Set(ByVal value As String)
            officeCode = value
        End Set
    End Property

    Public Property MEmployeeID1 As String
        Get
            Return EmpId
        End Get
        Set(value As String)
            EmpId = value
        End Set
    End Property

    Public Property Mdate1 As String
        Get
            Return mDate
        End Get
        Set(value As String)
            mDate = value
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
            Return mRemarks
        End Get
        Set(value As String)
            mRemarks = value
        End Set
    End Property
End Class
