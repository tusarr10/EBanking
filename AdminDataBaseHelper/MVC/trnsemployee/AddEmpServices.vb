Public Class AddEmpServices
    Private _repo As AddEmpinterface
    Public Sub New(connection As String)
        _repo = New AddEmpRepo(connection)

    End Sub

    Public Function AddEmployee(EmployeeDetails As clsEmpDetails, EmployeeInformation As ClsEmplInfo, EmployeeServices As EmpServices) As Boolean
        Return _repo.AddEmpDataTransction(EmployeeDetails, EmployeeInformation, EmployeeServices)
    End Function
    Public Function EmployeeExist(employeeId As String) As Boolean
        Return _repo.
    End Function
End Class
