﻿Public Class AddAccountTransctionService
    Private _repo As liveaccounttransctionInterface

    Public Sub New(connection As String)
        _repo = New AddAccountTransctionRepo(connection)
    End Sub

    Public Function MadeAddAccountTransction(liveacdata As liveAccountClass, nominidata As NominiClass, productdata As productClass, operatedata As accOperateClass, dltdata As dltClass) As Boolean
        Return _repo.MadeAddAccountTransction(liveacdata, nominidata, productdata, operatedata, dltdata)
    End Function
    Public Function DevAddAccountTransction(liveacdata As liveAccountClass, nominidata As NominiClass, productdata As productClass, operatedata As accOperateClass) As Boolean
        Return _repo.DevAddAccountTransction(liveacdata, nominidata, productdata, operatedata)
    End Function
    Public Function DevUpdateAccountTransction(liveacdata As liveAccountClass, nominidata As NominiClass, productdata As productClass, operatedata As accOperateClass) As Boolean
        Return _repo.DevUpdateAccountTransction(liveacdata, nominidata, productdata, operatedata)
    End Function
End Class