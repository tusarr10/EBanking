Imports System.Data.SqlClient
Imports Dapper


Public Class AddEmpRepo
    Implements AddEmpinterface
    Private _db As IDbConnection


    Public Sub New(connection As String)
        _db = New SqlConnection(connection)
    End Sub


    Public Function AddEmpDataTransction(empdetails As clsEmpDetails, empinfo As ClsEmplInfo, empservices As EmpServices, emptrnsf As clsEmpTrnsf) As Boolean Implements AddEmpinterface.AddEmpDataTransction
        Dim parm As SqlParameter() = {
        New SqlParameter("@officeid", empdetails.Mofficeid1),
        New SqlParameter("@empid", empdetails.MemployeeId1),
        New SqlParameter("@dateofposting", empdetails.MDateOfPosting1),
        New SqlParameter("@dateofjoin", empdetails.MDateofJoin1),
        New SqlParameter("@dateofret", empdetails.MDateofRet1),
        New SqlParameter("@empstatus", empdetails.MEmployeeStatus1),
        New SqlParameter("@postt", empdetails.post1),
        New SqlParameter("@trcalvl", empdetails.trcalvl1),
        New SqlParameter("@orgpost", empdetails.post1),
        New SqlParameter("@currentpost", empdetails.currentPost1),
        New SqlParameter("@currentPlace", empdetails.CurrentPlace1),
        New SqlParameter("@remarks", empdetails.remarks1),
        New SqlParameter("@IsUidai", empdetails.MIsUidai1),
        New SqlParameter("@IsIppb", empdetails.MIsIPPB1),
        New SqlParameter("@IsCsc", empdetails.MIsCSC1),
        New SqlParameter("@IsPli", empdetails.MIsPLI1)
   }
        Dim parm2 As SqlParameter() = {
        New SqlParameter("@UserId", empinfo.MUserId1),
        New SqlParameter("@EmployeeID", empinfo.MEmployeeId1),
        New SqlParameter("@Name", empinfo.MName1),
        New SqlParameter("@Father", empinfo.MFather1),
        New SqlParameter("@DOB", empinfo.MDOB1),
        New SqlParameter("@Gender", empinfo.MGender1),
        New SqlParameter("@Address", empinfo.MAddress1),
        New SqlParameter("@Address2", empinfo.MAddress21),
        New SqlParameter("@Mobile", empinfo.MMobile11),
        New SqlParameter("@Mobile2", empinfo.MMobile2),
        New SqlParameter("@Email", empinfo.MEmail1),
        New SqlParameter("@Blood", empinfo.MBlood1),
        New SqlParameter("@Aadhaar", empinfo.Maadhar1),
        New SqlParameter("@Pan", empinfo.MPan1),
        New SqlParameter("@Pran", empinfo.mpran1),
        New SqlParameter("@IdRemark", empinfo.MIdRemark1)
        }
        Dim parm3 As SqlParameter() = {
        New SqlParameter("@empId", empservices.memployeeid),
        New SqlParameter("@uidaiId", empservices.muidaiid),
        New SqlParameter("@ippbId", empservices.mippbid),
        New SqlParameter("@cscId", empservices.mcscid),
        New SqlParameter("@pliID", empservices.mpli)
        }
        Dim parm4 As SqlParameter() = {
        New SqlParameter("@empId", emptrnsf.MEmployeeID1),
        New SqlParameter("@mDate", emptrnsf.Mdate1),
        New SqlParameter("@mFrom", emptrnsf.MFrom1),
        New SqlParameter("@mTo", emptrnsf.MTO1),
        New SqlParameter("@Remark", emptrnsf.MRemark1),
        New SqlParameter("@officeCode", emptrnsf.mofficecode),
        New SqlParameter("@officeName", emptrnsf.mOfficename),
        New SqlParameter("@Name", emptrnsf.mname),
        New SqlParameter("@Designation", emptrnsf.mdesignation),
        New SqlParameter("@postt", emptrnsf.mpost),
        New SqlParameter("@other", emptrnsf.mother),
        New SqlParameter("@mmemo", emptrnsf.mmemo1)
        }

        Try
            If _db.State() Then
            Else
                _db.Open()
            End If
            Using transction = _db.BeginTransaction()
                Try
                    Dim query As String = "INSERT INTO dbo.EmpDetails (officeId, empId, DateOfPosting, DateOfJoin, DateOfRet, EmpStatus, Postt, trcalvl, orgPost, CurrentPost, CurrentPlace, Remarks, IsUIDAI, IsIPPB, IsCSC, IsPLI) VALUES (@officeid, @empid, @dateofposting, @dateofjoin, @dateofret, @empstatus, @postt, @trcalvl, @orgpost, @currentpost, @currentPlace, @remarks, @IsUidai, @IsIppb, @IsCsc, @IsPli)"
                    Dim args = New DynamicParameters()
                    For Each p As SqlParameter In parm
                        args.Add(p.ParameterName, p.Value)
                    Next
                    _db.Execute(query, args, transction) '1
                    '2
                    Dim query2 As String = "INSERT INTO dbo.EmpInfo (UserId, EmployeeID, Name, Father, DOB, Gender, Address, Address2, Mobile, Mobile2, Email, Blood, Aadhaar, Pan, Pran, IdRemark) VALUES (@UserId, @EmployeeID, @Name, @Father, @DOB, @Gender, @Address, @Address2, @Mobile, @Mobile2, @Email, @Blood, @Aadhaar, @Pan, @Pran, @IdRemark)"
                    Dim args2 = New DynamicParameters()
                    For Each q As SqlParameter In parm2
                        args2.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query2, args2, transction)
                    '3.
                    Dim query3 As String = "INSERT INTO dbo.EmpServices (empId, uidaiId, ippbID, cscId, pliID)VALUES (@empId, @uidaiId, @ippbID, @cscId, @pliID)"
                    Dim args3 = New DynamicParameters()
                    For Each q As SqlParameter In parm3
                        args3.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query3, args3, transction)
                    '4.
                    Dim query4 As String = "INSERT INTO dbo.EmpTransf (EmpId, mDate, mFrom, mTO, Remark, officeCode, officeName, Name, Designation, postt, other ,mmemo) VALUES (@empId, @mDate, @mFrom, @mTO, @Remark, @officeCode, @officeName, @Name, @Designation, @postt, @other ,@mmemo)"
                    Dim args4 = New DynamicParameters()
                    For Each q As SqlParameter In parm4
                        args4.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query4, args4, transction)
                    '.
                    '.

                    transction.Commit()
                    Return True
                Catch ex As Exception
                    transction.Rollback()
                    Return False
                End Try

            End Using
            '  Me._db.Query(Of allJournalClass)(query, args).SingleOrDefault
        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function UpdateDataTransction() As Boolean Implements AddEmpinterface.UpdateDataTransction
        Throw New NotImplementedException()
    End Function

    Public Function DeleteDataTransction() As Boolean Implements AddEmpinterface.DeleteDataTransction
        Throw New NotImplementedException()
    End Function

    Public Function CheckEmployeeExist(employeeId As String) As Boolean Implements AddEmpinterface.CheckEmployeeExist
        Dim x As Integer = Me._db.Query(Of clsEmpDetails)("SELECT * FROM EmpDetails WHERE empId = @emploID ", New With {Key .emploID = employeeId}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetEmpDetailsById(employeeId As String) As clsEmpDetails Implements AddEmpinterface.GetEmpDetailsById
        Return Me._db.Query(Of clsEmpDetails)("SELECT * FROM EmpDetails where empId = @accountnumber ", New With {Key .accountnumber = employeeId}).FirstOrDefault
    End Function

    Public Function GetEmpInfoById(employeeId As String) As ClsEmplInfo Implements AddEmpinterface.GetEmpInfoById
        Return Me._db.Query(Of ClsEmplInfo)("SELECT * FROM EmpInfo where EmployeeID = @accountnumber ", New With {Key .accountnumber = employeeId}).FirstOrDefault
    End Function

    Public Function GetEmpServiceById(employeeId As String) As EmpServices Implements AddEmpinterface.GetEmpServiceById
        Return Me._db.Query(Of EmpServices)("SELECT * FROM EmpServices where empId = @accountnumber ", New With {Key .accountnumber = employeeId}).FirstOrDefault
    End Function

    Public Function GetTransferById(employeeId As String) As List(Of clsEmpTrnsf) Implements AddEmpinterface.GetTransferById
        Return Me._db.Query(Of clsEmpTrnsf)("SELECT * FROM EmpTransf where EmpId = @accountnumber ", New With {Key .accountnumber = employeeId})
    End Function
End Class
