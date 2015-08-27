Module Module1

    Class Animal

        Public Overridable Sub SayHello()
            Console.WriteLine("hello i am an animal")
        End Sub

    End Class


    Class Dog
        Inherits Animal

        Public Overrides Sub SayHello()
            Console.WriteLine("hello i am a dog")
        End Sub

    End Class

    Class Cat
        Inherits Animal

        Public Shadows Sub SayHello()
            Console.WriteLine("Hello i am a Cat")
        End Sub

    End Class

    Class BigDog
        Inherits Dog

        Public Overrides Sub SayHello()
            Console.WriteLine("HELLO i am a big DOOOG")
        End Sub

    End Class

    Sub Main()

        Dim A As Animal
        Dim C As Cat
        Dim D As Dog
        Dim B As BigDog

        A = New Animal()
        C = New Cat()
        D = New Dog()
        B = New BigDog()

        A.SayHello()
        C.SayHello()
        D.SayHello()
        B.SayHello()

        Dim AD As Animal
        Dim AC As Animal
        Dim AB As Animal

        AD = New Dog()
        AC = New Cat()
        AB = New BigDog()

        AD.SayHello()
        AC.SayHello()
        AB.SayHello()

        Dim L As New List(Of Animal)
        L.Add(New Animal)
        L.Add(New Cat)
        L.Add(New Dog)
        L.Add(New BigDog)

        For Each X In L
            X.SayHello()
        Next

        Console.ReadLine()

    End Sub

End Module
