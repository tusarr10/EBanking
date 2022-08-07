Public Class clsEmpTrnsf
    Private mEmployeeID As String
    Private mdate As String
    Private mFrom As String
    Private mTO As String
    Private mRemark As String

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
