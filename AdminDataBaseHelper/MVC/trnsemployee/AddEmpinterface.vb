Public Interface AddEmpinterface

    Function CheckEmployeeExist(employeeId As String) As Boolean
    '  Function AddEmpDataTransction(empdetails As clsEmpDetails, empinfo As ClsEmplInfo, empservices As EmpServices) As Boolean
    Function UpdateDataTransction() As Boolean
    Function DeleteDataTransction() As Boolean
    Function GetEmpDetailsById(employeeId As String) As clsEmpDetails
    Function GetEmpInfoById(employeeId As String) As ClsEmplInfo
    Function AddEmpDataTransction(empdetails As clsEmpDetails, empinfo As ClsEmplInfo, empservices As EmpServices, emptrnsf As clsEmpTrnsf) As Boolean
    Function GetEmpServiceById(employeeId As String) As EmpServices
    Function GetTransferById(employeeId As String) As clsEmpTrnsf


End Interface
