Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports DevExpress.XtraScheduler

Namespace Model
    ' Sample Data
    Public Class Issue
        Private privateId As Long
        Public Property Id() As Long
            Get
                Return privateId
            End Get
            Set(ByVal value As Long)
                privateId = value
            End Set
        End Property
        Private privateSubject As String
        Public Property Subject() As String
            Get
                Return privateSubject
            End Get
            Set(ByVal value As String)
                privateSubject = value
            End Set
        End Property
        Private privateCustomer As Contact
        Public Property Customer() As Contact
            Get
                Return privateCustomer
            End Get
            Private Set(ByVal value As Contact)
                privateCustomer = value
            End Set
        End Property
        Public Property CustomerId() As Long
            Get
                Return If((Customer IsNot Nothing), Customer.Id, -1)
            End Get
            Set(ByVal value As Long)
                Customer = DataProvider.GetContacts().Find(Function(contact) contact.Id = value)
            End Set
        End Property
        Private privateCreated As DateTime
        Public Property Created() As DateTime
            Get
                Return privateCreated
            End Get
            Set(ByVal value As DateTime)
                privateCreated = value
            End Set
        End Property
        Private privateUpdated As DateTime
        Public Property Updated() As DateTime
            Get
                Return privateUpdated
            End Get
            Set(ByVal value As DateTime)
                privateUpdated = value
            End Set
        End Property
        Private privateNotes As String
        Public Property Notes() As String
            Get
                Return privateNotes
            End Get
            Set(ByVal value As String)
                privateNotes = value
            End Set
        End Property
        Private privateUnread As Boolean
        Public Property Unread() As Boolean
            Get
                Return privateUnread
            End Get
            Set(ByVal value As Boolean)
                privateUnread = value
            End Set
        End Property
        Private privateIsDraft As Boolean
        Public Property IsDraft() As Boolean
            Get
                Return privateIsDraft
            End Get
            Set(ByVal value As Boolean)
                privateIsDraft = value
            End Set
        End Property
        Private privateIsArchived As Boolean
        Public Property IsArchived() As Boolean
            Get
                Return privateIsArchived
            End Get
            Set(ByVal value As Boolean)
                privateIsArchived = value
            End Set
        End Property
        Private privateKind As Integer
        Public Property Kind() As Integer
            Get
                Return privateKind
            End Get
            Set(ByVal value As Integer)
                privateKind = value
            End Set
        End Property
        Private privatePriority As Integer
        Public Property Priority() As Integer
            Get
                Return privatePriority
            End Get
            Set(ByVal value As Integer)
                privatePriority = value
            End Set
        End Property
        Private privateStatus As Integer
        Public Property Status() As Integer
            Get
                Return privateStatus
            End Get
            Set(ByVal value As Integer)
                privateStatus = value
            End Set
        End Property
        Private privateVotes As Integer
        Public Property Votes() As Integer
            Get
                Return privateVotes
            End Get
            Set(ByVal value As Integer)
                privateVotes = value
            End Set
        End Property

        Public Sub New()
            Kind = 1
            IsDraft = True
            Status = 1
            Priority = 1
            Customer = New Contact()
        End Sub
        Public Sub SetCustomer(ByVal value As Contact)
            Customer = value
        End Sub
        Public Sub Assign(ByVal src As Issue)
            Subject = src.Subject
            SetCustomer(src.Customer)
            Updated = DateTime.Now
            Notes = src.Notes
            IsDraft = src.IsDraft
            IsArchived = src.IsArchived
            Kind = src.Kind
            Priority = src.Priority
            Status = src.Status
        End Sub
    End Class

    Public Class Contact
        Private privateId As Long
        Public Property Id() As Long
            Get
                Return privateId
            End Get
            Set(ByVal value As Long)
                privateId = value
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
        Public ReadOnly Property FullName() As String
            Get
                Return String.Format("{0} {1}", FirstName, LastName)
            End Get
        End Property
        Private privateAddressBook As String
        Public Property AddressBook() As String
            Get
                Return privateAddressBook
            End Get
            Set(ByVal value As String)
                privateAddressBook = value
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
        Private privatePhotoFileName As String
        Public Property PhotoFileName() As String
            Get
                Return privatePhotoFileName
            End Get
            Set(ByVal value As String)
                privatePhotoFileName = value
            End Set
        End Property
        Public ReadOnly Property PhotoUrl() As String
            Get
                Return String.Format("Content/Photo/{0}", PhotoFileName)
            End Get
        End Property
        Private privateCountry As String
        Public Property Country() As String
            Get
                Return privateCountry
            End Get
            Set(ByVal value As String)
                privateCountry = value
            End Set
        End Property
        Private privateCity As String
        Public Property City() As String
            Get
                Return privateCity
            End Get
            Set(ByVal value As String)
                privateCity = value
            End Set
        End Property
        Private privateAddress As String
        Public Property Address() As String
            Get
                Return privateAddress
            End Get
            Set(ByVal value As String)
                privateAddress = value
            End Set
        End Property
        Private privatePhone As String
        Public Property Phone() As String
            Get
                Return privatePhone
            End Get
            Set(ByVal value As String)
                privatePhone = value
            End Set
        End Property
        Private privateBirthday As DateTime
        Public Property Birthday() As DateTime
            Get
                Return privateBirthday
            End Get
            Set(ByVal value As DateTime)
                privateBirthday = value
            End Set
        End Property
    End Class

