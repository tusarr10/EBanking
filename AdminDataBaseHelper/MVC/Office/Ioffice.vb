Public Interface Ioffice
    Function GetAll() As IList(Of clsoffice)
    Function FindByOfficeCode(officeCode As String) As clsoffice
    Function IsOfficecodeExist(officeCode As String) As Boolean
    Function AddOffice(officeData As clsoffice) As Boolean
    Function UpdateOffice(office As clsoffice) As Boolean
    Function DeleteOffice(officeCode As String) As Boolean
    Function FindBySubdivision(SD As String) As List(Of clsoffice)


End Interface
