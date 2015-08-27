Option Strict On

Module Polymorhism

    Class Animal
        Public Overridable Sub SayHello()
            Console.WriteLine("Virtual: Hello, I am an Animal")
        End Sub

        Public Sub SayGoodbye()
            Console.WriteLine("NonVirtual: Bye, I am an Animal")
        End Sub

    End Class

    Class Dog
        Inherits Animal

        Public Overrides Sub SayHello()
            Console.WriteLine("Virtual: Hello, I am a dog!!!")
        End Sub

        Public Shadows Sub SayGoodbye()
            Console.WriteLine("NonVirtual: Bye, I am a Dog!!!")
        End Sub

    End Class

    Class Cat
        Inherits Animal

        Public Overrides Sub SayHello()
            Console.WriteLine("Virtual: Hello, I am a Cat!!!")
        End Sub

        Public Shadows Sub SayGoodbye()
            Console.WriteLine("NonVirtual: Bye, I am a Cat!!!")
        End Sub

    End Class

    Class BigDog
        Inherits Dog

        Public Overrides Sub SayHello()
            MyBase.SayHello()

            Console.WriteLine("But I am a big dog")
        End Sub

    End Class

    Sub Main()

        Dim A As Animal
        Dim D As Dog

        Console.WriteLine("Animal A = new Animal() ")
        A = New Animal()
        A.SayHello()
        A.SayGoodbye()

        Console.WriteLine()
        Console.WriteLine("Dog D = new Dog()")
        D = New Dog
        D.SayHello()
        D.SayGoodbye()

        Console.WriteLine()
        Console.WriteLine("Animal A = new Dog()")
        A = New Dog
        A.SayHello()
        A.SayGoodbye()

        Console.WriteLine(vbNewLine & "##################################" & vbNewLine)

        Dim Lst As New List(Of Animal)
        Lst.Add(New Animal())
        Lst.Add(New Dog())
        Lst.Add(New BigDog())
        Lst.Add(New Cat())

        For Each Animal In Lst
            Animal.SayHello()
            ' Animal.SayGoodbye()
        Next

        Console.ReadLine()

    End Sub

End Module