#Region "DataProvider "
    Public NotInheritable Class DataProvider
        Private Sub New()
        End Sub
        Public Shared Function GetContacts() As List(Of Contact)
            If HttpContext.Current.Session("Contacts") Is Nothing Then
                HttpContext.Current.Session("Contacts") = GenerateContacts()
            End If
            Return TryCast(HttpContext.Current.Session("Contacts"), List(Of Contact))
        End Function

        Public Shared Function GetIssues() As List(Of Issue)
            If HttpContext.Current.Session("Issues") Is Nothing Then
                HttpContext.Current.Session("Issues") = GenerateIssues()
            End If
            Return TryCast(HttpContext.Current.Session("Issues"), List(Of Issue))
        End Function
        Private Shared Sub UpdateIssues(ByVal list As List(Of Issue))
            HttpContext.Current.Session("Issues") = list
        End Sub

        Private Shared ReadOnly lockObject As Object = New Object()
        Public Shared Sub AddNewIssue(ByVal issue As Issue)
            SyncLock lockObject
                Dim issues As List(Of Issue) = GetIssues()

                issue.Id = GetNextIssueId()
                issue.Created = DateTime.Now
                issue.Updated = DateTime.Now

                issues.Add(issue)

                UpdateIssues(issues)
            End SyncLock
        End Sub
        Public Shared Sub UpdateIssue(ByVal issue As Issue)
            Dim issues As List(Of Issue) = GetIssues()

            Dim existingIssue As Issue = issues.Find(Function(i) i.Id = issue.Id)
            If existingIssue IsNot Nothing Then
                existingIssue.Assign(issue)
            End If

            UpdateIssues(issues)
        End Sub
        Public Shared Sub DeleteIssues(ByVal ids As List(Of Long))
            Dim issues As List(Of Issue) = GetIssues()
            issues.RemoveAll(Function(i) ids.Contains(i.Id))
            UpdateIssues(issues)
        End Sub
        Private Shared Function GenerateContacts() As List(Of Contact)
            Dim contacts As New List(Of Contact)(
                New Contact() {
                    New Contact With {.Id = 1, .FirstName = "Naomi", .LastName = "Moreno", .AddressBook = "Personal", .Email = "naomi.moreno@dx-email.com", .PhotoFileName = "Naomi_Moreno.jpg", .Country = "Australia", .City = "Brisbane", .Address = "918 Park Lane", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1990, 1, 11)},
                    New Contact With {.Id = 2, .FirstName = "Logan", .LastName = "Hernandez", .AddressBook = "Personal", .Email = "logan.hernandez@dx-email.com", .PhotoFileName = "Logan_Hernandez.jpg", .Country = "Australia", .City = "Geelong", .Address = "7625 Cloudview Dr.", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1980, 2, 22)},
                    New Contact With {.Id = 3, .FirstName = "Heidi", .LastName = "Lopez", .AddressBook = "Business", .Email = "heidi.lopez@dx-email.com", .PhotoFileName = "Heidi_Lopez.jpg", .Country = "Australia", .City = "Matraville", .Address = "2514 Via Cordona", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1975, 3, 27)},
                    New Contact With {.Id = 4, .FirstName = "Rafael", .LastName = "Raje", .AddressBook = "Personal", .Email = "rafael.raje@dx-email.com", .PhotoFileName = "Rafael_Raje.jpg", .Country = "Australia", .City = "Hobart", .Address = "5269 Mt. Trinity Court", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1995, 4, 3)},
                    New Contact With {.Id = 5, .FirstName = "Jessie", .LastName = "She", .AddressBook = "Business", .Email = "jessie.she@dx-email.com", .PhotoFileName = "Jessie_She.jpg", .Country = "Australia", .City = "North Sydney", .Address = "5866 Military E", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1991, 5, 2)},
                    New Contact With {.Id = 6, .FirstName = "Alfredo", .LastName = "Gomez", .AddressBook = "Personal", .Email = "alfredo.gomez@dx-email.com", .PhotoFileName = "Alfredo_Gomez.jpg", .Country = "Australia", .City = "Port Macquarie", .Address = "9430 La Vista Avenue", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1976, 6, 7)},
                    New Contact With {.Id = 7, .FirstName = "Colin", .LastName = "He", .AddressBook = "Business", .Email = "colin.he@dx-email.com", .PhotoFileName = "Colin_He.jpg", .Country = "Australia", .City = "Seaford", .Address = "3144 Via Rerrari", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1972, 7, 18)},
                    New Contact With {.Id = 8, .FirstName = "Julia", .LastName = "Bell", .AddressBook = "Personal", .Email = "julia.bell@dx-email.com", .PhotoFileName = "Julia_Bell.jpg", .Country = "Canada", .City = "Vancouver", .Address = "7516 Laguna Street", .Phone = "1 (362) 555-0196", .Birthday = New DateTime(1977, 7, 7)},
                    New Contact With {.Id = 9, .FirstName = "Katelyn", .LastName = "Lopez", .AddressBook = "Business", .Email = "katelyn.lopez@dx-email.com", .PhotoFileName = "Katelyn_Lopez.jpg", .Country = "Canada", .City = "Victoria", .Address = "8873 Folson Drive", .Phone = "1 (316) 555-0185", .Birthday = New DateTime(1984, 8, 8)},
                    New Contact With {.Id = 10, .FirstName = "Nathan", .LastName = "Bryant", .AddressBook = "Personal", .Email = "nathan.bryant@dx-email.com", .PhotoFileName = "Nathan_Bryant.jpg", .Country = "Canada", .City = "Vancouver", .Address = "7111 Stinson", .Phone = "1 (161) 555-0172", .Birthday = New DateTime(1993, 9, 9)},
                    New Contact With {.Id = 11, .FirstName = "Destiny", .LastName = "Clark", .AddressBook = "Business", .Email = "destiny.clark@dx-email.com", .PhotoFileName = "Destiny_Clark.jpg", .Country = "Canada", .City = "Westminster", .Address = "6478 Pierce Ct", .Phone = "1 (695) 555-0137", .Birthday = New DateTime(1988, 10, 10)},
                    New Contact With {.Id = 12, .FirstName = "Diana", .LastName = "Martin", .AddressBook = "Personal", .Email = "diana.martin@dx-email.com", .PhotoFileName = "Diana_Martin.jpg", .Country = "France", .City = "Paris", .Address = "9554, rue des Pyrenees", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1986, 11, 11)},
                    New Contact With {.Id = 13, .FirstName = "Shannon", .LastName = "Sanz", .AddressBook = "Business", .Email = "shannon.sanz@dx-email.com", .PhotoFileName = "Shannon_Sanz.jpg", .Country = "France", .City = "Metz", .Address = "74, rue Descartes", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1974, 12, 12)},
                    New Contact With {.Id = 14, .FirstName = "Connor", .LastName = "Jenkins", .AddressBook = "Personal", .Email = "connor.jenkins@dx-email.com", .PhotoFileName = "Connor_Jenkins.jpg", .Country = "Australia", .City = "Newcastle", .Address = "2542 Pinecrest Court", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1977, 8, 26)},
                    New Contact With {.Id = 15, .FirstName = "Rebekah", .LastName = "Raman", .AddressBook = "Business", .Email = "rebekah.raman@dx-email.com", .PhotoFileName = "Rebekah_Raman.jpg", .Country = "Australia", .City = "Sydney", .Address = "566 Morgan Territory Rd.", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1995, 8, 21)},
                    New Contact With {.Id = 16, .FirstName = "Maria", .LastName = "Hernandez", .AddressBook = "Personal", .Email = "maria.hernandez@dx-email.com", .PhotoFileName = "Maria_Hernandez.jpg", .Country = "Australia", .City = "Wollongong", .Address = "644 North Ranchford", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1995, 5, 5)},
                    New Contact With {.Id = 17, .FirstName = "Martha", .LastName = "Gao", .AddressBook = "Business", .Email = "martha.gao@dx-email.com", .PhotoFileName = "Martha_Gao.jpg", .Country = "Australia", .City = "Sunshine", .Address = "4060 Roundtree Court", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1993, 6, 21)},
                    New Contact With {.Id = 18, .FirstName = "Clarence", .LastName = "Nath", .AddressBook = "Personal", .Email = "clarence.nath@dx-email.com", .PhotoFileName = "Clarence_Nath.jpg", .Country = "Australia", .City = "Coast", .Address = "1591 Apple Court", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1989, 9, 4)},
                    New Contact With {.Id = 19, .FirstName = "Gary", .LastName = "Rubio", .AddressBook = "Business", .Email = "gary.rubio@dx-email.com", .PhotoFileName = "Gary_Rubio.jpg", .Country = "Australia", .City = "Darwin", .Address = "6532 Pinecrest Rd", .Phone = "1 (11) 500 555-0", .Birthday = New DateTime(1989, 9, 4)},
                    New Contact With {.Id = 20, .FirstName = "Alberto", .LastName = "Alonso", .AddressBook = "Personal", .Email = "alberto.alonso@dx-email.com", .PhotoFileName = "Alberto_Alonso.jpg", .Country = "Australia", .City = "Brisbane", .Address = "1369 Rambling Lane", .Phone = "1 (875) 555-0149", .Birthday = New DateTime(1996, 6, 13)},
                    New Contact With {.Id = 21, .FirstName = "Jesse", .LastName = "Gonzalez", .AddressBook = "Business", .Email = "jesse.gonzalez@dx-email.com", .PhotoFileName = "Jesse_Gonzalez.jpg", .Country = "Australia", .City = "Townsville", .Address = "5587 Stanley Dollar Dr.", .Phone = "1 (228) 555-0146", .Birthday = New DateTime(1987, 11, 12)},
                    New Contact With {.Id = 22, .FirstName = "Kevin", .LastName = "Collins", .AddressBook = "Personal", .Email = "kevin.collins@dx-email.com", .PhotoFileName = "Kevin_Collins.jpg", .Country = "Australia", .City = "Adelaide", .Address = "7835 Rio Blanco Dr.", .Phone = "1 (837) 555-0190", .Birthday = New DateTime(1988, 2, 21)},
                    New Contact With {.Id = 23, .FirstName = "Julia", .LastName = "Evans", .AddressBook = "Business", .Email = "julia.evans@dx-email.com", .PhotoFileName = "Julia_Evans.jpg", .Country = "Australia", .City = "Hobart", .Address = "9104 Jacobsen Street", .Phone = "1 (910) 555-0138", .Birthday = New DateTime(1979, 3, 3)},
                    New Contact With {.Id = 24, .FirstName = "Angela", .LastName = "Murphy", .AddressBook = "Personal", .Email = "angela.murphy@dx-email.com", .PhotoFileName = "Angela_Murphy.jpg", .Country = "Australia", .City = "Melbourne", .Address = "4927 Virgil Street", .Phone = "1 (451) 555-0162", .Birthday = New DateTime(1972, 2, 2)},
                    New Contact With {.Id = 25, .FirstName = "Andrew", .LastName = "Lee", .AddressBook = "Business", .Email = "andrew.lee@dx-email.com", .PhotoFileName = "Andrew_Lee.jpg", .Country = "Australia", .City = "Geelong", .Address = "2115 Pasado", .Phone = "1 (992) 555-0120", .Birthday = New DateTime(1971, 8, 8)},
                    New Contact With {.Id = 26, .FirstName = "Miguel", .LastName = "Jones", .AddressBook = "Personal", .Email = "miguel.jones@dx-email.com", .PhotoFileName = "Miguel_Jones.jpg", .Country = "Australia", .City = "Perth", .Address = "8352 Turning View Cricle Drive", .Phone = "1 (947) 555-0134", .Birthday = New DateTime(1989, 11, 4)},
                    New Contact With {.Id = 27, .FirstName = "Connor", .LastName = "Lopez", .AddressBook = "Business", .Email = "connor.lopez@dx-email.com", .PhotoFileName = "Connor_Lopez.jpg", .Country = "Australia", .City = "Albany", .Address = "9073 Mayda Way", .Phone = "1 (666) 555-0112", .Birthday = New DateTime(1981, 2, 1)},
                    New Contact With {.Id = 28, .FirstName = "Xavier", .LastName = "Richardson", .AddressBook = "Personal", .Email = "xavier.richardson@dx-email.com", .PhotoFileName = "Xavier_Richardson.jpg", .Country = "Australia", .City = "Canberra", .Address = "3249 E Leland", .Phone = "1 (578) 555-0132", .Birthday = New DateTime(1982, 3, 15)},
                    New Contact With {.Id = 29, .FirstName = "Megan", .LastName = "Sanchez", .AddressBook = "Business", .Email = "megan.sanchez@dx-email.com", .PhotoFileName = "Megan_Sanchez.jpg", .Country = "Australia", .City = "Newcastle", .Address = "1397 Paraiso Ct.", .Phone = "1 (404) 555-0199", .Birthday = New DateTime(1988, 6, 22)}})
            Return contacts
        End Function

        Private Shared Function GenerateIssues() As List(Of Issue)
            Dim issues As New List(Of Issue)(
                New Issue() {
                    New Issue With {.Id = 1, .IsArchived = False, .IsDraft = False, .Subject = "DevAV Annual Performance Review", .Unread = True, .Kind = 1, .Priority = 3, .Status = 1, .Notes = "Some notes for subject: DevAV Annual Performance Review", .Votes = 1},
                    New Issue With {.Id = 2, .IsArchived = False, .IsDraft = False, .Subject = "DevAV Annual Performance Review", .Unread = True, .Kind = 1, .Priority = 2, .Status = 1, .Notes = "Some notes for subject: DevAV Annual Performance Review", .Votes = 1},
                    New Issue With {.Id = 3, .IsArchived = False, .IsDraft = False, .Subject = "Year End Financials", .Unread = True, .Kind = 2, .Priority = 3, .Status = 2, .Notes = "Some notes for subject: Year End Financials", .Votes = 1},
                    New Issue With {.Id = 4, .IsArchived = False, .IsDraft = False, .Subject = "Your NDA", .Unread = False, .Kind = 2, .Priority = 2, .Status = 2, .Notes = "Some notes for subject: Your NDA", .Votes = 0},
                    New Issue With {.Id = 5, .IsArchived = False, .IsDraft = False, .Subject = "Your NDA", .Unread = False, .Kind = 1, .Priority = 3, .Status = 2, .Notes = "Some notes for subject: Your NDA", .Votes = 16},
                    New Issue With {.Id = 6, .IsArchived = False, .IsDraft = False, .Subject = "Microsoft Surface Studio", .Unread = True, .Kind = 2, .Priority = 2, .Status = 2, .Notes = "Some notes for subject: Microsoft Surface Studio", .Votes = 3},
                    New Issue With {.Id = 7, .IsArchived = False, .IsDraft = False, .Subject = "DX-1200 Product Cut-Sheet", .Unread = False, .Kind = 1, .Priority = 3, .Status = 2, .Notes = "Some notes for subject: DX-1200 Product Cut-Sheet", .Votes = 4},
                    New Issue With {.Id = 8, .IsArchived = False, .IsDraft = False, .Subject = "HD Video Player Accessories", .Unread = False, .Kind = 2, .Priority = 1, .Status = 2, .Notes = "Some notes for subject: HD Video Player Accessories", .Votes = 0},
                    New Issue With {.Id = 9, .IsArchived = False, .IsDraft = False, .Subject = "HD Video Player Accessories", .Unread = False, .Kind = 2, .Priority = 3, .Status = 2, .Notes = "Some notes for subject: HD Video Player Accessories", .Votes = 18},
                    New Issue With {.Id = 10, .IsArchived = False, .IsDraft = False, .Subject = "Conference Room - Hotels in Germany", .Unread = False, .Kind = 2, .Priority = 3, .Status = 2, .Notes = "Some notes for subject: Conference Room - Hotels in Germany", .Votes = 6},
                    New Issue With {.Id = 11, .IsArchived = False, .IsDraft = False, .Subject = "Conference Room - Hotels in Germany", .Unread = False, .Kind = 1, .Priority = 2, .Status = 2, .Notes = "Some notes for subject: Conference Room - Hotels in Germany", .Votes = 7},
                    New Issue With {.Id = 12, .IsArchived = False, .IsDraft = False, .Subject = "Artwork for packaging", .Unread = True, .Kind = 2, .Priority = 3, .Status = 1, .Notes = "Some notes for subject: Artwork for packaging", .Votes = 0},
                    New Issue With {.Id = 13, .IsArchived = False, .IsDraft = False, .Subject = "Overdue Tasks", .Unread = False, .Kind = 2, .Priority = 2, .Status = 1, .Notes = "Some notes for subject: Overdue Tasks", .Votes = 12},
                    New Issue With {.Id = 14, .IsArchived = False, .IsDraft = False, .Subject = "Online Meeting", .Unread = False, .Kind = 1, .Priority = 1, .Status = 1, .Notes = "Some notes for subject: Online Meeting", .Votes = 9},
                    New Issue With {.Id = 15, .IsArchived = False, .IsDraft = False, .Subject = "Online Meeting", .Unread = False, .Kind = 1, .Priority = 1, .Status = 1, .Notes = "Some notes for subject: Online Meeting", .Votes = 4},
                    New Issue With {.Id = 16, .IsArchived = False, .IsDraft = False, .Subject = "Paris is Beautiful and Expensive", .Unread = False, .Kind = 2, .Priority = 3, .Status = 1, .Notes = "Some notes for subject: Paris is Beautiful and Expensive", .Votes = 4},
                    New Issue With {.Id = 17, .IsArchived = False, .IsDraft = False, .Subject = "Open Support Tickets", .Unread = False, .Kind = 1, .Priority = 2, .Status = 1, .Notes = "Some notes for subject: Open Support Tickets", .Votes = 2},
                    New Issue With {.Id = 18, .IsArchived = False, .IsDraft = False, .Subject = "Open Support Tickets", .Unread = False, .Kind = 2, .Priority = 1, .Status = 1, .Notes = "Some notes for subject: Open Support Tickets", .Votes = 0},
                    New Issue With {.Id = 19, .IsArchived = False, .IsDraft = False, .Subject = "Firmware Upgrade", .Unread = False, .Kind = 1, .Priority = 3, .Status = 1, .Notes = "Some notes for subject: Firmware Upgrade", .Votes = 4},
                    New Issue With {.Id = 20, .IsArchived = False, .IsDraft = False, .Subject = "A Few Quotes to Help with Motivation", .Unread = False, .Kind = 2, .Priority = 3, .Status = 1, .Notes = "Some notes for subject: A Few Quotes to Help with Motivation", .Votes = 3},
                    New Issue With {.Id = 21, .IsArchived = False, .IsDraft = False, .Subject = "Travel Per Diem and Reimbursements", .Unread = False, .Kind = 1, .Priority = 1, .Status = 2, .Notes = "Some notes for subject: Travel Per Diem and Reimbursements", .Votes = 2},
                    New Issue With {.Id = 22, .IsArchived = False, .IsDraft = False, .Subject = "Network Issues Remain Unresolved", .Unread = False, .Kind = 1, .Priority = 2, .Status = 1, .Notes = "Some notes for subject: Network Issues Remain Unresolved", .Votes = 6},
                    New Issue With {.Id = 23, .IsArchived = False, .IsDraft = False, .Subject = "Customer Feedback and Quotes About Our Service", .Unread = False, .Kind = 2, .Priority = 3, .Status = 2, .Notes = "Some notes for subject: Customer Feedback and Quotes About Our Service", .Votes = 7},
                    New Issue With {.Id = 24, .IsArchived = False, .IsDraft = False, .Subject = "Product Training and Continuing Education", .Unread = False, .Kind = 2, .Priority = 1, .Status = 1, .Notes = "Some notes for subject: Product Training and Continuing Education", .Votes = 0},
                    New Issue With {.Id = 25, .IsArchived = False, .IsDraft = False, .Subject = "Sales Opportunities Breakdown by Region", .Unread = False, .Kind = 2, .Priority = 1, .Status = 2, .Notes = "Some notes for subject: Sales Opportunities Breakdown by Region", .Votes = 6},
                    New Issue With {.Id = 26, .IsArchived = False, .IsDraft = False, .Subject = "Build Conference and SWAG", .Unread = False, .Kind = 1, .Priority = 1, .Status = 2, .Notes = "Some notes for subject: Build Conference and SWAG", .Votes = 6},
                    New Issue With {.Id = 27, .IsArchived = False, .IsDraft = False, .Subject = "Build Conference and SWAG", .Unread = False, .Kind = 1, .Priority = 3, .Status = 2, .Notes = "Some notes for subject: Build Conference and SWAG", .Votes = 1},
                    New Issue With {.Id = 28, .IsArchived = False, .IsDraft = False, .Subject = "DOL Consumer Report", .Unread = False, .Kind = 2, .Priority = 2, .Status = 1, .Notes = "Some notes for subject: DOL Consumer Report", .Votes = 4},
                    New Issue With {.Id = 29, .IsArchived = False, .IsDraft = False, .Subject = "Important: Data from the Bureau of Labor Statistics", .Unread = False, .Kind = 2, .Priority = 3, .Status = 2, .Notes = "Some notes for subject: Important: Data from the Bureau of Labor Statistics", .Votes = 3},
                    New Issue With {.Id = 30, .IsArchived = False, .IsDraft = False, .Subject = "People are Watching More TV", .Unread = False, .Kind = 1, .Priority = 1, .Status = 1, .Notes = "Some notes for subject: People are Watching More TV", .Votes = 8},
                    New Issue With {.Id = 31, .IsArchived = False, .IsDraft = False, .Subject = "A Question on Future Product Development", .Unread = False, .Kind = 1, .Priority = 3, .Status = 1, .Notes = "Some notes for subject: A Question on Future Product Development", .Votes = 9},
                    New Issue With {.Id = 32, .IsArchived = False, .IsDraft = False, .Subject = "A Question on Future Product Development", .Unread = False, .Kind = 2, .Priority = 2, .Status = 2, .Notes = "Some notes for subject: A Question on Future Product Development", .Votes = 0},
                    New Issue With {.Id = 33, .IsArchived = False, .IsDraft = False, .Subject = "Your Mailing Address", .Unread = False, .Kind = 2, .Priority = 2, .Status = 1, .Notes = "Some notes for subject: Your Mailing Address", .Votes = 6},
                    New Issue With {.Id = 34, .IsArchived = False, .IsDraft = False, .Subject = "Your Mailing Address", .Unread = False, .Kind = 1, .Priority = 3, .Status = 2, .Notes = "Some notes for subject: Your Mailing Address", .Votes = 13},
                    New Issue With {.Id = 35, .IsArchived = False, .IsDraft = False, .Subject = "New Circuit Board Design", .Unread = False, .Kind = 1, .Priority = 1, .Status = 2, .Notes = "Some notes for subject: New Circuit Board Design", .Votes = 5},
                    New Issue With {.Id = 36, .IsArchived = False, .IsDraft = False, .Subject = "New Power Supply and Overload Protection", .Unread = False, .Kind = 1, .Priority = 1, .Status = 2, .Notes = "Some notes for subject: New Power Supply and Overload Protection", .Votes = 1},
                    New Issue With {.Id = 37, .IsArchived = False, .IsDraft = False, .Subject = "Join Us for Lunch?", .Unread = False, .Kind = 2, .Priority = 1, .Status = 1, .Notes = "Some notes for subject: Join Us for Lunch?", .Votes = 6},
                    New Issue With {.Id = 38, .IsArchived = True, .IsDraft = False, .Subject = "My All-time Favorite Quote", .Unread = False, .Kind = 1, .Priority = 3, .Status = 2, .Notes = "Some notes for subject: My All-time Favorite Quote", .Votes = 7},
                    New Issue With {.Id = 39, .IsArchived = False, .IsDraft = False, .Subject = "I’m Getting Married", .Unread = False, .Kind = 1, .Priority = 3, .Status = 2, .Notes = "Some notes for subject: I’m Getting Married", .Votes = 0},
                    New Issue With {.Id = 40, .IsArchived = True, .IsDraft = False, .Subject = "Your Favorite Font", .Unread = False, .Kind = 2, .Priority = 3, .Status = 1, .Notes = "Some notes for subject: Your Favorite Font", .Votes = 8},
                    New Issue With {.Id = 41, .IsArchived = False, .IsDraft = False, .Subject = "Cabling and Termination", .Unread = False, .Kind = 2, .Priority = 3, .Status = 1, .Notes = "Some notes for subject: Cabling and Termination", .Votes = 5},
                    New Issue With {.Id = 42, .IsArchived = False, .IsDraft = True, .Subject = "Your Hard Work is Appreciated", .Unread = False, .Kind = 1, .Priority = 2, .Status = 1, .Notes = "Some notes for subject: Your Hard Work is Appreciated", .Votes = 0},
                    New Issue With {.Id = 43, .IsArchived = False, .IsDraft = False, .Subject = "Icons Icons and More Icons", .Unread = False, .Kind = 1, .Priority = 3, .Status = 2, .Notes = "Some notes for subject: Icons Icons and More Icons", .Votes = 8},
                    New Issue With {.Id = 44, .IsArchived = False, .IsDraft = False, .Subject = "Online Sales are Growing", .Unread = False, .Kind = 1, .Priority = 2, .Status = 1, .Notes = "Some notes for subject: Online Sales are Growing", .Votes = 8},
                    New Issue With {.Id = 45, .IsArchived = False, .IsDraft = False, .Subject = "Circuit Town Orders", .Unread = False, .Kind = 1, .Priority = 1, .Status = 1, .Notes = "Some notes for subject: Circuit Town Orders", .Votes = 3},
                    New Issue With {.Id = 46, .IsArchived = False, .IsDraft = False, .Subject = "Your Favorite Shakespeare Play", .Unread = False, .Kind = 1, .Priority = 1, .Status = 2, .Notes = "Some notes for subject: Your Favorite Shakespeare Play", .Votes = 2},
                    New Issue With {.Id = 47, .IsArchived = False, .IsDraft = False, .Subject = "My Favorite Resort in Las Vegas", .Unread = False, .Kind = 2, .Priority = 3, .Status = 2, .Notes = "Some notes for subject: My Favorite Resort in Las Vegas", .Votes = 6},
                    New Issue With {.Id = 48, .IsArchived = False, .IsDraft = False, .Subject = "Wikipedia Says I’m Right", .Unread = False, .Kind = 1, .Priority = 1, .Status = 1, .Notes = "Some notes for subject: Wikipedia Says I’m Right", .Votes = 0},
                    New Issue With {.Id = 49, .IsArchived = False, .IsDraft = False, .Subject = "Wikipedia Says I’m Right", .Unread = False, .Kind = 1, .Priority = 1, .Status = 2, .Notes = "Some notes for subject: Wikipedia Says I’m Right", .Votes = 15},
                    New Issue With {.Id = 50, .IsArchived = False, .IsDraft = False, .Subject = "Roy Orbison is my favorite", .Unread = False, .Kind = 1, .Priority = 1, .Status = 2, .Notes = "Some notes for subject: Roy Orbison is my favorite", .Votes = 4}})

            Dim rnd = New Random(Environment.TickCount)
            For Each i In issues
                Dim contactIndex As Integer = rnd.Next(0, 29)
                i.SetCustomer(GetContacts()(contactIndex))
                Dim d As DateTime = DateTime.Now
                i.Created = d.AddDays(-rnd.Next(1, 90) - 30)
                i.Updated = i.Created.AddDays(rnd.Next(1, 30))
            Next i

            Return issues
        End Function

        Friend Shared Function GetNextIssueId() As Long
            Dim issuesIds As IEnumerable(Of Long) = GetIssues().Select(Function(i) i.Id)
            If issuesIds.Count() > 0 Then
                Return issuesIds.Max() + 1
            Else
                Return 1
            End If
        End Function
    End Class
