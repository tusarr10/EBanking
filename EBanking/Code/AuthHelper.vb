Imports Microsoft.VisualBasic
Imports System.Web

Namespace Model
    Public Class ApplicationUser
        Private privateUserName As String
        Public Property UserName() As String
            Get
                Return privateUserName
            End Get
            Set(ByVal value As String)
                privateUserName = value
            End Set
        End Property
        Private privateFirstName As String
        Public Property FirstName() As String
            Get
                Return privateFirstName
            End Get
            Set(ByVal value As String)
                privateFirstName = value
            End Set
        End Property
        Private privateLastName As String
        Public Property LastName() As String
            Get
                Return privateLastName
            End Get
            Set(ByVal value As String)
                privateLastName = value
            End Set
        End Property
        Private privateEmail As String
        Public Property Email() As String
            Get
                Return privateEmail
            End Get
            Set(ByVal value As String)
                privateEmail = value
            End Set
        End Property
        Private privateAvatarUrl As String
        Public Property AvatarUrl() As String
            Get
                Return privateAvatarUrl
            End Get
            Set(ByVal value As String)
                privateAvatarUrl = value
            End Set
        End Property
    End Class

    Public NotInheritable Class AuthHelper
        Private Sub New()
        End Sub
        Public Shared Function SignIn(ByVal userName As String, ByVal password As String) As Boolean
            HttpContext.Current.Session("User") = CreateDefualtUser() ' Mock user data
            Return True
        End Function
        Public Shared Sub SignOut()
            HttpContext.Current.Session("User") = Nothing
        End Sub
        Public Shared Function IsAuthenticated() As Boolean
            Return GetLoggedInUserInfo() IsNot Nothing
        End Function

        Public Shared Function GetLoggedInUserInfo() As ApplicationUser
            Return TryCast(HttpContext.Current.Session("User"), ApplicationUser)
        End Function
        Private Shared Function CreateDefualtUser() As ApplicationUser
            Return New ApplicationUser With {
                .UserName = "JBell",
                .FirstName = "Julia",
                .LastName = "Bell",
                .Email = "julia.bell@example.com",
                .AvatarUrl = "~/Content/Photo/Julia_Bell.jpg"
            }
        End Function
    End Class
End Namespace