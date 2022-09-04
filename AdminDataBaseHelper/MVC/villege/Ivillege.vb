Public Interface Ivillege
    Function GetAll() As IList(Of clsvillege)

    ''' <summary>
    ''' List Of Villeger available Under Office
    ''' </summary>
    ''' <param Name="code"> as office code</param>
    ''' <returns>list of villege</returns>
    Function FindByOfficeCode(code As String) As IList(Of clsvillege)

    Function FindBy5star(code As String) As IList(Of clsvillege)
    Function FindByssg(code As String) As IList(Of clsvillege)
    Function FindByssb(code As String) As IList(Of clsvillege)

    Function Addvillege(custmor As clsvillege) As Boolean

    Function Updatevillege(custmor As clsvillege) As Boolean
    Function Deletevillege(custmor As clsvillege) As Boolean

End Interface