#End Region

    ' Scheduler Sample Data

    Public Class SchedulerLabel
        Private privateId As Long
        Public Property Id() As Long
            Get
                Return privateId
            End Get
            Set(ByVal value As Long)
                privateId = value
            End Set
        End Property
        Private privateName As String
        Public Property Name() As String
            Get
                Return privateName
            End Get
            Set(ByVal value As String)
                privateName = value
            End Set
        End Property
        Private privateColor As System.Drawing.Color
        Public Property Color() As System.Drawing.Color
            Get
                Return privateColor
            End Get
            Set(ByVal value As System.Drawing.Color)
                privateColor = value
            End Set
        End Property
    End Class

    Public Class SchedulerAppointment
        Private privateId As Long
        Public Property Id() As Long
            Get
                Return privateId
            End Get
            Set(ByVal value As Long)
                privateId = value
            End Set
        End Property
        Private privateSubject As String
        Public Property Subject() As String
            Get
                Return privateSubject
            End Get
            Set(ByVal value As String)
                privateSubject = value
            End Set
        End Property
        Private privateLocation As String
        Public Property Location() As String
            Get
                Return privateLocation
            End Get
            Set(ByVal value As String)
                privateLocation = value
            End Set
        End Property
        Private privateStartDate As DateTime
        Public Property StartDate() As DateTime
            Get
                Return privateStartDate
            End Get
            Set(ByVal value As DateTime)
                privateStartDate = value
            End Set
        End Property
        Private privateEndDate As DateTime
        Public Property EndDate() As DateTime
            Get
                Return privateEndDate
            End Get
            Set(ByVal value As DateTime)
                privateEndDate = value
            End Set
        End Property
        Private privateAllDay As Boolean
        Public Property AllDay() As Boolean
            Get
                Return privateAllDay
            End Get
            Set(ByVal value As Boolean)
                privateAllDay = value
            End Set
        End Property
        Private privateDescription As String
        Public Property Description() As String
            Get
                Return privateDescription
            End Get
            Set(ByVal value As String)
                privateDescription = value
            End Set
        End Property
        Private privateRecurrenceInfo As String
        Public Property RecurrenceInfo() As String
            Get
                Return privateRecurrenceInfo
            End Get
            Set(ByVal value As String)
                privateRecurrenceInfo = value
            End Set
        End Property
        Private privateEventType As Integer
        Public Property EventType() As Integer
            Get
                Return privateEventType
            End Get
            Set(ByVal value As Integer)
                privateEventType = value
            End Set
        End Property
        Private privateLabelId As Long
        Public Property LabelId() As Long
            Get
                Return privateLabelId
            End Get
            Set(ByVal value As Long)
                privateLabelId = value
            End Set
        End Property
        Private privateStatus As Integer
        Public Property Status() As Integer
            Get
                Return privateStatus
            End Get
            Set(ByVal value As Integer)
                privateStatus = value
            End Set
        End Property
        Private privateResourceId? As Long
        Public Property ResourceId() As Long?
            Get
                Return privateResourceId
            End Get
            Set(ByVal value? As Long)
                privateResourceId = value
            End Set
        End Property
    End Class

    Public Class SchedulerResource
        Private privateId As Long
        Public Property Id() As Long
            Get
                Return privateId
            End Get
            Set(ByVal value As Long)
                privateId = value
            End Set
        End Property
        Private privateName As String
        Public Property Name() As String
            Get
                Return privateName
            End Get
            Set(ByVal value As String)
                privateName = value
            End Set
        End Property
    End Class

    Public NotInheritable Class SchedulerLabelsHelper
        Private Shared items As List(Of SchedulerLabel)

        Private Sub New()
        End Sub
        Shared Sub New()
            items = New List(Of SchedulerLabel)()
            items.Add(New SchedulerLabel With {.Id = 1, .Name = "Development", .Color = System.Drawing.Color.DarkBlue})
            items.Add(New SchedulerLabel With {.Id = 2, .Name = "Webinars", .Color = System.Drawing.Color.Blue})
            items.Add(New SchedulerLabel With {.Id = 3, .Name = "Family", .Color = System.Drawing.Color.SkyBlue})
            items.Add(New SchedulerLabel With {.Id = 4, .Name = "Birthdays", .Color = System.Drawing.Color.OrangeRed})
        End Sub

        Public Shared Function GetItems() As List(Of SchedulerLabel)
            Return items
        End Function
    End Class


    Public Class AppointmentDataSourceHelper
        Public Sub New()
        End Sub

        Private Shared Function GetAppointments() As List(Of SchedulerAppointment)
            If HttpContext.Current.Session("SchedulerAppointments") Is Nothing Then
                HttpContext.Current.Session("SchedulerAppointments") = GenerateAppointments()
            End If
            Return TryCast(HttpContext.Current.Session("SchedulerAppointments"), List(Of SchedulerAppointment))
        End Function
        Private Shared Sub UpdateAppointments(ByVal list As List(Of SchedulerAppointment))
            HttpContext.Current.Session("SchedulerAppointments") = list
        End Sub

        Public Shared Function SelectMethodHandler() As List(Of SchedulerAppointment)
            Return GetAppointments()
        End Function

        Private Shared Function GenerateAppointments() As List(Of SchedulerAppointment)
            Dim list As New List(Of SchedulerAppointment)()

            Dim uniqueID As Integer = 0
            Dim startDate As DateTime = DateTime.Now.Date
            Dim random As New Random()

            ' Birthdays - from Contacts
            For i As Integer = 0 To DataProvider.GetContacts().Count - 1
                Dim contact As Contact = DataProvider.GetContacts()(i)

                Dim appointment As New SchedulerAppointment()
                appointment.Id = uniqueID
                appointment.Subject = contact.FirstName & " " & contact.LastName
                appointment.AllDay = True
                appointment.StartDate = contact.Birthday.Date
                appointment.EndDate = appointment.StartDate.AddDays(1)
                appointment.EventType = Fix(AppointmentType.Pattern) ' Represents the appointment which serves as the pattern for the other recurring appointments
                appointment.LabelId = SchedulerLabelsHelper.GetItems().FirstOrDefault(Function(c) c.Name = "Birthdays").Id ' Birthday label
                appointment.ResourceId = random.Next(1, ResourceDataSourceHelper.GetItems().Count + 1)

                Dim recInfo As New RecurrenceInfo()
                recInfo.Start = appointment.StartDate
                recInfo.Range = RecurrenceRange.NoEndDate
                recInfo.Type = RecurrenceType.Yearly
                recInfo.Periodicity = 1
                recInfo.Month = contact.Birthday.Month
                recInfo.DayNumber = contact.Birthday.Day
                appointment.RecurrenceInfo = recInfo.ToXml()

                list.Add(appointment)
                uniqueID += 1
            Next i

            ' Sample Appointments
            For i As Integer = -100 To 99
                If i <> 0 AndAlso i Mod random.Next(7, 10) = 0 Then
                    Continue For
                End If

                Dim appointment As New SchedulerAppointment()
                appointment.Id = uniqueID
                appointment.Subject = "Appointment " & uniqueID.ToString()
                Dim h As Integer = random.Next(7, 18)
                appointment.StartDate = startDate.AddDays(i).AddHours(h)
                appointment.EndDate = appointment.StartDate.AddHours(random.Next(2, 4))
                appointment.EventType = Fix(AppointmentType.Normal) ' Represents a standard (non-recurring) appointment
                appointment.LabelId = random.Next(1, 4)
                appointment.ResourceId = random.Next(1, ResourceDataSourceHelper.GetItems().Count + 1)
                appointment.Status = random.Next(1, 5)

                list.Add(appointment)
                uniqueID += 1
            Next i

            Return list
        End Function

        Public Shared Function InsertMethodHandler(ByVal newAppointment As SchedulerAppointment) As Object
            Dim list As List(Of SchedulerAppointment) = GetAppointments()
            Dim maxId As Long = If(list.Count = 0, 0, list.Max(Function(i) i.Id))
            newAppointment.Id = maxId + 1
            list.Add(newAppointment)

            UpdateAppointments(list)

            Return newAppointment.Id ' DXCOMMENT: Return this value to the ASPxScheduler and set the ASPxScheduler.ASPxAppointmentStorage.AutoRetrieveId ( https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxScheduler.ASPxAppointmentStorage.AutoRetrieveId.property ) property to true.
        End Function

        Public Shared Sub DeleteMethodHandler(ByVal deletedAppointment As SchedulerAppointment)
            Dim list As List(Of SchedulerAppointment) = GetAppointments()
            Dim item As SchedulerAppointment = list.FirstOrDefault(Function(i) i.Id.Equals(deletedAppointment.Id))
            If item IsNot Nothing Then
                list.Remove(item)
            End If

            UpdateAppointments(list)
        End Sub

        Public Shared Sub UpdateMethodHandler(ByVal updatedAppointment As SchedulerAppointment)
            Dim list As List(Of SchedulerAppointment) = GetAppointments()
            Dim item As SchedulerAppointment = list.FirstOrDefault(Function(i) i.Id.Equals(updatedAppointment.Id))

            item.AllDay = updatedAppointment.AllDay
            item.Description = updatedAppointment.Description
            item.StartDate = updatedAppointment.StartDate
            item.EndDate = updatedAppointment.EndDate
            item.EventType = updatedAppointment.EventType
            item.LabelId = updatedAppointment.LabelId
            item.Location = updatedAppointment.Location
            item.RecurrenceInfo = updatedAppointment.RecurrenceInfo
            item.Status = updatedAppointment.Status
            item.Subject = updatedAppointment.Subject
            item.ResourceId = updatedAppointment.ResourceId

            UpdateAppointments(list)
        End Sub
    End Class

    Public NotInheritable Class ResourceDataSourceHelper
        Private Shared items As List(Of SchedulerResource)

        Private Sub New()
        End Sub
        Shared Sub New()
            items = New List(Of SchedulerResource)()
            items.Add(New SchedulerResource With {.Id = 1, .Name = "Calendar 1"})
            items.Add(New SchedulerResource With {.Id = 2, .Name = "Calendar 2"})
            items.Add(New SchedulerResource With {.Id = 3, .Name = "Calendar 3"})
            items.Add(New SchedulerResource With {.Id = 4, .Name = "Calendar 4"})
            items.Add(New SchedulerResource With {.Id = 5, .Name = "Calendar 5"})
            items.Add(New SchedulerResource With {.Id = 6, .Name = "Calendar 6"})
            items.Add(New SchedulerResource With {.Id = 7, .Name = "Calendar 7"})
            items.Add(New SchedulerResource With {.Id = 8, .Name = "Calendar 8"})
        End Sub

        Public Shared Function GetItems() As List(Of SchedulerResource)
            Return GetItems(Nothing)
        End Function

        Public Shared Function GetItems(ByVal ids As List(Of Long)) As List(Of SchedulerResource)
            If ids Is Nothing Then
                Return items
            End If
            Return items.Where(Function(item) ids.Contains(item.Id)).ToList()
        End Function
    End Class

End Namespace