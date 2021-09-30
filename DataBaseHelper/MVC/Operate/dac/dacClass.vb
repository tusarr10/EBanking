''' <summary>
''' CREATE TABLE postaloperate.dbo.dacdb (
''' D_ate VARCHAR(MAX) Not NULL
''',Open_bal NUMERIC NULL
''',cashrec NUMERIC NULL
''',Sbdep NUMERIC NULL
''',rddep NUMERIC NULL
''',rdfine NUMERIC NULL
''',ssadep NUMERIC NULL
''',ssafine NUMERIC NULL
''',tddep NUMERIC NULL
''',rplidep NUMERIC NULL
''',rplifine NUMERIC NULL
''',rplitax NUMERIC NULL
''',vpp NUMERIC NULL
''',othcol1 NUMERIC NULL
''',othcol2 NUMERIC NULL
''',totaldep NUMERIC NULL
''',cashremet NUMERIC NULL
''',sbwith NUMERIC NULL
''',rdwith NUMERIC NULL
''',ssawith NUMERIC NULL
''',rpliwith NUMERIC NULL
''',MONwith NUMERIC NULL
''',othwith NUMERIC NULL
''',totalwith NUMERIC NULL
''',curr_ency NUMERIC NULL
''',stamp1 NUMERIC NULL
''',stamp2 NUMERIC NULL
''',closebal NUMERIC NULL
''',office VARCHAR(MAX) NULL
''',[user] VARCHAR(50) NULL
''',ti_me VARCHAR(50) NULL
''',status VARCHAR(50) NULL
''' </summary>
Public Class dacClass
    Private mD_ate As String 'Total 32 elements
    Public Property D_ate() As String
        Get
            Return mD_ate
        End Get
        Set(ByVal value As String)
            mD_ate = value
        End Set
    End Property
    Private mOpen_bal As Double
    Public Property Open_bal() As Double
        Get
            Return mOpen_bal
        End Get
        Set(ByVal value As Double)
            mOpen_bal = value
        End Set
    End Property
    Private mcashrec As Double
    Public Property cashrec() As Double
        Get
            Return mcashrec
        End Get
        Set(ByVal value As Double)
            mcashrec = value
        End Set
    End Property
    Private mSbdep As Double
    Public Property Sbdep() As Double
        Get
            Return mSbdep
        End Get
        Set(ByVal value As Double)
            mSbdep = value
        End Set
    End Property
    Private mrddep As Double
    Public Property rddep() As Double
        Get
            Return mrddep
        End Get
        Set(ByVal value As Double)
            mrddep = value
        End Set
    End Property
    Private mrdfine As Double
    Public Property rdfine() As Double
        Get
            Return mrdfine
        End Get
        Set(ByVal value As Double)
            mrdfine = value
        End Set
    End Property
    Private mssadep As Double
    Public Property ssadep() As Double
        Get
            Return mssadep
        End Get
        Set(ByVal value As Double)
            mssadep = value
        End Set
    End Property
    Private mssadine As Double
    Public Property ssafine() As Double
        Get
            Return mssadine
        End Get
        Set(ByVal value As Double)
            mssadine = value
        End Set
    End Property
    Private mtddep As Double
    Public Property tddep() As Double
        Get
            Return mtddep
        End Get
        Set(ByVal value As Double)
            mtddep = value
        End Set
    End Property
    Private mrplidep As Double
    Public Property rplidep() As Double
        Get
            Return mrplidep
        End Get
        Set(ByVal value As Double)
            mrplidep = value
        End Set
    End Property
    Private mrplifine As Double
    Public Property rplifine() As Double
        Get
            Return mrplifine
        End Get
        Set(ByVal value As Double)
            mrplifine = value
        End Set
    End Property
    Private mrplitax As Double
    Public Property rplitax() As Double
        Get
            Return mrplitax
        End Get
        Set(ByVal value As Double)
            mrplitax = value
        End Set
    End Property
    Private mvpp As Double
    Public Property vpp() As Double
        Get
            Return mvpp
        End Get
        Set(ByVal value As Double)
            mvpp = value
        End Set
    End Property
    Private mothcol1 As Double
    Public Property othcol1() As Double
        Get
            Return mothcol1
        End Get
        Set(ByVal value As Double)
            mothcol1 = value
        End Set
    End Property
    Private mothcol2 As Double
    Public Property othcol2() As Double
        Get
            Return mothcol2
        End Get
        Set(ByVal value As Double)
            mothcol2 = value
        End Set
    End Property
    Private mtotaldep As Double
    Public Property totaldep() As Double
        Get
            Return mtotaldep
        End Get
        Set(ByVal value As Double)
            mtotaldep = value
        End Set
    End Property
    Private mcashremet As Double
    Public Property cashremet() As Double
        Get
            Return mcashremet
        End Get
        Set(ByVal value As Double)
            mcashremet = value
        End Set
    End Property
    Private msbwith As Double
    Public Property sbwith() As Double
        Get
            Return msbwith
        End Get
        Set(ByVal value As Double)
            msbwith = value
        End Set
    End Property
    Private mrdwith As Double
    Public Property rdwith() As Double
        Get
            Return mrdwith
        End Get
        Set(ByVal value As Double)
            mrdwith = value
        End Set
    End Property
    Private mssawith As Double
    Public Property ssawith() As Double
        Get
            Return mssawith
        End Get
        Set(ByVal value As Double)
            mssawith = value
        End Set
    End Property
    Private mtdwith As Double
    Public Property tdwith() As Double
        Get
            Return mtdwith
        End Get
        Set(ByVal value As Double)
            mtdwith = value
        End Set
    End Property
    Private mrpliwith As Double
    Public Property rpliwith() As Double
        Get
            Return mrpliwith
        End Get
        Set(ByVal value As Double)
            mrpliwith = value
        End Set
    End Property
    Private mMONwith As Double
    Public Property MONwith() As Double
        Get
            Return mMONwith
        End Get
        Set(ByVal value As Double)
            mMONwith = value
        End Set
    End Property
    Private mothwith As Double
    Public Property othwith() As Double
        Get
            Return mothwith
        End Get
        Set(ByVal value As Double)
            mothwith = value
        End Set
    End Property
    Private mtotalwith As Double
    Public Property totalwith() As Double
        Get
            Return mtotalwith
        End Get
        Set(ByVal value As Double)
            mtotalwith = value
        End Set
    End Property
    Private mcurr_ency As String
    Public Property curr_ency() As String
        Get
            Return mcurr_ency
        End Get
        Set(ByVal value As String)
            mcurr_ency = value
        End Set
    End Property
    Private mstamp1 As Double
    Public Property stamp1() As Double
        Get
            Return mstamp1
        End Get
        Set(ByVal value As Double)
            mstamp1 = value
        End Set
    End Property
    Private mstamp2 As Double
    Public Property stamp2() As Double
        Get
            Return mstamp2
        End Get
        Set(ByVal value As Double)
            mstamp2 = value
        End Set
    End Property
    Private mClosebal As Double
    Public Property Closebal() As Double
        Get
            Return mClosebal
        End Get
        Set(ByVal value As Double)
            mClosebal = value
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
    Private mu_ser As String
    Public Property u_ser() As String
        Get
            Return mu_ser
        End Get
        Set(ByVal value As String)
            mu_ser = value
        End Set
    End Property
    Private mti_me As String
    Public Property ti_me() As String
        Get
            Return mti_me
        End Get
        Set(ByVal value As String)
            mti_me = value
        End Set
    End Property
    Private mstatus As String
    Public Property status() As String
        Get
            Return mstatus
        End Get
        Set(ByVal value As String)
            mstatus = value
        End Set
    End Property


End Class
