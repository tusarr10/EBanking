Public Interface Istaff
    Function GetAll() As IList(Of ClassStaff)
    ' Function FindById(staff As String) As ClassStaff
    Function findByOfficeId(office As String) As List(Of ClassStaff)

    Function IsofficExist(staff As String) As Boolean

    Function Addstaff(custmor As ClassStaff) As Boolean

    Function Updatestaff(custmor As ClassStaff) As Boolean

    Function UpdateStatus(status As String, id As String) As Boolean

    Function Deletestaff(staff As String) As Boolean

End Interface
