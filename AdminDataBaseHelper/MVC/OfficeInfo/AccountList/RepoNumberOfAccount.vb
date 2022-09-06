Public Class RepoNumberOfAccount
    Implements INumberOfAccount

    Public Function AddData(Data As clsNumberOfAccount) As Boolean Implements INumberOfAccount.AddData
        Throw New NotImplementedException()
    End Function

    Public Function IsOfficeIdExist() As Boolean Implements INumberOfAccount.IsOfficeIdExist
        Throw New NotImplementedException()
    End Function

    Public Function UpdateData(Data As clsNumberOfAccount) As Boolean Implements INumberOfAccount.UpdateData
        Throw New NotImplementedException()
    End Function

    Public Function DeleteData(OfficeId As String) As Boolean Implements INumberOfAccount.DeleteData
        Throw New NotImplementedException()
    End Function

    Public Function GetAll() As List(Of clsNumberOfAccount) Implements INumberOfAccount.GetAll
        Throw New NotImplementedException()
    End Function

    Public Function GetById(OfficeId As String) As clsNumberOfAccount Implements INumberOfAccount.GetById
        Throw New NotImplementedException()
    End Function
End Class
