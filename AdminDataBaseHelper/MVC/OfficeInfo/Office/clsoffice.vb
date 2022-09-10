Public Class clsoffice

    Private Circle As String                   'circle
    Private Region As String
    Private Division As String
    Private SubDiv As String
    Private Ho As String
    Private SO As String
    Private N_ame As String
    Private Staff As String
    Private officeId As String                 ' Primary Key   
    Private FacilityId As String               'office code
    Private ProfitCenter As String              '    profit centre
    Private Status As String                   'status
    Private Remark As String                  'remark
    Private EstDate As String
    Public Property MEstDate() As String
        Get
            Return EstDate
        End Get
        Set(ByVal value As String)
            EstDate = value
        End Set
    End Property
    Public Property MCircle1 As String
        Get
            Return Circle
        End Get
        Set(value As String)
            Circle = value
        End Set
    End Property

    Public Property MRO1 As String
        Get
            Return Region
        End Get
        Set(value As String)
            Region = value
        End Set
    End Property

    Public Property MDO1 As String
        Get
            Return Division
        End Get
        Set(value As String)
            Division = value
        End Set
    End Property

    Public Property MSDO1 As String
        Get
            Return SubDiv
        End Get
        Set(value As String)
            SubDiv = value
        End Set
    End Property

    Public Property MSO1 As String
        Get
            Return SO
        End Get
        Set(value As String)
            SO = value
        End Set
    End Property

    Public Property MBo1 As String
        Get
            Return N_ame
        End Get
        Set(value As String)
            N_ame = value
        End Set
    End Property

    Public Property staffNo As String
        Get
            Return Staff
        End Get
        Set(value As String)
            Staff = value
        End Set
    End Property

    Public Property MofficeId1 As String
        Get
            Return officeId
        End Get
        Set(value As String)
            officeId = value
        End Set
    End Property

    Public Property MFacilityId1 As String
        Get
            Return FacilityId
        End Get
        Set(value As String)
            FacilityId = value
        End Set
    End Property

    Public Property MProfitCenterId1 As String
        Get
            Return ProfitCenter
        End Get
        Set(value As String)
            ProfitCenter = value
        End Set
    End Property

    Public Property MBoType1 As String
        Get
            Return Status
        End Get
        Set(value As String)
            Status = value
        End Set
    End Property

    Public Property MRemarks1 As String
        Get
            Return Remark
        End Get
        Set(value As String)
            Remark = value
        End Set
    End Property

    Public Property MHO1 As String
        Get
            Return Ho
        End Get
        Set(value As String)
            Ho = value
        End Set
    End Property
End Class
