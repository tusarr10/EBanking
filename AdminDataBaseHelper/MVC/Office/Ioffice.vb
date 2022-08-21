Public Interface Ioffice
    Function GetAll() As IList(Of clsoffice)
    Function FindByOfficeCode(officeCode As String) As clsoffice
    Function IsOfficecodeExist() As Boolean
    Function AddOffice(officeData As clsoffice) As Boolean
    Function UpdateOffice(office As clsoffice) As Boolean
    Function DeleteOffice(officeCode As String) As Boolean


End Interface
