Public Interface ILocation
    Function AddData(Data As ClsLocation) As Boolean
    Function GetAllData() As List(Of ClsLocation)
    Function GetDataById(OfficeId As String) As ClsLocation
    Function updateData(data As ClsLocation) As Boolean
    Function deleteData(OfficeId As String) As Boolean
    Function IsDataExist(OfficeId As String) As Boolean

End Interface
