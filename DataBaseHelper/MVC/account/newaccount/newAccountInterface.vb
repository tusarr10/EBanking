''' <summary>
''' For Get Data And Filter Data From Database
''' </summary>
Public Interface newAccountInterface

    Function getAll() As List(Of NewAccountClass)

    Function getByName(EnterName As String) As List(Of NewAccountClass)

    Function gteByCif(cif As String) As List(Of NewAccountClass)

    Function getByType(type As String) As List(Of NewAccountClass)

    Function gteByReffNo(ReffNo As String) As NewAccountClass

    Function IsReffNoExist(reffno As String) As Boolean

    'add data by transction ok
    ' Function AddData(data As NewAccountClass) As Boolean

End Interface