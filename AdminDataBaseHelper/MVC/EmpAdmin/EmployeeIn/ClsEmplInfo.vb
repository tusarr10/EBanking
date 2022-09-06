''' <summary>
''' All Employee Information
''' Personal Data Store Here
''' 
''' </summary>

Public Class ClsEmplInfo

    Private UserId As String
    Private EmployeeId As String
    Private Name As String
    Private Father As String
    Private DOB As String
    Private Gender As String
    Private Address As String
    Private Address2 As String
    Private Mobile As String
    Private Mobile2 As String
    Private Email As String
    Private Blood As String
    Private Aadhaar As String
    Private Pan As String
    Private Pran As String ' 15
    Private IdRemark As String
    Public Property mpran1() As String
        Get
            Return Pran
        End Get
        Set(ByVal value As String)
            Pran = value
        End Set
    End Property


    Public Property MUserId1 As String
        Get
            Return UserId
        End Get
        Set(value As String)
            UserId = value
        End Set
    End Property

    Public Property MEmployeeId1 As String
        Get
            Return EmployeeId
        End Get
        Set(value As String)
            EmployeeId = value
        End Set
    End Property

    Public Property MName1 As String
        Get
            Return Name
        End Get
        Set(value As String)
            Name = value
        End Set
    End Property

    Public Property MFather1 As String
        Get
            Return Father
        End Get
        Set(value As String)
            Father = value
        End Set
    End Property

    Public Property MDOB1 As String
        Get
            Return DOB
        End Get
        Set(value As String)
            DOB = value
        End Set
    End Property

    Public Property MGender1 As String
        Get
            Return Gender
        End Get
        Set(value As String)
            Gender = value
        End Set
    End Property

    Public Property MAddress1 As String
        Get
            Return Address
        End Get
        Set(value As String)
            Address = value
        End Set
    End Property

    Public Property MAddress21 As String
        Get
            Return Address2
        End Get
        Set(value As String)
            Address2 = value
        End Set
    End Property

    Public Property MMobile2 As String
        Get
            Return Mobile
        End Get
        Set(value As String)
            Mobile = value
        End Set
    End Property

    Public Property MMobile11 As String
        Get
            Return Mobile2
        End Get
        Set(value As String)
            Mobile2 = value
        End Set
    End Property

    Public Property MEmail1 As String
        Get
            Return Email
        End Get
        Set(value As String)
            Email = value
        End Set
    End Property

    Public Property MBlood1 As String
        Get
            Return Blood
        End Get
        Set(value As String)
            Blood = value
        End Set
    End Property

    Public Property Maadhar1 As String
        Get
            Return Aadhaar
        End Get
        Set(value As String)
            Aadhaar = value
        End Set
    End Property

    Public Property MPan1 As String
        Get
            Return Pan
        End Get
        Set(value As String)
            Pan = value
        End Set
    End Property

    Public Property MIdRemark1 As String
        Get
            Return IdRemark
        End Get
        Set(value As String)
            IdRemark = value
        End Set
    End Property
End Class
