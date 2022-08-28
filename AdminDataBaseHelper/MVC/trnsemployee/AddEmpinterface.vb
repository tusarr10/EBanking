Public Interface AddEmpinterface

    Function CheckEmployeeExist(employeeId As String) As Boolean
    Function AddEmpDataTransction(empdetails As clsEmpDetails, empinfo As ClsEmplInfo, empservices As EmpServices) As Boolean
    Function UpdateDataTransction() As Boolean
    Function DeleteDataTransction() As Boolean


End Interface
