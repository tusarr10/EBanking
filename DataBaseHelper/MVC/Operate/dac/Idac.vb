Public Interface Idac
    Function SearchByDate(EnterDate As String) As dacClass
    Function SearchAllByMonth(EnterMonth As String, EnterYear As String) As List(Of dacClass)
    Function GetAll() As List(Of dacClass)

    Function IsDataExist(data As dacClass) As Boolean
    'crud
    Function InsertData(data As dacClass) As Boolean
    Function updateData(data As dacClass) As Boolean
    Function updateStatus(Data As dacClass) As Boolean
    Function DeleteData(data As dacClass) As Boolean

End Interface
