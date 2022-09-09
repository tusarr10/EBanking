Public Interface INumberOfAccount

    Function AddData(Data As clsNumberOfAccount) As Boolean
    Function IsOfficeIdExist(OfficeId As String) As Boolean
    Function UpdateData(Data As clsNumberOfAccount) As Boolean
    Function DeleteData(OfficeId As String) As Boolean
    Function GetAll() As List(Of clsNumberOfAccount)
    Function GetById(OfficeId As String) As clsNumberOfAccount


End Interface
