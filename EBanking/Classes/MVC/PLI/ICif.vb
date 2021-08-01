Public Interface ICif
    'interface
    Function GetAll() As IList(Of ClassCif)
    Function FindById(cif As String) As ClassCif
    Function AddCif(custmor As ClassCif) As Boolean
    Function UpdateCif(custmor As ClassCif) As Boolean
    Function DeleteCif(cif As String) As Boolean

End Interface
