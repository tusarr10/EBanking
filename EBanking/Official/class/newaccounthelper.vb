Imports System.Data.SqlClient

Module newaccounthelper
    Sub newOpenAccountSearch(ByVal reff As String)
        Try
            datasetcifdb.Tables(newaccounttable).Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstring()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM " & newaccounttable & " where reffno='" & reff & "'", databaseconnection)

        dataadapter.Fill(datasetcifdb, newaccounttable)
        'ShowData(currentrow)

        databaseconnection.Close()

    End Sub

    Function getNewAccountOpenDataTable() As DataTable
        Try
            Return datasetcifdb.Tables(newaccounttable)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Function getNewAccountVirtualid(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("VirtualId"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountcif(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("cif"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountacno(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("accountnumber"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountName(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("n_ame"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountproducttype(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("producttype"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountProductTerm(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("productterm"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountProductValue(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("productvalue"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountNominiReg(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("nominireg"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountNominiName(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("nomininame"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountNominiAge(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("nominiage"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountNominiaddress(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("nominiaddress"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountNominiRelation(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("nominirelation"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountMOP(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("acoperatemode"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountguardianname(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("guardianname"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountJointName(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("jointname"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountStatus(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("status"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountAddress(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("address"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountmobile(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("mobile"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountEmail(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("email"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountdob(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("dob"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountgender(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("gender"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountadhar(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("adhar"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountpan(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("pan"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountphoto(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("photo"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountsign(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("sign"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountdoo(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("doo"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountbalance(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("balance"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountreffno(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("reffno"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccountpr(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("pr"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getNewAccounttrid(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(newaccounttable).Rows(currentrow)("trid"), String)
        Catch
            Return Nothing
        End Try
    End Function




    Sub NewAccountNameSearch(ByVal Nmae As String)
        Try
            datasetcifdb.Tables(newaccounttable).Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstring()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0

        dataadapter = New SqlDataAdapter("SELECT * FROM " & newaccounttable & " where n_ame like '%" & Nmae & "%'", databaseconnection)

        dataadapter.Fill(datasetcifdb, newaccounttable)



        'ShowData(currentrow)

        databaseconnection.Close()

    End Sub

End Module
