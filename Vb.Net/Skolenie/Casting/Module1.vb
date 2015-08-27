Option Strict On

Module Module1

    Public Enum Dni As Integer
        Pondelok
        Utorok
        Streda
        Stvrtok
    End Enum

    Sub Main()

        '-- Value vs Reference types --
        'A data type is a value type if it holds the data within its own memory allocation. 
        'A reference type contains a pointer to another memory location that holds the data.

        'Value(types)
        'All numeric types, Boolean, Char, Date
        'All structures, enumerations

        'Reference types
        'String, Arrays, Classes, Delegates

        'ByRef vs ByVal
        'no out equivalent

        'Struct vs Classes
        'Do not define a structure unless the type has all of the following characteristics:
        '- It logically represents a single value, similar to primitive types (integer, double, and so on).
        '- It has an instance size smaller than 16 bytes.
        '- It is immutable.
        '- It will not have to be boxed frequently.

        Dim c As New ComplexNumber(3, 2)
        Console.WriteLine(c.toString())

        '-- Boxing and unboxing --  

        Dim I As Integer = 3

        'Boxing
        I.ToString()
        Dim X As Object = I 'Dynamic type of I is not object, it is Integer

        'Unboxing
        I = CInt(X)

        Dim test As Object = False

        '-- Casting --

        'CType

        'The CType Function takes a second argument, typename, and coerces expression to typename,
        'where typename can be any data type, structure, class, or interface to which there exists
        'a valid conversion.

        Console.WriteLine("CBool(True): {0}", CBool(test))
        Console.WriteLine("CInt(True): {0}", CInt(test))
        Console.WriteLine("CStr(True): {0}", CStr(test))

        test = "4/1/2010"
        Console.WriteLine("CType(""4/1/2010"", DateTime): {0}", CType(test, DateTime))

        'Console.WriteLine()

        'DirectCast

        'DirectCast requires the run-time type of an object variable to be the same as the specified type. 
        'If the specified type and the run-time type of the expression are the same, however, 
        'the run-time performance of DirectCast is better than that of CType.

        Console.WriteLine("DirectCast(""4/1/2010"", String): {0}", DirectCast(test, String))
        'Console.WriteLine("DirectCast(""4/1/2010"", Date): {0}", DirectCast(test, DateTime))


        '-- Evaluating types --

        If TypeOf test Is String Then
            Console.WriteLine("DirectCast(""4/1/2010"", String): {0}", DirectCast(test, String))
        End If
        If test.GetType() Is GetType(DateTime) Then
            Console.WriteLine("DirectCast(""4/1/2010"", Date): {0}", DirectCast(test, DateTime))
        End If

        Console.WriteLine()

        '-- Parsing --

        Integer.Parse("4")
        'Integer.Parse("4.1")
        'Integer.Parse("cosi")

        Console.WriteLine("Integer.TryParse(""4""): {0}", If(Integer.TryParse("46", I), I.ToString, "Format exception"))
        Console.WriteLine("Integer.TryParse(""4.1""): {0}", If(Integer.TryParse("4.1", I), I.ToString, "Format exception"))
        Console.WriteLine("Integer.TryParse(""Cosi""): {0}", If(Integer.TryParse("Cosi", I), I.ToString, "Format exception"))


        Console.WriteLine(3 Or 4)
        Console.WriteLine("Zadaj cislo")
        While Not Integer.TryParse(Console.ReadLine(), I)
            Console.WriteLine("Neplatny vstup")
        End While
        Console.WriteLine("OK")



    End Sub


End Module
