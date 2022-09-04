Public Class AddEmpServices
    Private _repo As AddEmpinterface
    Public Sub New(connection As String)
        _repo = New AddEmpRepo(connection)

    End Sub

    Public Function AddEmployee(EmployeeDetails As clsEmpDetails, EmployeeInformation As ClsEmplInfo, EmployeeServices As EmpServices, employeetransfer As clsEmpTrnsf) As Boolean
        Return _repo.AddEmpDataTransction(EmployeeDetails, EmployeeInformation, EmployeeServices, employeetransfer)
    End Function
    Public Function EmployeeExist(employeeId As String) As Boolean
        Return _repo.CheckEmployeeExist(employeeId)
    End Function
    Public Function GetEmployeeDetailsById(employeeId As String) As clsEmpDetails
        Return _repo.GetEmpDetailsById(employeeId)
    End Function
    Public Function GetEmployeeInfoById(employeeId As String) As ClsEmplInfo
        Return _repo.GetEmpInfoById(employeeId)
    End Function
    Public Function GetEmployeeServicesById(employeeId As String) As EmpServices
        Return _repo.GetEmpServiceById(employeeId)
    End Function
    Public Function GetEmpTrnsfById(employeeId As String) As List(Of clsEmpTrnsf)
        Return _repo.GetTransferById(employeeId)
    End Function
End Class
