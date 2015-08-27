Option Strict On

Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Module Module1

    Private Const PASSWD_PATH As String = "C:\Users\passwd"

    Public Enum ePrava As Integer
        BezPrav = 0
        Prihlasenie = 1
        VytvorenieUctu = 2
        ZmazanieUctu = 4
        AdminPrava = 7
    End Enum

    Class Uzivatel
        Private fUsername, fPassword, fMeno, fMail As String
        Private fPrava As Integer

        Public Sub New()
        End Sub

        Public Sub New(Username As String, Password As String, Meno As String, Mail As String, Prava As Integer)
            fUsername = Username : fPrava = Prava : fMeno = Meno : fMail = Mail : fPrava = Prava
        End Sub

        Public Sub New(Line As String(), Prava As Integer)
            fUsername = Line(0) : fPassword = Line(1) : fMeno = Line(2) : fMail = Line(3) : fPrava = Prava
        End Sub

        Public Sub New(Hodnoty As SortedList(Of String, String), Prava As Integer)
            fUsername = Hodnoty("username") : fPassword = Hodnoty("password") : fMeno = Hodnoty("meno") : fMail = Hodnoty("mail") : fPrava = Prava
        End Sub

        Public Function OverPravo(Pravo As ePrava) As Boolean
            Return (fPrava And Pravo) = Pravo
        End Function

        Public Overrides Function ToString() As String
            Dim SB As New StringBuilder(fUsername) : SB.Append(":") : SB.Append(fPassword) : SB.Append(":")
            SB.Append(fMail) : SB.Append(":") : SB.Append(fMeno) : SB.Append(":") : SB.Append(ePrava.AdminPrava)
            Return SB.ToString()
        End Function

#Region "Shared"

        Public Shared Function CreateUser(Optional PasswdExists As Boolean = True) As Uzivatel
            Dim Input As New SortedList(Of String, String), SW As StreamWriter = Nothing
            Try
                Console.Write("Zadajte UserName: ") : Input("username") = Console.ReadLine()
                Do
                    Console.Write("Zadajte Heslo: ") : Input("password") = Console.ReadLine()
                    Console.Write("Zadajte Heslo pre overenie: ") : Input("overPassword") = Console.ReadLine()
                    If Not Input("password") = Input("overPassword") Then
                        Console.WriteLine("Hesla sa nezhoduju")
                    Else
                        Exit Do
                    End If
                Loop While True
                Do
                    Console.Write("Zadajte svoje cele meno: ") : Input("meno") = Console.ReadLine()
                    If Input("meno").Length > 1 AndAlso Input("meno").Length < 100 Then
                        Exit Do
                    Else
                        Console.WriteLine("Dlzka mena musi byt v rozsahu 1..100")
                    End If
                Loop While True
                Dim R As New Regex("\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
                Do
                    Console.Write("Zadajte email: ") : Input("mail") = Console.ReadLine()
                    If R.IsMatch(Input("mail")) Then
                        Exit Do
                    Else
                        Console.WriteLine("Neplatny format mailu")
                    End If
                Loop While True

                Dim Prava As Integer = ePrava.BezPrav, Tmp As String = Nothing
                If PasswdExists Then 'pridaj usera s custom pravami
                    Do
                        Tmp = Console.ReadLine()
                        If Integer.TryParse(Tmp, Prava) AndAlso Prava <= ePrava.AdminPrava Then
                            Exit Do
                        Else
                            Console.WriteLine("Invalid rights")
                        End If
                    Loop While True
                Else 'pridaj admina
                    Prava = ePrava.AdminPrava
                    Console.Clear()
                End If
                Dim U As New Uzivatel(Input, Prava)
                SW = New StreamWriter(PASSWD_PATH, True) : SW.WriteLine(U) : SW.Close() 'Uloz uzivatela
                Console.WriteLine("Uzivatel bol uspesne vytvoreny")
                Return U
            Catch ex As Exception
            Finally
                If SW IsNot Nothing Then SW.Close()
            End Try
            Return Nothing
        End Function

        Public Shared Function Login() As Uzivatel
            Dim tmpMeno As String, tmpHeslo As String
            If File.Exists(PASSWD_PATH) Then
                Dim AllUsers As SortedList(Of String, Uzivatel) = LoadAllUsers()
                Console.Write("Zadaj meno: ")
                tmpMeno = Console.ReadLine()
                Console.Write("Zadaj heslo: ")
                tmpHeslo = Console.ReadLine()
                If AllUsers.ContainsKey(tmpMeno) Then
                    Dim U As Uzivatel = AllUsers(tmpMeno)
                    If U.Username = tmpMeno Then
                        'over heslo
                        If U.Password = tmpHeslo Then
                            'uspech, over prava a prihlas
                            If U.OverPravo(ePrava.Prihlasenie) Then
                                Return U
                            Else
                                Console.WriteLine("Nemate pravo na prihlasenie") : Console.ReadLine() : Return Nothing
                            End If
                        Else
                            Return Nothing
                        End If
                    End If
                End If
            Else
                Console.WriteLine("V systeme neexistuje uzivatel. Chcete ho vytvorit? y/n")
                Return If(Console.ReadLine().ToLower().Trim() = "y", CreateUser(False), Nothing)
            End If
            Return Nothing
        End Function

        Private Shared Function LoadAllUsers() As SortedList(Of String, Uzivatel)
            Dim SR As StreamReader = Nothing, Line As String, SplitLine As String(), Prava As Integer
            Dim AllUsers As New SortedList(Of String, Uzivatel)
            Try
                SR = New StreamReader(PASSWD_PATH)
                While Not SR.EndOfStream
                    Line = SR.ReadLine() : SplitLine = Line.Split(":"c)
                    If Integer.TryParse(SplitLine(4), Prava) Then
                        AllUsers.Add(SplitLine(0), New Uzivatel(SplitLine, Prava))
                    Else
                        Console.WriteLine("Corrupt file") : Return Nothing
                    End If
                End While
            Catch ex As Exception
            Finally
                If SR IsNot Nothing Then SR.Close()
            End Try

            For Each Item As KeyValuePair(Of String, Uzivatel) In AllUsers
                'Console.WriteLine(Item.Value)
                'Zapis do suboru
                'Tento foreach pouzit pri ukladani noveho uzivatela
                'Optimalizovat pocet volani LoadAllUsers
            Next

            Return AllUsers
        End Function

#End Region

#Region "Properties"

        Public ReadOnly Property Username As String
            Get
                Return fUsername
            End Get
        End Property

        Public ReadOnly Property Password As String
            Get
                Return fPassword
            End Get
        End Property

        Public ReadOnly Property Mail As String
            Get
                Return fMail
            End Get
        End Property

        Public ReadOnly Property Meno As String
            Get
                Return fMeno
            End Get
        End Property

        Public ReadOnly Property Prava As Integer
            Get
                Return fPrava
            End Get
        End Property

#End Region

    End Class

    Class Prompt
        Private Const fDefaultPromptString = ">"
        Private Shared fPromptString As String = fDefaultPromptString

        Public Shared Sub Obsluz(Prikaz As String)
            Dim SplitPrikaz As String() = Prikaz.Trim().Split()
            If SplitPrikaz.Length = 0 Then Return
            Select Case SplitPrikaz(0).ToLower
                Case "help" : Help()
                Case "setprompt" : fPromptString = If(SplitPrikaz.Length = 2, SplitPrikaz(1), fDefaultPromptString)
                Case "createuser" : Uzivatel.CreateUser()
                Case "clr" : Console.Clear()
                Case "exit" : Environment.Exit(0)
                Case Else
            End Select
        End Sub

        Private Shared Sub Help()
            Console.WriteLine("### COMMANDS ###")
            Console.WriteLine("Create new User ... createuser")
            Console.WriteLine("Set prompt ... setprompt")
            Console.WriteLine("Clear screen ... clr")
            Console.WriteLine("Help ... help")
            Console.WriteLine("Exit ... exit")
        End Sub

        Public Shared ReadOnly Property PromptString As String
            Get
                Return fPromptString
            End Get
        End Property
    End Class

    Sub Main()
        Dim AttemptsLeft = 3
        Dim U As Uzivatel = Nothing
        While U Is Nothing
            Console.Clear()
            U = Uzivatel.Login()
            AttemptsLeft -= 1
            If AttemptsLeft = 0 Then
                Console.WriteLine("Vieme o tebe, poslal som si mail")
                Console.ReadLine()
                Exit Sub
            End If
        End While
        'U.logout()
        Console.Clear()
        Console.WriteLine("Prihlasenie uspesne")
        While True
            Console.Write(Prompt.PromptString)
            Prompt.Obsluz(Console.ReadLine())
        End While

        Console.ReadLine()
    End Sub

End Module
